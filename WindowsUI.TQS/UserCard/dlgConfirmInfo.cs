using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaymentEquipment.Entity;
using Model.HHZX.UserInfomation.CardUserInfo;

namespace WindowsUI.TQS.UserCard
{
    public partial class dlgConfirmInfo : BaseForm
    {
        /// <summary>
        /// 卡信息
        /// </summary>
        public ConsumeCardInfo CardInfo { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeMoney { get; set; }
        /// <summary>
        /// 欠款
        /// </summary>
        public decimal PreCostMoney { get; set; }
        /// <summary>
        /// 人员信息
        /// </summary>
        public CardUserMaster_cus_Info UserInfo { get; set; }

        public dlgConfirmInfo()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            labCardNo.Text = string.Empty;
            labName.Text = string.Empty;
            labRechargeMoney.Text = decimal.Zero.ToString();
            labOldBalance.Text = decimal.Zero.ToString();
            labNewBalance.Text = decimal.Zero.ToString();
            labPreCost.Text = decimal.Zero.ToString();

            BindCardInfo();
        }

        private void BindCardInfo()
        {
            if (UserInfo != null)
            {
                labCardNo.Text = CardInfo != null ? CardInfo.CardNo : string.Empty;
                labCardNo.Text = labCardNo.Text.PadLeft(8, '0');
                labName.Text = UserInfo.cus_cChaName;
                labRechargeMoney.Text = CheckDecimalPoint(RechargeMoney.ToString());
                labPreCost.Text = CheckDecimalPoint(PreCostMoney.ToString());
                labOldBalance.Text = CardInfo != null ? CardInfo.CardBalance.ToString() : decimal.Zero.ToString();
                labOldBalance.Text = CheckDecimalPoint(labOldBalance.Text);
                labNewBalance.Text = CardInfo != null ? (CardInfo.CardBalance + RechargeMoney).ToString() : decimal.Zero.ToString();
                labNewBalance.Text = CheckDecimalPoint(labNewBalance.Text);

                decimal fNewBalance = decimal.Parse(labNewBalance.Text);
                if (fNewBalance < 0)
                {
                    btnConfim.Enabled = false;
                }
                else
                {
                    btnConfim.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 检查是否含有小数点
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private string CheckDecimalPoint(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return strValue;
            }
            if (!strValue.Contains('.'))
            {
                strValue += ".00";
            }
            return strValue;
        }
    }
}
