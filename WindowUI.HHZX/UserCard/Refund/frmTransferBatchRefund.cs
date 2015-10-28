using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.ComsumeAccount;
using Common;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.IModel;
using System.IO;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.General;

namespace WindowUI.HHZX.UserCard.Refund
{
    /// <summary>
    /// 批量转账退款金额
    /// </summary>
    public partial class frmTransferBatchRefund : BaseReaderForm
    {
        private ICardUserMasterBL _ICardUserMasterBL;
        private IRechargeRecordBL _IRechargeRecordBL;
        private IPreRechargeRecordBL _IPreRechargeRecordBL;

        public frmTransferBatchRefund()
        {
            InitializeComponent();

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IRechargeRecordBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            this._IPreRechargeRecordBL = MasterBLLFactory.GetBLL<IPreRechargeRecordBL>(MasterBLLFactory.PreRechargeRecord);
        }

        private void btnModelExport_Click(object sender, EventArgs e)
        {
            try
            {
                dlgBatchRefundExport dlg = new dlgBatchRefundExport();
                dlg.ShowDialog();
            }
            catch (Exception)
            { }
        }

        private void btnFileImport_Click(object sender, EventArgs e)
        {
            string strFilePath = tbxFilePath.Text.Trim();
            if (string.IsNullOrEmpty(strFilePath))
            {
                base.ShowWarningMessage("导入文件的路径不能为空，请重新选择。");
                btnFileImport.Focus();
                return;
            }

            if (!File.Exists(strFilePath))
            {
                base.ShowWarningMessage("该文件不存在，请重新选择。");
                btnFileImport.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                ImportExcelData(strFilePath);
            }
            catch (Exception ex)
            {
                base.ShowErrorMessage(ex);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Microsoft Office 97-2003 Excle文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbxFilePath.Text = dlg.FileName;
            }
        }

        private void btnClearFile_Click(object sender, EventArgs e)
        {
            tbxFilePath.Text = string.Empty;
        }

        private void tbxFilePath_TextChanged(object sender, EventArgs e)
        {
            TextBox tbxTarget = sender as TextBox;
            if (!string.IsNullOrEmpty(tbxTarget.Text))
            {
                btnClearFile.Enabled = true;
                btnFileImport.Enabled = true;
            }
            else
            {
                btnClearFile.Enabled = false;
                btnFileImport.Enabled = false;
            }
        }

        /// <summary>
        /// 导入Excel文件
        /// </summary>
        /// <param name="strFilePath"></param>
        void ImportExcelData(string strFilePath)
        {
            try
            {
                DataSet ds = General.GetExcelDs(strFilePath, "转账退款表");
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        List<TempBatchRechargeInfo> listTemp = new List<TempBatchRechargeInfo>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            #region  逐行验证充值数据的有效性

                            TempBatchRechargeInfo tmpRechargeInfo = new TempBatchRechargeInfo();

                            try
                            {
                                string strTmpNum = ds.Tables[0].Rows[i][0].ToString();
                                tmpRechargeInfo.UserNum = strTmpNum;
                                string strTmpName = ds.Tables[0].Rows[i][1].ToString();
                                tmpRechargeInfo.UserName = strTmpName;
                                if (string.IsNullOrEmpty(strTmpNum) && string.IsNullOrEmpty(strTmpName))
                                {
                                    break;
                                }
                                decimal dTmpRecharge = Convert.ToDecimal(ds.Tables[0].Rows[i][2].ToString());
                                tmpRechargeInfo.Refund = dTmpRecharge;

                                if (dTmpRecharge <= 0)
                                {
                                    tmpRechargeInfo.ValidInfo = "第" + (i + 1).ToString() + "行充值金额异常，需要为大于零的金额。";
                                    tmpRechargeInfo.Valid = false;
                                    listTemp.Add(tmpRechargeInfo);
                                    continue;
                                }
                                else if (dTmpRecharge > Common.DefineConstantValue.MaxRechargeVal)
                                {
                                    tmpRechargeInfo.ValidInfo = "第" + (i + 1).ToString() + "行充值金额异常，不能大于" + Common.DefineConstantValue.MaxRechargeVal + "。";
                                    tmpRechargeInfo.Valid = false;
                                    listTemp.Add(tmpRechargeInfo);
                                    continue;
                                }

                                //使用导入的Excel表资料中的用户编号查找用户
                                CardUserMaster_cus_Info searchUserInfo = new CardUserMaster_cus_Info();
                                searchUserInfo.cus_cStudentID = strTmpNum;
                                List<CardUserMaster_cus_Info> listTmpUser = this._ICardUserMasterBL.SearchRecords(searchUserInfo);
                                if (listTmpUser != null && listTmpUser.Count > 0)
                                {
                                    //有对应用户时，对比是否拥有对应excel数据里的名字的用户
                                    CardUserMaster_cus_Info cusUser = listTmpUser.Find(x => x.cus_cChaName.Trim() == strTmpName.Trim() && x.cus_lValid);
                                    if (cusUser != null)
                                    {
                                        tmpRechargeInfo.UserID = cusUser.cus_cRecordID;

                                        if (cusUser.PairInfo != null)
                                        {
                                            tmpRechargeInfo.CardID = cusUser.PairInfo.ucp_cCardID;

                                            if (cusUser.ClassInfo != null)
                                            {
                                                tmpRechargeInfo.Dept = cusUser.ClassInfo.csm_cClassName;
                                            }
                                            else if (cusUser.DeptInfo != null)
                                            {
                                                tmpRechargeInfo.Dept = cusUser.DeptInfo.dpm_cName;
                                            }

                                            tmpRechargeInfo.Valid = true;
                                            tmpRechargeInfo.ValidInfo = "验证通过";
                                        }
                                        //else
                                        //{
                                        //    tmpRechargeInfo.ValidInfo = "用户卡信息异常";
                                        //    tmpRechargeInfo.Valid = false;
                                        //}
                                        tmpRechargeInfo.Valid = true;
                                        tmpRechargeInfo.ValidInfo = "验证通过";
                                    }
                                    else
                                    {
                                        tmpRechargeInfo.ValidInfo = "用户编号与用户名称不符合";
                                        tmpRechargeInfo.Valid = false;
                                    }
                                }
                                else
                                {
                                    tmpRechargeInfo.ValidInfo = "不存在该编号的用户";
                                    tmpRechargeInfo.Valid = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                tmpRechargeInfo.ValidInfo = "第" + (i + 1).ToString() + "行数据异常，异常信息：" + ex.Message;
                                tmpRechargeInfo.Valid = false;
                            }

                            listTemp.Add(tmpRechargeInfo);

                            #endregion
                        }

                        if (listTemp.Count < 1)
                        {
                            ShowWarningMessage("没有可用的批量退款数据，请检查导入文件内容后重试。");
                            return;
                        }
                        if (listTemp.Count > Common.DefineConstantValue.MaxRechargeCount)
                        {
                            ShowWarningMessage("导入的退款记录数量超出限制【" + Common.DefineConstantValue.MaxRechargeCount.ToString() + "】条，请修改后重试。");
                            return;
                        }

                        lvBatchRechargeList.SetDataSource<TempBatchRechargeInfo>(listTemp, true);
                        if (lvBatchRechargeList.Items.Count > 0)
                        {
                            foreach (ListViewItem item in lvBatchRechargeList.Items)
                            {
                                if (Convert.ToBoolean(item.SubItems[2].Text))
                                {
                                    item.BackColor = Color.Green;
                                }
                                else
                                {
                                    item.BackColor = Color.Red;
                                }
                                item.ForeColor = Color.White;
                            }
                        }

                        bool isValid = listTemp.Exists(x => !x.Valid);
                        if (!isValid)
                        {
                            btnConfirmRecharge.Enabled = true;
                        }
                        else
                        {
                            btnConfirmRecharge.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// 临时批量充值信息
        /// </summary>
        class TempBatchRechargeInfo
        {
            /// <summary>
            /// 用户ID
            /// </summary>
            public Guid UserID { get; set; }
            /// <summary>
            /// 卡ID
            /// </summary>
            public string CardID { get; set; }
            /// <summary>
            /// 用户编号
            /// </summary>
            public string UserNum { get; set; }
            /// <summary>
            /// 班级名\部门名
            /// </summary>
            public string Dept { get; set; }
            /// <summary>
            /// 用户名称
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 充值金额
            /// </summary>
            public decimal Refund { get; set; }
            /// <summary>
            /// 验证信息
            /// </summary>
            public string ValidInfo { get; set; }
            /// <summary>
            /// 是否验证成功
            /// </summary>
            public bool Valid { get; set; }
        }

        private void btnConfirmRecharge_Click(object sender, EventArgs e)
        {
            bool resUkey = base.CheckUKey();
            if (!resUkey)
            {
                return;
            }
            
            if (lvBatchRechargeList.Items.Count > 0)
            {
                foreach (ListViewItem tmpItem in lvBatchRechargeList.Items)
                {
                    if (tmpItem != null)
                    {
                        try
                        {
                            PreRechargeRecord_prr_Info preRechargeInfo = new PreRechargeRecord_prr_Info();
                            preRechargeInfo.prr_cAdd = base.UserInformation.usm_cUserLoginID;
                            preRechargeInfo.prr_cLast = base.UserInformation.usm_cUserLoginID;
                            preRechargeInfo.prr_cRechargeType = DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer.ToString();
                            preRechargeInfo.prr_cRecordID = Guid.NewGuid();
                            preRechargeInfo.prr_cStatus = DefineConstantValue.ConsumeMoneyFlowStatus.WaitForAcceptTransfer.ToString();
                            preRechargeInfo.prr_cUserID = new Guid(tmpItem.SubItems[0].Text.ToString());
                            preRechargeInfo.prr_dAddDate = DateTime.Now;
                            preRechargeInfo.prr_dLastDate = DateTime.Now;
                            preRechargeInfo.prr_dRechargeTime = DateTime.Now;
                            preRechargeInfo.prr_fRechargeMoney = Convert.ToDecimal(tmpItem.SubItems[6].Text.ToString());

                            ReturnValueInfo rvInfo = this._IPreRechargeRecordBL.Save(preRechargeInfo, DefineConstantValue.EditStateEnum.OE_Insert);
                            if (rvInfo.boolValue && !rvInfo.isError)
                            {
                                tmpItem.SubItems[7].Text = "成功转账";
                                btnConfirmRecharge.Enabled = false;
                            }
                            else
                            {
                                tmpItem.SubItems[7].Text = "转账失败。" + rvInfo.messageText;
                            }
                        }
                        catch (Exception ex)
                        {
                            tmpItem.SubItems[7].Text = ex.Message;
                            continue;
                        }
                    }
                }

                base.ShowInformationMessage("转账结束。");
            }
        }
    }
}
