namespace WindowUI.HHZX.Report
{
    partial class frmChangeCard
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
            this.rpvMain = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rspSearch = new WindowUI.HHZX.UserControls.ReportSearchPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.nbbNewCardNo = new WindowControls.HHZX.NumberBox();
            this.SuspendLayout();
            // 
            // rpvMain
            // 
            this.rpvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvMain.Location = new System.Drawing.Point(233, 1);
            this.rpvMain.Name = "rpvMain";
            this.rpvMain.Size = new System.Drawing.Size(668, 568);
            this.rpvMain.TabIndex = 2;
            // 
            // rspSearch
            // 
            this.rspSearch.Location = new System.Drawing.Point(1, 39);
            this.rspSearch.Name = "rspSearch";
            this.rspSearch.RSP_CardID = 0;
            this.rspSearch.RSP_CardNoVisible = false;
            this.rspSearch.RSP_ChaName = "";
            this.rspSearch.RSP_ChaNameVisible = false;
            this.rspSearch.RSP_ClassID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rspSearch.RSP_ClassName = "";
            this.rspSearch.RSP_ClassVisible = true;
            this.rspSearch.RSP_DepartmentName = "";
            this.rspSearch.RSP_DepartmentVisible = true;
            this.rspSearch.RSP_GradeID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rspSearch.RSP_GradeName = "";
            this.rspSearch.RSP_GradeVisible = false;
            this.rspSearch.RSP_StudentID = "";
            this.rspSearch.RSP_StudentVisible = false;
            this.rspSearch.RSP_TimeFrom = new System.DateTime(2013, 8, 9, 10, 18, 47, 227);
            this.rspSearch.RSP_TimeTo = new System.DateTime(2013, 8, 9, 10, 18, 47, 225);
            this.rspSearch.RSP_TimeVisible = true;
            this.rspSearch.Size = new System.Drawing.Size(230, 243);
            this.rspSearch.TabIndex = 3;
            this.rspSearch.OnShowReportClick += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "新卡号：";
            // 
            // nbbNewCardNo
            // 
            this.nbbNewCardNo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbbNewCardNo.Location = new System.Drawing.Point(82, 17);
            this.nbbNewCardNo.Name = "nbbNewCardNo";
            this.nbbNewCardNo.Size = new System.Drawing.Size(124, 21);
            this.nbbNewCardNo.TabIndex = 5;
            // 
            // frmChangeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 569);
            this.Controls.Add(this.nbbNewCardNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rspSearch);
            this.Controls.Add(this.rpvMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "换卡明细表";
            this.Tag = "换卡明细表";
            this.Text = "换卡明细表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvMain;
        private WindowUI.HHZX.UserControls.ReportSearchPanel rspSearch;
        private System.Windows.Forms.Label label1;
        private WindowControls.HHZX.NumberBox nbbNewCardNo;
    }
}