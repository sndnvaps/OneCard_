using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaymentEquipment.Entity;
using BLL.IBLL.HHZX.UserCard;
using BLL.Factory.HHZX;
using Model.HHZX.UserCard;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using WeifenLuo.WinFormsUI.Docking;
using Model.SysMaster;
using sysBL = BLL.IBLL.SysMaster;
using sysFac = BLL.Factory.SysMaster;
using Common;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;

namespace WindowsUI.TQS.UserCard
{
    public partial class frmCardInfo : BaseForm
    {
        private ConsumeCardInfo _cardInfo;
        private IUserCardPairBL _iucpBL;
        private ICardUserAccountBL _icuaBL;
        private IRechargeRecordBL _irrBL;
        private sysBL.ICodeMasterBL _ICodeMasterBL;
        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        private string _strPwd;
        private CardUserMaster_cus_Info _UserInfo;

        public frmCardInfo(string strPwd)
        {
            InitializeComponent();
            _strPwd = strPwd;
        }

        public override void Show()
        {
            if (_iucpBL == null)
            {
                _iucpBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            }
            if (_icuaBL == null)
            {
                _icuaBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            }
            if (_ICodeMasterBL == null)
            {
                this._ICodeMasterBL = sysFac.MasterBLLFactory.GetBLL<sysBL.ICodeMasterBL>(sysFac.MasterBLLFactory.CodeMaster_cmt);
            }

            if (_irrBL == null)
            {
                this._irrBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            }
            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            ReadCard();
        }

        private void ReadCard()
        {
            ClearControl();

            WaitForCardReader wfcrFrm = new WaitForCardReader(_strPwd);
            if (wfcrFrm.ShowDialog() == DialogResult.OK)
            {
                _cardInfo = wfcrFrm.CardInfo;
                ShowCardMessage();
            }
        }

        private void ShowCardMessage()
        {
            try
            {
                UserCardPair_ucp_Info ucpInfo = new UserCardPair_ucp_Info();
                ucpInfo.ucp_cCardID = _cardInfo.CardSourceID;
                ucpInfo.ucp_iCardNo = Int32.Parse(_cardInfo.CardNo);

                ucpInfo = _iucpBL.SearchRecords(ucpInfo).FirstOrDefault() as UserCardPair_ucp_Info;

                if (ucpInfo != null)
                {
                    this._UserInfo = ucpInfo.CardOwner;
                    this.lblChaName.Text = ucpInfo.CardOwner.cus_cChaName;
                    this.lblCardNo.Text = ucpInfo.ucp_iCardNo.ToString();

                    if (ucpInfo.CardOwner.ClassInfo != null)
                    {
                        this.lblClassName.Text = ucpInfo.CardOwner.ClassInfo.csm_cClassName;
                    }
                    else if (ucpInfo.CardOwner.DeptInfo != null)
                    {
                        this.lblClassName.Text = ucpInfo.CardOwner.DeptInfo.dpm_cName;
                    }

                    if (_cardInfo.CardBalance != 0)
                    {
                        this.lblCardBalance.Text = _cardInfo.CardBalance.ToString("###.#") + " 元";
                    }
                    else
                    {
                        this.lblCardBalance.Text = "0.00 元";
                    }

                    switch (ucpInfo.ucp_cUseStatus)
                    {
                        case "Normal":
                            this.lblCardStatus.Text = "正常";
                            break;
                        case "LoseReporting":
                            this.lblCardStatus.Text = "挂失中";
                            break;
                        case "Damaged":
                            this.lblCardStatus.Text = "已损坏";
                            break;
                        case "Lost":
                            this.lblCardStatus.Text = "已丢失";
                            break;
                        case "Returned":
                            this.lblCardStatus.Text = "已退卡";
                            break;
                    }

                    CardUserAccount_cua_Info cuaInfo = new CardUserAccount_cua_Info();
                    cuaInfo.cua_cCUSID = ucpInfo.ucp_cCUSID;

                    cuaInfo = _icuaBL.SearchRecords(cuaInfo).FirstOrDefault() as CardUserAccount_cua_Info;

                    if (cuaInfo != null && cuaInfo.cua_fCurrentBalance > 0)
                    {
                        this.lblUserBalance.Text = cuaInfo.cua_fCurrentBalance.ToString("###.#") + " 元";
                    }
                    else
                    {
                        this.lblUserBalance.Text = "0 元";
                    }

                    this.lblSettle.Text = cuaInfo.cua_dLastSyncTime.ToString("yyy/MM/dd HH:mm:ss");

                    BindAdvanceCost(ucpInfo.ucp_cCUSID);
                    ShowUnPay();
                }
                else
                {
                    base.MessageDialog("提示", "找不到卡资料！");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 绑定透支款费用
        /// </summary>
        private void BindAdvanceCost(Guid userID)
        {
            //CodeMaster_cmt_Info codeInfo = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_ConstantExpenses, cmt_cKey2 = Common.DefineConstantValue.CodeMasterDefine.KEY2_AdvanceCost }).FirstOrDefault() as CodeMaster_cmt_Info;
            RechargeRecord_rcr_Info rcrInfo = new RechargeRecord_rcr_Info();
            rcrInfo.rcr_cUserID = userID;
            rcrInfo.rcr_cRechargeType = DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString();
            List<RechargeRecord_rcr_Info> rcrList = _irrBL.SearchRecords(rcrInfo);
            rcrList = rcrList.OrderByDescending(p => p.rcr_dRechargeTime).ToList();

            if (rcrList != null && rcrList.Count > 0)
            {
                if (rcrList[0].rcr_fRechargeMoney != decimal.Zero)
                {
                    labAdvanceMoney.Text = rcrList[0].rcr_fRechargeMoney.ToString("###.#") + " 元";
                }
                else
                {
                    labAdvanceMoney.Text = "0 元";
                }
            }
            else
            {
                labAdvanceMoney.Text = "0 元";
            }
        }

        private void ClearControl()
        {
            this.lblCardBalance.Text = "";
            this.lblCardNo.Text = "";
            this.lblCardStatus.Text = "";
            this.lblChaName.Text = "";
            this.lblClassName.Text = "";
            this.lblUserBalance.Text = "";
            this.labAdvanceMoney.Text = "";
            this.lblSettle.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReadCard();
        }

        private void btnUnpayDetail_Click(object sender, EventArgs e)
        {
            if (this._UserInfo == null)
            {
                base.MessageDialog("提示", "卡用户资料缺失，请重新读卡查询。");
                return;
            }
            dlgPreCostDetail dlg = new dlgPreCostDetail(this._UserInfo);

            GlobalVar.OpenFormList.Add(dlg);

            dlg.ShowDialog();
        }

        void ShowUnPay()
        {
            CardUserAccount_cua_Info cuaInfo = new CardUserAccount_cua_Info();
            cuaInfo.cua_cCUSID = this._UserInfo.cus_cRecordID;
            cuaInfo = _icuaBL.SearchRecords(cuaInfo).FirstOrDefault();
            if (cuaInfo == null)
            {
                return;
            }
            //未结算的预消费列表
            List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
            {
                pcs_cAccountID = cuaInfo.cua_cRecordID
            });
            if (listPreCost != null)
            {
                listPreCost = listPreCost.Where(x =>
                    x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                    && x.pcs_lIsSettled == false
                    && x.pcs_cUserID == this._UserInfo.cus_cRecordID
                    ).ToList();
                labUnPay.Text = Math.Round(listPreCost.Sum(x => x.pcs_fCost), 2).ToString();
            }
            else
            {
                labUnPay.Text = "0.00";
            }
        }
    }
}
