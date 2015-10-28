using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.IModel;

namespace BLL.IBLL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 账户资金流动明细
    /// </summary>
    public interface ICardUserAccountDetailBL : IBaseBL<CardUserAccountDetail_cuad_Info>
    {
        List<CardUserAccountDetail_cuad_Info> SearchRecords(IModelObject itemEntity, DateTime dtBegin, DateTime dtEnd);
    }
}
