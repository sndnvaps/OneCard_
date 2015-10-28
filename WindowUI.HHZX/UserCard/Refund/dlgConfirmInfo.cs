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

namespace WindowUI.HHZX.UserCard.Refund
{
    public partial class dlgConfirmInfo : BaseForm
    {
        /// <summary>
        /// 卡信息
        /// </summary>
        public ConsumeCardInfo CardInfo { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RefundMoney { get; set; }
        /// <summary>
        /// 欠款
        /// </summary>
        public decimal PreCostMoney { get; set; }
        /// <summary>
        /// 是否打印
        /// </summary>
        public bool IsPrinted { get; set; }
        /// <summary>
        /// 人员信息
        /// </summary>
        public CardUserMaster_cus_Info UserInfo { get; set; }
        /// <summary>
        /// 是否跳过欠款
        /// </summary>
        public bool IsSkipPreCost { get; set; }

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
            labIsPrinted.Text = string.Empty;
            labOldBalance.Text = decimal.Zero.ToString();
            labNewBalance.Text = decimal.Zero.ToString();
            //labPreCost.Text = decimal.Zero.ToString();

            BindCardInfo();
        }

        private void BindCardInfo()
        {
            if (UserInfo != null)
            {
                labCardNo.Text = CardInfo != null ? CardInfo.CardNo : string.Empty;
                labName.Text = UserInfo.cus_cChaName;
                labRechargeMoney.Text = RefundMoney.ToString();
                labPreCost.Text = PreCostMoney.ToString();
                labIsPrinted.Text = IsPrinted ? "是" : "否";
                labOldBalance.Text = CardInfo != null ? CardInfo.CardBalance.ToString() : decimal.Zero.ToString();
                labNewBalance.Text = CardInfo != null ? (CardInfo.CardBalance + RefundMoney + PreCostMoney).ToString() : decimal.Zero.ToString();

                if ((RefundMoney + PreCostMoney) < 0 && RefundMoney > 0 && !IsSkipPreCost)
                {
                    btnConfim.Enabled = false;
                }
            }
        }
    }
}
