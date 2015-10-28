using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsUI.TQS.SystemForm;
using PaymentEquipment.Entity;
using BLL.IBLL.HHZX.UserCard;
using BLL.Factory.HHZX;
using Model.HHZX.UserCard;
using BLL.IBLL.HHZX.MealBooking;
using Model.HHZX.MealBooking;
using Model.IModel;
using Common;

namespace WindowsUI.TQS.UserCard
{
    public partial class frmPaymentUDMeal : BaseForm
    {
        private ConsumeCardInfo _cardInfo;

        private UserCardPair_ucp_Info _userInfo;

        private IUserCardPairBL _iucpBL;
        private IPaymentUDMealStateBL _ipumsBL;
        private IMealBookingHistoryBL _imbhBL;
        private string _strPwd;

        private List<SetMealList> _smlList = new List<SetMealList>();//顯示內容集合
        private int _PageIndex = 1;//當前頁號
        private int _PageSize = 28;//每頁內容條數
        private int _MaxPage = 1;//最大頁號

        public frmPaymentUDMeal(string strPwd)
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
            if (_ipumsBL == null)
            {
                _ipumsBL = MasterBLLFactory.GetBLL<IPaymentUDMealStateBL>(MasterBLLFactory.PaymentUDMealState);
            }
            if (_imbhBL == null)
            {
                _imbhBL = MasterBLLFactory.GetBLL<IMealBookingHistoryBL>(MasterBLLFactory.MealBookingHistory);
            }

            ReadCard();

            ShowInit();
        }

        private void ShowInit()
        {
            try
            {
                if (_cardInfo == null)
                {
                    return;
                }

                DateTime nowTime = System.DateTime.Now;

                DateTime StartTime;
                DateTime EndTime;

                for (DateTime dt = nowTime; ; dt = dt.AddDays(-1))
                {
                    if (dt.DayOfWeek.ToString().ToLower() == "monday")
                    {
                        StartTime = dt;
                        break;
                    }
                }

                for (DateTime dt = nowTime; ; dt = dt.AddDays(1))
                {
                    if (dt.DayOfWeek.ToString().ToLower() == "sunday")
                    {
                        EndTime = dt;
                        break;
                    }
                }

                this.dtpDateFrom.Value = StartTime;
                this.dtpDateTo.Value = EndTime;

                ShowRecord();
            }
            catch
            {

            }
        }

        private void ReadCard()
        {
            ClearControl();

            WaitForCardReader wfcrFrm = new WaitForCardReader(this._strPwd);
            if (wfcrFrm.ShowDialog() == DialogResult.OK)
            {
                _cardInfo = wfcrFrm.CardInfo;
                ShowCardMessage();
            }
            else
            {
                this.btnSearch.Enabled = false;
            }
        }

        private void ClearControl()
        {
            this.lblChaName.Text = "";
            this.lblCardNo.Text = "";
            this.lblRecordAmount.Text = "0";
            this.lblPage.Text = "0/0";
            this.flpMealList.Controls.Clear();
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
                    _userInfo = ucpInfo;

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

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            ClearControl();
            _smlList = new List<SetMealList>();
            ShowList();
            _PageIndex = 1;
            _MaxPage = 1;
            SetUpDownBtnStatus();

            ReadCard();
        }

        private void ShowRecord()
        {
            try
            {
                this.flpMealList.Visible = false;
                this.flpMealList.Controls.Clear();
                this.lblRecordAmount.Text = "";

                _smlList = new List<SetMealList>();

                DateTime startTime = DateTime.Parse(dtpDateFrom.Value.ToString("yyyy/MM/dd"));
                DateTime endTime = DateTime.Parse(dtpDateTo.Value.ToString("yyyy/MM/dd"));

                int lastIndex = 0;

                if (endTime >= startTime)
                {
                    System.TimeSpan ts = endTime.Subtract(startTime);//TimeSpan得到dt1和dt2的时间间隔
                    int countDays = ts.Days;//相隔天数
                    if (countDays > 60)
                    {
                        base.MessageDialog("提示", "最多只能查询前后60天的记录！");
                        startTime = startTime.AddDays(60);
                        this.dtpDateTo.Value = startTime;
                        return;
                    }


                    DateTime nowDate = DateTime.Parse(System.DateTime.Now.ToString("yyyy/MM/dd"));

                    if (startTime < nowDate)//如果開始時間是小于當前時間，則查詢定餐使用記錄
                    {
                        MealBookingHistory_mbh_Info mbhInfo = new MealBookingHistory_mbh_Info();
                        mbhInfo.mbh_cTargetID = _userInfo.ucp_cCUSID;
                        mbhInfo.StartTime = startTime;

                        if (endTime > nowDate)
                        {
                            mbhInfo.EndTime = nowDate;
                        }
                        else
                        {
                            mbhInfo.EndTime = endTime;
                        }

                        List<MealBookingHistory_mbh_Info> mbhList = _imbhBL.SearchRecords(mbhInfo);

                        if (mbhList != null && mbhList.Count > 0)
                        {
                            //補全一個星期
                            int weekIndex = GetWeekIndex(mbhList[0].mbh_dMealDate);

                            for (int index = 0; index < weekIndex - 1; index++)
                            {
                                SetMealList mealList = new SetMealList(null);
                                _smlList.Add(mealList);
                                //this.flpMealList.Controls.Add(mealList);
                            }

                            lastIndex = GetWeekIndex(mbhList[mbhList.Count - 1].mbh_dMealDate);//如果有定餐記錄，記下最后一日

                            for (DateTime dt = startTime; dt < nowDate; dt = dt.AddDays(1))
                            {
                                SetMealInfo mealInfo = new SetMealInfo();
                                mealInfo.times = dt;

                                bool isSet = false;

                                foreach (MealBookingHistory_mbh_Info info in mbhList)
                                {
                                    DateTime subDt = DateTime.Parse(info.mbh_dMealDate.ToString("yyyy/MM/dd"));
                                    if (subDt == dt)
                                    {
                                        if (info.mbh_cMealType == DefineConstantValue.MealType.Breakfast.ToString())
                                        {
                                            mealInfo.Breakfast = info.mbh_lIsSet;
                                            isSet = true;
                                        }
                                        else if (info.mbh_cMealType == DefineConstantValue.MealType.Lunch.ToString())
                                        {
                                            mealInfo.Lunch = info.mbh_lIsSet;
                                            isSet = true;
                                        }
                                        else if (info.mbh_cMealType == DefineConstantValue.MealType.Supper.ToString())
                                        {
                                            mealInfo.Dinner = info.mbh_lIsSet;
                                            isSet = true;
                                        }
                                    }
                                }

                                if (isSet == true)
                                {
                                    SetMealList mealList = new SetMealList(mealInfo);

                                    _smlList.Add(mealList);

                                    //this.flpMealList.Controls.Add(mealList);
                                }

                                isSet = false;
                            }
                        }
                    }

                    if (endTime >= nowDate)//如果結束日期大于當前日期，則查詢定餐設置記錄
                    {
                        PaymentUDMealState_pms_Info pmsInfo = new PaymentUDMealState_pms_Info();
                        pmsInfo.pms_cCardUserID = _userInfo.ucp_cCUSID;
                        pmsInfo.pms_cClassID = _userInfo.CardOwner.cus_cClassID;
                        pmsInfo.pms_cGradeID = _userInfo.CardOwner.ClassInfo.csm_cGDMID;

                        pmsInfo.TimeTo = dtpDateTo.Value;

                        if (startTime > nowDate)
                        {
                            pmsInfo.TimeFrom = startTime;
                        }
                        else
                        {
                            pmsInfo.TimeFrom = nowDate;
                        }

                        List<PaymentUDMealState_pms_Info> pmsList = _ipumsBL.SearchMealRecords(pmsInfo);

                        if (pmsList != null && pmsList.Count > 0)
                        {
                            ////補全一個星期
                            //int weekIndex = GetWeekIndex((DateTime)(pmsList[0].pms_dStartDate));

                            //if (lastIndex == 0)
                            //{
                            //    lastIndex = weekIndex - 1;
                            //}
                            //else
                            //{
                            //    lastIndex = 7 - lastIndex - weekIndex;
                            //}

                            //for (int index = 0; index < lastIndex; index++)
                            //{
                            //    SetMealList mealList = new SetMealList(null);
                            //    _smlList.Add(mealList);
                            //    //this.flpMealList.Controls.Add(mealList);
                            //}

                            this.lblRecordAmount.Text = pmsList.Count.ToString();

                            pmsList = pmsList.OrderBy(p => p.pms_dStartDate).ToList();

                            for (int index = 0; index < pmsList.Count; index++)
                            {
                                SetMealInfo mealInfo = new SetMealInfo();
                                mealInfo.times = (DateTime)pmsList[index].pms_dStartDate;
                                mealInfo.Breakfast = pmsList[index].pms_cBreakfast;
                                mealInfo.Lunch = pmsList[index].pms_cLunch;
                                mealInfo.Dinner = pmsList[index].pms_cDinner;

                                SetMealList mealList = new SetMealList(mealInfo);


                                _smlList.Add(mealList);

                                //this.flpMealList.Controls.Add(mealList);
                            }
                        }
                    }
                }
                else
                {
                    base.MessageDialog("提示", "结束时间不能小于开始时间！");
                }
            }
            catch
            {

            }
            finally
            {
                this.flpMealList.Visible = true;
                //計算最大頁數
                if (_smlList != null)
                {
                    _MaxPage = _smlList.Count / _PageSize;

                    if (_smlList.Count % _PageSize != 0)
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
            _smlList = new List<SetMealList>();
            ShowList();
            _PageIndex = 1;
            _MaxPage = 1;
            SetUpDownBtnStatus();

            ReadCard();

            ShowRecord();
        }

        /// <summary>
        /// 顯示列表
        /// </summary>
        private void ShowList()
        {
            this.flpMealList.Controls.Clear();

            if (_smlList != null)
            {
                for (int index = (_PageIndex - 1) * _PageSize; index < _PageSize * _PageIndex; index++)
                {
                    if (index >= _smlList.Count || index < 0)
                    {
                        break;
                    }

                    this.flpMealList.Controls.Add(_smlList[index]);
                }
            }

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

        private int GetWeekIndex(DateTime dt)
        {
            int index = 0;

            string dtStr = dt.DayOfWeek.ToString().ToLower();
            switch (dtStr)
            {
                case "monday":
                    index = 1;
                    break;
                case "tuesday":
                    index = 2;
                    break;
                case "wednesday":
                    index = 3;
                    break;
                case "thursday":
                    index = 4;
                    break;
                case "friday":
                    index = 5;
                    break;
                case "saturday":
                    index = 6;
                    break;
                case "sunday":
                    index = 7;
                    break;
            }

            return index;
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
