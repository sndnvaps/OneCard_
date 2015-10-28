namespace WindowUI.HHZX.Report
{
    partial class frmStudentCostSummary
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
            this.tbxRechargeDay = new WindowControls.HHZX.NumberBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbExcept = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbxSupplement = new WindowControls.HHZX.NumberBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rsPanel = new WindowUI.HHZX.UserControls.ReportSearchPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvMain = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbxRechargeMonth = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.tbxRechargeMonth);
            this.groupBox1.Controls.Add(this.tbxRechargeDay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ckbExcept);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nbxSupplement);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rsPanel);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 481);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbxRechargeDay
            // 
            this.tbxRechargeDay.DecimalValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.tbxRechargeDay.Location = new System.Drawing.Point(155, 32);
            this.tbxRechargeDay.Name = "tbxRechargeDay";
            this.tbxRechargeDay.Size = new System.Drawing.Size(31, 21);
            this.tbxRechargeDay.TabIndex = 11;
            this.tbxRechargeDay.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "月";
            // 
            // ckbExcept
            // 
            this.ckbExcept.AutoSize = true;
            this.ckbExcept.Checked = true;
            this.ckbExcept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbExcept.Location = new System.Drawing.Point(87, 99);
            this.ckbExcept.Name = "ckbExcept";
            this.ckbExcept.Size = new System.Drawing.Size(132, 16);
            this.ckbExcept.TabIndex = 7;
            this.ckbExcept.Text = "不包含余额足够学生";
            this.ckbExcept.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "扣费日期：";
            // 
            // nbxSupplement
            // 
            this.nbxSupplement.DecimalValue = new decimal(new int[] {
            5000,
            0,
            0,
            131072});
            this.nbxSupplement.Location = new System.Drawing.Point(87, 63);
            this.nbxSupplement.Name = "nbxSupplement";
            this.nbxSupplement.Size = new System.Drawing.Size(124, 21);
            this.nbxSupplement.TabIndex = 2;
            this.nbxSupplement.Text = "50.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "补充预算：";
            // 
            // rsPanel
            // 
            this.rsPanel.Location = new System.Drawing.Point(6, 121);
            this.rsPanel.Name = "rsPanel";
            this.rsPanel.RSP_CardID = 0;
            this.rsPanel.RSP_CardNoVisible = false;
            this.rsPanel.RSP_ChaName = "";
            this.rsPanel.RSP_ChaNameVisible = true;
            this.rsPanel.RSP_ClassID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rsPanel.RSP_ClassName = "";
            this.rsPanel.RSP_ClassVisible = true;
            this.rsPanel.RSP_DepartmentID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rsPanel.RSP_DepartmentName = "";
            this.rsPanel.RSP_DepartmentVisible = false;
            this.rsPanel.RSP_GradeID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rsPanel.RSP_GradeName = "";
            this.rsPanel.RSP_GradeVisible = true;
            this.rsPanel.RSP_MonthVisible = false;
            this.rsPanel.RSP_SingleMonthVisible = true;
            this.rsPanel.RSP_StudentID = "";
            this.rsPanel.RSP_StudentVisible = true;
            this.rsPanel.RSP_TimeFrom = new System.DateTime(2013, 11, 26, 0, 0, 0, 0);
            this.rsPanel.RSP_TimeTo = new System.DateTime(2013, 11, 26, 0, 0, 0, 0);
            this.rsPanel.RSP_TimeVisible = false;
            this.rsPanel.Size = new System.Drawing.Size(230, 230);
            this.rsPanel.TabIndex = 0;
            this.rsPanel.OnShowReportClick += new System.EventHandler(this.rsPanel_OnShowReportClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rvMain);
            this.groupBox2.Location = new System.Drawing.Point(253, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 481);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rvMain
            // 
            this.rvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvMain.Location = new System.Drawing.Point(3, 17);
            this.rvMain.Name = "rvMain";
            this.rvMain.Size = new System.Drawing.Size(470, 461);
            this.rvMain.TabIndex = 0;
            // 
            // tbxRechargeMonth
            // 
            this.tbxRechargeMonth.Location = new System.Drawing.Point(87, 32);
            this.tbxRechargeMonth.Name = "tbxRechargeMonth";
            this.tbxRechargeMonth.Size = new System.Drawing.Size(38, 21);
            this.tbxRechargeMonth.TabIndex = 12;
            this.tbxRechargeMonth.Text = "本";
            // 
            // frmStudentCostSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 485);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmStudentCostSummary";
            this.TabText = "学生消费汇总表";
            this.Text = "学生消费汇总表";
            this.Load += new System.EventHandler(this.frmStudentCostSummary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private WindowUI.HHZX.UserControls.ReportSearchPanel rsPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvMain;
        private System.Windows.Forms.Label label1;
        private WindowControls.HHZX.NumberBox nbxSupplement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbExcept;
        private System.Windows.Forms.Label label4;
        private WindowControls.HHZX.NumberBox tbxRechargeDay;
        private System.Windows.Forms.TextBox tbxRechargeMonth;
    }
}