using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsUI.TQS.SystemForm
{
    public partial class MessageDialog : Form
    {
        public MessageDialog()
        {
            InitializeComponent();
        }

        public void Show(string title , string message)
        {
            lblMessage.Text = FormatMessage(message);
            lblTitle.Text = title;
            this.ShowDialog();
        }

        public string FormatMessage(string message)
        {
            string returnStr = "";

            if (message.Length > 15)
            {
                for (int index = 0; index < message.Length; index = index + 15)
                {
                    int strLeng = 15;
                    if (message.Length - index < 15)
                    {
                        strLeng = message.Length - index;
                    }

                    returnStr += message.Substring(index, strLeng);
                    returnStr += "\r\n";
                }
            }
            else
            {
                returnStr = message;
            }

            return returnStr;
        }

        public void SetNoCloseModel()
        {
            this.btnOK.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
