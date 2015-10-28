namespace WindowsUI.TQS.UserCard
{
    partial class frmCardRecharge
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
            this.panelForm = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucMealBookingDetail = new WindowUI.TQS.ucMealBookingDetail();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.labTotalRecharge = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.labCardNo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labPreCost = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labCardBalance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labRecharge = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPreCostDetail = new System.Windows.Forms.Button();
            this.btnRecharge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvRechargeList = new System.Windows.Forms.ListView();
            this.RecordID = new System.Windows.Forms.ColumnHeader();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.RechargeMoney = new System.Windows.Forms.ColumnHeader();
            this.RechargeTime = new System.Windows.Forms.ColumnHeader();
            this.RechargeType = new System.Windows.Forms.ColumnHeader();
            this.panelForm.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.groupBox2);
            this.panelForm.Controls.Add(this.groupBox1);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(670, 650);
            this.panelForm.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ucMealBookingDetail);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.btnPreCostDetail);
            this.groupBox2.Controls.Add(this.btnRecharge);
            this.groupBox2.Location = new System.Drawing.Point(4, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 167);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // ucMealBookingDetail
            // 
            this.ucMealBookingDetail.Location = new System.Drawing.Point(57, 142);
            this.ucMealBookingDetail.Name = "ucMealBookingDetail";
            this.ucMealBookingDetail.Size = new System.Drawing.Size(275, 36);
            this.ucMealBookingDetail.TabIndex = 20;
            this.ucMealBookingDetail.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.labTotalRecharge);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(331, 83);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(231, 31);
            this.panel6.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "实际到账额：";
            // 
            // labTotalRecharge
            // 
            this.labTotalRecharge.AutoSize = true;
            this.labTotalRecharge.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.labTotalRecharge.ForeColor = System.Drawing.Color.Red;
            this.labTotalRecharge.Location = new System.Drawing.Point(113, 3);
            this.labTotalRecharge.Name = "labTotalRecharge";
            this.labTotalRecharge.Size = new System.Drawing.Size(65, 22);
            this.labTotalRecharge.TabIndex = 6;
            this.labTotalRecharge.Text = "100.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(202, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "元";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.labCardNo);
            this.panel5.Location = new System.Drawing.Point(331, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(231, 31);
            this.panel5.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(49, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 22);
            this.label12.TabIndex = 13;
            this.label12.Text = "卡号：";
            // 
            // labCardNo
            // 
            this.labCardNo.AutoSize = true;
            this.labCardNo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.labCardNo.ForeColor = System.Drawing.Color.Blue;
            this.labCardNo.Location = new System.Drawing.Point(125, 3);
            this.labCardNo.Name = "labCardNo";
            this.labCardNo.Size = new System.Drawing.Size(90, 22);
            this.labCardNo.TabIndex = 14;
            this.labCardNo.Text = "00000120";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.labPreCost);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(101, 113);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 31);
            this.panel4.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "未结算款：";
            // 
            // labPreCost
            // 
            this.labPreCost.AutoSize = true;
            this.labPreCost.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.labPreCost.ForeColor = System.Drawing.Color.Red;
            this.labPreCost.Location = new System.Drawing.Point(113, 3);
            this.labPreCost.Name = "labPreCost";
            this.labPreCost.Size = new System.Drawing.Size(65, 22);
            this.labPreCost.TabIndex = 4;
            this.labPreCost.Text = "100.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(198, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 22);
            this.label8.TabIndex = 9;
            this.label8.Text = "元";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labCardBalance);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(101, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 31);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(4, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "卡可用余额：";
            // 
            // labCardBalance
            // 
            this.labCardBalance.AutoSize = true;
            this.labCardBalance.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.labCardBalance.ForeColor = System.Drawing.Color.Blue;
            this.labCardBalance.Location = new System.Drawing.Point(116, 3);
            this.labCardBalance.Name = "labCardBalance";
            this.labCardBalance.Size = new System.Drawing.Size(45, 22);
            this.labCardBalance.TabIndex = 16;
            this.labCardBalance.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(198, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "元";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.labRecharge);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(101, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 31);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "待转账总额：";
            // 
            // labRecharge
            // 
            this.labRecharge.AutoSize = true;
            this.labRecharge.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.labRecharge.ForeColor = System.Drawing.Color.Red;
            this.labRecharge.Location = new System.Drawing.Point(113, 3);
            this.labRecharge.Name = "labRecharge";
            this.labRecharge.Size = new System.Drawing.Size(65, 22);
            this.labRecharge.TabIndex = 2;
            this.labRecharge.Text = "100.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(198, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "元";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(241, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 40);
            this.panel1.TabIndex = 19;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.labName.ForeColor = System.Drawing.Color.Blue;
            this.labName.Location = new System.Drawing.Point(100, 8);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(58, 22);
            this.labName.TabIndex = 12;
            this.labName.Text = "王小虎";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(20, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 22);
            this.label10.TabIndex = 11;
            this.label10.Text = "持卡人：";
            // 
            // btnPreCostDetail
            // 
            this.btnPreCostDetail.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.btnPreCostDetail.Location = new System.Drawing.Point(408, 125);
            this.btnPreCostDetail.Name = "btnPreCostDetail";
            this.btnPreCostDetail.Size = new System.Drawing.Size(118, 35);
            this.btnPreCostDetail.TabIndex = 18;
            this.btnPreCostDetail.Text = "未结算款明细";
            this.btnPreCostDetail.UseVisualStyleBackColor = true;
            this.btnPreCostDetail.Click += new System.EventHandler(this.btnPreCostDetail_Click);
            // 
            // btnRecharge
            // 
            this.btnRecharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecharge.Enabled = false;
            this.btnRecharge.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.btnRecharge.Location = new System.Drawing.Point(545, 125);
            this.btnRecharge.Name = "btnRecharge";
            this.btnRecharge.Size = new System.Drawing.Size(109, 35);
            this.btnRecharge.TabIndex = 7;
            this.btnRecharge.Text = "自助转账";
            this.btnRecharge.UseVisualStyleBackColor = true;
            this.btnRecharge.Click += new System.EventHandler(this.btnRecharge_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvRechargeList);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 474);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "待转账金额列表";
            // 
            // lvRechargeList
            // 
            this.lvRechargeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRechargeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RecordID,
            this.ID,
            this.RechargeMoney,
            this.RechargeTime,
            this.RechargeType});
            this.lvRechargeList.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvRechargeList.FullRowSelect = true;
            this.lvRechargeList.GridLines = true;
            this.lvRechargeList.Location = new System.Drawing.Point(6, 20);
            this.lvRechargeList.MultiSelect = false;
            this.lvRechargeList.Name = "lvRechargeList";
            this.lvRechargeList.Size = new System.Drawing.Size(647, 445);
            this.lvRechargeList.TabIndex = 0;
            this.lvRechargeList.UseCompatibleStateImageBehavior = false;
            this.lvRechargeList.View = System.Windows.Forms.View.Details;
            this.lvRechargeList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvRechargeList_ColumnClick);
            // 
            // RecordID
            // 
            this.RecordID.Tag = "RecordID";
            this.RecordID.Width = 0;
            // 
            // ID
            // 
            this.ID.Tag = "ID";
            this.ID.Text = "序号";
            // 
            // RechargeMoney
            // 
            this.RechargeMoney.Tag = "RechargeMoney";
            this.RechargeMoney.Text = "金额(元)";
            this.RechargeMoney.Width = 100;
            // 
            // RechargeTime
            // 
            this.RechargeTime.Tag = "RechargeTime";
            this.RechargeTime.Text = "转账时间";
            this.RechargeTime.Width = 227;
            // 
            // RechargeType
            // 
            this.RechargeType.Tag = "RechargeType";
            this.RechargeType.Text = "转账类型";
            this.RechargeType.Width = 244;
            // 
            // frmCardRecharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 650);
            this.Controls.Add(this.panelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCardRecharge";
            this.Text = "自助转账充值";
            this.panelForm.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvRechargeList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader RechargeMoney;
        private System.Windows.Forms.ColumnHeader RechargeTime;
        private System.Windows.Forms.ColumnHeader RechargeType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labPreCost;
        private System.Windows.Forms.Label labRecharge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labTotalRecharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRecharge;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labCardNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader RecordID;
        private System.Windows.Forms.Label labCardBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPreCostDetail;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private WindowUI.TQS.ucMealBookingDetail ucMealBookingDetail;
    }
}