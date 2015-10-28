namespace WindowUI.HHZX.UserCard.Recharge
{
    partial class frmRechargeOfflineSingle
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
            this.components = new System.ComponentModel.Container();
            this.labCardUserInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxTransferMoney = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.labAccountSyncTime = new System.Windows.Forms.Label();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.labAccountBalance = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labStuNum = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labUserName = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labClassName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnConfirmRecharge = new System.Windows.Forms.Button();
            this.ttConfirmRecharge = new System.Windows.Forms.ToolTip(this.components);
            this.cbxPrint = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labCardUserInfo
            // 
            this.labCardUserInfo.AutoSize = true;
            this.labCardUserInfo.BackColor = System.Drawing.Color.White;
            this.labCardUserInfo.Font = new System.Drawing.Font("宋体", 20F);
            this.labCardUserInfo.ForeColor = System.Drawing.Color.Red;
            this.labCardUserInfo.Location = new System.Drawing.Point(101, 47);
            this.labCardUserInfo.Name = "labCardUserInfo";
            this.labCardUserInfo.Size = new System.Drawing.Size(0, 27);
            this.labCardUserInfo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxPrint);
            this.groupBox1.Controls.Add(this.tbxTransferMoney);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.labCardUserInfo);
            this.groupBox1.Location = new System.Drawing.Point(11, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 384);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tbxTransferMoney
            // 
            this.tbxTransferMoney.Enabled = false;
            this.tbxTransferMoney.Font = new System.Drawing.Font("微软雅黑", 40F);
            this.tbxTransferMoney.ForeColor = System.Drawing.Color.Red;
            this.tbxTransferMoney.Location = new System.Drawing.Point(151, 298);
            this.tbxTransferMoney.Name = "tbxTransferMoney";
            this.tbxTransferMoney.Size = new System.Drawing.Size(169, 78);
            this.tbxTransferMoney.TabIndex = 21;
            this.tbxTransferMoney.Text = "0.00";
            this.tbxTransferMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxTransferMoney.TextChanged += new System.EventHandler(this.tbxRechargeMoney_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel10);
            this.groupBox2.Controls.Add(this.btnSelectUser);
            this.groupBox2.Controls.Add(this.panel9);
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(6, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 272);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请确认如下信息";
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.labAccountSyncTime);
            this.panel10.Location = new System.Drawing.Point(157, 229);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(287, 33);
            this.panel10.TabIndex = 22;
            // 
            // labAccountSyncTime
            // 
            this.labAccountSyncTime.AutoSize = true;
            this.labAccountSyncTime.BackColor = System.Drawing.Color.White;
            this.labAccountSyncTime.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Underline);
            this.labAccountSyncTime.ForeColor = System.Drawing.Color.Blue;
            this.labAccountSyncTime.Location = new System.Drawing.Point(3, -1);
            this.labAccountSyncTime.Name = "labAccountSyncTime";
            this.labAccountSyncTime.Size = new System.Drawing.Size(278, 27);
            this.labAccountSyncTime.TabIndex = 12;
            this.labAccountSyncTime.Text = "2013-08-07 10:00:00";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Font = new System.Drawing.Font("宋体", 15F);
            this.btnSelectUser.Location = new System.Drawing.Point(357, 21);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(84, 33);
            this.btnSelectUser.TabIndex = 1;
            this.btnSelectUser.Text = "选择";
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.labAccountBalance);
            this.panel9.Location = new System.Drawing.Point(157, 177);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(192, 33);
            this.panel9.TabIndex = 21;
            // 
            // labAccountBalance
            // 
            this.labAccountBalance.AutoSize = true;
            this.labAccountBalance.BackColor = System.Drawing.Color.White;
            this.labAccountBalance.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Underline);
            this.labAccountBalance.ForeColor = System.Drawing.Color.Blue;
            this.labAccountBalance.Location = new System.Drawing.Point(3, -1);
            this.labAccountBalance.Name = "labAccountBalance";
            this.labAccountBalance.Size = new System.Drawing.Size(68, 27);
            this.labAccountBalance.TabIndex = 10;
            this.labAccountBalance.Text = "0.00";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.labStuNum);
            this.panel8.Location = new System.Drawing.Point(157, 125);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(192, 33);
            this.panel8.TabIndex = 20;
            // 
            // labStuNum
            // 
            this.labStuNum.AutoSize = true;
            this.labStuNum.BackColor = System.Drawing.Color.White;
            this.labStuNum.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Underline);
            this.labStuNum.ForeColor = System.Drawing.Color.Blue;
            this.labStuNum.Location = new System.Drawing.Point(3, -1);
            this.labStuNum.Name = "labStuNum";
            this.labStuNum.Size = new System.Drawing.Size(138, 27);
            this.labStuNum.TabIndex = 5;
            this.labStuNum.Text = "201300105";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.labUserName);
            this.panel7.Location = new System.Drawing.Point(157, 73);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(192, 33);
            this.panel7.TabIndex = 19;
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.BackColor = System.Drawing.Color.White;
            this.labUserName.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Underline);
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
            this.panel6.Location = new System.Drawing.Point(157, 21);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(192, 33);
            this.panel6.TabIndex = 18;
            // 
            // labClassName
            // 
            this.labClassName.AutoSize = true;
            this.labClassName.BackColor = System.Drawing.Color.White;
            this.labClassName.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Underline);
            this.labClassName.ForeColor = System.Drawing.Color.Blue;
            this.labClassName.Location = new System.Drawing.Point(3, 0);
            this.labClassName.Name = "labClassName";
            this.labClassName.Size = new System.Drawing.Size(175, 27);
            this.labClassName.TabIndex = 1;
            this.labClassName.Text = "高一（12）班";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(13, 229);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(145, 33);
            this.panel5.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "账户同步时间：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 33);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "班别\\部门：";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(13, 177);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(145, 33);
            this.panel4.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "账户余额：";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(13, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 33);
            this.panel3.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "学号\\工号：";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(13, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 33);
            this.panel2.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "姓  名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 20F);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(106, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 27);
            this.label10.TabIndex = 12;
            this.label10.Text = "￥";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "转账金额：";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(408, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(89, 406);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "确认请点击";
            // 
            // btnConfirmRecharge
            // 
            this.btnConfirmRecharge.Enabled = false;
            this.btnConfirmRecharge.Font = new System.Drawing.Font("宋体", 12F);
            this.btnConfirmRecharge.Location = new System.Drawing.Point(191, 392);
            this.btnConfirmRecharge.Name = "btnConfirmRecharge";
            this.btnConfirmRecharge.Size = new System.Drawing.Size(111, 37);
            this.btnConfirmRecharge.TabIndex = 5;
            this.btnConfirmRecharge.Text = "确认转账";
            this.ttConfirmRecharge.SetToolTip(this.btnConfirmRecharge, "组合键：Ctrl+Enter");
            this.btnConfirmRecharge.UseVisualStyleBackColor = true;
            this.btnConfirmRecharge.Click += new System.EventHandler(this.btnConfirmRecharge_Click);
            // 
            // ttConfirmRecharge
            // 
            this.ttConfirmRecharge.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttConfirmRecharge.ToolTipTitle = "快捷方式";
            // 
            // cbxPrint
            // 
            this.cbxPrint.AutoSize = true;
            this.cbxPrint.Location = new System.Drawing.Point(385, 357);
            this.cbxPrint.Name = "cbxPrint";
            this.cbxPrint.Size = new System.Drawing.Size(72, 16);
            this.cbxPrint.TabIndex = 22;
            this.cbxPrint.Text = "打印小票";
            this.cbxPrint.UseVisualStyleBackColor = true;
            // 
            // frmRechargeOfflineSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 436);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnConfirmRecharge);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRechargeOfflineSingle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "转账充值【个人转账】";
            this.Tag = "转账充值【个人转账】";
            this.Text = "转账充值【个人转账】";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRechargeOfflineSingle_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labCardUserInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnConfirmRecharge;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labClassName;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label labStuNum;
        private System.Windows.Forms.TextBox tbxTransferMoney;
        private System.Windows.Forms.ToolTip ttConfirmRecharge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labAccountSyncTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labAccountBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox cbxPrint;
    }
}