namespace TwitchTest
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lbCommand = new System.Windows.Forms.ListBox();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCmd = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(12, 12);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(71, 45);
            this.btnLock.TabIndex = 2;
            this.btnLock.Text = "Find emulator";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(89, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(73, 45);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect to Chat";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lbCommand
            // 
            this.lbCommand.BackColor = System.Drawing.SystemColors.MenuText;
            this.lbCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCommand.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCommand.ForeColor = System.Drawing.SystemColors.Window;
            this.lbCommand.FormattingEnabled = true;
            this.lbCommand.ItemHeight = 19;
            this.lbCommand.Location = new System.Drawing.Point(12, 158);
            this.lbCommand.Name = "lbCommand";
            this.lbCommand.Size = new System.Drawing.Size(228, 247);
            this.lbCommand.TabIndex = 4;
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 500;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(8, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Time so far:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTime.Location = new System.Drawing.Point(12, 132);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(27, 19);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(8, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keys pressed:";
            // 
            // lblCmd
            // 
            this.lblCmd.AutoSize = true;
            this.lblCmd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmd.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCmd.Location = new System.Drawing.Point(12, 89);
            this.lblCmd.Name = "lblCmd";
            this.lblCmd.Size = new System.Drawing.Size(27, 19);
            this.lblCmd.TabIndex = 10;
            this.lblCmd.Text = "00";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(168, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 45);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(250, 456);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCmd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCommand);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnLock);
            this.Name = "frmMain";
            this.Text = "Twitch Gameboy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lbCommand;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCmd;
        private System.Windows.Forms.Button btnSave;
    }
}

