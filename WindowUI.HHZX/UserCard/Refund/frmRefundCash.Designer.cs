namespace WindowUI.HHZX.UserCard.Refund
{
    partial class frmRefundCash
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
            this.cbxPrint = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnConfirmRefund = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxRefundMoney = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.tbxRefundDesc = new System.Windows.Forms.TextBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labReaderState = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.labCardNo = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.labCardBalance = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labStuNum = new System.Windows.Forms.Label();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labUserName = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labClassName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.labAccountSyncTime = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labAccountBalance = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.ckbPreCost = new System.Windows.Forms.CheckBox();
            this.labPreCost = new System.Windows.Forms.Label();
            this.btnPreCostDetail = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labCardUserInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxPrint
            // 
            this.cbxPrint.AutoSize = true;
            this.cbxPrint.Enabled = false;
            this.cbxPrint.Location = new System.Drawing.Point(328, 477);
            this.cbxPrint.Name = "cbxPrint";
            this.cbxPrint.Size = new System.Drawing.Size(72, 16);
            this.cbxPrint.TabIndex = 12;
            this.cbxPrint.Text = "打印小票";
            this.cbxPrint.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(28, 507);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "确认请点击";
            // 
            // btnConfirmRefund
            // 
            this.btnConfirmRefund.Enabled = false;
            this.btnConfirmRefund.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnConfirmRefund.Location = new System.Drawing.Point(190, 512);
            this.btnConfirmRefund.Name = "btnConfirmRefund";
            this.btnConfirmRefund.Size = new System.Drawing.Size(111, 37);
            this.btnConfirmRefund.TabIndex = 10;
            this.btnConfirmRefund.Text = "确认退款";
            this.btnConfirmRefund.UseVisualStyleBackColor = true;
            this.btnConfirmRefund.Click += new System.EventHandler(this.btnConfirmRefund_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(407, 526);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxPrint);
            this.groupBox1.Controls.Add(this.tbxRefundMoney);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.labCardUserInfo);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 506);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 20F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(108, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 27);
            this.label6.TabIndex = 30;
            this.label6.Text = "￥";
            // 
            // tbxRefundMoney
            // 
            this.tbxRefundMoney.Enabled = false;
            this.tbxRefundMoney.Font = new System.Drawing.Font("Microsoft YaHei", 40F);
            this.tbxRefundMoney.ForeColor = System.Drawing.Color.Red;
            this.tbxRefundMoney.Location = new System.Drawing.Point(153, 424);
            this.tbxRefundMoney.Name = "tbxRefundMoney";
            this.tbxRefundMoney.Size = new System.Drawing.Size(169, 78);
            this.tbxRefundMoney.TabIndex = 21;
            this.tbxRefundMoney.Text = "0.00";
            this.tbxRefundMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxRefundMoney.TextChanged += new System.EventHandler(this.tbxRefundMoney_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel17);
            this.groupBox2.Controls.Add(this.panel18);
            this.groupBox2.Controls.Add(this.labReaderState);
            this.groupBox2.Controls.Add(this.panel15);
            this.groupBox2.Controls.Add(this.panel16);
            this.groupBox2.Controls.Add(this.panel13);
            this.groupBox2.Controls.Add(this.panel14);
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Controls.Add(this.btnReadCard);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel11);
            this.groupBox2.Controls.Add(this.panel12);
            this.groupBox2.Controls.Add(this.panel10);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel9);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Location = new System.Drawing.Point(9, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 405);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请确认如下信息";
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.tbxRefundDesc);
            this.panel17.Location = new System.Drawing.Point(157, 329);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(287, 65);
            this.panel17.TabIndex = 84;
            // 
            // tbxRefundDesc
            // 
            this.tbxRefundDesc.Location = new System.Drawing.Point(3, 3);
            this.tbxRefundDesc.Multiline = true;
            this.tbxRefundDesc.Name = "tbxRefundDesc";
            this.tbxRefundDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRefundDesc.Size = new System.Drawing.Size(278, 57);
            this.tbxRefundDesc.TabIndex = 23;
            // 
            // panel18
            // 
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.label1);
            this.panel18.Location = new System.Drawing.Point(14, 329);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(145, 65);
            this.panel18.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 15F);
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "退款原因：";
            // 
            // labReaderState
            // 
            this.labReaderState.AutoSize = true;
            this.labReaderState.BackColor = System.Drawing.Color.White;
            this.labReaderState.Location = new System.Drawing.Point(362, 51);
            this.labReaderState.Name = "labReaderState";
            this.labReaderState.Size = new System.Drawing.Size(77, 12);
            this.labReaderState.TabIndex = 12;
            this.labReaderState.Text = "读卡器未连接";
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.labCardNo);
            this.panel15.Location = new System.Drawing.Point(157, 134);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(192, 33);
            this.panel15.TabIndex = 46;
            // 
            // labCardNo
            // 
            this.labCardNo.AutoSize = true;
            this.labCardNo.BackColor = System.Drawing.Color.White;
            this.labCardNo.Font = new System.Drawing.Font("SimSun", 20F);
            this.labCardNo.ForeColor = System.Drawing.Color.Blue;
            this.labCardNo.Location = new System.Drawing.Point(3, 2);
            this.labCardNo.Name = "labCardNo";
            this.labCardNo.Size = new System.Drawing.Size(124, 27);
            this.labCardNo.TabIndex = 27;
            this.labCardNo.Text = "00000000";
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label13);
            this.panel16.Location = new System.Drawing.Point(13, 134);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(145, 33);
            this.panel16.TabIndex = 45;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("SimSun", 15F);
            this.label13.Location = new System.Drawing.Point(3, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 20);
            this.label13.TabIndex = 9;
            this.label13.Text = "卡号：";
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.labCardBalance);
            this.panel13.Location = new System.Drawing.Point(157, 173);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(192, 33);
            this.panel13.TabIndex = 44;
            // 
            // labCardBalance
            // 
            this.labCardBalance.AutoSize = true;
            this.labCardBalance.BackColor = System.Drawing.Color.White;
            this.labCardBalance.Font = new System.Drawing.Font("SimSun", 20F);
            this.labCardBalance.ForeColor = System.Drawing.Color.Blue;
            this.labCardBalance.Location = new System.Drawing.Point(3, 2);
            this.labCardBalance.Name = "labCardBalance";
            this.labCardBalance.Size = new System.Drawing.Size(68, 27);
            this.labCardBalance.TabIndex = 27;
            this.labCardBalance.Text = "0.00";
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.label4);
            this.panel14.Location = new System.Drawing.Point(13, 173);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(145, 33);
            this.panel14.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 15F);
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "卡可用余额：";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.labStuNum);
            this.panel8.Location = new System.Drawing.Point(157, 95);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(192, 33);
            this.panel8.TabIndex = 42;
            // 
            // labStuNum
            // 
            this.labStuNum.AutoSize = true;
            this.labStuNum.BackColor = System.Drawing.Color.White;
            this.labStuNum.Font = new System.Drawing.Font("SimSun", 20F);
            this.labStuNum.ForeColor = System.Drawing.Color.Blue;
            this.labStuNum.Location = new System.Drawing.Point(3, 2);
            this.labStuNum.Name = "labStuNum";
            this.labStuNum.Size = new System.Drawing.Size(138, 27);
            this.labStuNum.TabIndex = 5;
            this.labStuNum.Text = "201300105";
            // 
            // btnReadCard
            // 
            this.btnReadCard.Font = new System.Drawing.Font("SimSun", 15F);
            this.btnReadCard.Location = new System.Drawing.Point(355, 18);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(84, 33);
            this.btnReadCard.TabIndex = 24;
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.labUserName);
            this.panel7.Location = new System.Drawing.Point(157, 56);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(192, 33);
            this.panel7.TabIndex = 41;
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.BackColor = System.Drawing.Color.White;
            this.labUserName.Font = new System.Drawing.Font("SimSun", 20F);
            this.labUserName.ForeColor = System.Drawing.Color.Blue;
            this.labUserName.Location = new System.Drawing.Point(3, 2);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(93, 27);
            this.labUserName.TabIndex = 3;
            this.labUserName.Text = "宋一鸣";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.labClassName);
            this.panel6.Location = new System.Drawing.Point(157, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(192, 33);
            this.panel6.TabIndex = 40;
            // 
            // labClassName
            // 
            this.labClassName.AutoSize = true;
            this.labClassName.BackColor = System.Drawing.Color.White;
            this.labClassName.Font = new System.Drawing.Font("SimSun", 20F);
            this.labClassName.ForeColor = System.Drawing.Color.Blue;
            this.labClassName.Location = new System.Drawing.Point(3, 2);
            this.labClassName.Name = "labClassName";
            this.labClassName.Size = new System.Drawing.Size(161, 27);
            this.labClassName.TabIndex = 1;
            this.labClassName.Text = "高一（1）班";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(13, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 33);
            this.panel3.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 15F);
            this.label8.Location = new System.Drawing.Point(1, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "班别\\部门：";
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.label10);
            this.panel11.Location = new System.Drawing.Point(13, 95);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(145, 33);
            this.panel11.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 15F);
            this.label10.Location = new System.Drawing.Point(3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "学号\\工号：";
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label12);
            this.panel12.Location = new System.Drawing.Point(13, 56);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(145, 33);
            this.panel12.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("SimSun", 15F);
            this.label12.Location = new System.Drawing.Point(3, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 7;
            this.label12.Text = "姓  名：";
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.labAccountSyncTime);
            this.panel10.Location = new System.Drawing.Point(157, 251);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(287, 33);
            this.panel10.TabIndex = 36;
            // 
            // labAccountSyncTime
            // 
            this.labAccountSyncTime.AutoSize = true;
            this.labAccountSyncTime.BackColor = System.Drawing.Color.White;
            this.labAccountSyncTime.Font = new System.Drawing.Font("SimSun", 20F);
            this.labAccountSyncTime.ForeColor = System.Drawing.Color.Blue;
            this.labAccountSyncTime.Location = new System.Drawing.Point(3, 2);
            this.labAccountSyncTime.Name = "labAccountSyncTime";
            this.labAccountSyncTime.Size = new System.Drawing.Size(278, 27);
            this.labAccountSyncTime.TabIndex = 12;
            this.labAccountSyncTime.Text = "2013-08-07 10:00:00";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(13, 251);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(145, 33);
            this.panel5.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 15F);
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "账户同步时间：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labAccountBalance);
            this.panel1.Location = new System.Drawing.Point(157, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 33);
            this.panel1.TabIndex = 34;
            // 
            // labAccountBalance
            // 
            this.labAccountBalance.AutoSize = true;
            this.labAccountBalance.BackColor = System.Drawing.Color.White;
            this.labAccountBalance.Font = new System.Drawing.Font("SimSun", 20F);
            this.labAccountBalance.ForeColor = System.Drawing.Color.Blue;
            this.labAccountBalance.Location = new System.Drawing.Point(3, 2);
            this.labAccountBalance.Name = "labAccountBalance";
            this.labAccountBalance.Size = new System.Drawing.Size(68, 27);
            this.labAccountBalance.TabIndex = 27;
            this.labAccountBalance.Text = "0.00";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(13, 212);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 33);
            this.panel2.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 15F);
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "账户余额：";
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.ckbPreCost);
            this.panel9.Controls.Add(this.labPreCost);
            this.panel9.Controls.Add(this.btnPreCostDetail);
            this.panel9.Location = new System.Drawing.Point(157, 290);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(287, 33);
            this.panel9.TabIndex = 32;
            // 
            // ckbPreCost
            // 
            this.ckbPreCost.AutoSize = true;
            this.ckbPreCost.Checked = true;
            this.ckbPreCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPreCost.Location = new System.Drawing.Point(209, 9);
            this.ckbPreCost.Name = "ckbPreCost";
            this.ckbPreCost.Size = new System.Drawing.Size(72, 16);
            this.ckbPreCost.TabIndex = 47;
            this.ckbPreCost.Text = "同步结算";
            this.ckbPreCost.UseVisualStyleBackColor = true;
            // 
            // labPreCost
            // 
            this.labPreCost.AutoSize = true;
            this.labPreCost.BackColor = System.Drawing.Color.White;
            this.labPreCost.Font = new System.Drawing.Font("SimSun", 20F);
            this.labPreCost.ForeColor = System.Drawing.Color.Blue;
            this.labPreCost.Location = new System.Drawing.Point(3, 2);
            this.labPreCost.Name = "labPreCost";
            this.labPreCost.Size = new System.Drawing.Size(68, 27);
            this.labPreCost.TabIndex = 24;
            this.labPreCost.Text = "0.00";
            // 
            // btnPreCostDetail
            // 
            this.btnPreCostDetail.Enabled = false;
            this.btnPreCostDetail.Location = new System.Drawing.Point(127, 4);
            this.btnPreCostDetail.Name = "btnPreCostDetail";
            this.btnPreCostDetail.Size = new System.Drawing.Size(64, 23);
            this.btnPreCostDetail.TabIndex = 25;
            this.btnPreCostDetail.Text = "查看详细";
            this.btnPreCostDetail.UseVisualStyleBackColor = true;
            this.btnPreCostDetail.Click += new System.EventHandler(this.btnPreCostDetail_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(13, 290);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(145, 33);
            this.panel4.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 15F);
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "未结算款项：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "退款金额：";
            // 
            // labCardUserInfo
            // 
            this.labCardUserInfo.AutoSize = true;
            this.labCardUserInfo.BackColor = System.Drawing.Color.White;
            this.labCardUserInfo.Font = new System.Drawing.Font("SimSun", 20F);
            this.labCardUserInfo.ForeColor = System.Drawing.Color.Red;
            this.labCardUserInfo.Location = new System.Drawing.Point(101, 47);
            this.labCardUserInfo.Name = "labCardUserInfo";
            this.labCardUserInfo.Size = new System.Drawing.Size(0, 27);
            this.labCardUserInfo.TabIndex = 0;
            // 
            // frmRefundCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 556);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnConfirmRefund);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRefundCash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "退款【现金退款】";
            this.Tag = "退款【现金退款】";
            this.Text = "退款【现金退款】";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRechargeOfflineSingle_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxPrint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnConfirmRefund;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxRefundMoney;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labClassName;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label labStuNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labCardUserInfo;
        private System.Windows.Forms.TextBox tbxRefundDesc;
        private System.Windows.Forms.Label labPreCost;
        private System.Windows.Forms.Label labAccountBalance;
        private System.Windows.Forms.Button btnPreCostDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label labAccountSyncTime;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label labCardBalance;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label labCardNo;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ckbPreCost;
        private System.Windows.Forms.Label labReaderState;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel17;

    }
}