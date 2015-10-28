using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowUI.HHZX.UserInformation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserCard;
using Model.General;
using PaymentEquipment.Entity;
using Model.HHZX.Report;
using Microsoft.Reporting.WebForms;
using WindowUI.HHZX.ClassLibrary.Public;
using Common;
using System.Configuration;

namespace WindowUI.HHZX.UserCard.Recharge
{
    /*
    * 06-04 Donald FINISH : 个人转账；TODO：1、显示此用户今天的定餐情况，2、打印小票
    */
    /// <summary>
    /// 个人转账充值
    /// </summary>
    public partial class frmRechargeOfflineSingle : BaseReaderForm
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        private CardUserMaster_cus_Info _CurrentUser;
        /// <summary>
        /// 当前用户发卡信息
        /// </summary>
        private UserCardPair_ucp_Info _CurrentPair;
        private ICardUserAccountBL _ICardUserAccountBL;
        private IUserCardPairBL _IUserCardPairBL;
        private IRechargeRecordBL _IRechargeRecordBL;
        private IPreRechargeRecordBL _IPreRechargeRecordBL;
        private IPreConsumeRecordBL _IPreConsumeRecordBL;

        public frmRechargeOfflineSingle()
        {
            InitializeComponent();

            this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._IRechargeRecordBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            this._IPreRechargeRecordBL = MasterBLLFactory.GetBLL<IPreRechargeRecordBL>(MasterBLLFactory.PreRechargeRecord);
            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ResetAllControls();

            btnSelectUser_Click(null, null);
        }

        private void ResetAllControls()
        {
            labUserName.Text = string.Empty;
            labClassName.Text = string.Empty;
            labStuNum.Text = string.Empty;
            labAccountBalance.Text = "0.00";
            labAccountSyncTime.Text = "未同步";
            tbxTransferMoney.Text = "0.00";
            tbxTransferMoney.Enabled = false;
            btnConfirmRecharge.Enabled = false;
        }

        /// <summary>
        /// 计算预付款欠款值
        /// </summary>
        /// <param name="pairInfo">发卡资料</param>
        private decimal computePreCost(Guid cusID)
        {
            try
            {
                //计算未付的预付款金额
                List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
                {
                    pcs_cUserID = cusID
                });
                listPreCost = listPreCost.Where(x =>
                    x.pcs_lIsSettled == false
                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                    ).ToList();
                if (listPreCost != null)
                {
                    if (listPreCost.Count > 0)
                    {
                        decimal fSumPreCost = listPreCost.Sum(x => x.pcs_fCost);
                        return Math.Round(fSumPreCost, 2);
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }

        }

        private void btnConfirmRecharge_Click(object sender, EventArgs e)
        {
            bool resUkey = base.CheckUKey();
            if (!resUkey)
            {
                return;
            }

            if (string.IsNullOrEmpty(tbxTransferMoney.Text.Trim()))
            {
                this.ShowWarningMessage("请输入充值金额。");
                tbxTransferMoney.Focus();
                return;
            }
            decimal fRecharge;
            bool res = decimal.TryParse(tbxTransferMoney.Text.Trim(), out fRecharge);
            if (!res)
            {
                this.ShowWarningMessage("请检查充值金额的格式。");
                tbxTransferMoney.Focus();
                return;
            }
            if (fRecharge <= 0)
            {
                this.ShowWarningMessage("充值金额需大于0，请重新输入。");
                tbxTransferMoney.Focus();
                return;
            }
            else if (fRecharge > Common.DefineConstantValue.MaxRechargeVal)
            {
                this.ShowWarningMessage("充值金额不能大于" + Common.DefineConstantValue.MaxRechargeVal.ToString() + "，请重新输入。");
                tbxTransferMoney.Focus();
                tbxTransferMoney.SelectAll();
                return;
            }

            //帐号余额
            ConsumeCardInfo ccInfo = new ConsumeCardInfo();
            ccInfo.CardBalance = decimal.Parse(this.labAccountBalance.Text);

            //查卡号
            UserCardPair_ucp_Info ucpInfo = new UserCardPair_ucp_Info();
            ucpInfo.ucp_cCUSID = this._CurrentUser.cus_cRecordID;
            List<UserCardPair_ucp_Info> ucpList = _IUserCardPairBL.SearchRecords(ucpInfo);
            if (ucpList != null && ucpList.Count > 0)
            {
                ucpList = ucpList.OrderBy(p => p.ucp_dAddDate).ToList();
                ccInfo.CardNo = ucpList[0].ucp_iCardNo.ToString();
            }
            else
            {
                if (MessageBox.Show("该用户未发卡，确认继续进行操作?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }
            }

            dlgConfirmInfo dlg = new dlgConfirmInfo();
            dlg.RechargeMoney = fRecharge;
            dlg.UserInfo = this._CurrentUser;
            dlg.PreCostMoney = computePreCost(this._CurrentUser.cus_cRecordID);
            dlg.CardInfo = ccInfo;
            dlg.IsPrinted = cbxPrint.Checked;
            dlg.IsSkipPreCost = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    PreRechargeRecord_prr_Info preRechargeInfo = new PreRechargeRecord_prr_Info();
                    preRechargeInfo.prr_cAdd = base.UserInformation.usm_cUserLoginID;
                    preRechargeInfo.prr_cLast = base.UserInformation.usm_cUserLoginID;
                    preRechargeInfo.prr_cRechargeType = Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalTransfer.ToString();
                    preRechargeInfo.prr_cRecordID = Guid.NewGuid();
                    preRechargeInfo.prr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.WaitForAcceptTransfer.ToString();
                    preRechargeInfo.prr_cUserID = this._CurrentUser.cus_cRecordID;
                    preRechargeInfo.prr_dRechargeTime = DateTime.Now;
                    preRechargeInfo.prr_fRechargeMoney = fRecharge;

                    ReturnValueInfo rvInfo = this._IPreRechargeRecordBL.Save(preRechargeInfo, Common.DefineConstantValue.EditStateEnum.OE_Insert);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        this.ShowInformationMessage("转账成功，请通知卡用户进行卡充值。");

                        if (cbxPrint.Checked)
                        {
                            RechargeDetail rdInfo = new RechargeDetail();
                            //rdInfo.CardNo = Int32.Parse(this.labCardNo.Text);
                            rdInfo.OperationTime = System.DateTime.Now;
                            rdInfo.Operator = this.UserInformation.usm_cUserLoginID;
                            rdInfo.RechargeValue = fRecharge;
                            rdInfo.UserName = this.labUserName.Text;
                            rdInfo.ClassName = this.labClassName.Text;
                            //打印小票
                            PrintTicket(rdInfo);
                        }

                    }
                    else
                    {
                        base.ShowErrorMessage("转账失败。" + rvInfo.messageText);
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    this.ShowErrorMessage(ex);
                }

                ResetAllControls();
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 打印小票
        /// </summary>
        /// <param name="rdInfo"></param>
        private void PrintTicket(RechargeDetail rdInfo)
        {
            List<RechargeDetail> rdList = new List<RechargeDetail>();

            rdList.Add(rdInfo);

            LocalReport lr = new LocalReport();
            ReportDataSource rds = new ReportDataSource("RechargeDetail", rdList);
            lr.ReportPath = DefineConstantValue.ReportFileBasePath + @"RechargeTicket.rdlc";
            lr.DataSources.Add(rds);

            string printName = ConfigurationSettings.AppSettings["TicketPrintName"];

            TicketPrint tp = new TicketPrint();
            tp.PrintTicket(lr, printName);
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            dlgCardUserSelection dlg = new dlgCardUserSelection();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedUser != null)
                {
                    this._CurrentUser = dlg.SelectedUser;
                    this._CurrentPair = dlg.SelectedUser.PairInfo;
                    labUserName.Text = this._CurrentUser.cus_cChaName;
                    labClassName.Text = dlg.SelectedUser.ClassInfo != null ? dlg.SelectedUser.ClassInfo.csm_cClassName : dlg.SelectedUser.DeptInfo.dpm_cName;
                    labStuNum.Text = this._CurrentUser.cus_cStudentID;

                    this.Cursor = Cursors.WaitCursor;

                    //获取当前余额
                    CardUserAccount_cua_Info accountInfo = this._ICardUserAccountBL.SearchRecords(new CardUserAccount_cua_Info()
                    {
                        cua_cCUSID = this._CurrentUser.cus_cRecordID
                    }).FirstOrDefault() as CardUserAccount_cua_Info;

                    if (accountInfo != null)
                    {
                        labAccountBalance.Text = accountInfo.cua_fCurrentBalance.ToString();
                        labAccountSyncTime.Text = accountInfo.cua_dLastSyncTime.ToString("yyyy/MM/dd HH:mm:ss");
                    }

                    tbxTransferMoney.Enabled = true;
                    tbxTransferMoney.Focus();
                    btnConfirmRecharge.Enabled = false;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void tbxRechargeMoney_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxTransferMoney.Text.Trim()))
            {
                return;
            }
            decimal fRecharge = Convert.ToDecimal(tbxTransferMoney.Text);
            if (fRecharge > 0)
            {
                btnConfirmRecharge.Enabled = true;
            }
            else
            {
                btnConfirmRecharge.Enabled = false;
            }
        }

        private void frmRechargeOfflineSingle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnConfirmRecharge.Enabled)
                {
                    btnConfirmRecharge_Click(null, null);
                }
            }
        }
    }
}
