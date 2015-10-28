namespace WindowUI.HHZX.UserControls
{
    partial class ReportSearchPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUserClass = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChaName = new System.Windows.Forms.TextBox();
            this.palTime = new System.Windows.Forms.Panel();
            this.palStudent = new System.Windows.Forms.Panel();
            this.palChaName = new System.Windows.Forms.Panel();
            this.palCardNo = new System.Windows.Forms.Panel();
            this.nubCardNo = new WindowControls.HHZX.NumberBox();
            this.palGrade = new System.Windows.Forms.Panel();
            this.palClass = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSingleMonth = new System.Windows.Forms.Panel();
            this.cbxSingelMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlMonth = new System.Windows.Forms.Panel();
            this.cbxMonthTo = new System.Windows.Forms.ComboBox();
            this.cbxMonthFrom = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.palDepartment = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.palTime.SuspendLayout();
            this.palStudent.SuspendLayout();
            this.palChaName.SuspendLayout();
            this.palCardNo.SuspendLayout();
            this.palGrade.SuspendLayout();
            this.palClass.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlSingleMonth.SuspendLayout();
            this.pnlMonth.SuspendLayout();
            this.palDepartment.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(15, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(126, 31);
            this.btnQuery.TabIndex = 29;
            this.btnQuery.Text = "生成报表";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.ShowReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "日期范围：";
            // 
            // cmbUserClass
            // 
            this.cmbUserClass.DropDownHeight = 120;
            this.cmbUserClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserClass.FormattingEnabled = true;
            this.cmbUserClass.IntegralHeight = false;
            this.cmbUserClass.Location = new System.Drawing.Point(79, 4);
            this.cmbUserClass.Name = "cmbUserClass";
            this.cmbUserClass.Size = new System.Drawing.Size(125, 20);
            this.cmbUserClass.TabIndex = 28;
            this.cmbUserClass.SelectedIndexChanged += new System.EventHandler(this.cmbUserClass_SelectedIndexChanged);
            this.cmbUserClass.Click += new System.EventHandler(this.cmbUserClass_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(78, 5);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(125, 21);
            this.dtpFrom.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "班级：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "至：";
            // 
            // cmbGrade
            // 
            this.cmbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Location = new System.Drawing.Point(79, 5);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(125, 20);
            this.cmbGrade.TabIndex = 26;
            this.cmbGrade.SelectedIndexChanged += new System.EventHandler(this.cmbGrade_SelectedIndexChanged);
            this.cmbGrade.Click += new System.EventHandler(this.cmbGrade_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(78, 34);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(125, 21);
            this.dtpTo.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "年级：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "学号：";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(79, 5);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(125, 21);
            this.txtStudentID.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "卡号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "姓名：";
            // 
            // txtChaName
            // 
            this.txtChaName.Location = new System.Drawing.Point(79, 4);
            this.txtChaName.Name = "txtChaName";
            this.txtChaName.Size = new System.Drawing.Size(125, 21);
            this.txtChaName.TabIndex = 22;
            // 
            // palTime
            // 
            this.palTime.Controls.Add(this.label2);
            this.palTime.Controls.Add(this.dtpTo);
            this.palTime.Controls.Add(this.label1);
            this.palTime.Controls.Add(this.dtpFrom);
            this.palTime.Location = new System.Drawing.Point(3, 109);
            this.palTime.Name = "palTime";
            this.palTime.Size = new System.Drawing.Size(220, 61);
            this.palTime.TabIndex = 31;
            // 
            // palStudent
            // 
            this.palStudent.Controls.Add(this.label3);
            this.palStudent.Controls.Add(this.txtStudentID);
            this.palStudent.Location = new System.Drawing.Point(3, 176);
            this.palStudent.Name = "palStudent";
            this.palStudent.Size = new System.Drawing.Size(220, 30);
            this.palStudent.TabIndex = 32;
            // 
            // palChaName
            // 
            this.palChaName.Controls.Add(this.label4);
            this.palChaName.Controls.Add(this.txtChaName);
            this.palChaName.Location = new System.Drawing.Point(3, 212);
            this.palChaName.Name = "palChaName";
            this.palChaName.Size = new System.Drawing.Size(220, 30);
            this.palChaName.TabIndex = 32;
            // 
            // palCardNo
            // 
            this.palCardNo.Controls.Add(this.label5);
            this.palCardNo.Controls.Add(this.nubCardNo);
            this.palCardNo.Location = new System.Drawing.Point(3, 248);
            this.palCardNo.Name = "palCardNo";
            this.palCardNo.Size = new System.Drawing.Size(220, 30);
            this.palCardNo.TabIndex = 32;
            // 
            // nubCardNo
            // 
            this.nubCardNo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nubCardNo.Location = new System.Drawing.Point(79, 5);
            this.nubCardNo.Name = "nubCardNo";
            this.nubCardNo.Size = new System.Drawing.Size(125, 21);
            this.nubCardNo.TabIndex = 30;
            // 
            // palGrade
            // 
            this.palGrade.Controls.Add(this.label6);
            this.palGrade.Controls.Add(this.cmbGrade);
            this.palGrade.Location = new System.Drawing.Point(3, 284);
            this.palGrade.Name = "palGrade";
            this.palGrade.Size = new System.Drawing.Size(220, 30);
            this.palGrade.TabIndex = 32;
            // 
            // palClass
            // 
            this.palClass.Controls.Add(this.label7);
            this.palClass.Controls.Add(this.cmbUserClass);
            this.palClass.Controls.Add(this.panel1);
            this.palClass.Location = new System.Drawing.Point(3, 320);
            this.palClass.Name = "palClass";
            this.palClass.Size = new System.Drawing.Size(220, 30);
            this.palClass.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 30);
            this.panel1.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "班级：";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 20);
            this.comboBox1.TabIndex = 28;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlSingleMonth);
            this.flowLayoutPanel1.Controls.Add(this.pnlMonth);
            this.flowLayoutPanel1.Controls.Add(this.palTime);
            this.flowLayoutPanel1.Controls.Add(this.palStudent);
            this.flowLayoutPanel1.Controls.Add(this.palChaName);
            this.flowLayoutPanel1.Controls.Add(this.palCardNo);
            this.flowLayoutPanel1.Controls.Add(this.palGrade);
            this.flowLayoutPanel1.Controls.Add(this.palClass);
            this.flowLayoutPanel1.Controls.Add(this.palDepartment);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 508);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // pnlSingleMonth
            // 
            this.pnlSingleMonth.Controls.Add(this.cbxSingelMonth);
            this.pnlSingleMonth.Controls.Add(this.label14);
            this.pnlSingleMonth.Location = new System.Drawing.Point(3, 3);
            this.pnlSingleMonth.Name = "pnlSingleMonth";
            this.pnlSingleMonth.Size = new System.Drawing.Size(220, 33);
            this.pnlSingleMonth.TabIndex = 34;
            this.pnlSingleMonth.Visible = false;
            // 
            // cbxSingelMonth
            // 
            this.cbxSingelMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSingelMonth.FormattingEnabled = true;
            this.cbxSingelMonth.Location = new System.Drawing.Point(78, 6);
            this.cbxSingelMonth.Name = "cbxSingelMonth";
            this.cbxSingelMonth.Size = new System.Drawing.Size(121, 20);
            this.cbxSingelMonth.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 15;
            this.label14.Text = "月份选择：";
            // 
            // pnlMonth
            // 
            this.pnlMonth.Controls.Add(this.cbxMonthTo);
            this.pnlMonth.Controls.Add(this.cbxMonthFrom);
            this.pnlMonth.Controls.Add(this.label11);
            this.pnlMonth.Controls.Add(this.label12);
            this.pnlMonth.Location = new System.Drawing.Point(3, 42);
            this.pnlMonth.Name = "pnlMonth";
            this.pnlMonth.Size = new System.Drawing.Size(220, 61);
            this.pnlMonth.TabIndex = 33;
            this.pnlMonth.Visible = false;
            // 
            // cbxMonthTo
            // 
            this.cbxMonthTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonthTo.FormattingEnabled = true;
            this.cbxMonthTo.Location = new System.Drawing.Point(78, 35);
            this.cbxMonthTo.Name = "cbxMonthTo";
            this.cbxMonthTo.Size = new System.Drawing.Size(121, 20);
            this.cbxMonthTo.TabIndex = 19;
            // 
            // cbxMonthFrom
            // 
            this.cbxMonthFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonthFrom.FormattingEnabled = true;
            this.cbxMonthFrom.Location = new System.Drawing.Point(78, 6);
            this.cbxMonthFrom.Name = "cbxMonthFrom";
            this.cbxMonthFrom.Size = new System.Drawing.Size(121, 20);
            this.cbxMonthFrom.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "至：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "月份范围：";
            // 
            // palDepartment
            // 
            this.palDepartment.Controls.Add(this.label9);
            this.palDepartment.Controls.Add(this.cmbDepartment);
            this.palDepartment.Controls.Add(this.panel3);
            this.palDepartment.Location = new System.Drawing.Point(3, 356);
            this.palDepartment.Name = "palDepartment";
            this.palDepartment.Size = new System.Drawing.Size(220, 30);
            this.palDepartment.TabIndex = 32;
            this.palDepartment.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "部门：";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(79, 4);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(125, 20);
            this.cmbDepartment.TabIndex = 28;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            this.cmbDepartment.Click += new System.EventHandler(this.cmbDepartment_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.comboBox3);
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 30);
            this.panel3.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "班级：";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(79, 4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(125, 20);
            this.comboBox3.TabIndex = 28;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnClear);
            this.panel8.Controls.Add(this.btnQuery);
            this.panel8.Location = new System.Drawing.Point(3, 392);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(220, 38);
            this.panel8.TabIndex = 32;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(143, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(62, 31);
            this.btnClear.TabIndex = 30;
            this.btnClear.Text = "清空条件";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ReportSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ReportSearchPanel";
            this.Size = new System.Drawing.Size(230, 508);
            this.palTime.ResumeLayout(false);
            this.palTime.PerformLayout();
            this.palStudent.ResumeLayout(false);
            this.palStudent.PerformLayout();
            this.palChaName.ResumeLayout(false);
            this.palChaName.PerformLayout();
            this.palCardNo.ResumeLayout(false);
            this.palCardNo.PerformLayout();
            this.palGrade.ResumeLayout(false);
            this.palGrade.PerformLayout();
            this.palClass.ResumeLayout(false);
            this.palClass.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlSingleMonth.ResumeLayout(false);
            this.pnlSingleMonth.PerformLayout();
            this.pnlMonth.ResumeLayout(false);
            this.pnlMonth.PerformLayout();
            this.palDepartment.ResumeLayout(false);
            this.palDepartment.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUserClass;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChaName;
        private WindowControls.HHZX.NumberBox nubCardNo;
        private System.Windows.Forms.Panel palTime;
        private System.Windows.Forms.Panel palStudent;
        private System.Windows.Forms.Panel palChaName;
        private System.Windows.Forms.Panel palCardNo;
        private System.Windows.Forms.Panel palGrade;
        private System.Windows.Forms.Panel palClass;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel palDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlMonth;
        private System.Windows.Forms.ComboBox cbxMonthTo;
        private System.Windows.Forms.ComboBox cbxMonthFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlSingleMonth;
        private System.Windows.Forms.ComboBox cbxSingelMonth;
        private System.Windows.Forms.Label label14;
    }
}
