using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.UserCard;

namespace BLL.IBLL.HHZX.UserInfomation.UserCard
{
    public interface IConsumeCardMasterBL : IMainGeneralBL
    {
        List<ConsumeCardMaster_ccm_Info> SearchRecords(Model.IModel.IModelObject searchCondition);
        List<ConsumeCardMaster_ccm_Info> SearchDisplayRecords(UserCardPair_ucp_Info searchInfo);

        List<ConsumeCardMaster_ccm_Info> SearchHistoryRecords(UserCardPair_ucp_Info searchInfo);

        Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject deleteInfo);
        Model.General.ReturnValueInfo UpdateRecord(Model.IModel.IModelObject updateInfo);
        Model.General.ReturnValueInfo SaveRecord(Model.IModel.IModelObject saveInfo);
    }
}
