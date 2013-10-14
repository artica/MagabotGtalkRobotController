using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;

using agsXMPP;
using Microsoft.Win32;

namespace gTalkRobotController
{
    public partial class Form1 : Form
    {
        XmppClientConnection xmppCon = new XmppClientConnection();

        List<gTalkUserTab> gTalkUserTabs = new List<gTalkUserTab>();

        string selectedChatUser;
        bool chatUserSelected;
        int controlState;
        bool rememberMe = false;

        Registry winreg;
        string path = (string)"HARDWARE\\DEVICEMAP\\SERIALCOMM";
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(winreg.HKEY_LOCAL_MACHINE);


        public Form1()
        {
            InitializeComponent();

            Init();

            this.FormClosing += delegate
            {
                serialPort.Close();
            };

            //availabe COM ports
            SerialPort tmp;
            foreach (string str in SerialPort.GetPortNames())
            {
                tmp = new SerialPort(str);
                if (tmp.IsOpen == false)
                    port_combobox.Items.Add(str);

                
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\xyz");
                string pathName = (string)"HARDWARE\\DEVICEMAP\\SERIALCOMM";
            }
        }
        
     
        private void Init()
        {
            listEvents.Items.Clear();

            // Subscribe to Events
            xmppCon.OnLogin         += new ObjectHandler(xmppCon_OnLogin);
            xmppCon.OnRosterStart   += new ObjectHandler(xmppCon_OnRosterStart);
            xmppCon.OnRosterEnd     += new ObjectHandler(xmppCon_OnRosterEnd);
            xmppCon.OnRosterItem    += new XmppClientConnection.RosterHandler(xmppCon_OnRosterItem);
            xmppCon.OnPresence      += new agsXMPP.protocol.client.PresenceHandler(xmppCon_OnPresence);
            xmppCon.OnAuthError     += new XmppElementHandler(xmppCon_OnAuthError);
            xmppCon.OnError         += new ErrorHandler(xmppCon_OnError);
            xmppCon.OnClose         += new ObjectHandler(xmppCon_OnClose);
            xmppCon.OnMessage       += new agsXMPP.protocol.client.MessageHandler(xmppCon_OnMessage);

            cmdLogin.Enabled = true;
            cmdLogout.Enabled = false;
        }


        #region Serial

        private void port_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort.PortName = port_combobox.Text;
            //open serial port
            serialPort.Open();
            port_combobox.Enabled = false;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            chatUserSelected = true;
        }

        private void msg_listbox_TextChanged(object sender, EventArgs e)
        {
            msg_listbox.SelectionStart = msg_listbox.Text.Length;
            msg_listbox.ScrollToCaret();
            msg_listbox.Refresh();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // blocks until TERM_CHAR is received
            string msg = serialPort.ReadExisting();
            if (msg[0] == 'i')
            {
                if (chatUserSelected)
                {
                    agsXMPP.protocol.client.Message answerMsg = new agsXMPP.protocol.client.Message();
                    answerMsg.Type = agsXMPP.protocol.client.MessageType.chat;
                    answerMsg.To = new Jid(selectedChatUser);
                    answerMsg.Body = Properties.Settings.Default.holeMessage;
                    xmppCon.Send(answerMsg);
                }
                
                msg_listbox.Invoke((Action)delegate() { msg_listbox.Text += string.Format("R: {0} \r\n", msg); });
            }
            else if (msg[0] == 'b')
            {
                if (chatUserSelected)
                {
                    agsXMPP.protocol.client.Message answerMsg = new agsXMPP.protocol.client.Message();
                    answerMsg.Type = agsXMPP.protocol.client.MessageType.chat;
                    answerMsg.To = new Jid(selectedChatUser);
                    answerMsg.Body = Properties.Settings.Default.bumperMessage;
                    xmppCon.Send(answerMsg);
                }
                
                msg_listbox.Invoke((Action)delegate() { msg_listbox.Text += string.Format("R: {0} \r\n", msg); });
            }
        }

        private void user_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedChatUser = user_combobox.Text;
            //this.BeginInvoke((Action)(() => { skype.SendMessage(selectedChatUser, Properties.Settings.Default.controllerMessage); }));

            agsXMPP.protocol.client.Message answerMsg = new agsXMPP.protocol.client.Message();
            answerMsg.Type = agsXMPP.protocol.client.MessageType.chat;
            answerMsg.To = new Jid(user_combobox.Text);
            answerMsg.Body = Properties.Settings.Default.controllerMessage;
            xmppCon.Send(answerMsg);

            chatUserSelected = true;
        }

#endregion

        void xmppCon_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            // ignore empty messages (events)
            if (msg.Body == null)
                return;

            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new agsXMPP.protocol.client.MessageHandler(xmppCon_OnMessage), new object[] { sender, msg });
                return;
            }

            listEvents.Items.Add(String.Format("Message from {1}: {2}", msg.From.User, msg.From.Bare, msg.Body));
            listEvents.SelectedIndex = listEvents.Items.Count -1;


            if (!gTalkUserTabs.Contains(new gTalkUserTab(msg.From.Bare)))
            {
                agsXMPP.protocol.client.Message answerMsg = new agsXMPP.protocol.client.Message();
                answerMsg.Type = agsXMPP.protocol.client.MessageType.chat;
                answerMsg.To = new Jid(msg.From.Bare);
                answerMsg.Body = Properties.Settings.Default.welcomeMessage;
                xmppCon.Send(answerMsg); 
                
                user_combobox.Items.Add(msg.From.Bare);
                var newTabUser = new gTalkUserTab(msg.From.Bare);
                gTalkUserTabs.Add(newTabUser);
                tabUsers.Controls.Add(newTabUser.tabPage);
            }

            if (msg.Body.Length == 1)
            {
                gTalkUserTab selected = gTalkUserTabs.First(delegate(gTalkUserTab value) { return value.skypeChatUser == msg.From.Bare; });
                selected.textBox.Text += string.Format("{0} \r\n", msg.Body);

                if (selected.skypeChatUser == selectedChatUser)
                {
                    if (serialPort.IsOpen)
                    {
                        if (msg.Body.Contains('3'))
                            controlState = 3;
                        else if (msg.Body.Contains('2'))
                            controlState = 2;
                        else if (msg.Body.Contains('1'))
                            controlState = 1;
                        
                        if (!msg.Body.Contains('1') && !msg.Body.Contains('2') && !msg.Body.Contains('3') && controlState != 1)
                        {
                            controlState = 1;
                            serialPort.WriteLine("1");
                            msg_listbox.Paste(string.Format("S: {0} \r\n", '1'));
                        }


                        serialPort.Write(msg.Body.ToCharArray(), 0, 1);
                        msg_listbox.Paste(string.Format("S: {0} \r\n", msg.Body));
                    }
                    else
                    {
                        if (!msg.Body.Contains('1') && !msg.Body.Contains('2') && !msg.Body.Contains('3') && controlState != 1)
                        {
                            controlState = 1;
                            msg_listbox.Paste(string.Format("Failed to Send: {0} \r\n", '1'));
                        }

                        msg_listbox.Text += string.Format("Failed to Send: {0} \r\n", msg.Body);
                        agsXMPP.protocol.client.Message answerMsg = new agsXMPP.protocol.client.Message();
                        answerMsg.Type = agsXMPP.protocol.client.MessageType.chat;
                        answerMsg.To = new Jid(msg.From.Bare);
                        answerMsg.Body = Properties.Settings.Default.failedToSendMessage;
                        xmppCon.Send(answerMsg);
                    }
                }
                else
                {
                    agsXMPP.protocol.client.Message answerMsg = new agsXMPP.protocol.client.Message();
                    answerMsg.Type = agsXMPP.protocol.client.MessageType.chat;
                    answerMsg.To = new Jid(msg.From.Bare);
                    answerMsg.Body = Properties.Settings.Default.waitMessage;
                    xmppCon.Send(answerMsg);
                }
            }

            if (chatUserSelected == false)
            {
                chatUserSelected = true;

                user_combobox.ResetText();
                user_combobox.SelectedText = msg.From.Bare;
                selectedChatUser = msg.From.Bare;
                
                agsXMPP.protocol.client.Message answerMsg = new agsXMPP.protocol.client.Message();
                answerMsg.Type = agsXMPP.protocol.client.MessageType.chat;
                answerMsg.To = new Jid(user_combobox.Text);
                answerMsg.Body = Properties.Settings.Default.controllerMessage;
                xmppCon.Send(answerMsg);
            }
        }


        void xmppCon_OnPresence(object sender, agsXMPP.protocol.client.Presence pres)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new agsXMPP.protocol.client.PresenceHandler(xmppCon_OnPresence), new object[] { sender, pres });
                return;
            }
            //listEvents.Items.Add(String.Format("Received Presence from:{0} show:{1} status:{2}", pres.From.ToString(), pres.Show.ToString(), pres.Status));

            //listEvents.Items.Add(String.Format("Received Presence from:{0}", pres.From.ToString()));

            comboBoxID.Items.Add(pres.From.ToString());
                

            listEvents.SelectedIndex = listEvents.Items.Count - 1;

            /*
            if (!gTalkUserTabs.Contains(new gTalkUserTab(item.Jid.Bare)))
            {
                user_combobox.Items.Add(item.Jid.Bare);
                var newTabUser = new gTalkUserTab(item.Jid.Bare);
                gTalkUserTabs.Add(newTabUser);
                tabUsers.Controls.Add(newTabUser.tabPage);
            }
             */
        }


        #region Código sem interesse

        void xmppCon_OnClose(object sender)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(xmppCon_OnClose), new object[] { sender });
                return;
            }
            listEvents.Items.Add("OnClose Connection closed");
            listEvents.SelectedIndex = listEvents.Items.Count -1;
        }

        void xmppCon_OnError(object sender, Exception ex)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ErrorHandler(xmppCon_OnError), new object[] { sender, ex });
                return;
            }
            listEvents.Items.Add("OnError");
            listEvents.SelectedIndex = listEvents.Items.Count -1;
        }

        void xmppCon_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new XmppElementHandler(xmppCon_OnAuthError), new object[] { sender, e });
                return;
            }
            listEvents.Items.Add("OnAuthError");
            listEvents.SelectedIndex = listEvents.Items.Count -1;
        }


        void xmppCon_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new XmppClientConnection.RosterHandler(xmppCon_OnRosterItem), new object[] { sender, item });
                return;
            }
            //listEvents.Items.Add(String.Format("Received Contact {0}", item.Jid.Bare));
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
            
        }

        void xmppCon_OnRosterEnd(object sender)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(xmppCon_OnRosterEnd), new object[] { sender });
                return;
            }
            listEvents.Items.Add("OnRosterEnd");
            listEvents.SelectedIndex = listEvents.Items.Count - 1;

            // Send our own presence to teh server, so other epople send us online
            // and the server sends us the presences of our contacts when they are
            // available
            xmppCon.SendMyPresence();
        }

        void xmppCon_OnRosterStart(object sender)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(xmppCon_OnRosterStart), new object[] { sender });
                return;
            }
            listEvents.Items.Add("OnRosterStart");
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
        }

        void xmppCon_OnLogin(object sender)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(xmppCon_OnLogin), new object[] { sender });
                return;
            }
            listEvents.Items.Add("OnLogin");
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
        }

        private void cmdLogout_Click(object sender, EventArgs e)
        {
            // close the xmpp connection
            xmppCon.Close();

            rememberCheckBox.Enabled = true;
            txtJabberId.Enabled = true;
            txtPassword.Enabled = true;

            cmdLogin.Enabled = true;
            cmdLogout.Enabled = false;
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            Jid jidUser = new Jid(txtJabberId.Text);

            xmppCon.Username = jidUser.User;
            xmppCon.Server = jidUser.Server;
            xmppCon.Password = txtPassword.Text;
            xmppCon.AutoResolveConnectServer = true;

            xmppCon.Open();

            if (rememberCheckBox.Checked)
            {
                Properties.Settings.Default.email = txtJabberId.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.Save();
            }

            rememberCheckBox.Enabled = false;
            txtJabberId.Enabled = false;
            txtPassword.Enabled = false;

            cmdLogin.Enabled = false;
            cmdLogout.Enabled = true;

        }

        #endregion

        private void cmdSend_Click(object sender, EventArgs e)
        {
            // Send a message
            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();
            msg.Type = agsXMPP.protocol.client.MessageType.chat;
            //msg.To = new Jid(txtJabberIdReceiver.Text);
            msg.To = new Jid(comboBoxID.Text);
            msg.Body = txtMessage.Text;

            xmppCon.Send(msg);

            txtMessage.Text = "";
        }

        #region Controlo Manual
        private void up_button_Click(object sender, EventArgs e)
        {
            if (controlState != 1) one_button.PerformClick();

            String msg = "w";
            if (serialPort.IsOpen)
            {
                this.BeginInvoke((Action)(() => { serialPort.WriteLine(msg); }));
                this.BeginInvoke((Action)(() => { msg_listbox.Paste(string.Format("S: {0} \r\n", msg)); }));
            }
            else
            {
                this.BeginInvoke((Action)(() => { msg_listbox.Text += string.Format("Failed to Send: {0} \r\n", msg); }));
            }
        }

        private void down_button_Click(object sender, EventArgs e)
        {
            if (controlState != 1) one_button.PerformClick();

            String msg = "s";
            if (serialPort.IsOpen)
            {
                this.BeginInvoke((Action)(() => { serialPort.WriteLine(msg); }));
                this.BeginInvoke((Action)(() => { msg_listbox.Paste(string.Format("S: {0} \r\n", msg)); }));
            }
            else
            {
                this.BeginInvoke((Action)(() => { msg_listbox.Text += string.Format("Failed to Send: {0} \r\n", msg); }));
            }

        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            if (controlState != 1) one_button.PerformClick();

            String msg = "p";
            if (serialPort.IsOpen)
            {
                this.BeginInvoke((Action)(() => { serialPort.WriteLine(msg); }));
                this.BeginInvoke((Action)(() => { msg_listbox.Paste(string.Format("S: {0} \r\n", msg)); }));
            }
            else
            {
                this.BeginInvoke((Action)(() => { msg_listbox.Text += string.Format("Failed to Send: {0} \r\n", msg); }));
            }
        }

        private void left_button_Click(object sender, EventArgs e)
        {
            if (controlState != 1) one_button.PerformClick();

            String msg = "a";
            if (serialPort.IsOpen)
            {
                this.BeginInvoke((Action)(() => { serialPort.WriteLine(msg); }));
                this.BeginInvoke((Action)(() => { msg_listbox.Paste(string.Format("S: {0} \r\n", msg)); }));
            }
            else
            {
                this.BeginInvoke((Action)(() => { msg_listbox.Text += string.Format("Failed to Send: {0} \r\n", msg); }));
            }
        }

        private void right_button_Click(object sender, EventArgs e)
        {
            if (controlState != 1) one_button.PerformClick();

            String msg = "d";
            if (serialPort.IsOpen)
            {
                this.BeginInvoke((Action)(() => { serialPort.WriteLine(msg); }));
                this.BeginInvoke((Action)(() => { msg_listbox.Paste(string.Format("S: {0} \r\n", msg)); }));
            }
            else
            {
                this.BeginInvoke((Action)(() => { msg_listbox.Text += string.Format("Failed to Send: {0} \r\n", msg); }));
            }
        }

        private void one_button_Click(object sender, EventArgs e)
        {
            controlState = 1;

            String msg = "1";
            if (serialPort.IsOpen)
            {
                this.BeginInvoke((Action)(() => { serialPort.WriteLine(msg); }));
                this.BeginInvoke((Action)(() => { msg_listbox.Paste(string.Format("S: {0} \r\n", msg)); }));
            }
            else
            {
                this.BeginInvoke((Action)(() => { msg_listbox.Text += string.Format("Failed to Send: {0} \r\n", msg); }));
            }
        }

        private void two_button_Click(object sender, EventArgs e)
        {
            controlState = 2;

            String msg = "2";
            if (serialPort.IsOpen)
            {
                this.BeginInvoke((Action)(() => { serialPort.WriteLine(msg); }));
                this.BeginInvoke((Action)(() => { msg_listbox.Paste(string.Format("S: {0} \r\n", msg)); }));
            }
            else
            {
                this.BeginInvoke((Action)(() => { msg_listbox.Text += string.Format("Failed to Send: {0} \r\n", msg); }));
            }
        }

#endregion

        private void rememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            rememberMe = true;
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void findButton_Click(object sender, EventArgs e)
        {
            foreach (string str in SerialPort.GetPortNames())
            {
                //availabe COM ports
                SerialPort tmp;
                tmp = new SerialPort(str);
                if (tmp.IsOpen == false)
                    port_combobox.Items.Add(str);
            }
        }

    }
}