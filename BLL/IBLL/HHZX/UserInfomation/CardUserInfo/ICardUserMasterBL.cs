using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.General;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.IModel;

namespace BLL.IBLL.HHZX.UserInfomation.CardUserInfo
{
    public interface ICardUserMasterBL : IBaseBL<CardUserMaster_cus_Info>
    {
        /// <summary>
        /// 批量修改用户信息
        /// </summary>
        /// <returns></returns>
        ReturnValueInfo BatchUpdateUserInfo(List<CardUserMaster_cus_Info> listUsers);

        ReturnValueInfo UpdateStudentsInfo(List<CardUserMaster_cus_Info> students, Guid classID);

        List<CardUserMaster_cus_Info> GetClassInfo(Guid classID);

        List<CardUserMaster_cus_Info> CheckForInportData(List<CardUserMaster_cus_Info> inportData);

        ReturnValueInfo InportData(List<CardUserMaster_cus_Info> inportData);

        ReturnValueInfo InportChangeClassData(List<ChangeClassRecord_ccr_Info> inportData);

        List<CardUserMaster_cus_Info> GetClassStudents(ClassMaster_csm_Info classInfo);

        List<CardUserMaster_cus_Info> GetGradeStudents(Guid gradeID);

        /// <summary>
        /// 搜寻卡用户主档信息
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        List<CardUserMaster_cus_Info> SearchRecordsWithCardInfo(IModelObject searchCondition);

        /// <summary>
        /// 获取用户最新自动编号
        /// </summary>
        /// <param name="strUserType"></param>
        /// <returns></returns>
        string GetLastAutoUserCode(string strUserType);

        /// <summary>
        /// 搜寻记录（主档专用）
        /// </summary>
        /// <param name="searchInfo">条件</param>
        /// <returns></returns>
        List<CardUserMaster_cus_Info> SearchRecord_ForMaster(CardUserMaster_cus_Info searchInfo);
    }
}
