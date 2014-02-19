using IniParser.Model;
using IniParser.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchTest
{
    public partial class frmMain : Form
    {
        
        /// <summary>
        /// Irc client
        /// </summary>
        NetIrc2.IrcClient client = new NetIrc2.IrcClient();

        /// <summary>
        /// Commands sent so far
        /// </summary>
        public long CmdSent {get; set; }

        /// <summary>
        /// Used to keep track of start spamming
        /// </summary>
        public long LastStart { get; set; }

        /// <summary>
        /// Time passed so far
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Ini parser
        /// </summary>
        IniParser.FileIniDataParser parser = new IniParser.FileIniDataParser();

        /// <summary>
        /// Ini data file
        /// </summary>
        IniData data;

        /// <summary>
        /// Emulator
        /// </summary>
        Emulator emulator;

        public frmMain()
        {
            InitializeComponent();

            // Loads config file
            data = parser.LoadFile("config.ini");
            // New emulator class
            emulator = new Emulator(data["emulator"]["gametitle"]);

            // New IRC events
            client.GotIrcError += client_GotIrcError;
            client.Closed += client_Closed;
            client.Connected += client_Connected;
            client.GotMessage += client_GotMessage;

            // Loads in saved progress
            if (data["progress"]["date"] == string.Empty)
            {
                StartTime = DateTime.UtcNow;
            }
            else
                StartTime = DateTime.Parse(data["progress"]["date"]);

            CmdSent = long.Parse(data["progress"]["sent"]);
        }

        /// <summary>
        /// Reconnect 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_Closed(object sender, EventArgs e)
        {
            client.Connect("irc.twitch.tv");
            client.LogIn(data["tool"]["twitch_username"], "Guest", data["tool"]["twitch_username"], null, null, data["tool"]["twitch_oauth"]);
        }

        /// <summary>
        /// Reconnect 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_GotIrcError(object sender, NetIrc2.Events.IrcErrorEventArgs e)
        {
            if (client.IsConnected == false)
            {
                client.Connect("irc.twitch.tv");
                client.LogIn(data["tool"]["twitch_username"], "Guest", data["tool"]["twitch_username"], null, null, data["tool"]["twitch_oauth"]);
            }
        }

        /// <summary>
        /// New chat message recieve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_GotMessage(object sender, NetIrc2.Events.ChatMessageEventArgs e)
        {
            string msg = e.Message.ToString().ToLower();
            if (e.Recipient == data["tool"]["twitch_channel"])
            {
                switch (msg)
                {
                    case "left":
                        {
                            emulator.PressKey(int.Parse(data["emulator"]["left"], NumberStyles.HexNumber));
                            CmdSent++;
                            AddToList(e.Sender.Nickname, "left");
                            break;
                        }
                    case "right":
                        {
                            emulator.PressKey(int.Parse(data["emulator"]["right"], NumberStyles.HexNumber));
                            CmdSent++;
                            AddToList(e.Sender.Nickname, "right");
                            break;
                        }
                    case "up":
                        {
                            emulator.PressKey(int.Parse(data["emulator"]["up"], NumberStyles.HexNumber));
                            CmdSent++;
                            AddToList(e.Sender.Nickname, "up");
                            break;
                        }
                    case "down":
                        {
                            emulator.PressKey(int.Parse(data["emulator"]["down"], NumberStyles.HexNumber));
                            CmdSent++;
                            AddToList(e.Sender.Nickname, "down");
                            break;
                        }
                    case "a":
                        {
                            emulator.PressKey(int.Parse(data["emulator"]["A"], NumberStyles.HexNumber));
                            CmdSent++;
                            AddToList(e.Sender.Nickname, "a");
                            break;
                        }
                    case "b":
                        {
                            emulator.PressKey(int.Parse(data["emulator"]["B"], NumberStyles.HexNumber));
                            CmdSent++;
                            AddToList(e.Sender.Nickname, "b");
                            break;
                        }
                    case "select":
                        {
                            emulator.PressKey(int.Parse(data["emulator"]["select"], NumberStyles.HexNumber));
                            CmdSent++;
                            AddToList(e.Sender.Nickname, "select");
                            break;
                        }
                    case "start":
                        {
                            // Simple start spam throttle
                            if (CmdSent - LastStart > int.Parse(data["tool"]["start"])) 
                            {
                                emulator.PressKey(int.Parse(data["emulator"]["start"], NumberStyles.HexNumber));
                                CmdSent++;
                                AddToList(e.Sender.Nickname, "start");
                                LastStart = CmdSent;
                            }
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Join channel once connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_Connected(object sender, EventArgs e)
        {
            client.Join(data["tool"]["twitch_channel"]);
        }

        /// <summary>
        /// Adds action to listbox and keeps it small
        /// </summary>
        /// <param name="name"></param>
        /// <param name="command"></param>
        public void AddToList(string name, string command)
        {
            lblCmd.Text = CmdSent.ToString();
            if(lbCommand.Items.Count == 10)
            {
                lbCommand.Items.RemoveAt(0);
            }

            lbCommand.Items.Add(name + '\t' + command);
        }

        /// <summary>
        /// Finds hWnd of emulator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (emulator.FindEmulator())
                MessageBox.Show("Found emulator!");
            else
                MessageBox.Show("Emulator not found!");
        }

        /// <summary>
        /// Connects to Twitch chat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connect("irc.twitch.tv");
            client.LogIn(data["tool"]["twitch_username"], "Guest", data["tool"]["twitch_username"], null, null, data["tool"]["twitch_oauth"]);
            
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.UtcNow - StartTime;
            
            string elapsedTime = String.Format("{0}d {1:00}h {2:00}m {3:00}s", duration.Days,
        duration.Hours, duration.Minutes, duration.Seconds);
            lblTime.Text = elapsedTime;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            data["progress"]["date"] = DateTime.UtcNow.ToString();
            data["progress"]["sent"] = CmdSent.ToString();
            parser.SaveFile("config.ini", data);
        }

    }
}
