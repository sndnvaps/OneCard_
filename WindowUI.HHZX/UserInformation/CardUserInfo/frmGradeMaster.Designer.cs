namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmGradeMaster
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
            this.lvGradeList = new System.Windows.Forms.ListView();
            this.gdm_cRecordID = new System.Windows.Forms.ColumnHeader();
            this.gdm_cGradeName = new System.Windows.Forms.ColumnHeader();
            this.gdm_cAbbreviation = new System.Windows.Forms.ColumnHeader();
            this.gdm_cPraepostorName = new System.Windows.Forms.ColumnHeader();
            this.gdm_cPraepostorPhone = new System.Windows.Forms.ColumnHeader();
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.SuspendLayout();
            // 
            // lvGradeList
            // 
            this.lvGradeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGradeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gdm_cRecordID,
            this.gdm_cGradeName,
            this.gdm_cAbbreviation,
            this.gdm_cPraepostorName,
            this.gdm_cPraepostorPhone});
            this.lvGradeList.Font = new System.Drawing.Font("SimSun", 12F);
            this.lvGradeList.FullRowSelect = true;
            this.lvGradeList.Location = new System.Drawing.Point(0, 29);
            this.lvGradeList.MultiSelect = false;
            this.lvGradeList.Name = "lvGradeList";
            this.lvGradeList.Size = new System.Drawing.Size(784, 532);
            this.lvGradeList.TabIndex = 1;
            this.lvGradeList.UseCompatibleStateImageBehavior = false;
            this.lvGradeList.View = System.Windows.Forms.View.Details;
            this.lvGradeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvGradeList_MouseDoubleClick);
            this.lvGradeList.SelectedIndexChanged += new System.EventHandler(this.lvGradeList_SelectedIndexChanged);
            this.lvGradeList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvGradeList_ColumnClick);
            // 
            // gdm_cRecordID
            // 
            this.gdm_cRecordID.Tag = "gdm_cRecordID";
            this.gdm_cRecordID.Text = "ID";
            this.gdm_cRecordID.Width = 0;
            // 
            // gdm_cGradeName
            // 
            this.gdm_cGradeName.Tag = "gdm_cGradeName";
            this.gdm_cGradeName.Text = "年级名称";
            this.gdm_cGradeName.Width = 200;
            // 
            // gdm_cAbbreviation
            // 
            this.gdm_cAbbreviation.Tag = "gdm_cAbbreviation";
            this.gdm_cAbbreviation.Text = "年级简写";
            this.gdm_cAbbreviation.Width = 200;
            // 
            // gdm_cPraepostorName
            // 
            this.gdm_cPraepostorName.Tag = "gdm_cPraepostorName";
            this.gdm_cPraepostorName.Text = "级长";
            this.gdm_cPraepostorName.Width = 100;
            // 
            // gdm_cPraepostorPhone
            // 
            this.gdm_cPraepostorPhone.Tag = "gdm_cPraepostorPhone";
            this.gdm_cPraepostorPhone.Text = "级长联系电话";
            this.gdm_cPraepostorPhone.Width = 150;
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
            this.sysToolBar.TabIndex = 1;
            this.sysToolBar.OnItemDelete_Click += new WindowControls.HBPMS.SystemToolBar.ItemDelete_Click(this.sysToolBar_OnItemDelete_Click);
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            this.sysToolBar.OnItemModify_Click += new WindowControls.HBPMS.SystemToolBar.ItemModify_Click(this.sysToolBar_OnItemModify_Click);
            this.sysToolBar.OnItemNew_Click += new WindowControls.HBPMS.SystemToolBar.ItemNew_Click(this.sysToolBar_OnItemNew_Click);
            // 
            // frmGradeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lvGradeList);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmGradeMaster";
            this.TabText = "年級信息";
            this.Tag = "年級信息";
            this.Text = "年級信息";
            this.ToolTipText = "年級信息";
            this.Load += new System.EventHandler(this.frmGradeMaster_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvGradeList;
        private System.Windows.Forms.ColumnHeader gdm_cRecordID;
        private System.Windows.Forms.ColumnHeader gdm_cGradeName;
        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.ColumnHeader gdm_cPraepostorName;
        private System.Windows.Forms.ColumnHeader gdm_cPraepostorPhone;
        private System.Windows.Forms.ColumnHeader gdm_cAbbreviation;

        
    }
}