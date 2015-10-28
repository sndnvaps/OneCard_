namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmStaffMaster
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxStaffID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDeparment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxRes = new System.Windows.Forms.GroupBox();
            this.lvStaffList = new System.Windows.Forms.ListView();
            this.cus_cRecordID = new System.Windows.Forms.ColumnHeader();
            this.cus_cChaName = new System.Windows.Forms.ColumnHeader();
            this.cus_cStudentID = new System.Windows.Forms.ColumnHeader();
            this.SexName = new System.Windows.Forms.ColumnHeader();
            this.DepartmentName = new System.Windows.Forms.ColumnHeader();
            this.cus_cContractPhone = new System.Windows.Forms.ColumnHeader();
            this.cus_cRemark = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.gbxRes.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysToolBar
            // 
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
            this.sysToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(784, 23);
            this.sysToolBar.TabIndex = 0;
            this.sysToolBar.OnItemDelete_Click += new WindowControls.HBPMS.SystemToolBar.ItemDelete_Click(this.sysToolBar_OnItemDelete_Click);
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            this.sysToolBar.OnItemModify_Click += new WindowControls.HBPMS.SystemToolBar.ItemModify_Click(this.sysToolBar_OnItemModify_Click);
            this.sysToolBar.OnItemNew_Click += new WindowControls.HBPMS.SystemToolBar.ItemNew_Click(this.sysToolBar_OnItemNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Controls.Add(this.cbxSex);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbxName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbxStaffID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbxDeparment);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(0, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 530);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(40, 282);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(105, 28);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbxSex
            // 
            this.cbxSex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.Location = new System.Drawing.Point(14, 225);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(157, 20);
            this.cbxSex.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "性 别：";
            // 
            // tbxName
            // 
            this.tbxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxName.Location = new System.Drawing.Point(14, 167);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(157, 21);
            this.tbxName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "姓 名：";
            // 
            // tbxStaffID
            // 
            this.tbxStaffID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxStaffID.Location = new System.Drawing.Point(14, 109);
            this.tbxStaffID.Name = "tbxStaffID";
            this.tbxStaffID.Size = new System.Drawing.Size(157, 21);
            this.tbxStaffID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "工 号：";
            // 
            // cbxDeparment
            // 
            this.cbxDeparment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDeparment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDeparment.FormattingEnabled = true;
            this.cbxDeparment.Items.AddRange(new object[] {
            "行政部",
            "会计部",
            "财务部",
            "实训处",
            "体育部"});
            this.cbxDeparment.Location = new System.Drawing.Point(14, 52);
            this.cbxDeparment.Name = "cbxDeparment";
            this.cbxDeparment.Size = new System.Drawing.Size(157, 20);
            this.cbxDeparment.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部 门：";
            // 
            // gbxRes
            // 
            this.gbxRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRes.Controls.Add(this.lvStaffList);
            this.gbxRes.Location = new System.Drawing.Point(188, 29);
            this.gbxRes.Name = "gbxRes";
            this.gbxRes.Size = new System.Drawing.Size(596, 530);
            this.gbxRes.TabIndex = 0;
            this.gbxRes.TabStop = false;
            this.gbxRes.Text = "查询结果：共 0 条";
            // 
            // lvStaffList
            // 
            this.lvStaffList.CheckBoxes = true;
            this.lvStaffList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cus_cRecordID,
            this.cus_cChaName,
            this.cus_cStudentID,
            this.SexName,
            this.DepartmentName,
            this.cus_cContractPhone,
            this.cus_cRemark});
            this.lvStaffList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStaffList.Font = new System.Drawing.Font("SimSun", 12F);
            this.lvStaffList.FullRowSelect = true;
            this.lvStaffList.Location = new System.Drawing.Point(3, 17);
            this.lvStaffList.Name = "lvStaffList";
            this.lvStaffList.Size = new System.Drawing.Size(590, 510);
            this.lvStaffList.TabIndex = 3;
            this.lvStaffList.UseCompatibleStateImageBehavior = false;
            this.lvStaffList.View = System.Windows.Forms.View.Details;
            this.lvStaffList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvStaffList_MouseDoubleClick);
            this.lvStaffList.SelectedIndexChanged += new System.EventHandler(this.lvStaffList_SelectedIndexChanged);
            this.lvStaffList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvStaffList_ColumnClick);
            // 
            // cus_cRecordID
            // 
            this.cus_cRecordID.Tag = "cus_cRecordID";
            this.cus_cRecordID.Text = "ID";
            this.cus_cRecordID.Width = 0;
            // 
            // cus_cChaName
            // 
            this.cus_cChaName.Tag = "cus_cChaName";
            this.cus_cChaName.Text = "姓名";
            this.cus_cChaName.Width = 120;
            // 
            // cus_cStudentID
            // 
            this.cus_cStudentID.Tag = "cus_cStudentID";
            this.cus_cStudentID.Text = "工号";
            this.cus_cStudentID.Width = 120;
            // 
            // SexName
            // 
            this.SexName.Tag = "SexName";
            this.SexName.Text = "性别";
            // 
            // DepartmentName
            // 
            this.DepartmentName.Tag = "DepartmentName";
            this.DepartmentName.Text = "所属部门";
            this.DepartmentName.Width = 150;
            // 
            // cus_cContractPhone
            // 
            this.cus_cContractPhone.Tag = "cus_cContractPhone";
            this.cus_cContractPhone.Text = "联系电话";
            this.cus_cContractPhone.Width = 100;
            // 
            // cus_cRemark
            // 
            this.cus_cRemark.Tag = "cus_cRemark";
            this.cus_cRemark.Text = "备注";
            this.cus_cRemark.Width = 200;
            // 
            // frmStaffMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.gbxRes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmStaffMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "教师信息";
            this.Tag = "教师信息";
            this.Text = "教师信息";
            this.Load += new System.EventHandler(this.frmStaffMaster_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxRes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbxSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxStaffID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDeparment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxRes;
        private System.Windows.Forms.ListView lvStaffList;
        private System.Windows.Forms.ColumnHeader cus_cChaName;
        private System.Windows.Forms.ColumnHeader cus_cStudentID;
        private System.Windows.Forms.ColumnHeader DepartmentName;
        private System.Windows.Forms.ColumnHeader cus_cRecordID;
        private System.Windows.Forms.ColumnHeader SexName;
        private System.Windows.Forms.ColumnHeader cus_cContractPhone;
        private System.Windows.Forms.ColumnHeader cus_cRemark;
    }
}