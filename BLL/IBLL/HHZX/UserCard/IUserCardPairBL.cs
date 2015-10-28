using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserCard;
using Model.General;
using Model.HHZX.Report;
using Model.HHZX.ComsumeAccount;

namespace BLL.IBLL.HHZX.UserCard
{
    public interface IUserCardPairBL : IBaseBL<UserCardPair_ucp_Info>
    {
        /// <summary>
        /// 获取不正常状态的卡列表
        /// </summary>
        /// <returns></returns>
        List<UserCardPair_ucp_Info> GetUnusualCardList();

        /// <summary>
        /// 发新卡
        /// </summary>
        /// <param name="infoObject">发卡资料</param>
        /// <param name="dCost">新卡工本费</param>
        /// <returns></returns>
        ReturnValueInfo InsertNewCard(UserCardPair_ucp_Info infoObject, decimal dCost);

        /// <summary>
        /// 换卡并插入换卡费用
        /// </summary>
        /// <param name="infoObject">新卡信息</param>
        /// <param name="dCost">换卡费用</param>
        /// <returns></returns>
        ReturnValueInfo InsertExchargeCard(UserCardPair_ucp_Info infoObject, decimal dCost);

        /// <summary>
        /// 退卡
        /// </summary>
        /// <param name="infoObject">卡信息</param>
        /// <returns></returns>
        ReturnValueInfo ReturnCard(UserCardPair_ucp_Info infoObject);

        /// <summary>
        /// 取得时间段内换卡记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<ChangeCardDetail_ccd_Info> GetChangeCardDetail(ChangeCardDetail_ccd_Info query);

        /// <summary>
        /// 取得开户情况信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<CardUserAccount_cua_Info> GetAccoumtEstablishInfo(DateTime startDate, DateTime endDate, Guid classID, string studentID);

        /// <summary>
        /// 获取长期黑名单的卡号列表
        /// </summary>
        List<int> GetContinuedBalckListCardNoList();
    }
}
