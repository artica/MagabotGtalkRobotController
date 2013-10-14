namespace gTalkRobotController
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmdLogin = new System.Windows.Forms.Button();
            this.cmdLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rememberCheckBox = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJabberId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.txtJabberIdReceiver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabUsers = new System.Windows.Forms.TabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.Serial = new System.Windows.Forms.GroupBox();
            this.findButton = new System.Windows.Forms.Button();
            this.msg_listbox = new System.Windows.Forms.TextBox();
            this.user_combobox = new System.Windows.Forms.ComboBox();
            this.port_combobox = new System.Windows.Forms.ComboBox();
            this.GTalk = new System.Windows.Forms.GroupBox();
            this.listEvents = new System.Windows.Forms.ListBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.one_tabPage = new System.Windows.Forms.TabPage();
            this.stop_button = new System.Windows.Forms.Button();
            this.up_button = new System.Windows.Forms.Button();
            this.one_button = new System.Windows.Forms.Button();
            this.right_button = new System.Windows.Forms.Button();
            this.down_button = new System.Windows.Forms.Button();
            this.left_button = new System.Windows.Forms.Button();
            this.two_tabPage = new System.Windows.Forms.TabPage();
            this.two_button = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.Serial.SuspendLayout();
            this.GTalk.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.one_tabPage.SuspendLayout();
            this.two_tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdLogin
            // 
            this.cmdLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLogin.Location = new System.Drawing.Point(19, 119);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(75, 23);
            this.cmdLogin.TabIndex = 2;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // cmdLogout
            // 
            this.cmdLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLogout.Location = new System.Drawing.Point(120, 119);
            this.cmdLogout.Name = "cmdLogout";
            this.cmdLogout.Size = new System.Drawing.Size(75, 23);
            this.cmdLogout.TabIndex = 3;
            this.cmdLogout.Text = "Logout";
            this.cmdLogout.UseVisualStyleBackColor = true;
            this.cmdLogout.Click += new System.EventHandler(this.cmdLogout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(269, 211);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rememberCheckBox);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmdLogout);
            this.tabPage1.Controls.Add(this.txtJabberId);
            this.tabPage1.Controls.Add(this.cmdLogin);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(261, 185);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Google Account";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rememberCheckBox
            // 
            this.rememberCheckBox.AutoSize = true;
            this.rememberCheckBox.Location = new System.Drawing.Point(115, 154);
            this.rememberCheckBox.Name = "rememberCheckBox";
            this.rememberCheckBox.Size = new System.Drawing.Size(95, 17);
            this.rememberCheckBox.TabIndex = 6;
            this.rememberCheckBox.Text = "Remember Me";
            this.rememberCheckBox.UseVisualStyleBackColor = true;
            this.rememberCheckBox.CheckedChanged += new System.EventHandler(this.rememberCheckBox_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(19, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(176, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // txtJabberId
            // 
            this.txtJabberId.AutoCompleteCustomSource.AddRange(new string[] {
            "magabot.cc@gmail.com"});
            this.txtJabberId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtJabberId.Location = new System.Drawing.Point(19, 49);
            this.txtJabberId.Name = "txtJabberId";
            this.txtJabberId.Size = new System.Drawing.Size(176, 20);
            this.txtJabberId.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Google ID\r\n";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxID);
            this.tabPage2.Controls.Add(this.txtMessage);
            this.tabPage2.Controls.Add(this.cmdSend);
            this.tabPage2.Controls.Add(this.txtJabberIdReceiver);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(261, 185);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chat";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxID
            // 
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(8, 46);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(242, 21);
            this.comboBoxID.TabIndex = 9;
            this.comboBoxID.SelectedIndexChanged += new System.EventHandler(this.comboBoxID_SelectedIndexChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(9, 73);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(241, 70);
            this.txtMessage.TabIndex = 6;
            // 
            // cmdSend
            // 
            this.cmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSend.Location = new System.Drawing.Point(150, 149);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(100, 30);
            this.cmdSend.TabIndex = 8;
            this.cmdSend.Text = "Send Message";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // txtJabberIdReceiver
            // 
            this.txtJabberIdReceiver.Location = new System.Drawing.Point(6, 21);
            this.txtJabberIdReceiver.Name = "txtJabberIdReceiver";
            this.txtJabberIdReceiver.Size = new System.Drawing.Size(244, 20);
            this.txtJabberIdReceiver.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Google ID";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabUsers);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(261, 185);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conversations";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabUsers
            // 
            this.tabUsers.Location = new System.Drawing.Point(2, 3);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.SelectedIndex = 0;
            this.tabUsers.Size = new System.Drawing.Size(256, 179);
            this.tabUsers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label1";
            // 
            // Serial
            // 
            this.Serial.Controls.Add(this.findButton);
            this.Serial.Controls.Add(this.msg_listbox);
            this.Serial.Controls.Add(this.user_combobox);
            this.Serial.Controls.Add(this.port_combobox);
            this.Serial.Location = new System.Drawing.Point(12, 229);
            this.Serial.Name = "Serial";
            this.Serial.Size = new System.Drawing.Size(269, 173);
            this.Serial.TabIndex = 9;
            this.Serial.TabStop = false;
            this.Serial.Text = "Serial";
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(98, 19);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(36, 20);
            this.findButton.TabIndex = 3;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // msg_listbox
            // 
            this.msg_listbox.Location = new System.Drawing.Point(6, 46);
            this.msg_listbox.Multiline = true;
            this.msg_listbox.Name = "msg_listbox";
            this.msg_listbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.msg_listbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.msg_listbox.Size = new System.Drawing.Size(248, 121);
            this.msg_listbox.TabIndex = 1;
            this.msg_listbox.WordWrap = false;
            this.msg_listbox.TextChanged += new System.EventHandler(this.msg_listbox_TextChanged);
            // 
            // user_combobox
            // 
            this.user_combobox.FormattingEnabled = true;
            this.user_combobox.Location = new System.Drawing.Point(154, 19);
            this.user_combobox.Name = "user_combobox";
            this.user_combobox.Size = new System.Drawing.Size(100, 21);
            this.user_combobox.TabIndex = 2;
            this.user_combobox.Text = "User";
            this.user_combobox.SelectedIndexChanged += new System.EventHandler(this.user_combobox_SelectedIndexChanged);
            // 
            // port_combobox
            // 
            this.port_combobox.FormattingEnabled = true;
            this.port_combobox.Location = new System.Drawing.Point(6, 19);
            this.port_combobox.Name = "port_combobox";
            this.port_combobox.Size = new System.Drawing.Size(86, 21);
            this.port_combobox.TabIndex = 0;
            this.port_combobox.Text = "Serial Port";
            this.port_combobox.SelectedIndexChanged += new System.EventHandler(this.port_combobox_SelectedIndexChanged);
            // 
            // GTalk
            // 
            this.GTalk.Controls.Add(this.listEvents);
            this.GTalk.Location = new System.Drawing.Point(287, 229);
            this.GTalk.Name = "GTalk";
            this.GTalk.Size = new System.Drawing.Size(216, 172);
            this.GTalk.TabIndex = 10;
            this.GTalk.TabStop = false;
            this.GTalk.Text = "GTalk";
            // 
            // listEvents
            // 
            this.listEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listEvents.FormattingEnabled = true;
            this.listEvents.HorizontalScrollbar = true;
            this.listEvents.Location = new System.Drawing.Point(6, 19);
            this.listEvents.Name = "listEvents";
            this.listEvents.ScrollAlwaysVisible = true;
            this.listEvents.Size = new System.Drawing.Size(204, 147);
            this.listEvents.TabIndex = 5;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.one_tabPage);
            this.tabControl2.Controls.Add(this.two_tabPage);
            this.tabControl2.Location = new System.Drawing.Point(287, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(210, 211);
            this.tabControl2.TabIndex = 12;
            // 
            // one_tabPage
            // 
            this.one_tabPage.Controls.Add(this.stop_button);
            this.one_tabPage.Controls.Add(this.up_button);
            this.one_tabPage.Controls.Add(this.one_button);
            this.one_tabPage.Controls.Add(this.right_button);
            this.one_tabPage.Controls.Add(this.down_button);
            this.one_tabPage.Controls.Add(this.left_button);
            this.one_tabPage.Location = new System.Drawing.Point(4, 22);
            this.one_tabPage.Name = "one_tabPage";
            this.one_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.one_tabPage.Size = new System.Drawing.Size(202, 185);
            this.one_tabPage.TabIndex = 0;
            this.one_tabPage.Text = "1 - Assis. Navig.";
            this.one_tabPage.UseVisualStyleBackColor = true;
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(80, 88);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(45, 45);
            this.stop_button.TabIndex = 6;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // up_button
            // 
            this.up_button.Location = new System.Drawing.Point(80, 37);
            this.up_button.Name = "up_button";
            this.up_button.Size = new System.Drawing.Size(45, 45);
            this.up_button.TabIndex = 3;
            this.up_button.Text = "Up";
            this.up_button.UseVisualStyleBackColor = true;
            this.up_button.Click += new System.EventHandler(this.up_button_Click);
            // 
            // one_button
            // 
            this.one_button.Location = new System.Drawing.Point(35, 6);
            this.one_button.Name = "one_button";
            this.one_button.Size = new System.Drawing.Size(134, 25);
            this.one_button.TabIndex = 9;
            this.one_button.Text = "Select";
            this.one_button.UseVisualStyleBackColor = true;
            this.one_button.Click += new System.EventHandler(this.one_button_Click);
            // 
            // right_button
            // 
            this.right_button.Location = new System.Drawing.Point(131, 88);
            this.right_button.Name = "right_button";
            this.right_button.Size = new System.Drawing.Size(45, 45);
            this.right_button.TabIndex = 8;
            this.right_button.Text = "Right";
            this.right_button.UseVisualStyleBackColor = true;
            this.right_button.Click += new System.EventHandler(this.right_button_Click);
            // 
            // down_button
            // 
            this.down_button.Location = new System.Drawing.Point(80, 139);
            this.down_button.Name = "down_button";
            this.down_button.Size = new System.Drawing.Size(45, 45);
            this.down_button.TabIndex = 5;
            this.down_button.Text = "Down";
            this.down_button.UseVisualStyleBackColor = true;
            this.down_button.Click += new System.EventHandler(this.down_button_Click);
            // 
            // left_button
            // 
            this.left_button.Location = new System.Drawing.Point(29, 88);
            this.left_button.Name = "left_button";
            this.left_button.Size = new System.Drawing.Size(45, 45);
            this.left_button.TabIndex = 7;
            this.left_button.Text = "Left";
            this.left_button.UseVisualStyleBackColor = true;
            this.left_button.Click += new System.EventHandler(this.left_button_Click);
            // 
            // two_tabPage
            // 
            this.two_tabPage.Controls.Add(this.two_button);
            this.two_tabPage.Location = new System.Drawing.Point(4, 22);
            this.two_tabPage.Name = "two_tabPage";
            this.two_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.two_tabPage.Size = new System.Drawing.Size(202, 185);
            this.two_tabPage.TabIndex = 1;
            this.two_tabPage.Text = "2 - Obs. Avoid.";
            this.two_tabPage.UseVisualStyleBackColor = true;
            // 
            // two_button
            // 
            this.two_button.Location = new System.Drawing.Point(33, 6);
            this.two_button.Name = "two_button";
            this.two_button.Size = new System.Drawing.Size(134, 25);
            this.two_button.TabIndex = 10;
            this.two_button.Text = "Select";
            this.two_button.UseVisualStyleBackColor = true;
            this.two_button.Click += new System.EventHandler(this.two_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 414);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.GTalk);
            this.Controls.Add(this.Serial);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "gTalkRobotControlller";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.Serial.ResumeLayout(false);
            this.Serial.PerformLayout();
            this.GTalk.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.one_tabPage.ResumeLayout(false);
            this.two_tabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.Button cmdLogout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJabberId;
        private System.Windows.Forms.TextBox txtJabberIdReceiver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button cmdSend;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox Serial;
        public System.Windows.Forms.TextBox msg_listbox;
        private System.Windows.Forms.ComboBox user_combobox;
        private System.Windows.Forms.ComboBox port_combobox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabUsers;
        private System.Windows.Forms.GroupBox GTalk;
        private System.Windows.Forms.ListBox listEvents;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage one_tabPage;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button up_button;
        private System.Windows.Forms.Button one_button;
        private System.Windows.Forms.Button right_button;
        private System.Windows.Forms.Button down_button;
        private System.Windows.Forms.Button left_button;
        private System.Windows.Forms.TabPage two_tabPage;
        private System.Windows.Forms.Button two_button;
        private System.Windows.Forms.CheckBox rememberCheckBox;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.Button findButton;

    }
}

