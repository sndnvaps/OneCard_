using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.IModel;

namespace DAL.IDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 账户资金流动详细信息
    /// </summary>
    public interface ICardUserAccountDetailDA : IMainGeneralDA<CardUserAccountDetail_cuad_Info>
    {
        List<CardUserAccountDetail_cuad_Info> SearchRecords(IModelObject itemEntity, DateTime dtBegin, DateTime dtEnd);
    }
}
