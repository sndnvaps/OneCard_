namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmStudentMasterDetailNew
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
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nbxBankAccount = new WindowControls.HHZX.NumberBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAutoCode = new System.Windows.Forms.Button();
            this.tbxContactNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxContactName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxGraduation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxYear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxStuNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxRemarks = new System.Windows.Forms.TextBox();
            this.cbxIsActive = new System.Windows.Forms.ComboBox();
            this.cbxClassName = new System.Windows.Forms.ComboBox();
            this.cbxSexName = new System.Windows.Forms.ComboBox();
            this.labUserID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysToolBar
            // 
            this.sysToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sysToolBar.BtnDelete_IsEnabled = false;
            this.sysToolBar.BtnDelete_IsUsed = false;
            this.sysToolBar.BtnDetail_IsEnabled = false;
            this.sysToolBar.BtnDetail_IsUsed = false;
            this.sysToolBar.BtnExit_IsEnabled = true;
            this.sysToolBar.BtnExit_IsUsed = true;
            this.sysToolBar.BtnModify_IsEnabled = false;
            this.sysToolBar.BtnModify_IsUsed = false;
            this.sysToolBar.BtnNew_IsEnabled = false;
            this.sysToolBar.BtnNew_IsUsed = false;
            this.sysToolBar.BtnRefresh_IsEnabled = true;
            this.sysToolBar.BtnRefresh_IsUsed = true;
            this.sysToolBar.BtnSave_IsEnabled = true;
            this.sysToolBar.BtnSave_IsUsed = true;
            this.sysToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(467, 23);
            this.sysToolBar.TabIndex = 1;
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            this.sysToolBar.OnItemSave_Click += new WindowControls.HBPMS.SystemToolBar.ItemSave_Click(this.sysToolBar_OnItemSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nbxBankAccount);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbxUserName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnAutoCode);
            this.groupBox1.Controls.Add(this.tbxContactNum);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxContactName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbxGraduation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxYear);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxStuNum);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxRemarks);
            this.groupBox1.Controls.Add(this.cbxIsActive);
            this.groupBox1.Controls.Add(this.cbxClassName);
            this.groupBox1.Controls.Add(this.cbxSexName);
            this.groupBox1.Controls.Add(this.labUserID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 536);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // nbxBankAccount
            // 
            this.nbxBankAccount.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbxBankAccount.Font = new System.Drawing.Font("SimSun", 12F);
            this.nbxBankAccount.Location = new System.Drawing.Point(133, 413);
            this.nbxBankAccount.Name = "nbxBankAccount";
            this.nbxBankAccount.Size = new System.Drawing.Size(199, 26);
            this.nbxBankAccount.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("SimSun", 12F);
            this.label12.Location = new System.Drawing.Point(21, 416);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "银行账户：";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxUserName.Location = new System.Drawing.Point(133, 53);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(199, 26);
            this.tbxUserName.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("SimSun", 12F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(23, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "*姓名：";
            // 
            // btnAutoCode
            // 
            this.btnAutoCode.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnAutoCode.Location = new System.Drawing.Point(338, 131);
            this.btnAutoCode.Name = "btnAutoCode";
            this.btnAutoCode.Size = new System.Drawing.Size(95, 26);
            this.btnAutoCode.TabIndex = 20;
            this.btnAutoCode.Text = "自动编号";
            this.btnAutoCode.UseVisualStyleBackColor = true;
            this.btnAutoCode.Click += new System.EventHandler(this.btnAutoCode_Click);
            // 
            // tbxContactNum
            // 
            this.tbxContactNum.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxContactNum.Location = new System.Drawing.Point(133, 373);
            this.tbxContactNum.Name = "tbxContactNum";
            this.tbxContactNum.Size = new System.Drawing.Size(199, 26);
            this.tbxContactNum.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("SimSun", 12F);
            this.label9.Location = new System.Drawing.Point(21, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "联系人电话：";
            // 
            // tbxContactName
            // 
            this.tbxContactName.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxContactName.Location = new System.Drawing.Point(135, 333);
            this.tbxContactName.Name = "tbxContactName";
            this.tbxContactName.Size = new System.Drawing.Size(197, 26);
            this.tbxContactName.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("SimSun", 12F);
            this.label10.Location = new System.Drawing.Point(21, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "联系人名称：";
            // 
            // tbxGraduation
            // 
            this.tbxGraduation.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxGraduation.Location = new System.Drawing.Point(133, 253);
            this.tbxGraduation.Name = "tbxGraduation";
            this.tbxGraduation.Size = new System.Drawing.Size(199, 26);
            this.tbxGraduation.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("SimSun", 12F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(21, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "*届别：";
            // 
            // tbxYear
            // 
            this.tbxYear.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxYear.Location = new System.Drawing.Point(133, 213);
            this.tbxYear.Name = "tbxYear";
            this.tbxYear.Size = new System.Drawing.Size(199, 26);
            this.tbxYear.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("SimSun", 12F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(21, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "*入学时间：";
            // 
            // tbxStuNum
            // 
            this.tbxStuNum.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxStuNum.Location = new System.Drawing.Point(133, 133);
            this.tbxStuNum.Name = "tbxStuNum";
            this.tbxStuNum.Size = new System.Drawing.Size(199, 26);
            this.tbxStuNum.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("SimSun", 12F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(21, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "*学号：";
            // 
            // tbxRemarks
            // 
            this.tbxRemarks.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxRemarks.Location = new System.Drawing.Point(133, 457);
            this.tbxRemarks.Multiline = true;
            this.tbxRemarks.Name = "tbxRemarks";
            this.tbxRemarks.Size = new System.Drawing.Size(300, 73);
            this.tbxRemarks.TabIndex = 9;
            // 
            // cbxIsActive
            // 
            this.cbxIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIsActive.Font = new System.Drawing.Font("SimSun", 12F);
            this.cbxIsActive.FormattingEnabled = true;
            this.cbxIsActive.Location = new System.Drawing.Point(133, 293);
            this.cbxIsActive.Name = "cbxIsActive";
            this.cbxIsActive.Size = new System.Drawing.Size(80, 24);
            this.cbxIsActive.TabIndex = 8;
            // 
            // cbxClassName
            // 
            this.cbxClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClassName.Font = new System.Drawing.Font("SimSun", 12F);
            this.cbxClassName.FormattingEnabled = true;
            this.cbxClassName.Location = new System.Drawing.Point(133, 93);
            this.cbxClassName.Name = "cbxClassName";
            this.cbxClassName.Size = new System.Drawing.Size(199, 24);
            this.cbxClassName.TabIndex = 7;
            // 
            // cbxSexName
            // 
            this.cbxSexName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexName.Font = new System.Drawing.Font("SimSun", 12F);
            this.cbxSexName.FormattingEnabled = true;
            this.cbxSexName.Location = new System.Drawing.Point(133, 173);
            this.cbxSexName.Name = "cbxSexName";
            this.cbxSexName.Size = new System.Drawing.Size(80, 24);
            this.cbxSexName.TabIndex = 6;
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.BackColor = System.Drawing.Color.White;
            this.labUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labUserID.Font = new System.Drawing.Font("SimSun", 12F);
            this.labUserID.Location = new System.Drawing.Point(135, 14);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(298, 18);
            this.labUserID.TabIndex = 5;
            this.labUserID.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("SimSun", 12F);
            this.label5.Location = new System.Drawing.Point(21, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "备注：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("SimSun", 12F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(21, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "*是否有效：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("SimSun", 12F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(21, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "*班别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(21, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "*性别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F);
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "学生ID：";
            // 
            // frmStudentMasterDetailNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 569);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudentMasterDetailNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "学生信息";
            this.Tag = "学生信息";
            this.Text = "学生信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxRemarks;
        private System.Windows.Forms.ComboBox cbxIsActive;
        private System.Windows.Forms.ComboBox cbxClassName;
        private System.Windows.Forms.ComboBox cbxSexName;
        private System.Windows.Forms.Label labUserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAutoCode;
        private System.Windows.Forms.TextBox tbxContactNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxContactName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxGraduation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxStuNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label11;
        private WindowControls.HHZX.NumberBox nbxBankAccount;
        private System.Windows.Forms.Label label12;
    }
}