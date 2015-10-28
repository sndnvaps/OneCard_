namespace WindowUI.HHZX.UserCard
{
    partial class frmBlackWhiteList
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlWhite = new System.Windows.Forms.Panel();
            this.rbtWhite = new System.Windows.Forms.RadioButton();
            this.btnWhite = new System.Windows.Forms.Button();
            this.pnlBlack = new System.Windows.Forms.Panel();
            this.rbtBlack = new System.Windows.Forms.RadioButton();
            this.btnBlack = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChaName = new System.Windows.Forms.Label();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.pnlWhite.SuspendLayout();
            this.pnlBlack.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlWhite);
            this.groupBox2.Controls.Add(this.pnlBlack);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.btnSelectUser);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 306);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // pnlWhite
            // 
            this.pnlWhite.Controls.Add(this.rbtWhite);
            this.pnlWhite.Controls.Add(this.btnWhite);
            this.pnlWhite.Location = new System.Drawing.Point(6, 270);
            this.pnlWhite.Name = "pnlWhite";
            this.pnlWhite.Size = new System.Drawing.Size(189, 27);
            this.pnlWhite.TabIndex = 20;
            // 
            // rbtWhite
            // 
            this.rbtWhite.AutoSize = true;
            this.rbtWhite.Location = new System.Drawing.Point(7, 5);
            this.rbtWhite.Name = "rbtWhite";
            this.rbtWhite.Size = new System.Drawing.Size(59, 16);
            this.rbtWhite.TabIndex = 10;
            this.rbtWhite.Text = "卡解挂";
            this.rbtWhite.UseVisualStyleBackColor = true;
            this.rbtWhite.CheckedChanged += new System.EventHandler(this.rbtWhite_CheckedChanged);
            // 
            // btnWhite
            // 
            this.btnWhite.Enabled = false;
            this.btnWhite.Location = new System.Drawing.Point(84, 2);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(75, 23);
            this.btnWhite.TabIndex = 11;
            this.btnWhite.Text = "确认解挂";
            this.btnWhite.UseVisualStyleBackColor = true;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // pnlBlack
            // 
            this.pnlBlack.Controls.Add(this.rbtBlack);
            this.pnlBlack.Controls.Add(this.btnBlack);
            this.pnlBlack.Location = new System.Drawing.Point(6, 237);
            this.pnlBlack.Name = "pnlBlack";
            this.pnlBlack.Size = new System.Drawing.Size(189, 29);
            this.pnlBlack.TabIndex = 19;
            // 
            // rbtBlack
            // 
            this.rbtBlack.AutoSize = true;
            this.rbtBlack.Checked = true;
            this.rbtBlack.Location = new System.Drawing.Point(7, 6);
            this.rbtBlack.Name = "rbtBlack";
            this.rbtBlack.Size = new System.Drawing.Size(59, 16);
            this.rbtBlack.TabIndex = 7;
            this.rbtBlack.TabStop = true;
            this.rbtBlack.Text = "卡挂失";
            this.rbtBlack.UseVisualStyleBackColor = true;
            this.rbtBlack.CheckedChanged += new System.EventHandler(this.rbtBlack_CheckedChanged);
            // 
            // btnBlack
            // 
            this.btnBlack.Location = new System.Drawing.Point(84, 3);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(75, 23);
            this.btnBlack.TabIndex = 9;
            this.btnBlack.Text = "确认挂失";
            this.btnBlack.UseVisualStyleBackColor = true;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(344, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.lblUserStatus);
            this.groupBox1.Controls.Add(this.lblCardNo);
            this.groupBox1.Controls.Add(this.lblClass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblChaName);
            this.groupBox1.Location = new System.Drawing.Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 220);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人員信息";
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
            this.lblNumber.Font = new System.Drawing.Font("宋体", 20F);
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
            this.lblUserStatus.Font = new System.Drawing.Font("宋体", 20F);
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
            this.lblCardNo.Font = new System.Drawing.Font("宋体", 20F);
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
            this.lblClass.Font = new System.Drawing.Font("宋体", 20F);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "姓名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "学号/工号：";
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
            this.lblChaName.Font = new System.Drawing.Font("宋体", 20F);
            this.lblChaName.ForeColor = System.Drawing.Color.Red;
            this.lblChaName.Location = new System.Drawing.Point(86, 64);
            this.lblChaName.Name = "lblChaName";
            this.lblChaName.Size = new System.Drawing.Size(26, 27);
            this.lblChaName.TabIndex = 1;
            this.lblChaName.Text = " ";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Location = new System.Drawing.Point(344, 242);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(75, 23);
            this.btnSelectUser.TabIndex = 2;
            this.btnSelectUser.Text = "选择人员";
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // frmBlackWhiteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 326);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(471, 364);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(471, 364);
            this.Name = "frmBlackWhiteList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "卡挂失\\解挂";
            this.Text = "卡挂失\\解挂";
            this.groupBox2.ResumeLayout(false);
            this.pnlWhite.ResumeLayout(false);
            this.pnlWhite.PerformLayout();
            this.pnlBlack.ResumeLayout(false);
            this.pnlBlack.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.RadioButton rbtWhite;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.RadioButton rbtBlack;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblChaName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUserStatus;
        private System.Windows.Forms.Panel pnlWhite;
        private System.Windows.Forms.Panel pnlBlack;
    }
}