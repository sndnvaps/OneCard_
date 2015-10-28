using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using WindowUI.TQS;
using PaymentEquipment.Entity;
using System.Threading;

namespace WindowsUI.TQS
{
    public partial class WaitForCardReader : BaseReaderForm
    {
        private int _times = 30;

        public ConsumeCardInfo CardInfo;

        public WaitForCardReader(string strPwd)
            : base(strPwd)
        {
            InitializeComponent();
            ShowForm();
        }

        public void ShowForm()
        {
            this.lblTimes.Text = _times.ToString();
            timReadCard.Enabled = true;
            timOutTime.Enabled = true;
        }

        private void FormClose(DialogResult diaType)
        {
            this.DialogResult = diaType;
            this.Close();
        }

        private void timReadCard_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_times > 0)
                {
                    if (ReadCard())//如果成功讀卡，關閉定時器，返回OK
                    {
                        timReadCard.Enabled = false;
                        FormClose(DialogResult.OK);
                    }
                    else
                    {

                    }
                }
                else
                {
                    FormClose(DialogResult.No);
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 讀卡
        /// </summary>
        /// <returns></returns>
        private bool ReadCard()
        {
            try
            {
                if (_IsConnected)
                {
                    CardInfo = _Reader.ReadCardInfo(_CardInfoSection, _SectionPwd);
                    if (CardInfo != null)
                    {
                        this.lblMessage.Text = "已读卡，请稍后。";
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                }
            }
            catch
            {

            }

            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FormClose(DialogResult.No);
        }

        private void timOutTime_Tick(object sender, EventArgs e)
        {
            this.lblTimes.Text = _times.ToString();
            _times--;
        }

    }
}
