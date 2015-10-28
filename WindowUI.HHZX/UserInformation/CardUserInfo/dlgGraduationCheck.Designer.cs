namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class dlgGraduationCheck
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvStudentList = new System.Windows.Forms.ListView();
            this.cus_cRecordID = new System.Windows.Forms.ColumnHeader();
            this.CheckBool = new System.Windows.Forms.ColumnHeader();
            this.cus_cStudentID = new System.Windows.Forms.ColumnHeader();
            this.cus_cChaName = new System.Windows.Forms.ColumnHeader();
            this.ClassName = new System.Windows.Forms.ColumnHeader();
            this.CheckString = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(0, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 34);
            this.panel1.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(500, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(97, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确认毕业处理";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(603, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvStudentList);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 367);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "确认信息";
            // 
            // lvStudentList
            // 
            this.lvStudentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cus_cRecordID,
            this.CheckBool,
            this.cus_cStudentID,
            this.cus_cChaName,
            this.ClassName,
            this.CheckString});
            this.lvStudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStudentList.Font = new System.Drawing.Font("SimSun", 10F);
            this.lvStudentList.FullRowSelect = true;
            this.lvStudentList.GridLines = true;
            this.lvStudentList.Location = new System.Drawing.Point(3, 17);
            this.lvStudentList.MultiSelect = false;
            this.lvStudentList.Name = "lvStudentList";
            this.lvStudentList.Size = new System.Drawing.Size(678, 347);
            this.lvStudentList.TabIndex = 4;
            this.lvStudentList.UseCompatibleStateImageBehavior = false;
            this.lvStudentList.View = System.Windows.Forms.View.Details;
            // 
            // cus_cRecordID
            // 
            this.cus_cRecordID.Tag = "cus_cRecordID";
            this.cus_cRecordID.Text = "";
            this.cus_cRecordID.Width = 0;
            // 
            // CheckBool
            // 
            this.CheckBool.Tag = "CheckBool";
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
            this.cus_cChaName.Width = 80;
            // 
            // ClassName
            // 
            this.ClassName.Tag = "ClassName";
            this.ClassName.Text = "班级";
            this.ClassName.Width = 120;
            // 
            // CheckString
            // 
            this.CheckString.Tag = "CheckString";
            this.CheckString.Text = "检查结果";
            this.CheckString.Width = 300;
            // 
            // dlgGraduationCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgGraduationCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "毕业信息确认";
            this.Tag = "毕业信息确认";
            this.Text = "毕业信息确认";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvStudentList;
        private System.Windows.Forms.ColumnHeader cus_cRecordID;
        private System.Windows.Forms.ColumnHeader CheckBool;
        private System.Windows.Forms.ColumnHeader cus_cStudentID;
        private System.Windows.Forms.ColumnHeader cus_cChaName;
        private System.Windows.Forms.ColumnHeader ClassName;
        private System.Windows.Forms.ColumnHeader CheckString;
    }
}