using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.HHZX.UserInfomation.CardUserInfo;

namespace BLL.IBLL.HHZX.Report
{
    public interface IMoneyBalanceBL
    {
        List<CardUserAccount_cua_Info> SearchRecords(CardUserMaster_cus_Info cusInfo);
    }
}
