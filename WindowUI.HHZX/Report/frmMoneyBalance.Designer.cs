namespace WindowUI.HHZX.Report
{
    partial class frmMoneyBalance
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpvMain
            // 
            this.rpvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvMain.Location = new System.Drawing.Point(234, 0);
            this.rpvMain.Name = "rpvMain";
            this.rpvMain.Size = new System.Drawing.Size(657, 570);
            this.rpvMain.TabIndex = 3;
            // 
            // rspSearch
            // 
            this.rspSearch.Location = new System.Drawing.Point(2, 4);
            this.rspSearch.Name = "rspSearch";
            this.rspSearch.RSP_CardID = 0;
            this.rspSearch.RSP_CardNoVisible = false;
            this.rspSearch.RSP_ChaName = "";
            this.rspSearch.RSP_ChaNameVisible = true;
            this.rspSearch.RSP_ClassID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rspSearch.RSP_ClassName = "";
            this.rspSearch.RSP_ClassVisible = true;
            this.rspSearch.RSP_DepartmentID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rspSearch.RSP_DepartmentName = "";
            this.rspSearch.RSP_DepartmentVisible = true;
            this.rspSearch.RSP_GradeID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rspSearch.RSP_GradeName = "";
            this.rspSearch.RSP_GradeVisible = false;
            this.rspSearch.RSP_StudentID = "";
            this.rspSearch.RSP_StudentVisible = true;
            this.rspSearch.RSP_TimeFrom = new System.DateTime(2013, 9, 11, 0, 0, 0, 0);
            this.rspSearch.RSP_TimeTo = new System.DateTime(2013, 9, 11, 0, 0, 0, 0);
            this.rspSearch.RSP_TimeVisible = false;
            this.rspSearch.Size = new System.Drawing.Size(230, 216);
            this.rspSearch.TabIndex = 4;
            this.rspSearch.OnShowReportClick += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(2, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 175);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报表说明事项";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Blue;
            this.richTextBox1.Location = new System.Drawing.Point(6, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(210, 144);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "1.余额以结算时间的余额为准。";
            // 
            // frmMoneyBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rspSearch);
            this.Controls.Add(this.rpvMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmMoneyBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "帐户余额查询";
            this.Tag = "帐户余额查询";
            this.Text = "帐户余额查询";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvMain;
        private WindowUI.HHZX.UserControls.ReportSearchPanel rspSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}