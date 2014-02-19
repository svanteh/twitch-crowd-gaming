using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchTest
{
    class Emulator
    {
        #region imports
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        #endregion

        /// <summary>
        /// Keeps track of process handle
        /// </summary>
        public IntPtr hWnd;

        /// <summary>
        /// Title to look for
        /// </summary>
        public string EmulatorTitle { get; set; }

        public Emulator(string title)
        {
            this.EmulatorTitle = title;
        }

        /// <summary>
        /// Looks for emulator
        /// </summary>
        /// <returns>true if successfull</returns>
        public bool FindEmulator()
        {
            IntPtr thWnd = FindWindow(null, this.EmulatorTitle);
            if (thWnd.ToInt32() != 0)
            {
                this.hWnd = thWnd;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Sends key press to emulator
        /// </summary>
        /// <param name="vk"></param>
        public void PressKey(int vk)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;

            if (this.hWnd != null)
            {
                PostMessage(hWnd, WM_KEYDOWN, vk, 0x11480001);
                Thread.Sleep(200);
                PostMessage(hWnd, WM_KEYUP, vk, 0x11480001);
            }
        }
    }
}
