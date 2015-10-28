using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.MealBooking;
using BLL.IBLL.HHZX.MealBooking;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;

namespace WindowUI.HHZX.UserControls
{
    /// <summary>
    /// 学生每日定餐情况
    /// </summary>
    public partial class ucMealBookingDetail : UserControl
    {
        /// <summary>
        /// 当前查询对象
        /// </summary>
        public CardUserMaster_cus_Info UserInfo;

        private IMealBookingHistoryBL _IMealBookingHistoryBL;
        private IPaymentUDGeneralSettingBL _IPaymentUDGeneralSettingBL;
        private IPaymentUDMealStateBL _IPaymentUDMealStateBL;
        private ICardUserMasterBL _ICardUserMasterBL;
        /// <summary>
        /// 未设置定餐计划提示语
        /// </summary>
        private string _StrUnSetContent;

        public bool BreakfastPlanning;
        public bool LunchPlanning;
        public bool SupperPlanning;
        public List<MealBookingHistory_mbh_Info> ListUserOldPlanning;

        public string BreakfastDesc
        {
            get
            {
                return labBreakfastMB.Text;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    labBreakfastMB.Text = value;
                }
                else
                {
                    labBreakfastMB.Text = string.Empty;
                }
            }
        }

        public string LunchDesc
        {
            get
            {
                return labLunchMB.Text;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    labLunchMB.Text = value;
                }
                else
                {
                    labLunchMB.Text = string.Empty;
                }
            }
        }

        public string SupperDesc
        {
            get
            {
                return labSupperMB.Text;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    labSupperMB.Text = value;
                }
                else
                {
                    labSupperMB.Text = string.Empty;
                }
            }
        }

        public ucMealBookingDetail()
        {
            InitializeComponent();

            this._IMealBookingHistoryBL = MasterBLLFactory.GetBLL<IMealBookingHistoryBL>(MasterBLLFactory.MealBookingHistory);
            this._IPaymentUDGeneralSettingBL = MasterBLLFactory.GetBLL<IPaymentUDGeneralSettingBL>(MasterBLLFactory.PaymentUDGeneralSetting);
            this._IPaymentUDMealStateBL = MasterBLLFactory.GetBLL<IPaymentUDMealStateBL>(MasterBLLFactory.PaymentUDMealState);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);

            this._StrUnSetContent = "否(未设置)";
        }

        public void ShowData(CardUserMaster_cus_Info userInfo)
        {
            this.UserInfo = userInfo;
            if (userInfo == null)
            {
                labBreakfastMB.Text = "缺失";
                labLunchMB.Text = "缺失";
                labSupperMB.Text = "缺失";
                return;
            }
            BindMealBookingInfo();
        }

        /// <summary>
        /// 绑定定餐信息
        /// </summary>
        void BindMealBookingInfo()
        {
            //历史定餐登记记录
            List<MealBookingHistory_mbh_Info> listHistory = this._IMealBookingHistoryBL.SearchRecords(new MealBookingHistory_mbh_Info()
            {
                mbh_cTargetID = this.UserInfo.cus_cRecordID,
                mbh_dMealDate = DateTime.Now.Date
            });
            //listHistory = listHistory.Where(x => x.mbh_cTargetID == this.UserInfo.cus_cRecordID).ToList();

            List<MealBookingHistory_mbh_Info> listGeneralPlan = getlistMealBookingPlanning(this.UserInfo);
            this.ListUserOldPlanning = listGeneralPlan;

            MealBookingHistory_mbh_Info breakfastBookingInfo = listHistory.Find(x => x.mbh_cMealType == Common.DefineConstantValue.MealType.Breakfast.ToString());
            if (breakfastBookingInfo == null)
            {
                bool isSet = false;
                MealBookingHistory_mbh_Info breakfastGeneral = listGeneralPlan.Find(x => x.mbh_cMealType == Common.DefineConstantValue.MealType.Breakfast.ToString());
                if (breakfastGeneral != null)
                {
                    isSet = breakfastGeneral.mbh_lIsSet;
                    BreakfastPlanning = isSet;
                    labBreakfastMB.Text = isSet == true ? "是" : "否";
                }
                else
                {
                    labBreakfastMB.Text = this._StrUnSetContent;
                }
            }
            else
            {
                labBreakfastMB.Text = breakfastBookingInfo.mbh_lIsSet == true ? "是" : "否";
            }

            MealBookingHistory_mbh_Info lunchBookingInfo = listHistory.Find(x => x.mbh_cMealType == Common.DefineConstantValue.MealType.Lunch.ToString());
            if (lunchBookingInfo == null)
            {
                //bool isSet = GetMealBookingPlaning(Common.DefineConstantValue.MealType.Lunch.ToString());
                //labLunchMB.Text = isSet == true ? "是" : "否";

                bool isSet = false;
                MealBookingHistory_mbh_Info lunchGeneral = listGeneralPlan.Find(x => x.mbh_cMealType == Common.DefineConstantValue.MealType.Lunch.ToString());
                if (lunchGeneral != null)
                {
                    isSet = lunchGeneral.mbh_lIsSet;
                    LunchPlanning = isSet;
                    labLunchMB.Text = isSet == true ? "是" : "否";
                }
                else
                {
                    labLunchMB.Text = this._StrUnSetContent;
                }
            }
            else
            {
                labLunchMB.Text = lunchBookingInfo.mbh_lIsSet == true ? "是" : "否";
            }

            MealBookingHistory_mbh_Info supperBookingInfo = listHistory.Find(x => x.mbh_cMealType == Common.DefineConstantValue.MealType.Supper.ToString());
            if (supperBookingInfo == null)
            {
                bool isSet = false;
                MealBookingHistory_mbh_Info supperGeneral = listGeneralPlan.Find(x => x.mbh_cMealType == Common.DefineConstantValue.MealType.Supper.ToString());
                if (supperGeneral != null)
                {
                    isSet = supperGeneral.mbh_lIsSet;
                    SupperPlanning = isSet;
                    labSupperMB.Text = isSet == true ? "是" : "否";
                }
                else
                {
                    labSupperMB.Text = this._StrUnSetContent;
                }
            }
            else
            {
                labSupperMB.Text = supperBookingInfo.mbh_lIsSet == true ? "是" : "否";
            }
        }

        /// <summary>
        /// 获取当前用户计划定餐设置
        /// </summary>
        /// <param name="targetUser">用户信息</param>
        /// <returns></returns>
        public List<MealBookingHistory_mbh_Info> getlistMealBookingPlanning(CardUserMaster_cus_Info targetUser)
        {
            try
            {
                List<MealBookingHistory_mbh_Info> listMealPlan = new List<MealBookingHistory_mbh_Info>();

                //获取默认定餐设置
                List<PaymentUDGeneralSetting_pus_Info> listGeneralSettings = this._IPaymentUDGeneralSettingBL.SearchRecords(new PaymentUDGeneralSetting_pus_Info() { pus_iWeek = (int)DateTime.Now.DayOfWeek });

                //获取自定义定餐设置
                List<PaymentUDMealState_pms_Info> listCustomSettings = this._IPaymentUDMealStateBL.SearchRecords(new PaymentUDMealState_pms_Info()
                {
                    //pms_dStartDate = DateTime.Now.Date, 
                    //pms_dEndDate = DateTime.Now.Date 
                    TimeFrom = DateTime.Now.Date,
                    TimeTo = DateTime.Now.Date
                });

                foreach (Common.DefineConstantValue.MealType mealType in Enum.GetValues(typeof(Common.DefineConstantValue.MealType)))
                {
                    if (mealType == Common.DefineConstantValue.MealType.UnKnown)
                    {
                        continue;
                    }
                    MealBookingHistory_mbh_Info history = new MealBookingHistory_mbh_Info();
                    history.mbh_cMealType = mealType.ToString();

                    #region 个人--》班级--》年级

                    //学生自定义
                    PaymentUDMealState_pms_Info stuCustom = listCustomSettings.Find(x => x.pms_cCardUserID == targetUser.cus_cRecordID);
                    if (stuCustom == null)
                    {
                        //学生默认
                        PaymentUDGeneralSetting_pus_Info stuDefault = listGeneralSettings.Find(x => x.pus_cCardUserID == targetUser.cus_cRecordID);
                        if (stuDefault == null)
                        {
                            #region 班级--》年级

                            //班级自定义
                            stuCustom = listCustomSettings.Find(x => x.pms_cClassID == targetUser.cus_cClassID);
                            if (stuCustom == null)
                            {
                                //班级默认
                                stuDefault = listGeneralSettings.Find(x => x.pus_cClassID == targetUser.cus_cClassID);
                                if (stuDefault == null)
                                {
                                    if (targetUser.ClassInfo != null && targetUser.ClassInfo.GradeInfo != null)
                                    {
                                        #region 年级

                                        //年级自定义
                                        stuCustom = listCustomSettings.Find(x => x.pms_cGradeID == targetUser.ClassInfo.GradeInfo.gdm_cRecordID);
                                        if (stuCustom == null)
                                        {
                                            //年级默认
                                            stuDefault = listGeneralSettings.Find(x => x.pus_cGradeID == targetUser.ClassInfo.GradeInfo.gdm_cRecordID);
                                            if (stuDefault != null)
                                            {
                                                history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.GradeDefault.ToString();
                                                history.mbh_lIsSet = GetGeneralSettings(mealType.ToString(), stuDefault);
                                                listMealPlan.Add(history);
                                                continue;
                                            }
                                            else
                                            {
                                                //缺失年级默认设置时，默认不定餐
                                                history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.Unknown.ToString();
                                                history.mbh_lIsSet = false;
                                                listMealPlan.Add(history);
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.GradeCustom.ToString();
                                            history.mbh_lIsSet = GetCustomMealSettings(mealType.ToString(), stuCustom);
                                            listMealPlan.Add(history);
                                            continue;
                                        }

                                        #endregion
                                    }
                                    else
                                    {
                                        //缺失年级信息时，默认不定餐
                                        history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.Unknown.ToString();
                                        history.mbh_lIsSet = false;
                                        listMealPlan.Add(history);
                                        continue;
                                    }
                                }
                                else
                                {
                                    history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.ClassDefault.ToString();
                                    history.mbh_lIsSet = GetGeneralSettings(mealType.ToString(), stuDefault);
                                    if (history.mbh_lIsSet)
                                    {
                                        CheckClassGradeIsSet(targetUser, history, listGeneralSettings, listCustomSettings, mealType.ToString());
                                    }
                                    listMealPlan.Add(history);
                                    continue;
                                }
                            }
                            else
                            {
                                history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.ClassCustom.ToString();
                                history.mbh_lIsSet = GetCustomMealSettings(mealType.ToString(), stuCustom);
                                if (history.mbh_lIsSet)
                                {
                                    CheckClassGradeIsSet(targetUser, history, listGeneralSettings, listCustomSettings, mealType.ToString());
                                }
                                listMealPlan.Add(history);
                                continue;
                            }

                            #endregion
                        }
                        else
                        {
                            history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.StudentDefault.ToString();
                            history.mbh_lIsSet = GetGeneralSettings(mealType.ToString(), stuDefault);
                            if (history.mbh_lIsSet)
                            {
                                CheckClassGradeIsSet(targetUser, history, listGeneralSettings, listCustomSettings, mealType.ToString());
                            }
                            listMealPlan.Add(history);
                            continue;
                        }
                    }
                    else
                    {
                        history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.StudentCustom.ToString();
                        history.mbh_lIsSet = GetCustomMealSettings(mealType.ToString(), stuCustom);
                        if (history.mbh_lIsSet)
                        {
                            CheckClassGradeIsSet(targetUser, history, listGeneralSettings, listCustomSettings, mealType.ToString());
                        }
                        listMealPlan.Add(history);
                        continue;
                    }

                    #endregion
                }

                return listMealPlan;
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// 扩展检查
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="targetInfo"></param>
        /// <param name="listGeneralSettings"></param>
        /// <param name="listCustomSettings"></param>
        void CheckClassGradeIsSet(CardUserMaster_cus_Info userInfo, MealBookingHistory_mbh_Info targetInfo, List<PaymentUDGeneralSetting_pus_Info> listGeneralSettings, List<PaymentUDMealState_pms_Info> listCustomSettings, string strMealType)
        {
            MealBookingHistory_mbh_Info rvHistoryInfo = new MealBookingHistory_mbh_Info();
            if (targetInfo.mbh_lIsSet)
            {
                if (userInfo.ClassInfo != null)
                {
                    //先检查年级是否停餐，默认+自定义
                    //年级自定义
                    PaymentUDMealState_pms_Info stuCustom = listCustomSettings.Find(x => x.pms_cGradeID == userInfo.ClassInfo.GradeInfo.gdm_cRecordID);
                    if (stuCustom != null)
                    {
                        //有年级自定义
                        bool setInfo = GetCustomMealSettings(strMealType, stuCustom);
                        if (!setInfo)
                        {
                            targetInfo.mbh_lIsSet = setInfo;
                            targetInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.GradeCustom.ToString();
                            return;
                        }
                    }
                    else
                    {
                        PaymentUDGeneralSetting_pus_Info stuDefault = listGeneralSettings.Find(x => x.pus_cGradeID == userInfo.ClassInfo.GradeInfo.gdm_cRecordID);
                        if (stuDefault != null)
                        {
                            //无年级自定义，有年级默认
                            bool setInfo = GetGeneralSettings(strMealType, stuDefault);
                            if (!setInfo)
                            {
                                targetInfo.mbh_lIsSet = setInfo;
                                targetInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.GradeDefault.ToString();
                                return;
                            }
                        }
                    }

                    stuCustom = listCustomSettings.Find(x => x.pms_cClassID == userInfo.ClassInfo.csm_cRecordID);
                    if (stuCustom != null)
                    {
                        //无年级自定义、默认，有班级自定义
                        bool setInfo = GetCustomMealSettings(strMealType, stuCustom);
                        if (!setInfo)
                        {
                            targetInfo.mbh_lIsSet = setInfo;
                            targetInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.ClassCustom.ToString();
                            return;
                        }
                    }
                    else
                    {
                        PaymentUDGeneralSetting_pus_Info stuDefault = listGeneralSettings.Find(x => x.pus_cClassID == userInfo.ClassInfo.csm_cRecordID);
                        if (stuDefault != null)
                        {
                            //无年级自定义、默认，无班级自定义，有班级默认
                            bool setInfo = GetGeneralSettings(strMealType, stuDefault);
                            if (!setInfo)
                            {
                                targetInfo.mbh_lIsSet = setInfo;
                                targetInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.ClassDefault.ToString();
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取当餐停餐信息
        /// </summary>
        /// <param name="strMealType">定餐类型</param>
        /// <returns></returns>
        bool GetMealBookingPlaning(string strMealType)
        {
            try
            {

                //获取默认定餐设置
                List<PaymentUDGeneralSetting_pus_Info> listGeneralSettings = this._IPaymentUDGeneralSettingBL.SearchRecords(new PaymentUDGeneralSetting_pus_Info() { pus_iWeek = (int)DateTime.Now.DayOfWeek });

                //获取自定义定餐设置
                List<PaymentUDMealState_pms_Info> listCustomSettings = this._IPaymentUDMealStateBL.SearchMealRecords(new PaymentUDMealState_pms_Info() { pms_dStartDate = DateTime.Now.Date, pms_dEndDate = DateTime.Now.Date });

                #region 个人--》班级--》年级

                //学生自定义
                PaymentUDMealState_pms_Info stuCustom = listCustomSettings.Find(x => x.pms_cCardUserID == UserInfo.cus_cRecordID);
                if (stuCustom == null)
                {
                    //学生默认
                    PaymentUDGeneralSetting_pus_Info stuDefault = listGeneralSettings.Find(x => x.pus_cCardUserID == UserInfo.cus_cRecordID);
                    if (stuDefault == null)
                    {
                        #region 班级--》年级

                        //班级自定义
                        stuCustom = listCustomSettings.Find(x => x.pms_cClassID == UserInfo.cus_cClassID);
                        if (stuCustom == null)
                        {
                            //班级默认
                            stuDefault = listGeneralSettings.Find(x => x.pus_cClassID == UserInfo.cus_cClassID);
                            if (stuDefault == null)
                            {
                                if (UserInfo.ClassInfo != null && UserInfo.ClassInfo.GradeInfo != null)
                                {
                                    #region 年级

                                    //年级自定义
                                    stuCustom = listCustomSettings.Find(x => x.pms_cGradeID == UserInfo.ClassInfo.GradeInfo.gdm_cRecordID);
                                    if (stuCustom == null)
                                    {
                                        //年级默认
                                        stuDefault = listGeneralSettings.Find(x => x.pus_cGradeID == UserInfo.ClassInfo.GradeInfo.gdm_cRecordID);
                                        if (stuDefault == null)
                                        {
                                            return GetGeneralSettings(strMealType, stuDefault);
                                        }
                                        else
                                        {
                                            //缺失年级默认设置时，默认不定餐
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return GetCustomMealSettings(strMealType, stuCustom);
                                    }

                                    #endregion
                                }
                                else
                                {
                                    //缺失年级信息时，默认不定餐
                                    return false;
                                }
                            }
                            else
                            {
                                return GetGeneralSettings(strMealType, stuDefault);
                            }
                        }
                        else
                        {
                            return GetCustomMealSettings(strMealType, stuCustom);
                        }

                        #endregion
                    }
                    else
                    {
                        return GetGeneralSettings(strMealType, stuDefault);
                    }
                }
                else
                {
                    return GetCustomMealSettings(strMealType, stuCustom);
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取自定义定餐指定餐类型的定餐情况
        /// </summary>
        /// <param name="strMealType"></param>
        /// <param name="customMeal"></param>
        /// <returns></returns>
        bool GetCustomMealSettings(string strMealType, PaymentUDMealState_pms_Info customMeal)
        {
            if (customMeal == null)
            {
                return false;
            }
            Common.DefineConstantValue.MealType mealType = GetMealType(strMealType);
            bool? res = false;
            switch (mealType)
            {
                case Common.DefineConstantValue.MealType.UnKnown:
                    break;
                case Common.DefineConstantValue.MealType.Breakfast:
                    res = customMeal.pms_cBreakfast;
                    if (res != null)
                        res = customMeal.pms_cBreakfast.Value;
                    else
                        res = true;
                    break;
                case Common.DefineConstantValue.MealType.Lunch:
                    res = customMeal.pms_cLunch;
                    if (res != null)
                        res = customMeal.pms_cLunch.Value;
                    else
                        res = true;
                    break;
                case Common.DefineConstantValue.MealType.Supper:
                    res = customMeal.pms_cDinner;
                    if (res != null)
                        res = customMeal.pms_cDinner.Value;
                    else
                        res = true;
                    break;
                default:
                    break;
            }
            return res.Value;
        }

        /// <summary>
        /// 获取默认定餐指定餐类型的定餐情况
        /// </summary>
        /// <param name="strMealType"></param>
        /// <param name="generalMeal"></param>
        /// <returns></returns>
        bool GetGeneralSettings(string strMealType, PaymentUDGeneralSetting_pus_Info generalMeal)
        {
            if (generalMeal == null)
            {
                return false;
            }

            Common.DefineConstantValue.MealType mealType = GetMealType(strMealType);
            bool? res = false;
            switch (mealType)
            {
                case Common.DefineConstantValue.MealType.UnKnown:
                    break;
                case Common.DefineConstantValue.MealType.Breakfast:
                    res = generalMeal.pus_cBreakfast;
                    if (res != null)
                        res = generalMeal.pus_cBreakfast.Value;
                    else
                        res = true;
                    break;
                case Common.DefineConstantValue.MealType.Lunch:
                    res = generalMeal.pus_cLunch;
                    if (res != null)
                        res = generalMeal.pus_cLunch.Value;
                    else
                        res = true;
                    break;
                case Common.DefineConstantValue.MealType.Supper:
                    res = generalMeal.pus_cDinner;
                    if (res != null)
                        res = generalMeal.pus_cDinner.Value;
                    else
                        res = true;
                    break;
                default:
                    break;
            }
            return res.Value;
        }

        /// <summary>
        /// 获取当前用餐类型
        /// </summary>
        /// <param name="strMealType"></param>
        /// <returns></returns>
        Common.DefineConstantValue.MealType GetMealType(string strMealType)
        {
            if (strMealType == Common.DefineConstantValue.MealType.Breakfast.ToString())
            {
                return Common.DefineConstantValue.MealType.Breakfast;
            }
            else if (strMealType == Common.DefineConstantValue.MealType.Lunch.ToString())
            {
                return Common.DefineConstantValue.MealType.Lunch;
            }
            else if (strMealType == Common.DefineConstantValue.MealType.Supper.ToString())
            {
                return Common.DefineConstantValue.MealType.Supper;
            }
            else
            {
                return Common.DefineConstantValue.MealType.UnKnown;
            }
        }
    }
}
