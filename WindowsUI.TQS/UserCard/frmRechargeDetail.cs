using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaymentEquipment.Entity;
using BLL.Factory.HHZX;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserCard;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using Model.IModel;
using WindowUI.TQS.ClassLibrary.Public;
using WindowsUI.TQS.SystemForm;
using System.Runtime.InteropServices;
using Common;

namespace WindowsUI.TQS.UserCard
{
    public partial class frmRechargeDetail : BaseForm
    {
        private ConsumeCardInfo _cardInfo;

        private Guid _userID;

        private IUserCardPairBL _iucpBL;
        private ICardUserAccountDetailBL _icuadBL;
        private ICardUserAccountBL _icuaBL;

        private List<ViewInfo> _showList = new List<ViewInfo>();

        private int _PageIndex = 1;//當前頁號
        private int _PageSize = 25;//每頁內容條數
        private int _MaxPage = 1;//最大頁號

        private string _strPwd;

        public frmRechargeDetail(string strPwd)
        {
            InitializeComponent();
            this._strPwd = strPwd;
        }

        public override void Show()
        {
            if (_iucpBL == null)
            {
                _iucpBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            }
            if (_icuadBL == null)
            {
                _icuadBL = MasterBLLFactory.GetBLL<ICardUserAccountDetailBL>(MasterBLLFactory.CardUserAccountDetail);
            }
            if (_icuaBL == null)
            {
                _icuaBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            }

            ReadCard();
        }

        private void ReadCard()
        {
            ClearControl();

            WaitForCardReader wfcrFrm = new WaitForCardReader(this._strPwd);
            if (wfcrFrm.ShowDialog() == DialogResult.OK)
            {
                _cardInfo = wfcrFrm.CardInfo;
                ShowCardMessage();

                ShowRecord();
            }
            else
            {
                this.btnSearch.Enabled = false;
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
                    _userID = ucpInfo.ucp_cCUSID;

                    this.lblChaName.Text = ucpInfo.CardOwner.cus_cChaName;
                    this.lblCardNo.Text = ucpInfo.ucp_iCardNo.ToString();

                    this.btnSearch.Enabled = true;
                }
                else
                {
                    base.MessageDialog("提示", "找不到卡资料！");
                    this.btnSearch.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void ClearControl()
        {
            this.lblChaName.Text = "";
            this.lblCardNo.Text = "";
            this.lblRecordAmount.Text = "0";
            this.lblPage.Text = "0/0";
            this.lvList.Items.Clear();
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            ClearControl();
            _showList = new List<ViewInfo>();
            ShowList();
            _PageIndex = 1;
            _MaxPage = 1;
            SetUpDownBtnStatus();

            ReadCard();
        }

        class ViewInfo
        {
            public int index { get; set; }//序号
            public string times { get; set; }//时间
            public string type { get; set; }//类型
            public string cost { get; set; }//金额
        }

        private void ShowRecord()
        {
            _showList = new List<ViewInfo>();

            try
            {
                this.lblRecordAmount.Text = "0";
                this.lvList.Items.Clear();

                DateTime startTime = DateTime.Parse(dtpDateFrom.Value.ToString("yyyy/MM/dd"));
                DateTime endTime = DateTime.Parse(dtpDateTo.Value.ToString("yyyy/MM/dd"));

                if (startTime > endTime)
                {
                    base.MessageDialog("提示", "结束时间不能小于开始时间！");
                    return;
                }

                System.TimeSpan ts = endTime.Subtract(startTime);//TimeSpan得到dt1和dt2的时间间隔
                int countDays = ts.Days;//相隔天数
                if (countDays > 60)
                {
                    base.MessageDialog("提示", "最多只能查询前后60天的记录！");
                    startTime = startTime.AddDays(60);
                    this.dtpDateTo.Value = startTime;
                    return;
                }

                CardUserAccount_cua_Info cuaInfo = new CardUserAccount_cua_Info();
                cuaInfo.cua_cCUSID = _userID;
                cuaInfo = _icuaBL.SearchRecords(cuaInfo).FirstOrDefault() as CardUserAccount_cua_Info;

                CardUserAccountDetail_cuad_Info cuadInfo = new CardUserAccountDetail_cuad_Info();
                cuadInfo.cuad_cCUAID = cuaInfo.cua_cRecordID;
                cuadInfo.OptTime_From = startTime;
                cuadInfo.OptTime_To = endTime.AddDays(1);

                List<CardUserAccountDetail_cuad_Info> infoList = _icuadBL.SearchRecords(cuadInfo);

                if (infoList != null)
                {
                    infoList = infoList.OrderByDescending(x => x.cuad_dOptTime).ToList();

                    int rowNo = 1;

                    for (int index = 0; index < infoList.Count; index++)
                    {
                        cuadInfo = infoList[index] as CardUserAccountDetail_cuad_Info;

                        ViewInfo vi = new ViewInfo();
                        vi.index = rowNo;
                        vi.times = cuadInfo.cuad_dOptTime.ToString("yyyy/MM/dd HH:mm:dd");
                        vi.cost = cuadInfo.cuad_fFlowMoney.ToString();
                        vi.type = cuadInfo.cuad_cFlowType;


                        SetShowViewInfo(vi, _showList);
                        //_showList.Add(vi);

                        rowNo = _showList.Count + 1;
                    }
                }

                if (_showList.Count == 0)
                {
                    if (startTime == endTime && startTime == DateTime.Parse(System.DateTime.Now.ToString("yyyy/MM/dd")))
                    {
                        base.MessageDialog("提示", "今天内无充值记录！");
                    }
                    else
                    {
                        base.MessageDialog("提示", "查找时间内无充值记录！");
                    }
                }


                this.lblRecordAmount.Text = _showList.Count.ToString();
            }
            catch
            {

            }
            finally
            {
                //計算最大頁數
                if (_showList != null)
                {
                    _MaxPage = _showList.Count / _PageSize;

                    if (_showList.Count % _PageSize != 0)
                    {
                        _MaxPage++;
                    }

                    if (_MaxPage == 0)
                    {
                        _PageIndex = 0;
                    }
                    else
                    {
                        if (_PageIndex == 0)
                        {
                            _PageIndex = 1;
                        }
                    }

                    ShowList();//顯示內容
                }
                SetUpDownBtnStatus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearControl();
            _showList = new List<ViewInfo>();
            ShowList();
            _PageIndex = 1;
            _MaxPage = 1;
            SetUpDownBtnStatus();

            ReadCard();

            ShowRecord();
        }

        private void SetShowViewInfo(ViewInfo info, List<ViewInfo> showList)
        {
            switch (info.type)
            {
                case "Recharge_AdvanceMoney":
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney);
                    showList.Add(info);
                    break;
                case "Recharge_PersonalRealTime":
                    //个人实时充值
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalRealTime);
                    showList.Add(info);
                    break;
                case "Recharge_PersonalTransfer":
                    //个转账充值
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalTransfer);
                    showList.Add(info);
                    break;
                case "Recharge_BatchTransfer":
                    //批量转账充值
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.Recharge_BatchTransfer);
                    showList.Add(info);
                    break;
                case "Refund_PersonalCash":
                    //个人现金退款
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalCash);
                    info.cost = "-" + info.cost;
                    showList.Add(info);
                    break;
                case "Refund_CardPersonalRealTime":
                    //个人实时卡退款
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.Refund_CardPersonalRealTime);
                    info.cost = "-" + info.cost;
                    showList.Add(info);
                    break;
                case "Refund_PersonalTransfer":
                    //个人转账退款
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalTransfer);
                    showList.Add(info);
                    break;
                case "Refund_BatchTransfer":
                    //批量转账退款
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer);
                    showList.Add(info);
                    break;
            }
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 顯示列表
        /// </summary>
        private void ShowList()
        {
            List<ViewInfo> viewList = new List<ViewInfo>();

            if (_showList != null)
            {
                for (int index = (_PageIndex - 1) * _PageSize; index < _PageSize * _PageIndex; index++)
                {
                    if (index >= _showList.Count || index < 0)
                    {
                        break;
                    }

                    viewList.Add(_showList[index]);
                }
            }

            this.lvList.SetDataSource(viewList);

            this.lblPage.Text = this._PageIndex + "/" + this._MaxPage;
        }

        private void SetUpDownBtnStatus()
        {
            if (_PageIndex <= 1)
            {
                this.btnUp.Enabled = false;
            }
            else
            {
                this.btnUp.Enabled = true;
            }

            if (_PageIndex >= _MaxPage)
            {
                this.btnDown.Enabled = false;
            }
            else
            {
                this.btnDown.Enabled = true;
            }
        }

        /// <summary>
        /// 上一頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            this._PageIndex--;
            SetUpDownBtnStatus();
            ShowList();
        }
        /// <summary>
        /// 下一頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            this._PageIndex++;
            SetUpDownBtnStatus();
            ShowList();
        }
    }
}
