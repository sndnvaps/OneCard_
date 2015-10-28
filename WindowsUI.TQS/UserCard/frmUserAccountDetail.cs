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
    public partial class frmUserAccountDetail : BaseForm
    {
        private ConsumeCardInfo _cardInfo;

        private Guid _userID;

        private IUserCardPairBL _iucpBL;
        private ICardUserAccountDetailBL _icuadBL;
        private ICardUserAccountBL _icuaBL;
        private IPreConsumeRecordBL _ipcrBL;
        private IConsumeRecordBL _IConsumeRecordBL;

        private List<ViewInfo> _showList = new List<ViewInfo>();

        private int _PageIndex = 1;//當前頁號
        private int _PageSize = 25;//每頁內容條數
        private int _MaxPage = 1;//最大頁號

        private string _strPwd;

        public frmUserAccountDetail(string strPwd)
        {
            InitializeComponent();
            //ReadCard();
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
            if (_ipcrBL == null)
            {
                _ipcrBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            }
            if (_IConsumeRecordBL == null)
            {
                _IConsumeRecordBL = MasterBLLFactory.GetBLL<IConsumeRecordBL>(MasterBLLFactory.ConsumeRecord);
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
            public string times { get; set; }//结算时间
            public string type { get; set; }//消费类型
            public string cost { get; set; }//金额
            public string mealTime { get; set; }//定餐时间
            public string CostType { get; set; }//扣费类别
        }

        /// <summary>
        /// 显示查询结果
        /// </summary>
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
                    base.MessageDialog("提示", "开始时间要小于结束时间！");
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
                        vi.times = cuadInfo.cuad_dOptTime.ToString("yyyy/MM/dd");
                        vi.cost = cuadInfo.cuad_fFlowMoney.ToString();
                        vi.type = cuadInfo.cuad_cFlowType;

                        try
                        {
                            //PreConsumeRecord_pcs_Info pcsinfo = new PreConsumeRecord_pcs_Info();
                            //pcsinfo.pcs_cRecordID = (Guid)cuadInfo.cuad_cConsumeID;
                            //pcsinfo = _ipcrBL.DisplayRecord(pcsinfo);

                            //if (pcsinfo != null)
                            //{
                            //    vi.mealTime = pcsinfo.pcs_dConsumeDate.ToString("yyyy/MM/dd HH:mm:ss");
                            //}
                            //else
                            //{
                            //    vi.mealTime = cuadInfo.cuad_dOptTime.ToString("yyyy/MM/dd HH:mm:ss");
                            //}

                            ConsumeRecord_csr_Info csrInfo = new ConsumeRecord_csr_Info();
                            csrInfo.csr_cRecordID = (Guid)cuadInfo.cuad_cConsumeID;
                            csrInfo = _IConsumeRecordBL.DisplayRecord(csrInfo);
                            if (csrInfo != null)
                            {
                                vi.mealTime = csrInfo.csr_dConsumeDate.ToString("yyyy/MM/dd HH:mm:ss");
                            }
                            else
                            {
                                PreConsumeRecord_pcs_Info pcsinfo = new PreConsumeRecord_pcs_Info();
                                pcsinfo.pcs_cRecordID = (Guid)cuadInfo.cuad_cConsumeID;
                                pcsinfo = _ipcrBL.DisplayRecord(pcsinfo);

                                if (pcsinfo != null)
                                {
                                    vi.mealTime = pcsinfo.pcs_dConsumeDate.ToString("yyyy/MM/dd HH:mm:ss");
                                }
                                else
                                {
                                    vi.mealTime = cuadInfo.cuad_dOptTime.ToString("yyyy/MM/dd HH:mm:ss");
                                }
                            }
                        }
                        catch
                        {

                        }
                        if (cuadInfo.MacNo != null)
                        {
                            vi.CostType = cuadInfo.MacNo.ToString() + "号机";
                        }
                        else
                        {
                            vi.CostType = "系统补扣";
                        }

                        SetShowViewInfo(vi, _showList);
                        //_showList.Add(vi);

                        rowNo = _showList.Count + 1;
                    }
                }

                if (_showList.Count == 0)
                {
                    if (startTime == endTime && startTime == DateTime.Parse(System.DateTime.Now.ToString("yyyy/MM/dd")))
                    {
                        base.MessageDialog("提示", "今天内无消费记录！");
                    }
                    else
                    {
                        base.MessageDialog("提示", "查找时间内无消费记录！");
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
                case "NewCardCost":
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.NewCardCost);
                    showList.Add(info);
                    break;
                case "ReplaceCardCost":
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.ReplaceCardCost);
                    showList.Add(info);
                    break;
                //case "AdvanceMealCost":
                //    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost);
                //    showList.Add(info);
                //    break;
                case "SetMealCost":
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.SetMealCost);
                    showList.Add(info);
                    break;
                case "FreeMealCost":
                    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.FreeMealCost);
                    showList.Add(info);
                    break;
                //case "PreCostRecharge":
                //    info.type = DefineConstantValue.GetMoneyFlowDesc(DefineConstantValue.ConsumeMoneyFlowType.PreCostRecharge);
                //    showList.Add(info);
                //    break;
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
                _showList = _showList.OrderByDescending(x => x.mealTime).ToList();

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
