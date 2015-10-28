namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmImportStudentData
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePatch = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labErrorMsg = new System.Windows.Forms.Label();
            this.lvStudentList = new System.Windows.Forms.ListView();
            this.CheckBool = new System.Windows.Forms.ColumnHeader();
            this.cus_cStudentID = new System.Windows.Forms.ColumnHeader();
            this.cus_cChaName = new System.Windows.Forms.ColumnHeader();
            this.cus_cSexName = new System.Windows.Forms.ColumnHeader();
            this.cus_cComeYear = new System.Windows.Forms.ColumnHeader();
            this.cus_cGraduationPeriod = new System.Windows.Forms.ColumnHeader();
            this.cus_cClassName = new System.Windows.Forms.ColumnHeader();
            this.cus_cContractName = new System.Windows.Forms.ColumnHeader();
            this.cus_cContractPhone = new System.Windows.Forms.ColumnHeader();
            this.cus_cRemark = new System.Windows.Forms.ColumnHeader();
            this.CheckString = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnSelectFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFilePatch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 38);
            this.panel1.TabIndex = 5;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(599, 8);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(73, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "确认导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnInport_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(520, 8);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(73, 23);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "浏览文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件路径";
            // 
            // txtFilePatch
            // 
            this.txtFilePatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePatch.Enabled = false;
            this.txtFilePatch.Location = new System.Drawing.Point(72, 9);
            this.txtFilePatch.Name = "txtFilePatch";
            this.txtFilePatch.Size = new System.Drawing.Size(442, 21);
            this.txtFilePatch.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 351);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(684, 23);
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labErrorMsg);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.lvStudentList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 374);
            this.panel2.TabIndex = 6;
            // 
            // labErrorMsg
            // 
            this.labErrorMsg.AutoSize = true;
            this.labErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labErrorMsg.Location = new System.Drawing.Point(3, 336);
            this.labErrorMsg.Name = "labErrorMsg";
            this.labErrorMsg.Size = new System.Drawing.Size(53, 12);
            this.labErrorMsg.TabIndex = 6;
            this.labErrorMsg.Text = "提示信息";
            this.labErrorMsg.Visible = false;
            // 
            // lvStudentList
            // 
            this.lvStudentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStudentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CheckBool,
            this.cus_cStudentID,
            this.cus_cChaName,
            this.cus_cSexName,
            this.cus_cComeYear,
            this.cus_cGraduationPeriod,
            this.cus_cClassName,
            this.cus_cContractName,
            this.cus_cContractPhone,
            this.cus_cRemark,
            this.CheckString});
            this.lvStudentList.FullRowSelect = true;
            this.lvStudentList.GridLines = true;
            this.lvStudentList.Location = new System.Drawing.Point(0, 0);
            this.lvStudentList.Name = "lvStudentList";
            this.lvStudentList.Size = new System.Drawing.Size(681, 374);
            this.lvStudentList.TabIndex = 5;
            this.lvStudentList.UseCompatibleStateImageBehavior = false;
            this.lvStudentList.View = System.Windows.Forms.View.Details;
            // 
            // CheckBool
            // 
            this.CheckBool.Tag = "CheckBool";
            this.CheckBool.Text = "验证布尔结果";
            this.CheckBool.Width = 0;
            // 
            // cus_cStudentID
            // 
            this.cus_cStudentID.Tag = "cus_cStudentID";
            this.cus_cStudentID.Text = "学号";
            this.cus_cStudentID.Width = 100;
            // 
            // cus_cChaName
            // 
            this.cus_cChaName.Tag = "cus_cChaName";
            this.cus_cChaName.Text = "姓名";
            // 
            // cus_cSexName
            // 
            this.cus_cSexName.Tag = "SexName";
            this.cus_cSexName.Text = "性别";
            this.cus_cSexName.Width = 50;
            // 
            // cus_cComeYear
            // 
            this.cus_cComeYear.Tag = "cus_cComeYear";
            this.cus_cComeYear.Text = "入学时间";
            // 
            // cus_cGraduationPeriod
            // 
            this.cus_cGraduationPeriod.Tag = "cus_cGraduationPeriod";
            this.cus_cGraduationPeriod.Text = "届别";
            // 
            // cus_cClassName
            // 
            this.cus_cClassName.Tag = "ClassName";
            this.cus_cClassName.Text = "班别";
            this.cus_cClassName.Width = 80;
            // 
            // cus_cContractName
            // 
            this.cus_cContractName.Tag = "cus_cContractName";
            this.cus_cContractName.Text = "联系人";
            // 
            // cus_cContractPhone
            // 
            this.cus_cContractPhone.Tag = "cus_cContractPhone";
            this.cus_cContractPhone.Text = "联系人电话";
            this.cus_cContractPhone.Width = 80;
            // 
            // cus_cRemark
            // 
            this.cus_cRemark.Tag = "cus_cRemark";
            this.cus_cRemark.Text = "备注";
            // 
            // CheckString
            // 
            this.CheckString.Tag = "CheckString";
            this.CheckString.Text = "验证结果";
            this.CheckString.Width = 300;
            // 
            // frmImportStudentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 412);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "frmImportStudentData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入学生数据";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePatch;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListView lvStudentList;
        private System.Windows.Forms.ColumnHeader cus_cStudentID;
        private System.Windows.Forms.ColumnHeader cus_cChaName;
        private System.Windows.Forms.ColumnHeader cus_cSexName;
        private System.Windows.Forms.ColumnHeader cus_cComeYear;
        private System.Windows.Forms.ColumnHeader cus_cGraduationPeriod;
        private System.Windows.Forms.ColumnHeader cus_cClassName;
        private System.Windows.Forms.ColumnHeader cus_cContractName;
        private System.Windows.Forms.ColumnHeader cus_cContractPhone;
        private System.Windows.Forms.ColumnHeader cus_cRemark;
        private System.Windows.Forms.ColumnHeader CheckString;
        private System.Windows.Forms.ColumnHeader CheckBool;
        private System.Windows.Forms.Label labErrorMsg;
    }
}