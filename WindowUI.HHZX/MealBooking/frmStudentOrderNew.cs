using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.HHZX.MealBooking;
using BLL.IBLL.General;
using BLL.Factory.General;
using BLL.Factory.HHZX;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.IModel;
using Model.HHZX.MealBooking;
using Model.General;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using PaymentEquipment.Entity;

namespace WindowUI.HHZX.MealBooking
{
    public partial class frmStudentOrderNew : BaseReaderForm
    {
        #region 自定义变量

        IPaymentUDMealStateBL _IPaymentUDMealStateBL;

        IPaymentUDGeneralSettingBL _IPaymentUDGeneralSettingBL;

        ICardUserMasterBL _ICardUserMasterBL;

        IGeneralBL _IGeneralBL;

        /// <summary>
        /// 当前在选的学生ID
        /// </summary>
        Guid _CurrentStudentID;

        /// <summary>
        /// 当前在选的停餐设置ID
        /// </summary>
        Guid? _CurrentSettingID;

        /// <summary>
        /// 学生默认设置缓存
        /// </summary>
        List<PaymentUDGeneralSetting_pus_Info> _TmpListDefaultGeneral;

        Common.DefineConstantValue.EditStateEnum _EditState;

        #endregion

        public frmStudentOrderNew()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this._IPaymentUDMealStateBL = MasterBLLFactory.GetBLL<IPaymentUDMealStateBL>(MasterBLLFactory.PaymentUDMealState);

            this._IPaymentUDGeneralSettingBL = MasterBLLFactory.GetBLL<IPaymentUDGeneralSettingBL>(MasterBLLFactory.PaymentUDGeneralSetting);

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);

            this._CurrentStudentID = Guid.Empty;

            this._EditState = Common.DefineConstantValue.EditStateEnum.OE_ReaOnly;

            ListViewSorter sorterGrade = new ListViewSorter(1, SortOrder.Ascending);
            lvStudentList.ListViewItemSorter = sorterGrade;
            lvStudentList.Sorting = SortOrder.Ascending;

            ListViewSorter sorterOrder = new ListViewSorter(1, SortOrder.Ascending);
            lvSpecialOrder.ListViewItemSorter = sorterOrder;
            lvSpecialOrder.Sorting = SortOrder.Ascending;

            labRecordTime.Text = "无记录";
        }

        /// <summary>
        /// 加载查询列表
        /// </summary>
        void loadStudentQueryInfo()
        {
            try
            {
                BindComboBox(Common.DefineConstantValue.MasterType.CardUserSex);
                BindComboBox(Common.DefineConstantValue.MasterType.UserClass);
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }
        }

        /// <summary>
        /// 绑定下拉框控件
        /// </summary>
        /// <param name="type"></param>
        private void BindComboBox(Common.DefineConstantValue.MasterType type)
        {
            try
            {
                List<Model.IModel.IModelObject> returnList = this._IGeneralBL.GetMasterDataInformations(type);

                switch (type)
                {
                    case Common.DefineConstantValue.MasterType.CardUserSex:

                        cbxSex.SetDataSource(returnList, 0);

                        cbxSex.SelectItemForValue(string.Empty);

                        break;

                    case Common.DefineConstantValue.MasterType.UserClass:

                        cbxClass.SetDataSource(returnList, 0);

                        cbxClass.SelectItemForValue(string.Empty);

                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }
        }

        private void frmGradeOrder_Load(object sender, EventArgs e)
        {
            gbxNormal.Enabled = false;

            gbxSpecial.Enabled = false;

            loadStudentQueryInfo();
        }

        private void lvGradeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStudentList.SelectedItems != null && lvStudentList.SelectedItems.Count > 0)
            {
                gbxNormal.Enabled = false;

                gbxSpecial.Enabled = false;

                initMealBookingDetail();
            }
        }

        /// <summary>
        /// 绑定对应年级的定餐信息详细
        /// </summary>
        private void initMealBookingDetail()
        {
            labDefaultUserName.Text = lvStudentList.SelectedItems[0].SubItems[1].Text + "-" + lvStudentList.SelectedItems[0].SubItems[3].Text; ;
            labSpecialUserName.Text = labDefaultUserName.Text;

            foreach (ListViewItem item in lvStudentList.Items)
            {
                item.BackColor = Color.White;
            }

            lvStudentList.SelectedItems[0].BackColor = Color.SteelBlue;

            loadDefaultSetting();

            loadSpecialSettings();

            this._CurrentStudentID = new Guid(lvStudentList.SelectedItems[0].SubItems[0].Text);
        }

        /// <summary>
        /// 加载默认定餐设置
        /// </summary>
        void loadDefaultSetting()
        {
            if (lvStudentList.SelectedItems != null && lvStudentList.SelectedItems.Count > 0)
            {
                PaymentUDGeneralSetting_pus_Info query = new PaymentUDGeneralSetting_pus_Info();

                query.pus_cCardUserID = new Guid(lvStudentList.SelectedItems[0].SubItems[0].Text);

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

                item.pus_cCardUserID = this._CurrentStudentID;

                item.pus_cAdd = this.UserInformation.usm_cUserLoginID;

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

            info.pms_cCardUserID = new Guid(lvStudentList.SelectedItems[0].SubItems[0].Text);

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
                info.pms_cCardUserID = this._CurrentStudentID;
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
                        specialMeal.pms_cCardUserID = this._CurrentStudentID;
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

        private void lvGradeList_DoubleClick(object sender, EventArgs e)
        {
            if (lvStudentList.SelectedItems != null && lvStudentList.SelectedItems.Count > 0)
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

        private void lvGradeList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvStudentList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvStudentList.ListViewItemSorter = sorter;
                lvStudentList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvStudentList.ListViewItemSorter = sorter;
                lvStudentList.Sorting = SortOrder.Ascending;
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                CardUserMaster_cus_Info query = new CardUserMaster_cus_Info();

                if (cbxClass.SelectedValue != null && !string.IsNullOrEmpty(cbxClass.Text))
                {
                    query.cus_cClassID = new Guid(cbxClass.SelectedValue.ToString());
                }

                if (cbxSex.SelectedValue != null && !string.IsNullOrEmpty(cbxSex.Text))
                {
                    query.cus_cSexNum = cbxSex.SelectedValue.ToString();
                }

                if (!string.IsNullOrEmpty(txtStudentID.Text))
                {
                    query.cus_cStudentID = txtStudentID.Text.Trim();
                }

                if (!string.IsNullOrEmpty(txtCName.Text))
                {
                    query.cus_cChaName = txtCName.Text.Trim();
                }

                query.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;

                List<CardUserMaster_cus_Info> returnList = new List<CardUserMaster_cus_Info>();

                if (!string.IsNullOrEmpty(nudCardNo.Text))
                {
                    query.PairCardNo = Convert.ToInt32(nudCardNo.Text);
                    returnList = this._ICardUserMasterBL.SearchRecordsWithCardInfo(query);
                }
                else
                {
                    returnList = this._ICardUserMasterBL.SearchRecord_ForMaster(query);
                }

                lvStudentList.SetDataSource(returnList);
                if (returnList == null || (returnList != null && returnList.Count < 1))
                {
                    base.ShowWarningMessage("没有符合条件的记录。");
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            ResetMealDetailControls();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 重置定餐详细
        /// </summary>
        void ResetMealDetailControls()
        {
            tclDetails.SelectedIndex = 0;
            gbxNormal.Enabled = false;
            gbxSpecial.Enabled = false;

            //早餐
            foreach (Control controlItem in pnlBreakfast.Controls)
            {
                CheckBox cbxTarget = controlItem as CheckBox;
                cbxTarget.Checked = false;
            }
            //午餐
            foreach (Control controlItem in pnlLunch.Controls)
            {
                CheckBox cbxTarget = controlItem as CheckBox;
                cbxTarget.Checked = false;
            }
            //晚餐
            foreach (Control controlItem in pnlSupper.Controls)
            {
                CheckBox cbxTarget = controlItem as CheckBox;
                cbxTarget.Checked = false;
            }

            dtpStartDate.MinDate = DateTime.MinValue;
            dtpStartDate.MaxDate = DateTime.Now.AddYears(1);
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.MaxDate = DateTime.Now.AddYears(1);
            dtpEndDate.Value = DateTime.Now.AddSeconds(1);
            cbxSBreakfast.Checked = false;
            cbxSLunch.Checked = false;
            cbxSDinner.Checked = false;
            btnSpecialAdd.Enabled = true;
            btnSpecialDel.Enabled = false;
            btnSpecialModify.Enabled = false;
            btnSpecialReset.Enabled = false;
            btnSpecialSave.Enabled = false;
            lvSpecialOrder.Items.Clear();
        }

        private void btnNormalDel_Click(object sender, EventArgs e)
        {
            if (ShowQuestionMessage("是否确认需要删除此学生默认定餐设置？"))
            {
                PaymentUDGeneralSetting_pus_Info delPlan = new PaymentUDGeneralSetting_pus_Info();
                delPlan.pus_cCardUserID = this._CurrentStudentID;
                ReturnValueInfo rvInfo = this._IPaymentUDGeneralSettingBL.BatchDeleteRecords(delPlan);
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    loadDefaultSetting();
                    ShowInformationMessage("删除此学生默认定餐设置成功。");
                }
                else
                {
                    ShowErrorMessage("删除此学生默认定餐设置失败。" + rvInfo.messageText);
                }
            }
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                bool resUkey = base.CheckUKey();
                if (!resUkey)
                {
                    return;
                }
                if (_IsConnected)
                {
                    this.Cursor = Cursors.WaitCursor;

                    ConsumeCardInfo cardInfo = base._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                    if (cardInfo != null)
                    {
                        this.nudCardNo.Text = cardInfo.CardNo;
                        btnQuery_Click(btnQuery, null);
                        if (lvStudentList.Items.Count == 1)
                        {
                            lvStudentList.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        base.ShowWarningMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");
                        this.nudCardNo.Text = string.Empty;
                        lvStudentList.Items.Clear();
                    }
                }
                else
                {
                    base.ShowErrorMessage("找不到读卡器，请确认读卡器是否已连接。");
                    this.nudCardNo.Text = string.Empty;
                    lvStudentList.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
