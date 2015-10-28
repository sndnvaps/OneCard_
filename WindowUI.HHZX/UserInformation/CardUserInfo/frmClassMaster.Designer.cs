namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmClassMaster
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
            this.lvClassList = new System.Windows.Forms.ListView();
            this.csm_cRecordID = new System.Windows.Forms.ColumnHeader();
            this.csm_cClassName = new System.Windows.Forms.ColumnHeader();
            this.csm_cMasterName = new System.Windows.Forms.ColumnHeader();
            this.csm_cRemark = new System.Windows.Forms.ColumnHeader();
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
            this.sysToolBar.Size = new System.Drawing.Size(784, 34);
            this.sysToolBar.TabIndex = 0;
            this.sysToolBar.OnItemDelete_Click += new WindowControls.HBPMS.SystemToolBar.ItemDelete_Click(this.sysToolBar_OnItemDelete_Click);
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            this.sysToolBar.OnItemModify_Click += new WindowControls.HBPMS.SystemToolBar.ItemModify_Click(this.sysToolBar_OnItemModify_Click);
            this.sysToolBar.OnItemNew_Click += new WindowControls.HBPMS.SystemToolBar.ItemNew_Click(this.sysToolBar_OnItemNew_Click);
            // 
            // lvClassList
            // 
            this.lvClassList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvClassList.CheckBoxes = true;
            this.lvClassList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.csm_cRecordID,
            this.csm_cClassName,
            this.csm_cMasterName,
            this.csm_cRemark});
            this.lvClassList.Font = new System.Drawing.Font("SimSun", 12F);
            this.lvClassList.FullRowSelect = true;
            this.lvClassList.GridLines = true;
            this.lvClassList.Location = new System.Drawing.Point(0, 29);
            this.lvClassList.MultiSelect = false;
            this.lvClassList.Name = "lvClassList";
            this.lvClassList.Size = new System.Drawing.Size(784, 532);
            this.lvClassList.TabIndex = 1;
            this.lvClassList.UseCompatibleStateImageBehavior = false;
            this.lvClassList.View = System.Windows.Forms.View.Details;
            this.lvClassList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvClassList_MouseDoubleClick);
            this.lvClassList.SelectedIndexChanged += new System.EventHandler(this.lvClassList_SelectedIndexChanged);
            this.lvClassList.DoubleClick += new System.EventHandler(this.lvClassList_DoubleClick);
            this.lvClassList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvClassList_ColumnClick);
            // 
            // csm_cRecordID
            // 
            this.csm_cRecordID.Tag = "csm_cRecordID";
            this.csm_cRecordID.Text = "ID";
            this.csm_cRecordID.Width = 0;
            // 
            // csm_cClassName
            // 
            this.csm_cClassName.Tag = "csm_cClassName";
            this.csm_cClassName.Text = "班别";
            this.csm_cClassName.Width = 180;
            // 
            // csm_cMasterName
            // 
            this.csm_cMasterName.Tag = "csm_cMasterName";
            this.csm_cMasterName.Text = "班主任";
            this.csm_cMasterName.Width = 180;
            // 
            // csm_cRemark
            // 
            this.csm_cRemark.Tag = "csm_cRemark";
            this.csm_cRemark.Text = "备注";
            this.csm_cRemark.Width = 250;
            // 
            // frmClassMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lvClassList);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmClassMaster";
            this.TabText = "班级信息";
            this.Tag = "班级信息";
            this.Text = "班级信息";
            this.Load += new System.EventHandler(this.frmClassMaster_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.ListView lvClassList;
        private System.Windows.Forms.ColumnHeader csm_cRecordID;
        private System.Windows.Forms.ColumnHeader csm_cClassName;
        private System.Windows.Forms.ColumnHeader csm_cMasterName;
        private System.Windows.Forms.ColumnHeader csm_cRemark;
    }
}