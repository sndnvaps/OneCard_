using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.HHZX.MealBooking;
using BLL.IBLL.General;
using Model.HHZX.MealBooking;
using BLL.Factory.General;
using BLL.Factory.HHZX;
using Model.IModel;
using Model.General;

namespace WindowUI.HHZX.MealBooking
{
    public partial class frmClassOrderNew : BaseForm
    {
        #region 自定义变量

        IPaymentUDMealStateBL _IPaymentUDMealStateBL;

        IPaymentUDGeneralSettingBL _IPaymentUDGeneralSettingBL;

        IGeneralBL _IGeneralBL;

        /// <summary>
        /// 当前在选的班级ID
        /// </summary>
        Guid _CurrentClassID;

        /// <summary>
        /// 当前在选的停餐设置ID
        /// </summary>
        Guid? _CurrentSettingID;

        /// <summary>
        /// 班级默认设置缓存
        /// </summary>
        List<PaymentUDGeneralSetting_pus_Info> _TmpListDefaultGeneral;

        Common.DefineConstantValue.EditStateEnum _EditState;

        #endregion

        public frmClassOrderNew()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this._IPaymentUDMealStateBL = MasterBLLFactory.GetBLL<IPaymentUDMealStateBL>(MasterBLLFactory.PaymentUDMealState);

            this._IPaymentUDGeneralSettingBL = MasterBLLFactory.GetBLL<IPaymentUDGeneralSettingBL>(MasterBLLFactory.PaymentUDGeneralSetting);

            this._CurrentClassID = Guid.Empty;

            this._EditState = Common.DefineConstantValue.EditStateEnum.OE_ReaOnly;

            ListViewSorter sorterClass = new ListViewSorter(1, SortOrder.Ascending);
            lvClassList.ListViewItemSorter = sorterClass;
            lvClassList.Sorting = SortOrder.Ascending;

            ListViewSorter sorterOrder = new ListViewSorter(1, SortOrder.Ascending);
            lvSpecialOrder.ListViewItemSorter = sorterOrder;
            lvSpecialOrder.Sorting = SortOrder.Ascending;

            labRecordTime.Text = "无记录";
        }

        /// <summary>
        /// 加载班级列表
        /// </summary>
        void loadClassInfoList()
        {
            try
            {
                List<IModelObject> listClass = this._IGeneralBL.GetMasterDataInformations(Common.DefineConstantValue.MasterType.UserClass);

                lvClassList.SetDataSource(listClass, true);
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }
        }

        private void frmClassOrder_Load(object sender, EventArgs e)
        {
            gbxNormal.Enabled = false;

            gbxSpecial.Enabled = false;

            loadClassInfoList();
        }

        private void lvClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvClassList.SelectedItems != null && lvClassList.SelectedItems.Count > 0)
            {
                gbxNormal.Enabled = false;

                gbxSpecial.Enabled = false;

                initMealBookingDetail();

                //if (this._TmpListDefaultGeneral == null || (this._TmpListDefaultGeneral != null && this._TmpListDefaultGeneral.Count < 1))
                //{
                //    if (ShowQuestionMessage("该年级无可用的默认计划，是否现在设置？"))
                //    {
                //        gbxNormal.Enabled = true;
                //    }
                //}
            }
        }

        /// <summary>
        /// 绑定对应班级的定餐信息详细
        /// </summary>
        private void initMealBookingDetail()
        {
            labDefaultClassName.Text = lvClassList.SelectedItems[0].SubItems[1].Text;
            labSpecialClassName.Text = lvClassList.SelectedItems[0].SubItems[1].Text;

            foreach (ListViewItem item in lvClassList.Items)
            {
                item.BackColor = Color.White;
            }

            lvClassList.SelectedItems[0].BackColor = Color.SteelBlue;

            loadDefaultSetting();

            loadSpecialSettings();

            this._CurrentClassID = new Guid(lvClassList.SelectedItems[0].SubItems[0].Text);
        }

        /// <summary>
        /// 加载默认定餐设置
        /// </summary>
        void loadDefaultSetting()
        {
            if (lvClassList.SelectedItems != null && lvClassList.SelectedItems.Count > 0)
            {
                PaymentUDGeneralSetting_pus_Info query = new PaymentUDGeneralSetting_pus_Info();

                query.pus_cClassID = new Guid(lvClassList.SelectedItems[0].SubItems[0].Text);

                try
                {
                    List<PaymentUDGeneralSetting_pus_Info> returnList = this._IPaymentUDGeneralSettingBL.SearchRecords(query);
                    if (returnList != null && returnList.Count > 0)
                    {
                        PaymentUDGeneralSetting_pus_Info lastInfo = returnList.OrderByDescending(x => x.pus_dLastDate).FirstOrDefault();
                        labRecordTime.Text = lastInfo.pus_dLastDate.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        labRecordTime.Text = "无记录";
                    }
                    this._TmpListDefaultGeneral = returnList;
                    bindAllDefaultSettings(returnList);
                }
                catch (Exception Ex)
                { ShowErrorMessage(Ex.Message); }
            }
        }

        /// <summary>
        /// 绑定年级默认定餐计划记录
        /// </summary>
        /// <param name="listSettings">原始记录</param>
        void bindAllDefaultSettings(List<PaymentUDGeneralSetting_pus_Info> listSettings)
        {
            try
            {
                if (listSettings != null && listSettings.Count > 0)
                {
                    foreach (PaymentUDGeneralSetting_pus_Info settingsItem in listSettings)
                    {
                        //早餐
                        foreach (Control controlItem in pnlBreakfast.Controls)
                        {
                            CheckBox cbxTarget = controlItem as CheckBox;
                            if (cbxTarget != null)
                            {
                                if (cbxTarget.Tag.ToString() == settingsItem.pus_iWeek.ToString())
                                {
                                    cbxTarget.Checked = settingsItem.pus_cBreakfast == null ? false : settingsItem.pus_cBreakfast.Value;
                                    break;
                                }
                            }
                        }
                        //午餐
                        foreach (Control controlItem in pnlLunch.Controls)
                        {
                            CheckBox cbxTarget = controlItem as CheckBox;
                            if (cbxTarget != null)
                            {
                                if (cbxTarget.Tag.ToString() == settingsItem.pus_iWeek.ToString())
                                {
                                    cbxTarget.Checked = settingsItem.pus_cLunch == null ? false : settingsItem.pus_cLunch.Value;
                                    break;
                                }
                            }
                        }
                        //晚餐
                        foreach (Control controlItem in pnlSupper.Controls)
                        {
                            CheckBox cbxTarget = controlItem as CheckBox;
                            if (cbxTarget != null)
                            {
                                if (cbxTarget.Tag.ToString() == settingsItem.pus_iWeek.ToString())
                                {
                                    cbxTarget.Checked = settingsItem.pus_cDinner == null ? false : settingsItem.pus_cDinner.Value;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Control controlItem in pnlBreakfast.Controls)
                    {
                        CheckBox cbxTarget = controlItem as CheckBox;
                        cbxTarget.Checked = false;
                    }
                    foreach (Control controlItem in pnlLunch.Controls)
                    {
                        CheckBox cbxTarget = controlItem as CheckBox;
                        cbxTarget.Checked = false;
                    }
                    foreach (Control controlItem in pnlSupper.Controls)
                    {
                        CheckBox cbxTarget = controlItem as CheckBox;
                        cbxTarget.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        private void btnNormalSave_Click(object sender, EventArgs e)
        {
            List<PaymentUDGeneralSetting_pus_Info> updateList = new List<PaymentUDGeneralSetting_pus_Info>();

            PaymentUDGeneralSetting_pus_Info sunInfo = new PaymentUDGeneralSetting_pus_Info();

            PaymentUDGeneralSetting_pus_Info monInfo = new PaymentUDGeneralSetting_pus_Info();

            PaymentUDGeneralSetting_pus_Info tuesInfo = new PaymentUDGeneralSetting_pus_Info();

            PaymentUDGeneralSetting_pus_Info wednesDay = new PaymentUDGeneralSetting_pus_Info();

            PaymentUDGeneralSetting_pus_Info thursDay = new PaymentUDGeneralSetting_pus_Info();

            PaymentUDGeneralSetting_pus_Info friDay = new PaymentUDGeneralSetting_pus_Info();

            PaymentUDGeneralSetting_pus_Info satDay = new PaymentUDGeneralSetting_pus_Info();


            sunInfo.pus_cBreakfast = cbxb0.Checked;

            sunInfo.pus_cLunch = cbxl0.Checked;

            sunInfo.pus_cDinner = cbxd0.Checked;

            sunInfo.pus_iWeek = 0;


            monInfo.pus_cBreakfast = cbxb1.Checked;

            monInfo.pus_cLunch = cbxl1.Checked;

            monInfo.pus_cDinner = cbxd1.Checked;

            monInfo.pus_iWeek = 1;


            tuesInfo.pus_cBreakfast = cbxb2.Checked;

            tuesInfo.pus_cLunch = cbxl2.Checked;

            tuesInfo.pus_cDinner = cbxd2.Checked;

            tuesInfo.pus_iWeek = 2;


            wednesDay.pus_cBreakfast = cbxb3.Checked;

            wednesDay.pus_cLunch = cbxl3.Checked;

            wednesDay.pus_cDinner = cbxd3.Checked;

            wednesDay.pus_iWeek = 3;


            thursDay.pus_cBreakfast = cbxb4.Checked;

            thursDay.pus_cLunch = cbxl4.Checked;

            thursDay.pus_cDinner = cbxd4.Checked;

            thursDay.pus_iWeek = 4;


            friDay.pus_cBreakfast = cbxb5.Checked;

            friDay.pus_cLunch = cbxl5.Checked;

            friDay.pus_cDinner = cbxd5.Checked;

            friDay.pus_iWeek = 5;


            satDay.pus_cBreakfast = cbxb6.Checked;

            satDay.pus_cLunch = cbxl6.Checked;

            satDay.pus_cDinner = cbxd6.Checked;

            satDay.pus_iWeek = 6;


            updateList.Add(sunInfo);

            updateList.Add(monInfo);

            updateList.Add(tuesInfo);

            updateList.Add(wednesDay);

            updateList.Add(thursDay);

            updateList.Add(friDay);

            updateList.Add(satDay);

            foreach (PaymentUDGeneralSetting_pus_Info item in updateList)
            {

                item.pus_cClassID = this._CurrentClassID;

                item.pus_cLast = this.UserInformation.usm_cUserLoginID;

            }

            try
            {
                ReturnValueInfo returnInfo = this._IPaymentUDGeneralSettingBL.Save(updateList);

                if (returnInfo.boolValue && !returnInfo.isError)
                {
                    ShowInformationMessage("保存成功。");
                }
                else
                {
                    ShowErrorMessage("保存失败。" + returnInfo.messageText);
                }
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }
        }

        private void btnNormalReset_Click(object sender, EventArgs e)
        {
            loadDefaultSetting();
            base.ShowInformationMessage("重置完毕。");
        }

        /// <summary>
        /// 加载自定义定餐设置
        /// </summary>
        void loadSpecialSettings()
        {
            PaymentUDMealState_pms_Info info = new PaymentUDMealState_pms_Info();

            info.pms_cClassID = new Guid(lvClassList.SelectedItems[0].SubItems[0].Text);

            try
            {
                List<PaymentUDMealState_pms_Info> allRecord = this._IPaymentUDMealStateBL.SearchRecords(info);
                if (allRecord != null)
                {
                    allRecord = allRecord.OrderByDescending(x => x.pms_dLastDate).ToList();
                }
                lvSpecialOrder.SetDataSource(allRecord);
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }
        }

        private void btnSpecialSave_Click(object sender, EventArgs e)
        {
            if (this._EditState == Common.DefineConstantValue.EditStateEnum.OE_Insert)
            {
                PaymentUDMealState_pms_Info info = new PaymentUDMealState_pms_Info();
                info.pms_dStartDate = DateTime.Parse(dtpStartDate.Value.ToString("yyyy/MM/dd"));
                info.pms_dEndDate = DateTime.Parse(dtpEndDate.Value.ToString("yyyy/MM/dd"));
                if (info.pms_dStartDate == info.pms_dEndDate)
                {
                    info.pms_dEndDate = info.pms_dEndDate.Value.AddSeconds(1);
                }
                info.pms_cBreakfast = cbxSBreakfast.Checked;
                info.pms_cLunch = cbxSLunch.Checked;
                info.pms_cDinner = cbxSDinner.Checked;
                info.pms_cClassID = this._CurrentClassID;
                info.pms_cAdd = this.UserInformation.usm_cUserLoginID;
                info.pms_cLast = this.UserInformation.usm_cUserLoginID;

                ReturnValueInfo returnInfo = this._IPaymentUDMealStateBL.Save(info, Common.DefineConstantValue.EditStateEnum.OE_Insert);
                if (returnInfo.boolValue && !returnInfo.isError)
                {
                    ShowInformationMessage("新增自定义定餐记录成功。");
                }
                else
                {
                    ShowErrorMessage("新增自定义定餐记录失败。" + returnInfo.messageText);
                }
            }
            else if (this._EditState == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                if (this._CurrentSettingID != null)
                {
                    PaymentUDMealState_pms_Info specialMeal = this._IPaymentUDMealStateBL.DisplayRecord(new PaymentUDMealState_pms_Info() { pms_cRecordID = this._CurrentSettingID.Value });
                    if (specialMeal != null)
                    {
                        specialMeal.pms_dStartDate = DateTime.Parse(dtpStartDate.Value.ToString("yyyy/MM/dd"));
                        specialMeal.pms_dEndDate = DateTime.Parse(dtpEndDate.Value.ToString("yyyy/MM/dd"));
                        if (specialMeal.pms_dStartDate == specialMeal.pms_dEndDate)
                        {
                            specialMeal.pms_dEndDate = specialMeal.pms_dEndDate.Value.AddSeconds(1);
                        }
                        specialMeal.pms_cBreakfast = cbxSBreakfast.Checked;
                        specialMeal.pms_cLunch = cbxSLunch.Checked;
                        specialMeal.pms_cDinner = cbxSDinner.Checked;
                        specialMeal.pms_cClassID = this._CurrentClassID;
                        specialMeal.pms_cLast = this.UserInformation.usm_cUserLoginID;

                        ReturnValueInfo returnInfo = this._IPaymentUDMealStateBL.Save(specialMeal, Common.DefineConstantValue.EditStateEnum.OE_Update);
                        if (returnInfo.boolValue && !returnInfo.isError)
                        {
                            ShowInformationMessage("修改自定义定餐记录成功。");
                        }
                        else
                        {
                            ShowErrorMessage("修改自定义定餐记录失败。" + returnInfo.messageText);
                        }
                    }
                }
            }

            loadSpecialSettings();

            ResetSpecialOrderForm();
        }

        /// <summary>
        /// 重置自定义定餐信息设置信息
        /// </summary>
        private void ResetSpecialOrderForm()
        {
            cbxSBreakfast.Checked = false;

            cbxSLunch.Checked = false;

            cbxSDinner.Checked = false;

            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;

            cbxSBreakfast.Enabled = false;
            cbxSBreakfast.Checked = false;

            cbxSLunch.Enabled = false;
            cbxSLunch.Checked = false;

            cbxSDinner.Enabled = false;
            cbxSDinner.Checked = false;

            btnSpecialSave.Enabled = false;
            btnSpecialAdd.Enabled = true;
            btnSpecialModify.Enabled = false;
            btnSpecialReset.Enabled = false;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = DateTime.Parse(dtpStartDate.Value.ToString("yyyy/MM/dd"));
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtpStartDate.MaxDate = DateTime.Parse(dtpEndDate.Value.ToString("yyyy/MM/dd"));
        }

        private void btnSpecialReset_Click(object sender, EventArgs e)
        {
            this._EditState = Common.DefineConstantValue.EditStateEnum.OE_ReaOnly;

            loadSpecialSettings();

            ResetSpecialOrderForm();
        }

        private void lvClassList_DoubleClick(object sender, EventArgs e)
        {
            if (lvClassList.SelectedItems != null && lvClassList.SelectedItems.Count > 0)
            {
                gbxNormal.Enabled = true;

                gbxSpecial.Enabled = true;

                initMealBookingDetail();
            }
        }

        private void btnSpecialAdd_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;

            cbxSBreakfast.Enabled = true;
            cbxSBreakfast.Checked = false;

            cbxSLunch.Enabled = true;
            cbxSLunch.Checked = false;

            cbxSDinner.Enabled = true;
            cbxSDinner.Checked = false;

            btnSpecialSave.Enabled = true;
            btnSpecialAdd.Enabled = false;
            btnSpecialReset.Enabled = true;
            btnSpecialModify.Enabled = false;

            this._EditState = Common.DefineConstantValue.EditStateEnum.OE_Insert;
        }

        private void btnSpecialModify_Click(object sender, EventArgs e)
        {
            if (this._CurrentSettingID != null)
            {
                PaymentUDMealState_pms_Info specialMeal = this._IPaymentUDMealStateBL.DisplayRecord(new PaymentUDMealState_pms_Info() { pms_cRecordID = this._CurrentSettingID.Value });
                if (specialMeal != null)
                {
                    if (dtpStartDate.MaxDate < specialMeal.pms_dStartDate.Value)
                    {
                        dtpStartDate.MaxDate = specialMeal.pms_dStartDate.Value;
                    }
                    dtpStartDate.Value = specialMeal.pms_dStartDate.Value;

                    if (dtpEndDate.MaxDate < specialMeal.pms_dEndDate.Value)
                    {
                        dtpEndDate.MaxDate = specialMeal.pms_dEndDate.Value;
                    }
                    dtpEndDate.Value = specialMeal.pms_dEndDate.Value;

                    cbxSBreakfast.Checked = specialMeal.pms_cBreakfast == true ? true : false;
                    cbxSLunch.Checked = specialMeal.pms_cLunch == true ? true : false;
                    cbxSDinner.Checked = specialMeal.pms_cDinner == true ? true : false;

                    dtpStartDate.Enabled = true;
                    dtpEndDate.Enabled = true;
                    cbxSBreakfast.Enabled = true;
                    cbxSLunch.Enabled = true;
                    cbxSDinner.Enabled = true;

                    btnSpecialSave.Enabled = true;
                    btnSpecialAdd.Enabled = false;
                    btnSpecialReset.Enabled = true;
                    btnSpecialModify.Enabled = false;
                    btnSpecialDel.Enabled = false;

                    this._EditState = Common.DefineConstantValue.EditStateEnum.OE_Update;

                    return;
                }
                else
                {
                    ShowErrorMessage("未找到合符条件的自定义定餐记录，记录ID为：" + this._CurrentSettingID.Value.ToString());
                }
            }
            else
            {
                ShowWarningMessage("未选定自定义定餐记录。");
            }

            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            cbxSBreakfast.Enabled = false;
            cbxSLunch.Enabled = false;
            cbxSDinner.Enabled = false;

            btnSpecialSave.Enabled = false;
            btnSpecialAdd.Enabled = true;
            btnSpecialReset.Enabled = false;
            btnSpecialModify.Enabled = false;
            btnSpecialDel.Enabled = false;

            loadSpecialSettings();
        }

        private void lvSpecialOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSpecialOrder.SelectedItems.Count > 0)
            {
                try
                {
                    string strID = lvSpecialOrder.SelectedItems[0].SubItems[0].Text;
                    Guid gRecordID = new Guid(strID);
                    this._CurrentSettingID = gRecordID;

                    btnSpecialModify.Enabled = true;
                    btnSpecialAdd.Enabled = false;
                    btnNormalSave.Enabled = false;
                    btnSpecialReset.Enabled = true;
                    btnSpecialDel.Enabled = true;
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex);
                }
            }
            else
            {
                this._CurrentSettingID = null;

                btnSpecialModify.Enabled = false; ;
                btnSpecialAdd.Enabled = true;
                btnNormalSave.Enabled = false;
                btnSpecialReset.Enabled = false;
                btnSpecialDel.Enabled = false;
            }
        }

        private void btnSpecialDel_Click(object sender, EventArgs e)
        {
            if (this._CurrentSettingID != null)
            {
                if (ShowQuestionMessage("是否确认需要删除此记录？"))
                {
                    PaymentUDMealState_pms_Info specialMeal = new PaymentUDMealState_pms_Info() { pms_cRecordID = this._CurrentSettingID.Value };
                    ReturnValueInfo rvInfo = this._IPaymentUDMealStateBL.Save(specialMeal, Common.DefineConstantValue.EditStateEnum.OE_Delete);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        ShowInformationMessage("删除自定义定餐记录成功。");
                    }
                    else
                    {
                        ShowErrorMessage("删除自定义定餐记录失败。" + rvInfo.messageText);
                    }
                }
            }
            else
            {
                ShowWarningMessage("未选定自定义定餐记录。");
            }

            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            cbxSBreakfast.Enabled = false;
            cbxSLunch.Enabled = false;
            cbxSDinner.Enabled = false;

            btnSpecialSave.Enabled = false;
            btnSpecialAdd.Enabled = true;
            btnSpecialReset.Enabled = false;
            btnSpecialModify.Enabled = false;
            btnSpecialDel.Enabled = false;

            loadSpecialSettings();
        }

        private void lvCLassList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvClassList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvClassList.ListViewItemSorter = sorter;
                lvClassList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvClassList.ListViewItemSorter = sorter;
                lvClassList.Sorting = SortOrder.Ascending;
            }
        }

        private void lvSpecialOrder_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvSpecialOrder.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvSpecialOrder.ListViewItemSorter = sorter;
                lvSpecialOrder.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvSpecialOrder.ListViewItemSorter = sorter;
                lvSpecialOrder.Sorting = SortOrder.Ascending;
            }
        }

        private void btnNormalDel_Click(object sender, EventArgs e)
        {
            if (ShowQuestionMessage("是否确认需要删除此班级默认定餐设置？"))
            {
                PaymentUDGeneralSetting_pus_Info delPlan = new PaymentUDGeneralSetting_pus_Info();
                delPlan.pus_cClassID = this._CurrentClassID;
                ReturnValueInfo rvInfo = this._IPaymentUDGeneralSettingBL.BatchDeleteRecords(delPlan);
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    loadDefaultSetting();
                    ShowInformationMessage("删除此班级默认定餐设置成功。");
                }
                else
                {
                    ShowErrorMessage("删除此班级默认定餐设置失败。" + rvInfo.messageText);
                }
            }
        }
    }
}
