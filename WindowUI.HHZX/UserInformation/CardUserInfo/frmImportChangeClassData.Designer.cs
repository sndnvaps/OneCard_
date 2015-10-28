namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmImportChangeClassData
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
            this.labErrorMsg = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePatch = new System.Windows.Forms.TextBox();
            this.lvStudentList = new System.Windows.Forms.ListView();
            this.ccr_cCardUserMasterID = new System.Windows.Forms.ColumnHeader();
            this.VaildBool = new System.Windows.Forms.ColumnHeader();
            this.ccr_cCName = new System.Windows.Forms.ColumnHeader();
            this.ccr_cOldClassName = new System.Windows.Forms.ColumnHeader();
            this.ccr_cOldStudentID = new System.Windows.Forms.ColumnHeader();
            this.ccr_cClassName = new System.Windows.Forms.ColumnHeader();
            this.ccr_cStudentID = new System.Windows.Forms.ColumnHeader();
            this.VaildString = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
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
            this.panel1.TabIndex = 7;
            // 
            // labErrorMsg
            // 
            this.labErrorMsg.AutoSize = true;
            this.labErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labErrorMsg.Location = new System.Drawing.Point(3, 374);
            this.labErrorMsg.Name = "labErrorMsg";
            this.labErrorMsg.Size = new System.Drawing.Size(53, 12);
            this.labErrorMsg.TabIndex = 4;
            this.labErrorMsg.Text = "提示信息";
            this.labErrorMsg.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(603, 8);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(73, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "确认导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(524, 8);
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
            this.label1.Location = new System.Drawing.Point(8, 13);
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
            this.txtFilePatch.Location = new System.Drawing.Point(67, 9);
            this.txtFilePatch.Name = "txtFilePatch";
            this.txtFilePatch.Size = new System.Drawing.Size(451, 21);
            this.txtFilePatch.TabIndex = 0;
            // 
            // lvStudentList
            // 
            this.lvStudentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStudentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ccr_cCardUserMasterID,
            this.VaildBool,
            this.ccr_cCName,
            this.ccr_cOldClassName,
            this.ccr_cOldStudentID,
            this.ccr_cClassName,
            this.ccr_cStudentID,
            this.VaildString});
            this.lvStudentList.FullRowSelect = true;
            this.lvStudentList.GridLines = true;
            this.lvStudentList.Location = new System.Drawing.Point(3, 44);
            this.lvStudentList.Name = "lvStudentList";
            this.lvStudentList.Size = new System.Drawing.Size(678, 365);
            this.lvStudentList.TabIndex = 5;
            this.lvStudentList.UseCompatibleStateImageBehavior = false;
            this.lvStudentList.View = System.Windows.Forms.View.Details;
            this.lvStudentList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvStudentList_ColumnClick);
            // 
            // ccr_cCardUserMasterID
            // 
            this.ccr_cCardUserMasterID.Tag = "ccr_cCardUserMasterID";
            this.ccr_cCardUserMasterID.Width = 0;
            // 
            // VaildBool
            // 
            this.VaildBool.Tag = "ValidBool";
            this.VaildBool.Width = 0;
            // 
            // ccr_cCName
            // 
            this.ccr_cCName.Tag = "ccr_cCName";
            this.ccr_cCName.Text = "姓名";
            this.ccr_cCName.Width = 80;
            // 
            // ccr_cOldClassName
            // 
            this.ccr_cOldClassName.Tag = "ccr_cOldClassName";
            this.ccr_cOldClassName.Text = "原班级";
            this.ccr_cOldClassName.Width = 80;
            // 
            // ccr_cOldStudentID
            // 
            this.ccr_cOldStudentID.Tag = "ccr_cOldStudentID";
            this.ccr_cOldStudentID.Text = "原学号";
            this.ccr_cOldStudentID.Width = 80;
            // 
            // ccr_cClassName
            // 
            this.ccr_cClassName.Tag = "ccr_cClassName";
            this.ccr_cClassName.Text = "新班级";
            this.ccr_cClassName.Width = 80;
            // 
            // ccr_cStudentID
            // 
            this.ccr_cStudentID.Tag = "ccr_cStudentID";
            this.ccr_cStudentID.Text = "新学号";
            this.ccr_cStudentID.Width = 80;
            // 
            // VaildString
            // 
            this.VaildString.Tag = "VaildString";
            this.VaildString.Text = "验证";
            this.VaildString.Width = 237;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labErrorMsg);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.lvStudentList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 412);
            this.panel2.TabIndex = 8;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 389);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(684, 23);
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // frmImportChangeClassData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "frmImportChangeClassData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "导入升年级\\转班信息";
            this.Tag = "导入升年级\\转班信息";
            this.Text = "导入升年级\\转班信息";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePatch;
        private System.Windows.Forms.ListView lvStudentList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader ccr_cCardUserMasterID;
        private System.Windows.Forms.ColumnHeader ccr_cCName;
        private System.Windows.Forms.ColumnHeader ccr_cOldClassName;
        private System.Windows.Forms.ColumnHeader ccr_cClassName;
        private System.Windows.Forms.ColumnHeader ccr_cStudentID;
        private System.Windows.Forms.ColumnHeader VaildString;
        private System.Windows.Forms.Label labErrorMsg;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ColumnHeader VaildBool;
        private System.Windows.Forms.ColumnHeader ccr_cOldStudentID;
    }
}