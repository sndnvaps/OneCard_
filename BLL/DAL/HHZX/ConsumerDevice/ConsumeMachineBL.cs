using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumerDevice;
using DAL.IDAL.HHZX.ConsumerDevice;
using DAL.Factory.HHZX;
using Model.IModel;
using Model.HHZX.ConsumerDevice;
using Model.General;

namespace BLL.DAL.HHZX.ConsumerDevice
{
    public class ConsumeMachineBL : IConsumeMachineBL
    {
        private IConsumeMachineDA _icmDA;

        public ConsumeMachineBL()
        {
            _icmDA = MasterDAFactory.GetDAL<IConsumeMachineDA>(MasterDAFactory.ConsumeMachine);
        }

        #region IMainGeneralBL 成员

        public List<ConsumeMachineMaster_cmm_Info> AllRecords()
        {
            try
            {
                List<ConsumeMachineMaster_cmm_Info> infoList = _icmDA.AllRecords();

                return infoList;
            }
            catch
            {
                throw;
            }

        }

        #endregion

        #region IMainBL 成员

        public ConsumeMachineMaster_cmm_Info DisplayRecord(Model.IModel.IModelObject itemEntity)
        {
            try
            {
                ConsumeMachineMaster_cmm_Info info = _icmDA.DisplayRecord(itemEntity);

                return info;
            }
            catch
            {
                throw;
            }
        }

        public List<ConsumeMachineMaster_cmm_Info> SearchRecords(Model.IModel.IModelObject itemEntity)
        {
            try
            {

                ConsumeMachineMaster_cmm_Info infos = itemEntity as ConsumeMachineMaster_cmm_Info;

                List<ConsumeMachineMaster_cmm_Info> infoList = _icmDA.SearchRecords(infos);


                return infoList;
            }
            catch
            {
                throw;
            }
        }

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            ConsumeMachineMaster_cmm_Info objInfo = itemEntity as ConsumeMachineMaster_cmm_Info;

            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                        objInfo.cmm_dAddDate = DateTime.Now;
                        objInfo.cmm_dLastDate = DateTime.Now;
                        objInfo.cmm_dLastAccessTime = DateTime.Now;
                        objInfo.cmm_cRecordID = Guid.NewGuid();
                        returnInfo = _icmDA.InsertRecord(objInfo);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:
                        objInfo.cmm_dLastDate = DateTime.Now;
                        returnInfo = _icmDA.UpdateRecord(objInfo);
                        break;
                }
            }
            catch
            {
                throw;
            }

            return returnInfo;
        }

        #endregion
    }
}
