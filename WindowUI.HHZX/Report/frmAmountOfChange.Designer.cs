namespace WindowUI.HHZX.Report
{
    partial class frmAmountOfChange
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
            this.chbPersonalRealTime = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbArther = new System.Windows.Forms.CheckBox();
            this.chbRechargeTransfer = new System.Windows.Forms.CheckBox();
            this.chbPersonalCash = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpvMain
            // 
            this.rpvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvMain.Location = new System.Drawing.Point(233, 1);
            this.rpvMain.Name = "rpvMain";
            this.rpvMain.Size = new System.Drawing.Size(648, 556);
            this.rpvMain.TabIndex = 2;
            // 
            // rspSearch
            // 
            this.rspSearch.Location = new System.Drawing.Point(1, 143);
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
            this.rspSearch.RSP_TimeFrom = new System.DateTime(2013, 9, 24, 0, 0, 0, 0);
            this.rspSearch.RSP_TimeTo = new System.DateTime(2013, 9, 24, 0, 0, 0, 0);
            this.rspSearch.RSP_TimeVisible = true;
            this.rspSearch.Size = new System.Drawing.Size(230, 273);
            this.rspSearch.TabIndex = 3;
            this.rspSearch.OnShowReportClick += new System.EventHandler(this.btnQuery_Click);
            // 
            // chbPersonalRealTime
            // 
            this.chbPersonalRealTime.AutoSize = true;
            this.chbPersonalRealTime.Checked = true;
            this.chbPersonalRealTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPersonalRealTime.Location = new System.Drawing.Point(70, 33);
            this.chbPersonalRealTime.Name = "chbPersonalRealTime";
            this.chbPersonalRealTime.Size = new System.Drawing.Size(72, 16);
            this.chbPersonalRealTime.TabIndex = 4;
            this.chbPersonalRealTime.Text = "实时充值";
            this.chbPersonalRealTime.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbArther);
            this.groupBox1.Controls.Add(this.chbRechargeTransfer);
            this.groupBox1.Controls.Add(this.chbPersonalCash);
            this.groupBox1.Controls.Add(this.chbPersonalRealTime);
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 130);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "款项类型";
            // 
            // chbArther
            // 
            this.chbArther.AutoSize = true;
            this.chbArther.Location = new System.Drawing.Point(70, 99);
            this.chbArther.Name = "chbArther";
            this.chbArther.Size = new System.Drawing.Size(72, 16);
            this.chbArther.TabIndex = 5;
            this.chbArther.Text = "其他款项";
            this.chbArther.UseVisualStyleBackColor = true;
            // 
            // chbRechargeTransfer
            // 
            this.chbRechargeTransfer.AutoSize = true;
            this.chbRechargeTransfer.Location = new System.Drawing.Point(70, 77);
            this.chbRechargeTransfer.Name = "chbRechargeTransfer";
            this.chbRechargeTransfer.Size = new System.Drawing.Size(72, 16);
            this.chbRechargeTransfer.TabIndex = 4;
            this.chbRechargeTransfer.Text = "转帐充值";
            this.chbRechargeTransfer.UseVisualStyleBackColor = true;
            // 
            // chbPersonalCash
            // 
            this.chbPersonalCash.AutoSize = true;
            this.chbPersonalCash.Checked = true;
            this.chbPersonalCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPersonalCash.Location = new System.Drawing.Point(70, 55);
            this.chbPersonalCash.Name = "chbPersonalCash";
            this.chbPersonalCash.Size = new System.Drawing.Size(72, 16);
            this.chbPersonalCash.TabIndex = 4;
            this.chbPersonalCash.Text = "现金退款";
            this.chbPersonalCash.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(5, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 134);
            this.groupBox2.TabIndex = 6;
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
            this.richTextBox1.Size = new System.Drawing.Size(210, 103);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "1.金额为该次增减款变动的金额，余额为当前帐户余额。";
            // 
            // frmAmountOfChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 558);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rspSearch);
            this.Controls.Add(this.rpvMain);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAmountOfChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "增减款明细";
            this.Tag = "增减款明细";
            this.Text = "增减款明细";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvMain;
        private WindowUI.HHZX.UserControls.ReportSearchPanel rspSearch;
        private System.Windows.Forms.CheckBox chbPersonalRealTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbPersonalCash;
        private System.Windows.Forms.CheckBox chbArther;
        private System.Windows.Forms.CheckBox chbRechargeTransfer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}