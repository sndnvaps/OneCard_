namespace WindowUI.HHZX.UserCard
{
    partial class frmCardReplace
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
            this.gpbReplace = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReaderCon = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblCost = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblReadNo = new System.Windows.Forms.Label();
            this.btnSetCost = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChaName = new System.Windows.Forms.Label();
            this.gbxMain = new System.Windows.Forms.GroupBox();
            this.gpbReplace.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbReplace
            // 
            this.gpbReplace.Controls.Add(this.label4);
            this.gpbReplace.Controls.Add(this.btnReaderCon);
            this.gpbReplace.Controls.Add(this.label12);
            this.gpbReplace.Controls.Add(this.btnRead);
            this.gpbReplace.Controls.Add(this.lblCost);
            this.gpbReplace.Controls.Add(this.btnSave);
            this.gpbReplace.Controls.Add(this.label10);
            this.gpbReplace.Controls.Add(this.lblReadNo);
            this.gpbReplace.Controls.Add(this.btnSetCost);
            this.gpbReplace.Enabled = false;
            this.gpbReplace.Location = new System.Drawing.Point(6, 246);
            this.gpbReplace.Name = "gpbReplace";
            this.gpbReplace.Size = new System.Drawing.Size(434, 106);
            this.gpbReplace.TabIndex = 10;
            this.gpbReplace.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "读卡器:";
            // 
            // btnReaderCon
            // 
            this.btnReaderCon.Location = new System.Drawing.Point(59, 50);
            this.btnReaderCon.Name = "btnReaderCon";
            this.btnReaderCon.Size = new System.Drawing.Size(75, 23);
            this.btnReaderCon.TabIndex = 22;
            this.btnReaderCon.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(293, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "元";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(59, 20);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 14;
            this.btnRead.Text = "读取新卡";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.ForeColor = System.Drawing.Color.Red;
            this.lblCost.Location = new System.Drawing.Point(257, 82);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(23, 12);
            this.lblCost.TabIndex = 19;
            this.lblCost.Text = "7.0";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(324, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "确认换卡";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(150, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "当前换卡费用：￥";
            // 
            // lblReadNo
            // 
            this.lblReadNo.AutoSize = true;
            this.lblReadNo.BackColor = System.Drawing.Color.White;
            this.lblReadNo.Font = new System.Drawing.Font("SimSun", 20F);
            this.lblReadNo.ForeColor = System.Drawing.Color.Blue;
            this.lblReadNo.Location = new System.Drawing.Point(147, 17);
            this.lblReadNo.Name = "lblReadNo";
            this.lblReadNo.Size = new System.Drawing.Size(93, 27);
            this.lblReadNo.TabIndex = 16;
            this.lblReadNo.Text = "未读卡";
            // 
            // btnSetCost
            // 
            this.btnSetCost.Location = new System.Drawing.Point(324, 77);
            this.btnSetCost.Name = "btnSetCost";
            this.btnSetCost.Size = new System.Drawing.Size(90, 23);
            this.btnSetCost.TabIndex = 17;
            this.btnSetCost.Text = "设置换卡费用";
            this.btnSetCost.UseVisualStyleBackColor = true;
            this.btnSetCost.Click += new System.EventHandler(this.btnSetCost_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(697, 477);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectUser);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.lblUserStatus);
            this.groupBox1.Controls.Add(this.lblCardNo);
            this.groupBox1.Controls.Add(this.lblClass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblChaName);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 220);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人员信息";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Location = new System.Drawing.Point(324, 189);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(90, 23);
            this.btnSelectUser.TabIndex = 13;
            this.btnSelectUser.Text = "选择人员";
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "卡状态：";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.BackColor = System.Drawing.Color.White;
            this.lblNumber.Font = new System.Drawing.Font("SimSun", 20F);
            this.lblNumber.ForeColor = System.Drawing.Color.Red;
            this.lblNumber.Location = new System.Drawing.Point(86, 102);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(26, 27);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = " ";
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.AutoSize = true;
            this.lblUserStatus.BackColor = System.Drawing.Color.White;
            this.lblUserStatus.Font = new System.Drawing.Font("SimSun", 20F);
            this.lblUserStatus.ForeColor = System.Drawing.Color.Red;
            this.lblUserStatus.Location = new System.Drawing.Point(87, 181);
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(26, 27);
            this.lblUserStatus.TabIndex = 4;
            this.lblUserStatus.Text = " ";
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.BackColor = System.Drawing.Color.White;
            this.lblCardNo.Font = new System.Drawing.Font("SimSun", 20F);
            this.lblCardNo.ForeColor = System.Drawing.Color.Red;
            this.lblCardNo.Location = new System.Drawing.Point(87, 141);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(26, 27);
            this.lblCardNo.TabIndex = 4;
            this.lblCardNo.Text = " ";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.BackColor = System.Drawing.Color.White;
            this.lblClass.Font = new System.Drawing.Font("SimSun", 20F);
            this.lblClass.ForeColor = System.Drawing.Color.Red;
            this.lblClass.Location = new System.Drawing.Point(86, 27);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(147, 27);
            this.lblClass.TabIndex = 1;
            this.lblClass.Text = "未选择人员";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "班级/部门：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "学号/工号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "持有卡号：";
            // 
            // lblChaName
            // 
            this.lblChaName.AutoSize = true;
            this.lblChaName.BackColor = System.Drawing.Color.White;
            this.lblChaName.Font = new System.Drawing.Font("SimSun", 20F);
            this.lblChaName.ForeColor = System.Drawing.Color.Red;
            this.lblChaName.Location = new System.Drawing.Point(86, 64);
            this.lblChaName.Name = "lblChaName";
            this.lblChaName.Size = new System.Drawing.Size(26, 27);
            this.lblChaName.TabIndex = 1;
            this.lblChaName.Text = " ";
            // 
            // gbxMain
            // 
            this.gbxMain.Controls.Add(this.groupBox1);
            this.gbxMain.Controls.Add(this.gpbReplace);
            this.gbxMain.Location = new System.Drawing.Point(169, 75);
            this.gbxMain.Name = "gbxMain";
            this.gbxMain.Size = new System.Drawing.Size(446, 362);
            this.gbxMain.TabIndex = 21;
            this.gbxMain.TabStop = false;
            // 
            // frmCardReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.gbxMain);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(472, 419);
            this.Name = "frmCardReplace";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "换卡";
            this.Text = "换卡";
            this.SizeChanged += new System.EventHandler(this.frmCardReplace_SizeChanged);
            this.gpbReplace.ResumeLayout(false);
            this.gpbReplace.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbReplace;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblReadNo;
        private System.Windows.Forms.Button btnSetCost;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblUserStatus;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblChaName;
        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReaderCon;
        private System.Windows.Forms.GroupBox gbxMain;

    }
}