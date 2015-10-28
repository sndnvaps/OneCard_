namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmDepartmentMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.lvDepartmentList = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.dpm_RecordID = new System.Windows.Forms.ColumnHeader();
            this.dpm_cName = new System.Windows.Forms.ColumnHeader();
            this.dpm_cRemark = new System.Windows.Forms.ColumnHeader();
            this.dpm_cLast = new System.Windows.Forms.ColumnHeader();
            this.dpm_dLastDate = new System.Windows.Forms.ColumnHeader();
            this.dpm_cAdd = new System.Windows.Forms.ColumnHeader();
            this.dpm_dAddDate = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // sysToolBar
            // 
            this.sysToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sysToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sysToolBar.BtnDelete_IsEnabled = false;
            this.sysToolBar.BtnDelete_IsUsed = true;
            this.sysToolBar.BtnDetail_IsEnabled = false;
            this.sysToolBar.BtnDetail_IsUsed = false;
            this.sysToolBar.BtnExit_IsEnabled = false;
            this.sysToolBar.BtnExit_IsUsed = false;
            this.sysToolBar.BtnModify_IsEnabled = false;
            this.sysToolBar.BtnModify_IsUsed = true;
            this.sysToolBar.BtnNew_IsEnabled = true;
            this.sysToolBar.BtnNew_IsUsed = true;
            this.sysToolBar.BtnRefresh_IsEnabled = true;
            this.sysToolBar.BtnRefresh_IsUsed = true;
            this.sysToolBar.BtnSave_IsEnabled = false;
            this.sysToolBar.BtnSave_IsUsed = false;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(784, 32);
            this.sysToolBar.TabIndex = 0;
            this.sysToolBar.OnItemDelete_Click += new WindowControls.HBPMS.SystemToolBar.ItemDelete_Click(this.sysToolBar_OnItemDelete_Click);
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            this.sysToolBar.OnItemModify_Click += new WindowControls.HBPMS.SystemToolBar.ItemModify_Click(this.sysToolBar_OnItemModify_Click);
            this.sysToolBar.OnItemNew_Click += new WindowControls.HBPMS.SystemToolBar.ItemNew_Click(this.sysToolBar_OnItemNew_Click);
            // 
            // lvDepartmentList
            // 
            this.lvDepartmentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDepartmentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.dpm_RecordID,
            this.dpm_cName,
            this.dpm_cRemark,
            this.dpm_cLast,
            this.dpm_dLastDate,
            this.dpm_cAdd,
            this.dpm_dAddDate});
            this.lvDepartmentList.Font = new System.Drawing.Font("宋体", 12F);
            this.lvDepartmentList.FullRowSelect = true;
            this.lvDepartmentList.Location = new System.Drawing.Point(0, 29);
            this.lvDepartmentList.Name = "lvDepartmentList";
            this.lvDepartmentList.Size = new System.Drawing.Size(784, 534);
            this.lvDepartmentList.TabIndex = 1;
            this.lvDepartmentList.UseCompatibleStateImageBehavior = false;
            this.lvDepartmentList.View = System.Windows.Forms.View.Details;
            this.lvDepartmentList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvDepartmentList_MouseDoubleClick);
            this.lvDepartmentList.SelectedIndexChanged += new System.EventHandler(this.lvDepartmentList_SelectedIndexChanged);
            this.lvDepartmentList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDepartmentList_ColumnClick);
            // 
            // ID
            // 
            this.ID.Tag = "ID";
            this.ID.Text = "ID";
            this.ID.Width = 0;
            // 
            // dpm_RecordID
            // 
            this.dpm_RecordID.DisplayIndex = 7;
            this.dpm_RecordID.Tag = "dpm_RecordID";
            this.dpm_RecordID.Text = "dpm_RecordID";
            this.dpm_RecordID.Width = 0;
            // 
            // dpm_cName
            // 
            this.dpm_cName.DisplayIndex = 1;
            this.dpm_cName.Tag = "dpm_cName";
            this.dpm_cName.Text = "部门名称";
            this.dpm_cName.Width = 204;
            // 
            // dpm_cRemark
            // 
            this.dpm_cRemark.DisplayIndex = 2;
            this.dpm_cRemark.Tag = "dpm_cRemark";
            this.dpm_cRemark.Text = "备注";
            this.dpm_cRemark.Width = 200;
            // 
            // dpm_cLast
            // 
            this.dpm_cLast.DisplayIndex = 3;
            this.dpm_cLast.Tag = "dpm_cLast";
            this.dpm_cLast.Text = "最后修改人";
            this.dpm_cLast.Width = 100;
            // 
            // dpm_dLastDate
            // 
            this.dpm_dLastDate.DisplayIndex = 4;
            this.dpm_dLastDate.Tag = "dpm_dLastDate";
            this.dpm_dLastDate.Text = "最后修改时间";
            this.dpm_dLastDate.Width = 180;
            // 
            // dpm_cAdd
            // 
            this.dpm_cAdd.DisplayIndex = 5;
            this.dpm_cAdd.Tag = "dpm_cAdd";
            this.dpm_cAdd.Text = "新增人";
            this.dpm_cAdd.Width = 100;
            // 
            // dpm_dAddDate
            // 
            this.dpm_dAddDate.DisplayIndex = 6;
            this.dpm_dAddDate.Tag = "dpm_dAddDate";
            this.dpm_dAddDate.Text = "新增时间";
            this.dpm_dAddDate.Width = 180;
            // 
            // frmDepartmentMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lvDepartmentList);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmDepartmentMaster";
            this.TabText = "部门信息";
            this.Tag = "部门信息";
            this.Text = "部门信息";
            this.Load += new System.EventHandler(this.frmDepartmentMaster_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.ListView lvDepartmentList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader dpm_cName;
        private System.Windows.Forms.ColumnHeader dpm_cRemark;
        private System.Windows.Forms.ColumnHeader dpm_cAdd;
        private System.Windows.Forms.ColumnHeader dpm_dAddDate;
        private System.Windows.Forms.ColumnHeader dpm_cLast;
        private System.Windows.Forms.ColumnHeader dpm_dLastDate;
        private System.Windows.Forms.ColumnHeader dpm_RecordID;
    }
}