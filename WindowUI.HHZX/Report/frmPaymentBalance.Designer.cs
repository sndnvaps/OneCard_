namespace WindowUI.HHZX.Report
{
    partial class frmPaymentBalance
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
            this.nbbMachenNo = new WindowControls.HHZX.NumberBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ckbMacRec = new System.Windows.Forms.CheckBox();
            this.ckbPreCostRec = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbUseTimeSpan = new System.Windows.Forms.CheckBox();
            this.pnlTimeSpan = new System.Windows.Forms.Panel();
            this.dtpTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlTimeSpan.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpvMain
            // 
            this.rpvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvMain.Location = new System.Drawing.Point(233, 0);
            this.rpvMain.Name = "rpvMain";
            this.rpvMain.Size = new System.Drawing.Size(624, 574);
            this.rpvMain.TabIndex = 4;
            // 
            // rspSearch
            // 
            this.rspSearch.Location = new System.Drawing.Point(1, 178);
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
            this.rspSearch.RSP_TimeFrom = new System.DateTime(2013, 10, 10, 0, 0, 0, 0);
            this.rspSearch.RSP_TimeTo = new System.DateTime(2013, 10, 10, 0, 0, 0, 0);
            this.rspSearch.RSP_TimeVisible = true;
            this.rspSearch.Size = new System.Drawing.Size(230, 271);
            this.rspSearch.TabIndex = 5;
            this.rspSearch.OnShowReportClick += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "机号：";
            // 
            // nbbMachenNo
            // 
            this.nbbMachenNo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbbMachenNo.Location = new System.Drawing.Point(134, 56);
            this.nbbMachenNo.Name = "nbbMachenNo";
            this.nbbMachenNo.Size = new System.Drawing.Size(89, 21);
            this.nbbMachenNo.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(5, 443);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 131);
            this.groupBox2.TabIndex = 8;
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
            this.richTextBox1.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Blue;
            this.richTextBox1.Location = new System.Drawing.Point(6, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(210, 100);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "1.金额为该次消费的金额，余额为当次消费后的卡余额。\n2.补扣记录包括定餐消费、新卡工本费、换卡工本费等系统后扣类型费用。";
            // 
            // ckbMacRec
            // 
            this.ckbMacRec.AutoSize = true;
            this.ckbMacRec.Checked = true;
            this.ckbMacRec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMacRec.Location = new System.Drawing.Point(12, 58);
            this.ckbMacRec.Name = "ckbMacRec";
            this.ckbMacRec.Size = new System.Drawing.Size(72, 16);
            this.ckbMacRec.TabIndex = 9;
            this.ckbMacRec.Text = "打卡记录";
            this.ckbMacRec.UseVisualStyleBackColor = true;
            this.ckbMacRec.CheckedChanged += new System.EventHandler(this.ckbMacRec_CheckedChanged);
            // 
            // ckbPreCostRec
            // 
            this.ckbPreCostRec.AutoSize = true;
            this.ckbPreCostRec.Checked = true;
            this.ckbPreCostRec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPreCostRec.Location = new System.Drawing.Point(12, 23);
            this.ckbPreCostRec.Name = "ckbPreCostRec";
            this.ckbPreCostRec.Size = new System.Drawing.Size(72, 16);
            this.ckbPreCostRec.TabIndex = 10;
            this.ckbPreCostRec.Text = "补扣记录";
            this.ckbPreCostRec.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbUseTimeSpan);
            this.groupBox1.Controls.Add(this.pnlTimeSpan);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // ckbUseTimeSpan
            // 
            this.ckbUseTimeSpan.AutoSize = true;
            this.ckbUseTimeSpan.Location = new System.Drawing.Point(5, 11);
            this.ckbUseTimeSpan.Name = "ckbUseTimeSpan";
            this.ckbUseTimeSpan.Size = new System.Drawing.Size(96, 16);
            this.ckbUseTimeSpan.TabIndex = 21;
            this.ckbUseTimeSpan.Text = "是否启用时段";
            this.ckbUseTimeSpan.UseVisualStyleBackColor = true;
            this.ckbUseTimeSpan.CheckedChanged += new System.EventHandler(this.ckbUseTimeSpan_CheckedChanged);
            // 
            // pnlTimeSpan
            // 
            this.pnlTimeSpan.Controls.Add(this.dtpTimeTo);
            this.pnlTimeSpan.Controls.Add(this.dtpTimeFrom);
            this.pnlTimeSpan.Enabled = false;
            this.pnlTimeSpan.Location = new System.Drawing.Point(74, 32);
            this.pnlTimeSpan.Name = "pnlTimeSpan";
            this.pnlTimeSpan.Size = new System.Drawing.Size(142, 62);
            this.pnlTimeSpan.TabIndex = 20;
            // 
            // dtpTimeTo
            // 
            this.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeTo.Location = new System.Drawing.Point(3, 37);
            this.dtpTimeTo.Name = "dtpTimeTo";
            this.dtpTimeTo.ShowUpDown = true;
            this.dtpTimeTo.Size = new System.Drawing.Size(125, 21);
            this.dtpTimeTo.TabIndex = 15;
            this.dtpTimeTo.Value = new System.DateTime(2013, 9, 26, 23, 59, 0, 0);
            // 
            // dtpTimeFrom
            // 
            this.dtpTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeFrom.Location = new System.Drawing.Point(2, 10);
            this.dtpTimeFrom.Name = "dtpTimeFrom";
            this.dtpTimeFrom.ShowUpDown = true;
            this.dtpTimeFrom.Size = new System.Drawing.Size(125, 21);
            this.dtpTimeFrom.TabIndex = 14;
            this.dtpTimeFrom.Value = new System.DateTime(2013, 9, 26, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "至：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "时段范围：";
            // 
            // frmPaymentBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 575);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ckbPreCostRec);
            this.Controls.Add(this.ckbMacRec);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nbbMachenNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rspSearch);
            this.Controls.Add(this.rpvMain);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmPaymentBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "消费明细表";
            this.Tag = "消费明细表";
            this.Text = "消费明细表";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlTimeSpan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvMain;
        private WindowUI.HHZX.UserControls.ReportSearchPanel rspSearch;
        private System.Windows.Forms.Label label1;
        private WindowControls.HHZX.NumberBox nbbMachenNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox ckbMacRec;
        private System.Windows.Forms.CheckBox ckbPreCostRec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlTimeSpan;
        private System.Windows.Forms.DateTimePicker dtpTimeTo;
        private System.Windows.Forms.DateTimePicker dtpTimeFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbUseTimeSpan;
    }
}