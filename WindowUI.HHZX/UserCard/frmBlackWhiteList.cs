using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowUI.HHZX.UserInformation.CardUserInfo;
using Common;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserCard;
using BLL.Factory.HHZX;
using BLL.IBLL.HHZX.ConsumerDevice;
using Model.HHZX.ConsumerDevice;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using System.Net;
using Model.General;
using BLL.IBLL.SysFunction;
using Model.SysFunction;
using BLL.IBLL.HHZX.MealBooking;
using Model.HHZX.MealBooking;

namespace WindowUI.HHZX.UserCard
{
    /// <summary>
    /// 黑白名单设置(用户卡停开卡)
    /// </summary>
    public partial class frmBlackWhiteList : BaseReaderForm
    {
        private CardUserMaster_cus_Info _cusInfo;
        private IUserCardPairBL _ucpBL;
        private IConsumeMachineBL _icmBL;
        private AbstractPayDevice _CurrentDevice;
        private IBlacklistChangeRecordBL m_blistBL;
        private ILogDetailBL _ildBL;

        public frmBlackWhiteList()
        {
            InitializeComponent();
            _ucpBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            _icmBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
            _CurrentDevice = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);

            _ildBL = BLL.Factory.SysFunction.SysBLLFactory.GetBLL<ILogDetailBL>(BLL.Factory.SysFunction.SysBLLFactory.LogDetail);

            this.m_blistBL = MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(MasterBLLFactory.BlacklistChangeRecord);
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            dlgCardUserSelection dcusForm = new dlgCardUserSelection();
            dcusForm.ShowDialog();
            if (dcusForm.SelectedUser != null)
            {
                _cusInfo = dcusForm.SelectedUser;
                initValue();
            }
        }

        private void initValue()
        {
            this.lblChaName.Text = _cusInfo.cus_cChaName;
            this.lblNumber.Text = _cusInfo.cus_cStudentID;

            if (_cusInfo.ClassInfo != null)
            {
                this.lblClass.Text = _cusInfo.ClassInfo.csm_cClassName;
            }
            else if (_cusInfo.DeptInfo != null)
            {
                this.lblClass.Text = _cusInfo.DeptInfo.dpm_cName;
            }
            else
            {
                this.lblClass.Text = "无";
            }

            if (_cusInfo.PairInfo != null)
            {
                this.lblCardNo.Text = _cusInfo.PairInfo.ucp_iCardNo.ToString();

                switch (_cusInfo.PairInfo.ucp_cUseStatus)
                {
                    case "Normal":
                        this.lblUserStatus.Text = "使用中";
                        this.rbtBlack.Checked = true;
                        this.rbtWhite.Checked = false;
                        rbtBlack_CheckedChanged(null, null);

                        this.pnlBlack.Enabled = true;
                        this.pnlWhite.Enabled = false;

                        break;
                    case "LoseReporting":
                        this.lblUserStatus.Text = "挂失中";
                        this.rbtBlack.Checked = false;
                        this.rbtWhite.Checked = true;

                        this.pnlBlack.Enabled = false;
                        this.pnlWhite.Enabled = true;

                        break;
                    case "Damaged":
                        this.lblUserStatus.Text = "已损坏";
                        break;
                    case "Lost":
                        this.lblUserStatus.Text = "已丢失";
                        this.rbtBlack.Checked = false;
                        this.rbtBlack.Checked = true;
                        rbtWhite_CheckedChanged(null, null);

                        this.pnlBlack.Enabled = true;
                        this.pnlWhite.Enabled = false;

                        break;
                    case "Returned":
                        this.lblUserStatus.Text = "已退卡";
                        break;
                }


            }
            else
            {
                this.lblCardNo.Text = "未发卡";
                this.lblUserStatus.Text = "未发卡";

                this.pnlBlack.Enabled = false;
                this.pnlWhite.Enabled = false;
            }
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            bool resUkey = base.CheckUKey();
            if (!resUkey)
            {
                return;
            }

            if (_cusInfo != null)
            {
                if (!ShowQuestionMessage("是否挂失该卡?"))
                {
                    return;
                }

                _cusInfo.PairInfo.ucp_cUseStatus = DefineConstantValue.ConsumeCardStatus.LoseReporting.ToString();
                if (_ucpBL.Save(_cusInfo.PairInfo, DefineConstantValue.EditStateEnum.OE_Update).isError)
                {
                    base.ShowErrorMessage("挂失失败。");
                }
                else
                {
                    #region 原直接与消费机通信添加黑名单操作

                    //ConsumeMachineMaster_cmm_Info ccmInfo = new ConsumeMachineMaster_cmm_Info();
                    //ccmInfo.cmm_lIsActive = true;

                    //List<ConsumeMachineMaster_cmm_Info> _infoList = _icmBL.SearchRecords(ccmInfo);

                    //if (_infoList != null)
                    //{
                    //    for (int index = 0; index < _infoList.Count; index++)//消费机挂失
                    //    {
                    //        IPAddress ip = IPAddress.Parse(_infoList[index].cmm_cIPAddr);

                    //        ReturnValueInfo returnInfo = _CurrentDevice.Conn(ip, _infoList[index].cmm_iPort, _infoList[index].cmm_iMacNo);

                    //        if (returnInfo.boolValue)
                    //        {
                    //            _CurrentDevice.AddBlacklist(_cusInfo.PairInfo.ucp_iCardNo.ToString());
                    //        }
                    //        else
                    //        {
                    //            try
                    //            {
                    //                LogDetail_lgd_Info lgdInfo = new LogDetail_lgd_Info();
                    //                lgdInfo.lgd_cClassMethodName = "btnBlack_Click";
                    //                lgdInfo.lgd_cIpAddr = _infoList[index].cmm_cIPAddr;
                    //                lgdInfo.lgd_cLogMessage = "挂失卡异常。"; // +returnInfo.messageText;
                    //                lgdInfo.lgd_cLogType = "Error";
                    //                lgdInfo.lgd_cOperator = this.UserInformation.usm_cUserLoginID;
                    //                lgdInfo.lgd_cSysName = "WindowUI.HHZX";
                    //                lgdInfo.lgd_dOperateDateTime = System.DateTime.Now;

                    //                _ildBL.InsertLog(lgdInfo);
                    //            }
                    //            catch
                    //            {

                    //            }

                    //        }
                    //    }
                    //}

                    #endregion
                    ReturnValueInfo rvInfo = RemoveCardFromWList(_cusInfo.PairInfo.ucp_iCardNo);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        base.ShowInformationMessage("挂失成功。");
                    }
                    else
                    {
                        base.ShowErrorMessage("挂失失败。" + rvInfo.messageText);
                    }

                    initValue();
                }
            }
            else
            {
                base.ShowErrorMessage("请选择一个人员再进行相关操作。");
            }
        }

        /// <summary>
        /// 将卡添加到黑名单记录中
        /// </summary>
        /// <param name="iCardNo"></param>
        ReturnValueInfo AddOldCardBList(int iCardNo, Common.DefineConstantValue.EnumCardUploadListOpt blistOpt)
        {
            return this.m_blistBL.InsertUploadCardNo(iCardNo, DefineConstantValue.EnumCardUploadListOpt.AddBlackList, DefineConstantValue.EnumCardUploadListReason.BlacklistOpt, this.UserInformation.usm_cUserLoginID);
        }

        /// <summary>
        /// 将卡移出白名单记录中
        /// </summary>
        /// <param name="iCardNo">卡号</param>
        ReturnValueInfo RemoveCardFromWList(int iCardNo)
        {
            return this.m_blistBL.InsertUploadCardNo(iCardNo, DefineConstantValue.EnumCardUploadListOpt.RemoveWhiteList, DefineConstantValue.EnumCardUploadListReason.BlacklistOpt, this.UserInformation.usm_cUserLoginID);
        }

        /// <summary>
        /// 将卡添加到白名单记录中
        /// </summary>
        /// <param name="iCardNo">卡号</param>
        ReturnValueInfo AddCardToWList(int iCardNo)
        {
            return this.m_blistBL.InsertUploadCardNo(iCardNo, DefineConstantValue.EnumCardUploadListOpt.AddWhiteList, DefineConstantValue.EnumCardUploadListReason.BlacklistOpt, this.UserInformation.usm_cUserLoginID);
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            bool resUkey = base.CheckUKey();
            if (!resUkey)
            {
                return;
            }

            if (_cusInfo != null)
            {
                if (!base.ShowQuestionMessage("是否解挂该卡?"))
                {
                    return;
                }

                _cusInfo.PairInfo.ucp_cUseStatus = DefineConstantValue.ConsumeCardStatus.Normal.ToString();
                if (_ucpBL.Save(_cusInfo.PairInfo, DefineConstantValue.EditStateEnum.OE_Update).isError)
                {
                    base.ShowErrorMessage("解挂失败。");
                }
                else
                {
                    #region 原直接与设备解挂逻辑

                    //ConsumeMachineMaster_cmm_Info ccmInfo = new ConsumeMachineMaster_cmm_Info();
                    //ccmInfo.cmm_lIsActive = true;

                    //List<ConsumeMachineMaster_cmm_Info> _infoList = _icmBL.SearchRecords(ccmInfo);

                    //if (_infoList != null)
                    //{
                    //    for (int index = 0; index < _infoList.Count; index++)
                    //    {
                    //        IPAddress ip = IPAddress.Parse(_infoList[index].cmm_cIPAddr);

                    //        ReturnValueInfo returnInfo = _CurrentDevice.Conn(ip, _infoList[index].cmm_iPort, _infoList[index].cmm_iMacNo);

                    //        if (returnInfo.boolValue)
                    //        {
                    //            _CurrentDevice.RemoveBlacklist(_cusInfo.PairInfo.ucp_iCardNo.ToString());
                    //        }
                    //        else
                    //        {
                    //            try
                    //            {
                    //                LogDetail_lgd_Info lgdInfo = new LogDetail_lgd_Info();
                    //                lgdInfo.lgd_cClassMethodName = "btnWhite_Click";
                    //                lgdInfo.lgd_cIpAddr = _infoList[index].cmm_cIPAddr;
                    //                lgdInfo.lgd_cLogMessage = "解挂失卡异常。";// +returnInfo.messageText;
                    //                lgdInfo.lgd_cLogType = "Error";
                    //                lgdInfo.lgd_cOperator = this.UserInformation.usm_cUserLoginID;
                    //                lgdInfo.lgd_cSysName = "WindowUI.HHZX";
                    //                lgdInfo.lgd_dOperateDateTime = System.DateTime.Now;

                    //                _ildBL.InsertLog(lgdInfo);
                    //            }
                    //            catch
                    //            {

                    //            }
                    //        }
                    //    }
                    //}

                    #endregion


                    ReturnValueInfo rvInfo = AddCardToWList(_cusInfo.PairInfo.ucp_iCardNo);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        base.ShowInformationMessage("解挂成功，卡片将于一至两分钟后可恢复刷卡。");
                    }
                    else
                    {
                        base.ShowErrorMessage("解挂失败。" + rvInfo.messageText);
                    }
                    initValue();
                }
            }
            else
            {
                base.ShowErrorMessage("请选择一个人员再进行相关操作。");
            }
        }

        private void rbtBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtBlack.Checked)
            {
                this.rbtWhite.Checked = false;
                this.btnBlack.Enabled = true;
                this.btnWhite.Enabled = false;
            }
            else
            {
                this.rbtWhite.Checked = true;
                this.btnBlack.Enabled = false;
                this.btnWhite.Enabled = true;
            }
        }

        private void rbtWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtWhite.Checked)
            {
                this.rbtBlack.Checked = false;
                this.btnBlack.Enabled = false;
                this.btnWhite.Enabled = true;
            }
            else
            {
                this.rbtBlack.Checked = true;
                this.btnBlack.Enabled = true;
                this.btnWhite.Enabled = false;
            }
        }
    }
}
