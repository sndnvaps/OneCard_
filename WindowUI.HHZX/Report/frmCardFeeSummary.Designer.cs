namespace WindowUI.HHZX.Report
{
    partial class frmCardFeeSummary
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
            this.rsPanel = new WindowUI.HHZX.UserControls.ReportSearchPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.rsPanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 509);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rsPanel
            // 
            this.rsPanel.Location = new System.Drawing.Point(7, 12);
            this.rsPanel.Name = "rsPanel";
            this.rsPanel.RSP_CardID = 0;
            this.rsPanel.RSP_CardNoVisible = false;
            this.rsPanel.RSP_ChaName = "";
            this.rsPanel.RSP_ChaNameVisible = false;
            this.rsPanel.RSP_ClassID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rsPanel.RSP_ClassName = "";
            this.rsPanel.RSP_ClassVisible = false;
            this.rsPanel.RSP_DepartmentID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rsPanel.RSP_DepartmentName = "";
            this.rsPanel.RSP_DepartmentVisible = false;
            this.rsPanel.RSP_GradeID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rsPanel.RSP_GradeName = "";
            this.rsPanel.RSP_GradeVisible = false;
            this.rsPanel.RSP_MonthVisible = true;
            this.rsPanel.RSP_StudentID = "";
            this.rsPanel.RSP_StudentVisible = false;
            this.rsPanel.RSP_TimeFrom = new System.DateTime(2013, 10, 29, 0, 0, 0, 0);
            this.rsPanel.RSP_TimeTo = new System.DateTime(2013, 10, 29, 0, 0, 0, 0);
            this.rsPanel.RSP_TimeVisible = false;
            this.rsPanel.Size = new System.Drawing.Size(230, 134);
            this.rsPanel.TabIndex = 0;
            this.rsPanel.OnShowReportClick += new System.EventHandler(this.rsPanel_OnShowReportClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rptViewer);
            this.groupBox2.Location = new System.Drawing.Point(263, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 509);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(3, 17);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.Size = new System.Drawing.Size(604, 489);
            this.rptViewer.TabIndex = 0;
            // 
            // frmCardFeeSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 517);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCardFeeSummary";
            this.TabText = "饭卡汇总表";
            this.Text = "饭卡汇总表";
            this.Load += new System.EventHandler(this.frmCardFeeSummary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private WindowUI.HHZX.UserControls.ReportSearchPanel rsPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
    }
}