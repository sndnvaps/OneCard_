namespace WindowUI.HHZX.UserCard
{
    partial class dlgCardReturnCheck
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvStudentList = new System.Windows.Forms.ListView();
            this.Ext_RecordID = new System.Windows.Forms.ColumnHeader();
            this.Ext_IsPassed = new System.Windows.Forms.ColumnHeader();
            this.Ext_UserNum = new System.Windows.Forms.ColumnHeader();
            this.Ext_UserName = new System.Windows.Forms.ColumnHeader();
            this.Ext_GroupName = new System.Windows.Forms.ColumnHeader();
            this.Ext_CardNo = new System.Windows.Forms.ColumnHeader();
            this.Ext_PairTime = new System.Windows.Forms.ColumnHeader();
            this.Ext_CheckResult = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvStudentList);
            this.groupBox1.Location = new System.Drawing.Point(0, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 367);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "退卡详细";
            // 
            // lvStudentList
            // 
            this.lvStudentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ext_RecordID,
            this.Ext_IsPassed,
            this.Ext_UserNum,
            this.Ext_UserName,
            this.Ext_GroupName,
            this.Ext_CardNo,
            this.Ext_PairTime,
            this.Ext_CheckResult});
            this.lvStudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStudentList.Font = new System.Drawing.Font("宋体", 10F);
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
            // Ext_RecordID
            // 
            this.Ext_RecordID.Tag = "Ext_RecordID";
            this.Ext_RecordID.Text = "";
            this.Ext_RecordID.Width = 0;
            // 
            // Ext_IsPassed
            // 
            this.Ext_IsPassed.Tag = "Ext_IsPassed";
            this.Ext_IsPassed.Width = 0;
            // 
            // Ext_UserNum
            // 
            this.Ext_UserNum.Tag = "Ext_UserNum";
            this.Ext_UserNum.Text = "学号/工号";
            this.Ext_UserNum.Width = 100;
            // 
            // Ext_UserName
            // 
            this.Ext_UserName.Tag = "Ext_UserName";
            this.Ext_UserName.Text = "姓名";
            this.Ext_UserName.Width = 80;
            // 
            // Ext_GroupName
            // 
            this.Ext_GroupName.Tag = "Ext_GroupName";
            this.Ext_GroupName.Text = "班级/部门";
            this.Ext_GroupName.Width = 80;
            // 
            // Ext_CardNo
            // 
            this.Ext_CardNo.Tag = "Ext_CardNo";
            this.Ext_CardNo.Text = "持有卡号";
            this.Ext_CardNo.Width = 70;
            // 
            // Ext_PairTime
            // 
            this.Ext_PairTime.Tag = "Ext_PairTime";
            this.Ext_PairTime.Text = "发卡时间";
            this.Ext_PairTime.Width = 150;
            // 
            // Ext_CheckResult
            // 
            this.Ext_CheckResult.Tag = "Ext_CheckResult";
            this.Ext_CheckResult.Text = "检查结果";
            this.Ext_CheckResult.Width = 300;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(0, 378);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 34);
            this.panel1.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(522, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确认退卡";
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
            // dlgCardReturnCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgCardReturnCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "退卡检查";
            this.Tag = "退卡检查";
            this.Text = "退卡检查";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvStudentList;
        private System.Windows.Forms.ColumnHeader Ext_RecordID;
        private System.Windows.Forms.ColumnHeader Ext_UserNum;
        private System.Windows.Forms.ColumnHeader Ext_UserName;
        private System.Windows.Forms.ColumnHeader Ext_GroupName;
        private System.Windows.Forms.ColumnHeader Ext_CardNo;
        private System.Windows.Forms.ColumnHeader Ext_PairTime;
        private System.Windows.Forms.ColumnHeader Ext_CheckResult;
        private System.Windows.Forms.ColumnHeader Ext_IsPassed;
    }
}