using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gTalkRobotController
{
    class gTalkUserTab : IEquatable<gTalkUserTab>
    {
        public string skypeChatUser;
        public TabPage tabPage;
        public TextBox textBox;


        public gTalkUserTab( string userName)
        {
            skypeChatUser = userName;
            
            tabPage = new TabPage(userName);
            
            textBox = new TextBox();
            
            textBox.Size = new System.Drawing.Size(252, 153);
            textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox.Multiline = true;

            tabPage.Controls.Add(textBox);
        }
        public bool Equals(gTalkUserTab other)
        {
            return skypeChatUser == other.skypeChatUser;
        }


    }
}
