namespace WindowUI.HHZX.Report
{
    partial class frmDepartmentBalance
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
            this.rspSearch = new WindowUI.HHZX.UserControls.ReportSearchPanel();
            this.rpvMain = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nbxOrtherIncome = new WindowControls.HHZX.NumberBox();
            this.nbxHotIncome = new WindowControls.HHZX.NumberBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveOIncome = new System.Windows.Forms.Button();
            this.btnDeleteOIncome = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOrtherIncome = new System.Windows.Forms.Label();
            this.btnQueryOIncome = new System.Windows.Forms.Button();
            this.lblHotWaterIncome = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOrderIncome = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rspSearch
            // 
            this.rspSearch.Location = new System.Drawing.Point(0, 12);
            this.rspSearch.Name = "rspSearch";
            this.rspSearch.RSP_CardID = 0;
            this.rspSearch.RSP_CardNoVisible = false;
            this.rspSearch.RSP_ChaName = "";
            this.rspSearch.RSP_ChaNameVisible = false;
            this.rspSearch.RSP_ClassID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rspSearch.RSP_ClassName = "";
            this.rspSearch.RSP_ClassVisible = false;
            this.rspSearch.RSP_DepartmentID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rspSearch.RSP_DepartmentName = "";
            this.rspSearch.RSP_DepartmentVisible = false;
            this.rspSearch.RSP_GradeID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.rspSearch.RSP_GradeName = "";
            this.rspSearch.RSP_GradeVisible = false;
            this.rspSearch.RSP_MonthVisible = false;
            this.rspSearch.RSP_SingleMonthVisible = false;
            this.rspSearch.RSP_StudentID = "";
            this.rspSearch.RSP_StudentVisible = false;
            this.rspSearch.RSP_TimeFrom = new System.DateTime(2014, 5, 20, 0, 0, 0, 0);
            this.rspSearch.RSP_TimeTo = new System.DateTime(2014, 5, 20, 0, 0, 0, 0);
            this.rspSearch.RSP_TimeVisible = true;
            this.rspSearch.Size = new System.Drawing.Size(211, 137);
            this.rspSearch.TabIndex = 3;
            this.rspSearch.OnShowReportClick += new System.EventHandler(this.btnQuery_Click);
            // 
            // rpvMain
            // 
            this.rpvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvMain.Location = new System.Drawing.Point(217, 1);
            this.rpvMain.Name = "rpvMain";
            this.rpvMain.Size = new System.Drawing.Size(691, 564);
            this.rpvMain.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nbxOrtherIncome);
            this.groupBox1.Controls.Add(this.nbxHotIncome);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnSaveOIncome);
            this.groupBox1.Controls.Add(this.btnDeleteOIncome);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblOrtherIncome);
            this.groupBox1.Controls.Add(this.btnQueryOIncome);
            this.groupBox1.Controls.Add(this.lblHotWaterIncome);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpOrderIncome);
            this.groupBox1.Location = new System.Drawing.Point(5, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 197);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "热水、其他收入";
            // 
            // nbxOrtherIncome
            // 
            this.nbxOrtherIncome.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbxOrtherIncome.Location = new System.Drawing.Point(97, 140);
            this.nbxOrtherIncome.Name = "nbxOrtherIncome";
            this.nbxOrtherIncome.Size = new System.Drawing.Size(100, 21);
            this.nbxOrtherIncome.TabIndex = 18;
            // 
            // nbxHotIncome
            // 
            this.nbxHotIncome.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbxHotIncome.Location = new System.Drawing.Point(97, 113);
            this.nbxHotIncome.Name = "nbxHotIncome";
            this.nbxHotIncome.Size = new System.Drawing.Size(100, 21);
            this.nbxHotIncome.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "录入其他收入：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "录入热水收入：";
            // 
            // btnSaveOIncome
            // 
            this.btnSaveOIncome.Location = new System.Drawing.Point(134, 167);
            this.btnSaveOIncome.Name = "btnSaveOIncome";
            this.btnSaveOIncome.Size = new System.Drawing.Size(63, 23);
            this.btnSaveOIncome.TabIndex = 12;
            this.btnSaveOIncome.Text = "保存";
            this.btnSaveOIncome.UseVisualStyleBackColor = true;
            this.btnSaveOIncome.Click += new System.EventHandler(this.btnSaveOIncome_Click);
            // 
            // btnDeleteOIncome
            // 
            this.btnDeleteOIncome.Location = new System.Drawing.Point(155, 78);
            this.btnDeleteOIncome.Name = "btnDeleteOIncome";
            this.btnDeleteOIncome.Size = new System.Drawing.Size(43, 23);
            this.btnDeleteOIncome.TabIndex = 11;
            this.btnDeleteOIncome.Text = "删除";
            this.btnDeleteOIncome.UseVisualStyleBackColor = true;
            this.btnDeleteOIncome.Click += new System.EventHandler(this.btnDeleteOIncome_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "元";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "元";
            // 
            // lblOrtherIncome
            // 
            this.lblOrtherIncome.AutoSize = true;
            this.lblOrtherIncome.Font = new System.Drawing.Font("SimSun", 10F);
            this.lblOrtherIncome.ForeColor = System.Drawing.Color.Red;
            this.lblOrtherIncome.Location = new System.Drawing.Point(77, 82);
            this.lblOrtherIncome.Name = "lblOrtherIncome";
            this.lblOrtherIncome.Size = new System.Drawing.Size(35, 14);
            this.lblOrtherIncome.TabIndex = 6;
            this.lblOrtherIncome.Text = "0.00";
            this.lblOrtherIncome.TextChanged += new System.EventHandler(this.lblOrtherIncome_TextChanged);
            // 
            // btnQueryOIncome
            // 
            this.btnQueryOIncome.Location = new System.Drawing.Point(155, 52);
            this.btnQueryOIncome.Name = "btnQueryOIncome";
            this.btnQueryOIncome.Size = new System.Drawing.Size(43, 23);
            this.btnQueryOIncome.TabIndex = 2;
            this.btnQueryOIncome.Text = "查询";
            this.btnQueryOIncome.UseVisualStyleBackColor = true;
            this.btnQueryOIncome.Click += new System.EventHandler(this.btnQueryOIncome_Click);
            // 
            // lblHotWaterIncome
            // 
            this.lblHotWaterIncome.AutoSize = true;
            this.lblHotWaterIncome.Font = new System.Drawing.Font("SimSun", 10F);
            this.lblHotWaterIncome.ForeColor = System.Drawing.Color.Red;
            this.lblHotWaterIncome.Location = new System.Drawing.Point(77, 56);
            this.lblHotWaterIncome.Name = "lblHotWaterIncome";
            this.lblHotWaterIncome.Size = new System.Drawing.Size(35, 14);
            this.lblHotWaterIncome.TabIndex = 5;
            this.lblHotWaterIncome.Text = "0.00";
            this.lblHotWaterIncome.TextChanged += new System.EventHandler(this.lblHotWaterIncome_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "其他收入：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "热水收入：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "日期：";
            // 
            // dtpOrderIncome
            // 
            this.dtpOrderIncome.Location = new System.Drawing.Point(57, 20);
            this.dtpOrderIncome.Name = "dtpOrderIncome";
            this.dtpOrderIncome.Size = new System.Drawing.Size(127, 21);
            this.dtpOrderIncome.TabIndex = 0;
            this.dtpOrderIncome.ValueChanged += new System.EventHandler(this.dtpOrderIncome_ValueChanged);
            // 
            // frmDepartmentBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 568);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rpvMain);
            this.Controls.Add(this.rspSearch);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepartmentBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "部门收支统计";
            this.Tag = "部门收支统计";
            this.Text = "部门收支统计";
            this.Load += new System.EventHandler(this.frmDepartmentBalance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowUI.HHZX.UserControls.ReportSearchPanel rspSearch;
        private Microsoft.Reporting.WinForms.ReportViewer rpvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQueryOIncome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpOrderIncome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOrtherIncome;
        private System.Windows.Forms.Label lblHotWaterIncome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveOIncome;
        private System.Windows.Forms.Button btnDeleteOIncome;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private WindowControls.HHZX.NumberBox nbxOrtherIncome;
        private WindowControls.HHZX.NumberBox nbxHotIncome;
    }
}