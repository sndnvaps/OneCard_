namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmStudentMaster
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBatchModifyDetail = new System.Windows.Forms.Button();
            this.btnGrauduation = new System.Windows.Forms.Button();
            this.pnlQUeryArea = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxVaild = new System.Windows.Forms.CheckBox();
            this.tbxStudentID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxStudenName = new System.Windows.Forms.TextBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlFuncArea = new System.Windows.Forms.Panel();
            this.btnDataImport = new System.Windows.Forms.Button();
            this.btnImportGradeUp = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportGradeUp = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBatchmodify = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.gbxRes = new System.Windows.Forms.GroupBox();
            this.ckbSelectAll = new System.Windows.Forms.CheckBox();
            this.lvStudentList = new System.Windows.Forms.ListView();
            this.cus_cRecordID = new System.Windows.Forms.ColumnHeader();
            this.cus_cStudentID = new System.Windows.Forms.ColumnHeader();
            this.cus_cChaName = new System.Windows.Forms.ColumnHeader();
            this.ClassName = new System.Windows.Forms.ColumnHeader();
            this.cus_cComeYear = new System.Windows.Forms.ColumnHeader();
            this.cus_cGraduationPeriod = new System.Windows.Forms.ColumnHeader();
            this.IsGraduate = new System.Windows.Forms.ColumnHeader();
            this.cus_cContractName = new System.Windows.Forms.ColumnHeader();
            this.cus_cContractPhone = new System.Windows.Forms.ColumnHeader();
            this.cus_cBankAccount = new System.Windows.Forms.ColumnHeader();
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.bgWorkerInfoTemp = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.bgWorkerGradeUpTemp = new System.ComponentModel.BackgroundWorker();
            this.cus_cRemark = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.pnlQUeryArea.SuspendLayout();
            this.pnlFuncArea.SuspendLayout();
            this.gbxRes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnBatchModifyDetail);
            this.groupBox2.Controls.Add(this.btnGrauduation);
            this.groupBox2.Controls.Add(this.pnlQUeryArea);
            this.groupBox2.Controls.Add(this.pnlFuncArea);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.btnBatchmodify);
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Location = new System.Drawing.Point(0, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 528);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // btnBatchModifyDetail
            // 
            this.btnBatchModifyDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchModifyDetail.Location = new System.Drawing.Point(20, 208);
            this.btnBatchModifyDetail.Name = "btnBatchModifyDetail";
            this.btnBatchModifyDetail.Size = new System.Drawing.Size(100, 30);
            this.btnBatchModifyDetail.TabIndex = 29;
            this.btnBatchModifyDetail.Text = "批量修改信息";
            this.btnBatchModifyDetail.UseVisualStyleBackColor = true;
            this.btnBatchModifyDetail.Visible = false;
            this.btnBatchModifyDetail.Click += new System.EventHandler(this.btnBatchModifyDetail_Click);
            // 
            // btnGrauduation
            // 
            this.btnGrauduation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrauduation.Enabled = false;
            this.btnGrauduation.Location = new System.Drawing.Point(126, 208);
            this.btnGrauduation.Name = "btnGrauduation";
            this.btnGrauduation.Size = new System.Drawing.Size(100, 30);
            this.btnGrauduation.TabIndex = 27;
            this.btnGrauduation.Text = "毕业处理";
            this.btnGrauduation.UseVisualStyleBackColor = true;
            this.btnGrauduation.Visible = false;
            this.btnGrauduation.Click += new System.EventHandler(this.btnGrauduation_Click);
            // 
            // pnlQUeryArea
            // 
            this.pnlQUeryArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQUeryArea.Controls.Add(this.label2);
            this.pnlQUeryArea.Controls.Add(this.cboClass);
            this.pnlQUeryArea.Controls.Add(this.label3);
            this.pnlQUeryArea.Controls.Add(this.cbxVaild);
            this.pnlQUeryArea.Controls.Add(this.tbxStudentID);
            this.pnlQUeryArea.Controls.Add(this.label4);
            this.pnlQUeryArea.Controls.Add(this.tbxStudenName);
            this.pnlQUeryArea.Controls.Add(this.cboSex);
            this.pnlQUeryArea.Controls.Add(this.label5);
            this.pnlQUeryArea.Location = new System.Drawing.Point(7, 17);
            this.pnlQUeryArea.Name = "pnlQUeryArea";
            this.pnlQUeryArea.Size = new System.Drawing.Size(233, 141);
            this.pnlQUeryArea.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "班 级：";
            // 
            // cboClass
            // 
            this.cboClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Items.AddRange(new object[] {
            "一班",
            "二班",
            "三班"});
            this.cboClass.Location = new System.Drawing.Point(68, 6);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(143, 20);
            this.cboClass.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "学 号：";
            // 
            // cbxVaild
            // 
            this.cbxVaild.AutoSize = true;
            this.cbxVaild.Location = new System.Drawing.Point(134, 119);
            this.cbxVaild.Name = "cbxVaild";
            this.cbxVaild.Size = new System.Drawing.Size(60, 16);
            this.cbxVaild.TabIndex = 13;
            this.cbxVaild.Text = "已毕业";
            this.cbxVaild.UseVisualStyleBackColor = true;
            // 
            // tbxStudentID
            // 
            this.tbxStudentID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxStudentID.Location = new System.Drawing.Point(69, 43);
            this.tbxStudentID.Name = "tbxStudentID";
            this.tbxStudentID.Size = new System.Drawing.Size(143, 21);
            this.tbxStudentID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "姓 名：";
            // 
            // tbxStudenName
            // 
            this.tbxStudenName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxStudenName.Location = new System.Drawing.Point(67, 80);
            this.tbxStudenName.Name = "tbxStudenName";
            this.tbxStudenName.Size = new System.Drawing.Size(142, 21);
            this.tbxStudenName.TabIndex = 7;
            // 
            // cboSex
            // 
            this.cboSex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(67, 117);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(47, 20);
            this.cboSex.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "性 别：";
            // 
            // pnlFuncArea
            // 
            this.pnlFuncArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFuncArea.Controls.Add(this.btnDataImport);
            this.pnlFuncArea.Controls.Add(this.btnImportGradeUp);
            this.pnlFuncArea.Controls.Add(this.btnExport);
            this.pnlFuncArea.Controls.Add(this.btnExportGradeUp);
            this.pnlFuncArea.Location = new System.Drawing.Point(5, 423);
            this.pnlFuncArea.Name = "pnlFuncArea";
            this.pnlFuncArea.Size = new System.Drawing.Size(237, 73);
            this.pnlFuncArea.TabIndex = 27;
            // 
            // btnDataImport
            // 
            this.btnDataImport.Location = new System.Drawing.Point(122, 3);
            this.btnDataImport.Name = "btnDataImport";
            this.btnDataImport.Size = new System.Drawing.Size(100, 30);
            this.btnDataImport.TabIndex = 11;
            this.btnDataImport.Text = "学生信息导入";
            this.btnDataImport.UseVisualStyleBackColor = true;
            this.btnDataImport.Click += new System.EventHandler(this.btnDataImport_Click);
            // 
            // btnImportGradeUp
            // 
            this.btnImportGradeUp.Location = new System.Drawing.Point(121, 39);
            this.btnImportGradeUp.Name = "btnImportGradeUp";
            this.btnImportGradeUp.Size = new System.Drawing.Size(100, 30);
            this.btnImportGradeUp.TabIndex = 26;
            this.btnImportGradeUp.Text = "升年级信息导入";
            this.btnImportGradeUp.UseVisualStyleBackColor = true;
            this.btnImportGradeUp.Click += new System.EventHandler(this.btnImportGradeUp_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(16, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "导出学生模板";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportGradeUp
            // 
            this.btnExportGradeUp.Enabled = false;
            this.btnExportGradeUp.Location = new System.Drawing.Point(15, 39);
            this.btnExportGradeUp.Name = "btnExportGradeUp";
            this.btnExportGradeUp.Size = new System.Drawing.Size(100, 30);
            this.btnExportGradeUp.TabIndex = 12;
            this.btnExportGradeUp.Text = "导出升年级模板";
            this.btnExportGradeUp.UseVisualStyleBackColor = true;
            this.btnExportGradeUp.Click += new System.EventHandler(this.btnChangeClass_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 502);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 23);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // btnBatchmodify
            // 
            this.btnBatchmodify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchmodify.Enabled = false;
            this.btnBatchmodify.Location = new System.Drawing.Point(127, 172);
            this.btnBatchmodify.Name = "btnBatchmodify";
            this.btnBatchmodify.Size = new System.Drawing.Size(100, 30);
            this.btnBatchmodify.TabIndex = 11;
            this.btnBatchmodify.Text = "批量修改";
            this.btnBatchmodify.UseVisualStyleBackColor = true;
            this.btnBatchmodify.Click += new System.EventHandler(this.btnBatchmodify_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(20, 172);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 30);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查  询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // gbxRes
            // 
            this.gbxRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRes.Controls.Add(this.ckbSelectAll);
            this.gbxRes.Controls.Add(this.lvStudentList);
            this.gbxRes.Location = new System.Drawing.Point(252, 29);
            this.gbxRes.Name = "gbxRes";
            this.gbxRes.Size = new System.Drawing.Size(532, 531);
            this.gbxRes.TabIndex = 0;
            this.gbxRes.TabStop = false;
            this.gbxRes.Text = "查询结果：共 0 条";
            // 
            // ckbSelectAll
            // 
            this.ckbSelectAll.AutoSize = true;
            this.ckbSelectAll.Location = new System.Drawing.Point(9, 24);
            this.ckbSelectAll.Name = "ckbSelectAll";
            this.ckbSelectAll.Size = new System.Drawing.Size(15, 14);
            this.ckbSelectAll.TabIndex = 29;
            this.ckbSelectAll.UseVisualStyleBackColor = true;
            this.ckbSelectAll.Visible = false;
            this.ckbSelectAll.CheckedChanged += new System.EventHandler(this.ckbSelectAll_CheckedChanged);
            // 
            // lvStudentList
            // 
            this.lvStudentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cus_cRecordID,
            this.cus_cStudentID,
            this.cus_cChaName,
            this.ClassName,
            this.cus_cComeYear,
            this.cus_cGraduationPeriod,
            this.IsGraduate,
            this.cus_cContractName,
            this.cus_cContractPhone,
            this.cus_cBankAccount,
            this.cus_cRemark});
            this.lvStudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStudentList.Font = new System.Drawing.Font("SimSun", 12F);
            this.lvStudentList.FullRowSelect = true;
            this.lvStudentList.GridLines = true;
            this.lvStudentList.Location = new System.Drawing.Point(3, 17);
            this.lvStudentList.Name = "lvStudentList";
            this.lvStudentList.Size = new System.Drawing.Size(526, 511);
            this.lvStudentList.TabIndex = 3;
            this.lvStudentList.UseCompatibleStateImageBehavior = false;
            this.lvStudentList.View = System.Windows.Forms.View.Details;
            this.lvStudentList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvStudentList_MouseDoubleClick);
            this.lvStudentList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvStudentList_ItemChecked);
            this.lvStudentList.SelectedIndexChanged += new System.EventHandler(this.lvStudentList_SelectedIndexChanged);
            this.lvStudentList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvStudentList_ColumnClick);
            // 
            // cus_cRecordID
            // 
            this.cus_cRecordID.Tag = "cus_cRecordID";
            this.cus_cRecordID.Text = "";
            this.cus_cRecordID.Width = 0;
            // 
            // cus_cStudentID
            // 
            this.cus_cStudentID.Tag = "cus_cStudentID";
            this.cus_cStudentID.Text = "学号";
            this.cus_cStudentID.Width = 120;
            // 
            // cus_cChaName
            // 
            this.cus_cChaName.Tag = "cus_cChaName";
            this.cus_cChaName.Text = "姓名";
            this.cus_cChaName.Width = 80;
            // 
            // ClassName
            // 
            this.ClassName.Tag = "ClassName";
            this.ClassName.Text = "班级";
            this.ClassName.Width = 120;
            // 
            // cus_cComeYear
            // 
            this.cus_cComeYear.Tag = "cus_cComeYear";
            this.cus_cComeYear.Text = "入学时间";
            this.cus_cComeYear.Width = 0;
            // 
            // cus_cGraduationPeriod
            // 
            this.cus_cGraduationPeriod.Tag = "cus_cGraduationPeriod";
            this.cus_cGraduationPeriod.Text = "届别";
            this.cus_cGraduationPeriod.Width = 0;
            // 
            // IsGraduate
            // 
            this.IsGraduate.Tag = "IsGraduate";
            this.IsGraduate.Text = "是否已毕业";
            this.IsGraduate.Width = 100;
            // 
            // cus_cContractName
            // 
            this.cus_cContractName.Tag = "cus_cContractName";
            this.cus_cContractName.Text = "家长姓名";
            this.cus_cContractName.Width = 80;
            // 
            // cus_cContractPhone
            // 
            this.cus_cContractPhone.Tag = "cus_cContractPhone";
            this.cus_cContractPhone.Text = "家长电话";
            this.cus_cContractPhone.Width = 120;
            // 
            // cus_cBankAccount
            // 
            this.cus_cBankAccount.Tag = "cus_cBankAccount";
            this.cus_cBankAccount.Text = "银行账号";
            this.cus_cBankAccount.Width = 200;
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
            // bgWorkerInfoTemp
            // 
            this.bgWorkerInfoTemp.WorkerReportsProgress = true;
            this.bgWorkerInfoTemp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerInfoTemp_DoWork);
            this.bgWorkerInfoTemp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerInfoTemp_RunWorkerCompleted);
            this.bgWorkerInfoTemp.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerInfoTemp_ProgressChanged);
            // 
            // bgWorkerGradeUpTemp
            // 
            this.bgWorkerGradeUpTemp.WorkerReportsProgress = true;
            this.bgWorkerGradeUpTemp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerGradeUpTemp_DoWork);
            this.bgWorkerGradeUpTemp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerGradeUpTemp_RunWorkerCompleted);
            this.bgWorkerGradeUpTemp.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerGradeUpTemp_ProgressChanged);
            // 
            // cus_cRemark
            // 
            this.cus_cRemark.Tag = "cus_cRemark";
            this.cus_cRemark.Text = "备注";
            this.cus_cRemark.Width = 200;
            // 
            // frmStudentMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.gbxRes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmStudentMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "学生信息";
            this.Tag = "学生信息";
            this.Text = "学生信息";
            this.Load += new System.EventHandler(this.frmStudentMaster_Load);
            this.groupBox2.ResumeLayout(false);
            this.pnlQUeryArea.ResumeLayout(false);
            this.pnlQUeryArea.PerformLayout();
            this.pnlFuncArea.ResumeLayout(false);
            this.gbxRes.ResumeLayout(false);
            this.gbxRes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxStudentID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxStudenName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbxRes;
        private System.Windows.Forms.ListView lvStudentList;
        private System.Windows.Forms.Button btnBatchmodify;
        private System.Windows.Forms.Button btnDataImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportGradeUp;
        private System.Windows.Forms.ColumnHeader cus_cRecordID;
        private System.Windows.Forms.ColumnHeader cus_cStudentID;
        private System.Windows.Forms.ColumnHeader cus_cChaName;
        private System.Windows.Forms.ColumnHeader cus_cComeYear;
        private System.Windows.Forms.ColumnHeader cus_cGraduationPeriod;
        private System.Windows.Forms.ColumnHeader ClassName;
        private System.Windows.Forms.ColumnHeader IsGraduate;
        private System.Windows.Forms.CheckBox cbxVaild;
        private System.ComponentModel.BackgroundWorker bgWorkerInfoTemp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgWorkerGradeUpTemp;
        private System.Windows.Forms.Button btnImportGradeUp;
        private System.Windows.Forms.Panel pnlFuncArea;
        private System.Windows.Forms.Button btnGrauduation;
        private System.Windows.Forms.Panel pnlQUeryArea;
        private System.Windows.Forms.CheckBox ckbSelectAll;
        private System.Windows.Forms.Button btnBatchModifyDetail;
        private System.Windows.Forms.ColumnHeader cus_cContractName;
        private System.Windows.Forms.ColumnHeader cus_cContractPhone;
        private System.Windows.Forms.ColumnHeader cus_cBankAccount;
        private System.Windows.Forms.ColumnHeader cus_cRemark;
    }
}