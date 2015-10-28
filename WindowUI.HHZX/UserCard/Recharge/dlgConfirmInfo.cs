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
using Microsoft.Reporting.WinForms;
using Common;
using Model.HHZX.Report;
using WindowUI.HHZX.ClassLibrary.Public;

namespace WindowUI.HHZX.UserCard.Recharge
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
        /// 预支额
        /// </summary>
        public decimal AdvanceMoney { get; set; }
        /// <summary>
        /// 是否打印
        /// </summary>
        public bool IsPrinted { get; set; }
        /// <summary>
        /// 是否跳过欠款
        /// </summary>
        public bool IsSkipPreCost { get; set; }

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
            labIsPrinted.Text = string.Empty;
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
                labName.Text = UserInfo.cus_cChaName;
                labRechargeMoney.Text = RechargeMoney.ToString();
                labPreCost.Text = PreCostMoney.ToString();
                labIsPrinted.Text = IsPrinted ? "是" : "否";
                labOldBalance.Text = CardInfo != null ? CardInfo.CardBalance.ToString() : decimal.Zero.ToString();
                labNewBalance.Text = CardInfo != null ? (CardInfo.CardBalance + RechargeMoney + PreCostMoney).ToString() : decimal.Zero.ToString();

                decimal fUserBalance = RechargeMoney + PreCostMoney + CardInfo.CardBalance - AdvanceMoney;
                if (fUserBalance < 0 && !IsSkipPreCost)
                {
                    lblMessage.Visible = true;
                    btnConfim.Enabled = false;
                }
            }
        }

    }
}
