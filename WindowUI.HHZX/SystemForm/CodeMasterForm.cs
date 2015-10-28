using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.General;
using BLL.Factory.General;
using Common;
using Model.IModel;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.HHZX.UserInfomation;
using Model.SysMaster;
using BLL.IBLL.SysMaster;
using BLL.Factory.SysMaster;

namespace WindowUI.HHZX.SystemForm
{
    public partial class CodeMasterForm : BaseForm
    {
        private IGeneralBL _IGeneralBL;
        private ICodeMasterBL _ICodeMasterBL;
        private CodeMaster_cmt_Info _CmtInfo;

        public CodeMasterForm()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            this._ICodeMasterBL = MasterBLLFactory.GetBLL<ICodeMasterBL>(MasterBLLFactory.CodeMaster_cmt);

            BindCombox(DefineConstantValue.MasterType.CodeMaster_Key1, null);
        }

        private void BindCombox(DefineConstantValue.MasterType mType, string strKey)
        {
            List<IModelObject> listRes = new List<IModelObject>();
            try
            {
                if (strKey != null)
                {
                    listRes = this._IGeneralBL.GetMasterDataInformations(mType, strKey);
                }
                else
                {
                    listRes = this._IGeneralBL.GetMasterDataInformations(mType);
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }

            switch (mType)
            {
                case DefineConstantValue.MasterType.CodeMaster_Key1:
                    {
                        cboKey1.SetDataSource(listRes);
                        break;
                    }
                case DefineConstantValue.MasterType.CodeMaster_Key2:
                    {
                        cboKey2.SetDataSource(listRes);
                        break;
                    }
                default:
                    break;
            }
        }

        private void cbocKey1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboKey1.SelectedValue != null)
            {
                BindCombox(DefineConstantValue.MasterType.CodeMaster_Key2, cboKey1.SelectedValue.ToString());
            }
        }

        private void SetControlStatus(DefineConstantValue.EditStateEnum editState)
        {
            switch (editState)
            {
                case DefineConstantValue.EditStateEnum.OE_ReaOnly:
                    {
                        cboKey1.Enabled = false;
                        cboKey2.Enabled = false;
                        this.txtcValue.TextBoxSetStatus(true);
                        this.txtfNum.TextBoxSetStatus(true);
                        this.txtcRemark.TextBoxSetStatus(true);
                        this.txtcRemark2.TextBoxSetStatus(true);

                        this.ToolBar.BtnNewEnabled = true;
                        this.ToolBar.BtnModifyEnabled = true;
                        this.ToolBar.BtnDeleteEnabled = true;
                        this.ToolBar.BtnSaveEnabled = false;
                        this.ToolBar.BtnCancelEnabled = false;
                        this.ToolBar.BtnFirstEnabled = true;
                        this.ToolBar.BtnPreviousEnabled = true;
                        this.ToolBar.BtnNextEnabled = true;
                        this.ToolBar.BtnLastEnabled = true;
                        this.ToolBar.BtnSearchEnabled = true;
                        break;
                    }
                case DefineConstantValue.EditStateEnum.OE_Update:
                    {
                        cboKey1.Enabled = false;
                        cboKey2.Enabled = false;
                        this.txtcValue.TextBoxSetStatus(false);
                        this.txtfNum.TextBoxSetStatus(false);
                        this.txtcRemark.TextBoxSetStatus(false);
                        this.txtcRemark2.TextBoxSetStatus(false);

                        this.ToolBar.BtnNewEnabled = false;
                        this.ToolBar.BtnModifyEnabled = false;
                        this.ToolBar.BtnDeleteEnabled = false;
                        this.ToolBar.BtnSaveEnabled = true;
                        this.ToolBar.BtnCancelEnabled = true;
                        this.ToolBar.BtnFirstEnabled = false;
                        this.ToolBar.BtnPreviousEnabled = false;
                        this.ToolBar.BtnNextEnabled = false;
                        this.ToolBar.BtnLastEnabled = false;
                        this.ToolBar.BtnSearchEnabled = false;
                        break;
                    }
                case DefineConstantValue.EditStateEnum.OE_Insert:
                    {
                        cboKey1.Enabled = true;
                        cboKey2.Enabled = true;
                        this.txtcValue.TextBoxSetStatus(false);
                        this.txtfNum.TextBoxSetStatus(false);
                        this.txtcRemark.TextBoxSetStatus(false);
                        this.txtcRemark2.TextBoxSetStatus(false);

                        this.ToolBar.BtnNewEnabled = false;
                        this.ToolBar.BtnModifyEnabled = false;
                        this.ToolBar.BtnDeleteEnabled = false;
                        this.ToolBar.BtnSaveEnabled = true;
                        this.ToolBar.BtnCancelEnabled = true;
                        this.ToolBar.BtnFirstEnabled = false;
                        this.ToolBar.BtnPreviousEnabled = false;
                        this.ToolBar.BtnNextEnabled = false;
                        this.ToolBar.BtnLastEnabled = false;
                        this.ToolBar.BtnSearchEnabled = false;
                        break;
                    }
                default:
                    break;
            }
        }

        private void CodeMasterForm_Load(object sender, EventArgs e)
        {
            SetPurview(this.ToolBar);

            SetControlStatus(DefineConstantValue.EditStateEnum.OE_ReaOnly);

            try
            {
                this._CmtInfo = this._ICodeMasterBL.GetRecord_Last();
            }
            catch (Exception Ex)
            { ShowErrorMessage(Ex); }

            SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_Last);

            ShowData(_CmtInfo);

            if (_CmtInfo == null || _CmtInfo.cmt_iRecordID == 0)
            {
                SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_Null);
            }

        }

        /// <summary>
        /// 數據顯示
        /// </summary>
        /// <param name="cmtInfo">需要顯示的記錄</param>
        private void ShowData(CodeMaster_cmt_Info cmtInfo)
        {
            if (cmtInfo != null)
            {
                cboKey1.Text = cmtInfo.cmt_cKey1;
                cboKey2.Text = cmtInfo.cmt_cKey2;
                txtcValue.Text = cmtInfo.cmt_cValue;
                txtfNum.Text = cmtInfo.cmt_fNumber.ToString();
                txtcRemark.Text = cmtInfo.cmt_cRemark;
                txtcRemark2.Text = cmtInfo.cmt_cRemark2;
                txtcLast.Text = cmtInfo.cmt_cLast;

                txtcAdd.Text = cmtInfo.cmt_cAdd;
                try
                {
                    txtdAddDate.Text = ((cmtInfo.cmt_dAddDate != null) ? Convert.ToDateTime(cmtInfo.cmt_dAddDate).ToString(DefineConstantValue.gc_DateFormat) : string.Empty);

                    txtdLastDate.Text = ((cmtInfo.cmt_dLastDate != null) ? Convert.ToDateTime(cmtInfo.cmt_dLastDate).ToString(DefineConstantValue.gc_DateFormat) : string.Empty);
                }
                catch (Exception Ex)
                { ShowErrorMessage(Ex); }
            }
            else
            {
                cboKey1.Text = string.Empty;
                cboKey2.Text = string.Empty;
                txtcValue.Text = string.Empty;
                txtfNum.Text = string.Empty;
                txtcRemark.Text = string.Empty;
                txtcRemark2.Text = string.Empty;

                txtcAdd.Text = string.Empty;
                txtdAddDate.Text = string.Empty;
                txtcLast.Text = string.Empty;
                txtdLastDate.Text = string.Empty;
            }
        }

        /// <summary>
        /// 設置ToolBar狀態
        /// </summary>
        /// <param name="recordState">記錄顯示狀態</param>
        private void SetToolBarViewState(DefineConstantValue.GetReocrdEnum recordState)
        {
            switch (recordState)
            {
                case DefineConstantValue.GetReocrdEnum.GR_First:
                    {
                        ToolBar.BtnFirstEnabled = false;
                        ToolBar.BtnPreviousEnabled = false;
                        ToolBar.BtnNextEnabled = true;
                        ToolBar.BtnLastEnabled = true;
                        break;
                    }
                case DefineConstantValue.GetReocrdEnum.GR_Last:
                    {
                        ToolBar.BtnFirstEnabled = true;
                        ToolBar.BtnPreviousEnabled = true;
                        ToolBar.BtnNextEnabled = false;
                        ToolBar.BtnLastEnabled = false;
                        break;
                    }
                case DefineConstantValue.GetReocrdEnum.GR_Middle:
                    {
                        ToolBar.BtnFirstEnabled = true;
                        ToolBar.BtnPreviousEnabled = true;
                        ToolBar.BtnNextEnabled = true;
                        ToolBar.BtnLastEnabled = true;
                        break;
                    }
                case DefineConstantValue.GetReocrdEnum.GR_Null:
                    {
                        ToolBar.BtnFirstEnabled = false;
                        ToolBar.BtnPreviousEnabled = false;
                        ToolBar.BtnNextEnabled = false;
                        ToolBar.BtnLastEnabled = false;
                        break;
                    }
                default:
                    break;
            }
        }

        private void HandelResult_FirstOrLast(DefineConstantValue.GetReocrdEnum recordState)
        {
            try
            {
                switch (recordState)
                {
                    case DefineConstantValue.GetReocrdEnum.GR_First: _CmtInfo = _ICodeMasterBL.GetRecord_First();
                        break;
                    case DefineConstantValue.GetReocrdEnum.GR_Last: _CmtInfo = _ICodeMasterBL.GetRecord_Last();
                        break;
                    default: break;
                }

                SetToolBarViewState(recordState);

                ShowData(this._CmtInfo);
            }
            catch (Exception Ex)
            { ShowErrorMessage(Ex); }
        }

        private void HandelResult_PreviousOrNext(DefineConstantValue.GetReocrdEnum recordState)
        {
            CodeMaster_cmt_Info info = new CodeMaster_cmt_Info();
            try
            {
                Model.Base.DataBaseCommandInfo com = new Model.Base.DataBaseCommandInfo();
                switch (recordState)
                {
                    case DefineConstantValue.GetReocrdEnum.GR_Next: com.CommandType = Model.Base.DataBaseCommandType.Next;
                        break;
                    case DefineConstantValue.GetReocrdEnum.GR_Previous: com.CommandType = Model.Base.DataBaseCommandType.Previous;
                        break;
                    default:
                        break;
                }


                Model.Base.DataBaseCommandKeyInfo comKey = new Model.Base.DataBaseCommandKeyInfo();
                info = _CmtInfo;
                comKey.KeyValue = _CmtInfo.cmt_iRecordID.ToString();
                com.KeyInfoList.Add(comKey);

                switch (recordState)
                {
                    case DefineConstantValue.GetReocrdEnum.GR_Next:
                        _CmtInfo = _ICodeMasterBL.GetRecord_Next(com);
                        if (_CmtInfo != null)
                        {
                            SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_Middle);
                        }
                        else
                        {
                            SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_Last);
                            _CmtInfo = info;
                        }
                        break;
                    case DefineConstantValue.GetReocrdEnum.GR_Previous:
                        _CmtInfo = _ICodeMasterBL.GetRecord_Previous(com);
                        if (_CmtInfo != null)
                        {
                            SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_Middle);
                        }
                        else
                        {
                            SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_First);
                            _CmtInfo = info;
                        }
                        break;
                    default:
                        break;
                }

                //顯視數據處理
                ShowData(_CmtInfo);

            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }

        }

        private void ToolBar_BtnCancelClick(object sender, EventArgs e)
        {
            this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;
            SetControlStatus(DefineConstantValue.EditStateEnum.OE_ReaOnly);
            ShowData(_CmtInfo);
        }

        private void ToolBar_BtnDeleteClick(object sender, EventArgs e)
        {
            Model.General.ReturnValueInfo returnValue = new Model.General.ReturnValueInfo();
            CodeMaster_cmt_Info info = new CodeMaster_cmt_Info();
            Model.Base.DataBaseCommandInfo com = new Model.Base.DataBaseCommandInfo();
            info.cmt_iRecordID = _CmtInfo.cmt_iRecordID;
            returnValue = _ICodeMasterBL.Save(info, DefineConstantValue.EditStateEnum.OE_Delete);
            if (returnValue.boolValue)
            {
                com.CommandType = Model.Base.DataBaseCommandType.Next;
                Model.Base.DataBaseCommandKeyInfo comKey = new Model.Base.DataBaseCommandKeyInfo();
                comKey.KeyValue = info.cmt_iRecordID.ToString();
                com.KeyInfoList.Add(comKey);
                try
                {
                    _CmtInfo = _ICodeMasterBL.GetRecord_Next(com);
                }
                catch (Exception Ex)
                {
                    ShowErrorMessage(Ex);
                }
                if (_CmtInfo == null)
                {
                    com.CommandType = Model.Base.DataBaseCommandType.Previous;
                    try
                    {
                        _CmtInfo = _ICodeMasterBL.GetRecord_Previous(com);
                    }
                    catch (Exception Ex)
                    {
                        ShowErrorMessage(Ex);
                    }
                    ShowData(_CmtInfo);
                    this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    SetControlStatus(DefineConstantValue.EditStateEnum.OE_ReaOnly);
                    SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_Last);
                    if (_CmtInfo == null)
                    {
                        cboKey1.Text = string.Empty;
                        SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_Null);
                    }
                }
            }

        }

        private void ToolBar_BtnFirstClick(object sender, EventArgs e)
        {
            HandelResult_FirstOrLast(DefineConstantValue.GetReocrdEnum.GR_First);
        }

        private void ToolBar_BtnLastClick(object sender, EventArgs e)
        {
            HandelResult_FirstOrLast(DefineConstantValue.GetReocrdEnum.GR_Last);
        }

        private void ToolBar_BtnModifyClick(object sender, EventArgs e)
        {
            SetControlStatus(DefineConstantValue.EditStateEnum.OE_Update);
            this.EditState = DefineConstantValue.EditStateEnum.OE_Update;
        }

        private void ToolBar_BtnNewClick(object sender, EventArgs e)
        {
            SetControlStatus(DefineConstantValue.EditStateEnum.OE_Insert);
            this.EditState = DefineConstantValue.EditStateEnum.OE_Insert;
            CodeMaster_cmt_Info info = new CodeMaster_cmt_Info();

            //重置表格
            ShowData(info);
            cboKey1.Text = string.Empty;
        }

        private void ToolBar_BtnNextClick(object sender, EventArgs e)
        {
            HandelResult_PreviousOrNext(DefineConstantValue.GetReocrdEnum.GR_Next);
        }

        private void ToolBar_BtnPreviousClick(object sender, EventArgs e)
        {
            HandelResult_PreviousOrNext(DefineConstantValue.GetReocrdEnum.GR_Previous);
        }

        private void ToolBar_BtnSaveClick(object sender, EventArgs e)
        {
            CodeMaster_cmt_Info info = new CodeMaster_cmt_Info();
            info.cmt_cKey1 = cboKey1.Text;
            info.cmt_cKey2 = cboKey2.Text;
            info.cmt_cValue = txtcValue.Text;
            info.cmt_fNumber = Convert.ToDecimal(txtfNum.Text);
            info.cmt_cRemark = txtcRemark.Text;
            info.cmt_cRemark2 = txtcRemark2.Text;

            info.cmt_cAdd = UserInformation.usm_cUserLoginID;
            info.cmt_dAddDate = DateTime.Now;
            info.cmt_cLast = UserInformation.usm_cUserLoginID;
            info.cmt_dLastDate = DateTime.Now;
            switch (this.EditState)
            {
                case DefineConstantValue.EditStateEnum.OE_Insert:
                    SaveSub(info);
                    break;
                case DefineConstantValue.EditStateEnum.OE_Update:
                    info.cmt_iRecordID = _CmtInfo.cmt_iRecordID;
                    UpdateSub(info);
                    break;
                default:
                    break;
            }

        }

        private void SaveSub(CodeMaster_cmt_Info info)
        {
            try
            {
                Model.General.ReturnValueInfo returnValue = new Model.General.ReturnValueInfo();
                returnValue = _ICodeMasterBL.Save(info, DefineConstantValue.EditStateEnum.OE_Insert);
                if (returnValue.boolValue)
                {
                    BindCombox(DefineConstantValue.MasterType.CodeMaster_Key1, null);
                    _CmtInfo = _ICodeMasterBL.GetRecord_Last();
                    SetControlStatus(DefineConstantValue.EditStateEnum.OE_ReaOnly);
                    this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;

                    ShowData(_CmtInfo);
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
        }

        private void UpdateSub(CodeMaster_cmt_Info info)
        {
            try
            {
                Model.General.ReturnValueInfo returnValue = new Model.General.ReturnValueInfo();
                returnValue = _ICodeMasterBL.Save(info, DefineConstantValue.EditStateEnum.OE_Update);
                if (returnValue.boolValue)
                {
                    SetControlStatus(DefineConstantValue.EditStateEnum.OE_ReaOnly);
                    this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
        }

        private void ToolBar_BtnSearchClick(object sender, EventArgs e)
        {
            CodeMasterFormSearch win = new CodeMasterFormSearch();
            win.ShowForm(_CmtInfo);
            if (win.DialogResult == DialogResult.OK)
            {
                ShowData(_CmtInfo);
                SetToolBarViewState(DefineConstantValue.GetReocrdEnum.GR_Middle);
            }
            win.Dispose();
            win = null;
        }
    }
}
