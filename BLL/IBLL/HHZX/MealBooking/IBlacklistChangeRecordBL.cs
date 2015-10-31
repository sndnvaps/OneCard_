using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.MealBooking;
using Model.General;

namespace BLL.IBLL.HHZX.MealBooking
{
    public interface IBlacklistChangeRecordBL : IBaseBL<BlacklistChangeRecord_blc_Info>
    {
        /// <summary>
        /// 批量更新黑名单记录状态
        /// </summary>
        /// <param name="listRecords"></param>
        /// <returns></returns>
        ReturnValueInfo UpdateBatchRecord(List<BlacklistChangeRecord_blc_Info> listRecords);

        /// <summary>
        /// 插入需要上传消费机的卡号
        /// </summary>
        /// <param name="iCardNo">卡号</param>
        /// <param name="enmOpt">上传操作</param>
        /// <param name="enmReason">上传原因</param>
        ReturnValueInfo InsertUploadCardNo(int iCardNo, Common.DefineConstantValue.EnumCardUploadListOpt enmOpt, Common.DefineConstantValue.EnumCardUploadListReason enmReason, string strUserID);
    }
}
