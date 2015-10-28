namespace WindowUI.HHZX.Report
{
    partial class frmDepositSummary
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
            this.rvMain = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportPanel = new WindowUI.HHZX.UserControls.ReportSearchPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rvMain
            // 
            this.rvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvMain.Location = new System.Drawing.Point(3, 17);
            this.rvMain.Name = "rvMain";
            this.rvMain.Size = new System.Drawing.Size(574, 506);
            this.rvMain.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.reportPanel);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 517);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // reportPanel
            // 
            this.reportPanel.Location = new System.Drawing.Point(6, 17);
            this.reportPanel.Name = "reportPanel";
            this.reportPanel.RSP_CardID = 0;
            this.reportPanel.RSP_CardNoVisible = false;
            this.reportPanel.RSP_ChaName = "";
            this.reportPanel.RSP_ChaNameVisible = false;
            this.reportPanel.RSP_ClassID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.reportPanel.RSP_ClassName = "";
            this.reportPanel.RSP_ClassVisible = true;
            this.reportPanel.RSP_DepartmentID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.reportPanel.RSP_DepartmentName = "";
            this.reportPanel.RSP_DepartmentVisible = true;
            this.reportPanel.RSP_GradeID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.reportPanel.RSP_GradeName = "";
            this.reportPanel.RSP_GradeVisible = false;
            this.reportPanel.RSP_MonthVisible = true;
            this.reportPanel.RSP_StudentID = "";
            this.reportPanel.RSP_StudentVisible = false;
            this.reportPanel.RSP_TimeFrom = new System.DateTime(2013, 10, 21, 0, 0, 0, 0);
            this.reportPanel.RSP_TimeTo = new System.DateTime(2013, 10, 21, 0, 0, 0, 0);
            this.reportPanel.RSP_TimeVisible = false;
            this.reportPanel.Size = new System.Drawing.Size(223, 204);
            this.reportPanel.TabIndex = 0;
            this.reportPanel.OnShowReportClick += new System.EventHandler(this.reportPanel_OnShowReportClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rvMain);
            this.groupBox2.Location = new System.Drawing.Point(244, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 526);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // frmDepositSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmDepositSummary";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "存款汇总表";
            this.Tag = "存款汇总表";
            this.Text = "存款汇总表";
            this.Load += new System.EventHandler(this.frmDepositSummary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private WindowUI.HHZX.UserControls.ReportSearchPanel reportPanel;
    }
}