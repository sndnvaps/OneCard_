namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmStaffMasterDetailNew
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
            this.cbxDptName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxStaffNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutoNum = new System.Windows.Forms.Button();
            this.cbxSexName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxContactNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxIsActive = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.sysToolBar.Size = new System.Drawing.Size(441, 23);
            this.sysToolBar.TabIndex = 2;
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            this.sysToolBar.OnItemSave_Click += new WindowControls.HBPMS.SystemToolBar.ItemSave_Click(this.sysToolBar_OnItemSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbxRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxIsActive);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxContactNum);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbxSexName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAutoNum);
            this.groupBox1.Controls.Add(this.tbxStaffNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxDptName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxUserName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labUserID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 408);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cbxDptName
            // 
            this.cbxDptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDptName.Font = new System.Drawing.Font("SimSun", 12F);
            this.cbxDptName.FormattingEnabled = true;
            this.cbxDptName.Location = new System.Drawing.Point(116, 98);
            this.cbxDptName.Name = "cbxDptName";
            this.cbxDptName.Size = new System.Drawing.Size(199, 24);
            this.cbxDptName.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("SimSun", 12F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(38, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "*部门：";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxUserName.Location = new System.Drawing.Point(116, 56);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(199, 26);
            this.tbxUserName.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("SimSun", 12F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(38, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "*姓名：";
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.BackColor = System.Drawing.Color.White;
            this.labUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labUserID.Font = new System.Drawing.Font("SimSun", 12F);
            this.labUserID.Location = new System.Drawing.Point(116, 19);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(298, 18);
            this.labUserID.TabIndex = 24;
            this.labUserID.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F);
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "教师ID：";
            // 
            // tbxStaffNum
            // 
            this.tbxStaffNum.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxStaffNum.Location = new System.Drawing.Point(116, 147);
            this.tbxStaffNum.Name = "tbxStaffNum";
            this.tbxStaffNum.Size = new System.Drawing.Size(199, 26);
            this.tbxStaffNum.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(38, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "*工号：";
            // 
            // btnAutoNum
            // 
            this.btnAutoNum.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnAutoNum.Location = new System.Drawing.Point(321, 145);
            this.btnAutoNum.Name = "btnAutoNum";
            this.btnAutoNum.Size = new System.Drawing.Size(93, 26);
            this.btnAutoNum.TabIndex = 31;
            this.btnAutoNum.Text = "自动编号";
            this.btnAutoNum.UseVisualStyleBackColor = true;
            this.btnAutoNum.Click += new System.EventHandler(this.btnAutoNum_Click);
            // 
            // cbxSexName
            // 
            this.cbxSexName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexName.Font = new System.Drawing.Font("SimSun", 12F);
            this.cbxSexName.FormattingEnabled = true;
            this.cbxSexName.Location = new System.Drawing.Point(116, 188);
            this.cbxSexName.Name = "cbxSexName";
            this.cbxSexName.Size = new System.Drawing.Size(80, 24);
            this.cbxSexName.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("SimSun", 12F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(38, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "*性别：";
            // 
            // tbxContactNum
            // 
            this.tbxContactNum.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxContactNum.Location = new System.Drawing.Point(116, 275);
            this.tbxContactNum.Name = "tbxContactNum";
            this.tbxContactNum.Size = new System.Drawing.Size(199, 26);
            this.tbxContactNum.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("SimSun", 12F);
            this.label9.Location = new System.Drawing.Point(18, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "联系电话:";
            // 
            // cbxIsActive
            // 
            this.cbxIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIsActive.Font = new System.Drawing.Font("SimSun", 12F);
            this.cbxIsActive.FormattingEnabled = true;
            this.cbxIsActive.Location = new System.Drawing.Point(116, 230);
            this.cbxIsActive.Name = "cbxIsActive";
            this.cbxIsActive.Size = new System.Drawing.Size(80, 24);
            this.cbxIsActive.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("SimSun", 12F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(6, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "*是否有效：";
            // 
            // tbxRemarks
            // 
            this.tbxRemarks.Font = new System.Drawing.Font("SimSun", 12F);
            this.tbxRemarks.Location = new System.Drawing.Point(116, 322);
            this.tbxRemarks.Multiline = true;
            this.tbxRemarks.Name = "tbxRemarks";
            this.tbxRemarks.Size = new System.Drawing.Size(300, 78);
            this.tbxRemarks.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("SimSun", 12F);
            this.label6.Location = new System.Drawing.Point(46, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "备注：";
            // 
            // frmStaffMasterDetailNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 438);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStaffMasterDetailNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "教师信息";
            this.Text = "教师信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxStaffNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAutoNum;
        private System.Windows.Forms.ComboBox cbxSexName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxContactNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxRemarks;
        private System.Windows.Forms.Label label6;
    }
}