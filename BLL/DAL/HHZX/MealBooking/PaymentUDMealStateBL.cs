using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.MealBooking;
using Model.IModel;
using Model.General;
using DAL.IDAL.HHZX.MealBooking;
using DAL.Factory.HHZX;
using Model.HHZX.MealBooking;
using BLL.Factory.HHZX;

namespace BLL.DAL.HHZX.MealBooking
{
    public class PaymentUDMealStateBL : IPaymentUDMealStateBL
    {
        IPaymentUDMealStateDA _paymentUMealStateDA;

        private IPaymentUDGeneralSettingBL _ipugsBL;
        private IPaymentUDMealStateBL _ipumsBL;


        public PaymentUDMealStateBL()
        {
            this._paymentUMealStateDA = MasterDAFactory.GetDAL<IPaymentUDMealStateDA>(MasterDAFactory.PaymentUDMealState);
        }

        #region IMainBL Members

        public PaymentUDMealState_pms_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                return this._paymentUMealStateDA.DisplayRecord(itemEntity);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<PaymentUDMealState_pms_Info> SearchRecords(IModelObject itemEntity)
        {
            List<PaymentUDMealState_pms_Info> searchData = null;
            try
            {
                searchData = this._paymentUMealStateDA.SearchRecords(itemEntity);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return searchData;
        }

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            PaymentUDMealState_pms_Info objInfo = itemEntity as PaymentUDMealState_pms_Info;

            objInfo.pms_dLastDate = DateTime.Now;

            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:

                        objInfo.pms_cRecordID = Guid.NewGuid();
                        objInfo.pms_dAddDate = DateTime.Now;

                        returnInfo = this._paymentUMealStateDA.InsertRecord(objInfo);

                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:

                        returnInfo = this._paymentUMealStateDA.UpdateRecord(objInfo);

                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:

                        returnInfo = this._paymentUMealStateDA.DeleteRecord(objInfo);

                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_ReaOnly:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return returnInfo;
        }

        #endregion

        #region IPaymentUDMealStateBL 成员

        public List<PaymentUDMealState_pms_Info> SearchMealRecords(IModelObject itemEntity)
        {
            List<PaymentUDMealState_pms_Info> returnList = new List<PaymentUDMealState_pms_Info>();

            try
            {
                _ipugsBL = MasterBLLFactory.GetBLL<IPaymentUDGeneralSettingBL>(MasterBLLFactory.PaymentUDGeneralSetting);
                _ipumsBL = MasterBLLFactory.GetBLL<IPaymentUDMealStateBL>(MasterBLLFactory.PaymentUDMealState);

                PaymentUDMealState_pms_Info searchInfo = itemEntity as PaymentUDMealState_pms_Info;

                DateTime startTime = DateTime.Parse(((DateTime)(searchInfo.TimeFrom)).ToString("yyy/MM/dd"));
                DateTime endTime = DateTime.Parse(((DateTime)(searchInfo.TimeTo)).ToString("yyyy/MM/dd"));

                PaymentUDGeneralSetting_pus_Info pusInfo = new PaymentUDGeneralSetting_pus_Info();
                pusInfo.pus_cCardUserID = searchInfo.pms_cCardUserID;

                List<PaymentUDGeneralSetting_pus_Info> userList_pus = _ipugsBL.SearchRecords(pusInfo);//用戶常規設置

                pusInfo.pus_cCardUserID = null;
                pusInfo.pus_cClassID = searchInfo.pms_cClassID;
                List<PaymentUDGeneralSetting_pus_Info> classList_pus = _ipugsBL.SearchRecords(pusInfo);//班級常規設置

                pusInfo.pus_cClassID = null;
                pusInfo.pus_cGradeID = searchInfo.pms_cGradeID;
                List<PaymentUDGeneralSetting_pus_Info> gradeList_pus = _ipugsBL.SearchRecords(pusInfo);//年級常規設置


                PaymentUDMealState_pms_Info pmsInfo = new PaymentUDMealState_pms_Info();
                pmsInfo.TimeFrom = startTime;
                pmsInfo.TimeTo = endTime;

                pmsInfo.pms_cCardUserID = searchInfo.pms_cCardUserID;
                List<PaymentUDMealState_pms_Info> userList_pms = _ipumsBL.SearchRecords(pmsInfo);//用戶自定義設置

                pmsInfo.pms_cCardUserID = null;
                pmsInfo.pms_cClassID = searchInfo.pms_cClassID;
                List<PaymentUDMealState_pms_Info> classList_pms = _ipumsBL.SearchRecords(pmsInfo);//班級自定義設置

                pmsInfo.pms_cClassID = null;
                pmsInfo.pms_cGradeID = searchInfo.pms_cGradeID;
                List<PaymentUDMealState_pms_Info> gradeList_pms = _ipumsBL.SearchRecords(pmsInfo);//年級自定義設置


                for (DateTime dt = startTime; dt <= endTime; dt = dt.AddDays(1))
                {
                    PaymentUDMealState_pms_Info pmsInfos = new PaymentUDMealState_pms_Info();
                    pmsInfos.pms_dStartDate = dt;
                    pmsInfos.pms_dEndDate = dt;

                    bool? user;
                    bool? clas;
                    bool? grade;
                    bool? zduser;
                    bool? zdclas;
                    bool? zdgrade;

                     user=GetStateStatus(0, dt, userList_pms);
                     clas=GetStateStatus(0, dt, classList_pms);
                     grade=GetStateStatus(0, dt, gradeList_pms);
                     zduser=GetSettingStatus(0, GetWeeks(dt), userList_pus);
                     zdclas=GetSettingStatus(0, GetWeeks(dt), classList_pus);
                     zdgrade=GetSettingStatus(0, GetWeeks(dt), gradeList_pus);

                     pmsInfos.pms_cBreakfast = (user != null ? user : zduser != null ? zduser : true) &
                         (clas != null ? clas : zdclas != null ? zdclas : true) &
                         (grade != null ? grade : zdgrade != null ? zdgrade : true);

                     user = GetStateStatus(1, dt, userList_pms);
                     clas = GetStateStatus(1, dt, classList_pms);
                     grade = GetStateStatus(1, dt, gradeList_pms);
                     zduser = GetSettingStatus(1, GetWeeks(dt), userList_pus);
                     zdclas = GetSettingStatus(1, GetWeeks(dt), classList_pus);
                     zdgrade = GetSettingStatus(1, GetWeeks(dt), gradeList_pus);

                     pmsInfos.pms_cLunch = (user != null ? user : zduser != null ? zduser : true) &
                         (clas != null ? clas : zdclas != null ? zdclas : true) &
                         (grade != null ? grade : zdgrade != null ? zdgrade : true);

                     user = GetStateStatus(2, dt, userList_pms);
                     clas = GetStateStatus(2, dt, classList_pms);
                     grade = GetStateStatus(2, dt, gradeList_pms);
                     zduser = GetSettingStatus(2, GetWeeks(dt), userList_pus);
                     zdclas = GetSettingStatus(2, GetWeeks(dt), classList_pus);
                     zdgrade = GetSettingStatus(2, GetWeeks(dt), gradeList_pus);

                     pmsInfos.pms_cDinner = (user != null ? user : zduser != null ? zduser : true )&
                         (clas != null ? clas : zdclas != null ? zdclas : true )&
                         (grade != null ? grade : zdgrade != null ? zdgrade : true);

                    //pmsInfos.pms_cBreakfast = GetStateStatus(0, dt, userList_pms) & GetStateStatus(0, dt, classList_pms) & GetStateStatus(0, dt, gradeList_pms) & GetSettingStatus(0, GetWeeks(dt), userList_pus) & GetSettingStatus(0, GetWeeks(dt), classList_pus) & GetSettingStatus(0, GetWeeks(dt), gradeList_pus);

                    //pmsInfos.pms_cLunch = GetStateStatus(1, dt, userList_pms) & GetStateStatus(1, dt, classList_pms) & GetStateStatus(1, dt, gradeList_pms) & GetSettingStatus(1, GetWeeks(dt), userList_pus) & GetSettingStatus(1, GetWeeks(dt), classList_pus) & GetSettingStatus(1, GetWeeks(dt), gradeList_pus);

                    //pmsInfos.pms_cDinner = GetStateStatus(2, dt, userList_pms) & GetStateStatus(2, dt, classList_pms) & GetStateStatus(2, dt, gradeList_pms) & GetSettingStatus(2, GetWeeks(dt), userList_pus) & GetSettingStatus(2, GetWeeks(dt), classList_pus) & GetSettingStatus(2, GetWeeks(dt), gradeList_pus);

                    //bool? zdBreakfast = GetSettingStatus(0, GetWeeks(dt), userList_pus, classList_pus, gradeList_pus);
                    //bool? zdLunch = GetSettingStatus(1, GetWeeks(dt), userList_pus, classList_pus, gradeList_pus);
                    //bool? zdDinner = GetSettingStatus(2, GetWeeks(dt), userList_pus, classList_pus,
//gradeList_pus);
                    //bool? Breakfast = GetStateStatus(0, dt, userList_pms, classList_pms, gradeList_pms);
                    //bool? Lunch = GetStateStatus(1, dt, userList_pms, classList_pms, gradeList_pms);
                    //bool? Dinner = GetStateStatus(2, dt, userList_pms, classList_pms, gradeList_pms);

                    //bool? zdBreakfast = GetSettingStatus(0, GetWeeks(dt), userList_pus, classList_pus, gradeList_pus);
                    //bool? zdLunch = GetSettingStatus(1, GetWeeks(dt), userList_pus, classList_pus, gradeList_pus);
                    //bool? zdDinner = GetSettingStatus(2, GetWeeks(dt), userList_pus, classList_pus, gradeList_pus);

                    //if (Breakfast != null)
                    //{
                    //    if (zdBreakfast != null)
                    //    {
                    //        if (!(bool)Breakfast)
                    //        {
                    //            pmsInfos.pms_cBreakfast = Breakfast;
                    //        }
                    //        else 
                    //        {
                    //            pmsInfos.pms_cBreakfast = zdBreakfast & Breakfast;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        pmsInfos.pms_cBreakfast = Breakfast;
                    //    }
                    //}
                    //else
                    //{
                    //    pmsInfos.pms_cBreakfast = zdBreakfast;
                    //}

                    //if (Lunch != null)
                    //{
                    //    if (zdLunch != null)
                    //    {
                    //        if (!(bool)Lunch)
                    //        {
                    //            pmsInfos.pms_cLunch = Lunch;
                    //        }
                    //        else
                    //        {
                    //            pmsInfos.pms_cLunch = zdLunch & Lunch;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        pmsInfos.pms_cLunch = Lunch;
                    //    }
                        
                    //}
                    //else
                    //{
                    //    pmsInfos.pms_cLunch = zdLunch;
                    //}

                    //if (Dinner != null)
                    //{
                    //    if (zdDinner != null)
                    //    {
                    //        if (!(bool)Dinner)
                    //        {
                    //            pmsInfos.pms_cDinner = Dinner;
                    //        }
                    //        else
                    //        {
                    //            pmsInfos.pms_cDinner = zdDinner & Dinner;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        pmsInfos.pms_cDinner = Dinner;
                    //    }
                        
                    //}
                    //else
                    //{
                    //    pmsInfos.pms_cDinner = zdDinner;
                    //}

                    returnList.Add(pmsInfos);
                }

            }
            catch
            {

            }

            return returnList;
        }

        /// <summary>
        /// 返回自定義設置內容
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dt"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool? GetStateStatus(int type, DateTime dt, List<PaymentUDMealState_pms_Info> list)
        {
            PaymentUDMealState_pms_Info pmsInfo;

            bool? isEit = null;

            if (list != null && list.Count > 0)//查用戶
            {
                for (int index = 0; index < list.Count; index++)
                {
                    pmsInfo = list[index] as PaymentUDMealState_pms_Info;

                    DateTime startDate = DateTime.Parse(((DateTime)pmsInfo.pms_dStartDate).ToString("yyyy/MM/dd"));
                    DateTime endDate = DateTime.Parse(((DateTime)pmsInfo.pms_dEndDate).ToString("yyyy/MM/dd"));

                    if (startDate <= dt && endDate >= dt)
                    {
                        switch (type)
                        {
                            case 0:
                                isEit = pmsInfo.pms_cBreakfast;
                                // return pmsInfo.pms_cBreakfast;
                                break;
                            case 1:
                                isEit = pmsInfo.pms_cLunch;
                                //return pmsInfo.pms_cLunch;
                                break;
                            case 2:
                                isEit = pmsInfo.pms_cDinner;
                                // return pmsInfo.pms_cDinner;
                                break;
                        }

                        continue;
                    }
                }
            }

            //if (isEit == null)
            //{
            //    return true;
            //}
            //else//沒設置當定餐
            //{
            //    return (bool)isEit;
            //}

            return isEit;
        }

        /// <summary>
        /// 返回默認設置
        /// </summary>
        /// <param name="type"></param>
        /// <param name="weeks"></param>
        /// <param name="userList_pus"></param>
        /// <param name="classList_pus"></param>
        /// <param name="gradeList_pus"></param>
        /// <returns></returns>
        private bool? GetSettingStatus(int type, int weeks, List<PaymentUDGeneralSetting_pus_Info> List)
        {
            PaymentUDGeneralSetting_pus_Info pusInfo;

            bool? isEit = null;

            if (List != null && List.Count > 0)
            {
                for (int index = 0; index < List.Count; index++)
                {
                    pusInfo = List[index] as PaymentUDGeneralSetting_pus_Info;

                    if (pusInfo.pus_iWeek == weeks)
                    {
                        switch (type)
                        {
                            case 0:
                                isEit = pusInfo.pus_cBreakfast;
                                //return pusInfo.pus_cBreakfast;
                                break;
                            case 1:
                                isEit = pusInfo.pus_cLunch;
                                //return pusInfo.pus_cLunch;
                                break;
                            case 2:
                                isEit = pusInfo.pus_cDinner;
                                //return pusInfo.pus_cDinner;
                                break;
                        }
                    }
                }
            }

            //if (isEit == null)
            //{
            //    return true;
            //}
            //else//沒設置當定餐
            //{
            //    return (bool)isEit;
            //}

            return isEit;
        }



        /// <summary>
        /// 返回自定義設置內容
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dt"></param>
        /// <param name="userList_pms"></param>
        /// <param name="classList_pms"></param>
        /// <param name="gradeList_pms"></param>
        /// <returns></returns>
        private bool? GetStateStatus(int type, DateTime dt, List<PaymentUDMealState_pms_Info> userList_pms, List<PaymentUDMealState_pms_Info> classList_pms, List<PaymentUDMealState_pms_Info> gradeList_pms)
        {
            PaymentUDMealState_pms_Info pmsInfo;

            bool? isEit = null;

            if (userList_pms != null && userList_pms.Count > 0)//查用戶
            {
                for (int index = 0; index < userList_pms.Count; index++)
                {
                    pmsInfo = userList_pms[index] as PaymentUDMealState_pms_Info;

                    DateTime startDate = DateTime.Parse(((DateTime)pmsInfo.pms_dStartDate).ToString("yyyy/MM/dd"));
                    DateTime endDate = DateTime.Parse(((DateTime)pmsInfo.pms_dEndDate).ToString("yyyy/MM/dd"));

                    if (startDate <= dt && endDate >= dt)
                    {
                        switch (type)
                        {
                            case 0:
                                isEit = pmsInfo.pms_cBreakfast;
                               // return pmsInfo.pms_cBreakfast;
                                break;
                            case 1:
                                isEit = pmsInfo.pms_cLunch;
                               //return pmsInfo.pms_cLunch;
                                break;
                            case 2:
                                isEit = pmsInfo.pms_cDinner;
                               // return pmsInfo.pms_cDinner;
                                break;
                        }

                        continue;
                    }
                }
            }

            if(isEit == false)
            {
                return isEit;
            }

            //isEit = false;
            for (int index = 0; index < gradeList_pms.Count; index++)
            {
                pmsInfo = gradeList_pms[index] as PaymentUDMealState_pms_Info;

                DateTime startDate = DateTime.Parse(((DateTime)pmsInfo.pms_dStartDate).ToString("yyyy/MM/dd"));
                DateTime endDate = DateTime.Parse(((DateTime)pmsInfo.pms_dEndDate).ToString("yyyy/MM/dd"));

                if (startDate <= dt && endDate >= dt)
                {
                    switch (type)
                    {
                        case 0:
                            isEit = pmsInfo.pms_cBreakfast;
                            // return pmsInfo.pms_cBreakfast;
                            break;
                        case 1:
                            isEit = pmsInfo.pms_cLunch;
                            //return pmsInfo.pms_cLunch;
                            break;
                        case 2:
                            isEit = pmsInfo.pms_cDinner;
                            // return pmsInfo.pms_cDinner;
                            break;
                    }

                    continue;
                }
            }

            if (isEit == false)
            {
                return isEit;
            }

            if (classList_pms != null && classList_pms.Count > 0)//查班級
            {
                //isEit = false;
                for (int index = 0; index < classList_pms.Count; index++)
                {
                    pmsInfo = classList_pms[index] as PaymentUDMealState_pms_Info;

                    DateTime startDate = DateTime.Parse(((DateTime)pmsInfo.pms_dStartDate).ToString("yyyy/MM/dd"));
                    DateTime endDate = DateTime.Parse(((DateTime)pmsInfo.pms_dEndDate).ToString("yyyy/MM/dd"));

                    if (startDate <= dt && endDate >= dt)
                    {
                        switch (type)
                        {
                            case 0:
                                isEit = pmsInfo.pms_cBreakfast;
                                // return pmsInfo.pms_cBreakfast;
                                break;
                            case 1:
                                isEit = pmsInfo.pms_cLunch;
                                //return pmsInfo.pms_cLunch;
                                break;
                            case 2:
                                isEit = pmsInfo.pms_cDinner;
                                // return pmsInfo.pms_cDinner;
                                break;
                        }
                        continue;
                    }
                }
            }

            return isEit;
        }

        /// <summary>
        /// 返回默認設置
        /// </summary>
        /// <param name="type"></param>
        /// <param name="weeks"></param>
        /// <param name="userList_pus"></param>
        /// <param name="classList_pus"></param>
        /// <param name="gradeList_pus"></param>
        /// <returns></returns>
        private bool? GetSettingStatus(int type, int weeks, List<PaymentUDGeneralSetting_pus_Info> userList_pus, List<PaymentUDGeneralSetting_pus_Info> classList_pus, List<PaymentUDGeneralSetting_pus_Info> gradeList_pus)
        {
            PaymentUDGeneralSetting_pus_Info pusInfo;

            bool? isEit = null;

            if (userList_pus != null && userList_pus.Count > 0)
            {
                for (int index = 0; index < userList_pus.Count; index++)
                {
                    pusInfo = userList_pus[index] as PaymentUDGeneralSetting_pus_Info;

                    if (pusInfo.pus_iWeek == weeks)
                    {
                        switch (type)
                        {
                            case 0:
                                isEit = pusInfo.pus_cBreakfast;
                                //return pusInfo.pus_cBreakfast;
                                break;
                            case 1:
                                isEit = pusInfo.pus_cLunch;
                                //return pusInfo.pus_cLunch;
                                break;
                            case 2:
                                isEit = pusInfo.pus_cDinner; 
                                //return pusInfo.pus_cDinner;
                                break;
                        }
                    }
                }
            }

            if (isEit == false)
            {
                return isEit;
            }

            if (gradeList_pus != null && gradeList_pus.Count > 0)
            {
                isEit = false;
                for (int index = 0; index < gradeList_pus.Count; index++)
                {
                    pusInfo = gradeList_pus[index] as PaymentUDGeneralSetting_pus_Info;

                    if (pusInfo.pus_iWeek == weeks)
                    {
                        switch (type)
                        {
                            case 0:
                                isEit = pusInfo.pus_cBreakfast;
                                //return pusInfo.pus_cBreakfast;
                                break;
                            case 1:
                                isEit = pusInfo.pus_cLunch;
                                //return pusInfo.pus_cLunch;
                                break;
                            case 2:
                                isEit = pusInfo.pus_cDinner;
                                //return pusInfo.pus_cDinner;
                                break;
                        }
                    }
                }
            }

            if (isEit == false)
            {
                return isEit;
            }

            if (classList_pus != null && classList_pus.Count > 0)
            {
                isEit = false;
                for (int index = 0; index < classList_pus.Count; index++)
                {
                    pusInfo = classList_pus[index] as PaymentUDGeneralSetting_pus_Info;

                    if (pusInfo.pus_iWeek == weeks)
                    {
                        switch (type)
                        {
                            case 0:
                                isEit = pusInfo.pus_cBreakfast;
                                //return pusInfo.pus_cBreakfast;
                                break;
                            case 1:
                                isEit = pusInfo.pus_cLunch;
                                //return pusInfo.pus_cLunch;
                                break;
                            case 2:
                                isEit = pusInfo.pus_cDinner;
                                //return pusInfo.pus_cDinner;
                                break;
                        }
                    }
                }
            }

            return isEit;
        }

        private int GetWeeks(DateTime dtime)
        {
            int index = 0;

            string dt = dtime.DayOfWeek.ToString().ToLower();
            switch (dt)
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
                    index = 0;
                    break;
            }

            return index;
        }

        public List<PaymentUDMealState_pms_Info> AllRecords()
        {
            try
            {
                return this._paymentUMealStateDA.AllRecords();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
