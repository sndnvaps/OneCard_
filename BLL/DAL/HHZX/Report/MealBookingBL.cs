using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using DAL.IDAL.Report;
using DAL.Factory.HHZX;
using Model.IModel;
using Model.HHZX.Report;
using BLL.IBLL.HHZX.MealBooking;
using Model.HHZX.MealBooking;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using BLL.Factory.HHZX;
using DAL.IDAL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using Common;

namespace BLL.DAL.HHZX.Report
{
    public class MealBookingBL : IMealBookingBL
    {
        private IMealBookingDA _imbDA;

        public MealBookingBL()
        {
            _imbDA = MasterDAFactory.GetDAL<IMealBookingDA>(MasterDAFactory.MealBookingReport);
        }


        #region IBaseBL<MealBooking_mbk_info> 成员

        public Model.HHZX.Report.MealBooking_mbk_info DisplayRecord(IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<MealBooking_mbk_info> SearchRecords(IModelObject searchCondition)
        {
            List<MealBooking_mbk_info> returnList = new List<MealBooking_mbk_info>();

            try
            {
                if (searchCondition != null)
                {
                    IPaymentUDMealStateBL ipumsBL = MasterBLLFactory.GetBLL<IPaymentUDMealStateBL>(MasterBLLFactory.PaymentUDMealState);
                    //IClassMasterDA icmDA = MasterDAFactory.GetDAL<IClassMasterDA>(MasterDAFactory.ClassMaster);
                    ICardUserMasterBL icumBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);

                    IConsumeRecordDA icrDA = MasterDAFactory.GetDAL<IConsumeRecordDA>(MasterDAFactory.ConsumeRecord);

                    MealBooking_mbk_info searchObj = searchCondition as MealBooking_mbk_info;

                    DateTime startTime = DateTime.Parse(searchObj.StartTime.ToString("yyyy/MM/dd"));
                    DateTime endTime = DateTime.Parse(searchObj.EndTime.ToString("yyyy/MM/dd"));

                    DateTime nowTime = DateTime.Parse(System.DateTime.Now.ToString("yyyy/MM/dd"));

                    //查詢班級
                    List<ClassMaster_csm_Info> csmList = new List<ClassMaster_csm_Info>();

                    //查詢人員
                    List<CardUserMaster_cus_Info> cusList = new List<CardUserMaster_cus_Info>();

                    MealBooking_mbk_info mbk = new MealBooking_mbk_info();

                    if (searchObj.ClassID == Guid.Empty && searchObj.GradeID == Guid.Empty)
                    {
                        //csmList = icmDA.AllRecords();
                        // return null;
                    }
                    else if (searchObj.GradeID != Guid.Empty)
                    {
                        ClassMaster_csm_Info csmInfo = new ClassMaster_csm_Info();
                        csmInfo.csm_cGDMID = searchObj.GradeID;
                        //csmList = icmDA.SearchRecords(csmInfo);

                        cusList = icumBL.GetGradeStudents(searchObj.GradeID);

                        mbk.GradeID = searchObj.GradeID;
                    }
                    else if (searchObj.ClassID != Guid.Empty)
                    {
                        ClassMaster_csm_Info csmInfo = new ClassMaster_csm_Info();
                        csmInfo.csm_cRecordID = searchObj.ClassID;
                        //csmInfo = icmDA.DisplayRecord(csmInfo);
                        csmList.Add(csmInfo);

                        //ClassMaster_csm_Info csmInfo = new ClassMaster_csm_Info();
                        //csmInfo.csm_cRecordID = searchObj.ClassID;
                        cusList = icumBL.GetClassStudents(csmInfo);

                        mbk.ClassID = searchObj.ClassID;
                    }

                    if (cusList != null)
                    {
                        if(startTime < nowTime)
                        {
                            DateTime et;

                            if (endTime < nowTime)
                            {
                                et = endTime;
                            }
                            else
                            {
                                et = nowTime.AddDays(-1);
                            }

                            for (DateTime dt = startTime; dt <= et; dt = dt.AddDays(1))
                            {
                                mbk.StartTime = dt;
                                mbk.EndTime = dt.AddDays(1);
                                returnList.AddRange(_imbDA.GetClassBookingHistory(mbk));
                            }
                        }

                        //for (DateTime dt = startTime; dt <= endTime; dt = dt.AddDays(1))//查詢預計定餐情況
                        //{
                        //    if(dt < nowTime)
                        //    {

                        //    }
                        //}

                        if (startTime <= nowTime || endTime >= nowTime)
                        {
                            DateTime et;
                            if (startTime <= nowTime && endTime >= nowTime)
                            {
                                et = nowTime;
                            }
                            else if (startTime > nowTime)
                            {
                                et = startTime;
                            }
                            else
                            {
                                et = endTime.AddDays(1);
                            }

                            for (DateTime dt = et; dt <= endTime; dt = dt.AddDays(1))
                            {
                                mbk.StartTime = dt;
                                mbk.EndTime = dt.AddDays(1);
                                returnList.AddRange(_imbDA.GetPlanBooking(mbk));
                            }


                        }

                    }

                    #region
                    //if (csmList != null) 
                    //{
                    //    for (int classNo = 0; classNo < csmList.Count; classNo++)//查找所有班級
                    //    {
                    //        ClassMaster_csm_Info csmInfo = csmList[classNo];

                    //        CardUserMaster_cus_Info cusInfo = new CardUserMaster_cus_Info();
                    //        cusInfo.cus_cClassID = csmInfo.csm_cRecordID;

                    //        List<CardUserMaster_cus_Info> cusList = icumBL.SearchRecords(cusInfo);//查班級內的人

                    //        if (cusList != null)
                    //        {
                    //            for (DateTime dt = startTime; dt <= endTime; dt = dt.AddDays(1))//查詢預計定餐情況
                    //            {
                    //                MealBooking_mbk_info mbkInfo = new MealBooking_mbk_info();
                    //                mbkInfo.className = csmInfo.csm_cClassName;
                    //                mbkInfo.bookingDate = dt.ToString("yyyy/MM/dd");
                    //                mbkInfo.userAmount = cusList.Count;

                    //                for (int userNo = 0; userNo < cusList.Count; userNo++)
                    //                {
                    //                    cusInfo = cusList[userNo] as CardUserMaster_cus_Info;

                    //                    if (cusInfo.ClassInfo != null)
                    //                    {
                    //                        mbkInfo.gradeName = cusInfo.ClassInfo.GradeInfo.gdm_cGradeName;
                    //                    }

                    //                    PaymentUDMealState_pms_Info pmsInfo = new PaymentUDMealState_pms_Info();
                    //                    pmsInfo.pms_cCardUserID = cusInfo.cus_cRecordID;
                    //                    pmsInfo.pms_cClassID = cusInfo.cus_cClassID;
                    //                    pmsInfo.pms_cGradeID = csmInfo.csm_cGDMID;
                    //                    pmsInfo.TimeFrom = dt;
                    //                    pmsInfo.TimeTo = dt;

                    //                    List<PaymentUDMealState_pms_Info> pmsList = ipumsBL.SearchMealRecords(pmsInfo);//查預計定餐
                    //                    if (pmsList != null && pmsList.Count > 0)
                    //                    {
                    //                        PaymentUDMealState_pms_Info pInfo = pmsList.FirstOrDefault();

                    //                        if (pInfo.pms_cBreakfast != null && (bool)(pInfo.pms_cBreakfast))
                    //                        {
                    //                            mbkInfo.breakfast_Est++;
                    //                        }
                    //                        if (pInfo.pms_cLunch != null && (bool)(pInfo.pms_cLunch))
                    //                        {
                    //                            mbkInfo.lunch_Est++;
                    //                        }
                    //                        if (pInfo.pms_cDinner != null && (bool)(pInfo.pms_cDinner))
                    //                        {
                    //                            mbkInfo.dinner_Est++;
                    //                        }
                    //                    }
                    //                }

                    //                List<ConsumeRecord_csr_Info> csrList = icrDA.GetClassConsumeRecord(cusInfo.cus_cClassID, dt);

                    //                if (csrList != null)
                    //                {
                    //                    for (int recNo = 0; recNo < csrList.Count; recNo++)
                    //                    {
                    //                        ConsumeRecord_csr_Info csrInfo = csrList[recNo];

                    //                        if (csrInfo.csr_cMealType == DefineConstantValue.MealType.Breakfast.ToString())
                    //                        {
                    //                            mbkInfo.breakfast_Act++;
                    //                        }
                    //                        else if (csrInfo.csr_cMealType == DefineConstantValue.MealType.Lunch.ToString())
                    //                        {
                    //                            mbkInfo.lunch_Act++;
                    //                        }
                    //                        else if (csrInfo.csr_cMealType == DefineConstantValue.MealType.Supper.ToString())
                    //                        {
                    //                            mbkInfo.dinner_Act++;
                    //                        }
                    //                    }
                    //                }

                    //                returnList.Add(mbkInfo);

                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                }

            }
            catch
            {

            }
            return returnList;
        }

        public List<MealBooking_mbk_info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBaseBL<MealBooking_mbk_info> Members

        public Model.General.ReturnValueInfo Save(IModelObject itemEntity, DefineConstantValue.EditStateEnum EditMode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
