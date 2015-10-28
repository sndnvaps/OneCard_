namespace WindowUI.HHZX.UserCard
{
    partial class frmUserCardMatch
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
            this.gbxAll = new System.Windows.Forms.GroupBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tbxContent = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSetNewCardCost = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labNewCardCost = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labAdvanceMoney = new System.Windows.Forms.Label();
            this.labDefault = new System.Windows.Forms.Label();
            this.labConnDetail = new System.Windows.Forms.Label();
            this.rBtnSingleMatch = new System.Windows.Forms.RadioButton();
            this.btnSingleMatch = new System.Windows.Forms.Button();
            this.btnBatchEnd = new System.Windows.Forms.Button();
            this.rBtnBatchMatch = new System.Windows.Forms.RadioButton();
            this.btnBatchBegin = new System.Windows.Forms.Button();
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxUserNum = new System.Windows.Forms.TextBox();
            this.cbxClass = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxDept = new System.Windows.Forms.ComboBox();
            this.ckbNoPaired = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.lvUserCardDetail = new System.Windows.Forms.ListView();
            this.CardID = new System.Windows.Forms.ColumnHeader();
            this.UserID = new System.Windows.Forms.ColumnHeader();
            this.StudentID = new System.Windows.Forms.ColumnHeader();
            this.ClassName = new System.Windows.Forms.ColumnHeader();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.PairStatus = new System.Windows.Forms.ColumnHeader();
            this.PairTime = new System.Windows.Forms.ColumnHeader();
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.gbxAll.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbxSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAll
            // 
            this.gbxAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAll.Controls.Add(this.pnlContent);
            this.gbxAll.Controls.Add(this.groupBox4);
            this.gbxAll.Controls.Add(this.gbxSearch);
            this.gbxAll.Controls.Add(this.lvUserCardDetail);
            this.gbxAll.Enabled = false;
            this.gbxAll.Location = new System.Drawing.Point(0, 20);
            this.gbxAll.Name = "gbxAll";
            this.gbxAll.Size = new System.Drawing.Size(784, 543);
            this.gbxAll.TabIndex = 0;
            this.gbxAll.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.tbxContent);
            this.pnlContent.Location = new System.Drawing.Point(0, 8);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(369, 165);
            this.pnlContent.TabIndex = 29;
            this.pnlContent.Visible = false;
            // 
            // tbxContent
            // 
            this.tbxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxContent.Font = new System.Drawing.Font("SimSun", 9F);
            this.tbxContent.ForeColor = System.Drawing.Color.Blue;
            this.tbxContent.Location = new System.Drawing.Point(4, 6);
            this.tbxContent.Multiline = true;
            this.tbxContent.Name = "tbxContent";
            this.tbxContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxContent.Size = new System.Drawing.Size(359, 150);
            this.tbxContent.TabIndex = 0;
            this.tbxContent.Text = "连续发卡开始:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnSetNewCardCost);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.labNewCardCost);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.labAdvanceMoney);
            this.groupBox4.Controls.Add(this.labDefault);
            this.groupBox4.Controls.Add(this.labConnDetail);
            this.groupBox4.Controls.Add(this.rBtnSingleMatch);
            this.groupBox4.Controls.Add(this.btnSingleMatch);
            this.groupBox4.Controls.Add(this.btnBatchEnd);
            this.groupBox4.Controls.Add(this.rBtnBatchMatch);
            this.groupBox4.Controls.Add(this.btnBatchBegin);
            this.groupBox4.Location = new System.Drawing.Point(6, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(772, 91);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发卡";
            // 
            // btnSetNewCardCost
            // 
            this.btnSetNewCardCost.Location = new System.Drawing.Point(202, 56);
            this.btnSetNewCardCost.Name = "btnSetNewCardCost";
            this.btnSetNewCardCost.Size = new System.Drawing.Size(44, 23);
            this.btnSetNewCardCost.TabIndex = 40;
            this.btnSetNewCardCost.Text = "修改";
            this.btnSetNewCardCost.UseVisualStyleBackColor = true;
            this.btnSetNewCardCost.Click += new System.EventHandler(this.btnSetNewCardCost_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "元";
            // 
            // labNewCardCost
            // 
            this.labNewCardCost.AutoSize = true;
            this.labNewCardCost.BackColor = System.Drawing.Color.White;
            this.labNewCardCost.Font = new System.Drawing.Font("SimSun", 11F);
            this.labNewCardCost.ForeColor = System.Drawing.Color.Red;
            this.labNewCardCost.Location = new System.Drawing.Point(107, 60);
            this.labNewCardCost.Name = "labNewCardCost";
            this.labNewCardCost.Size = new System.Drawing.Size(39, 15);
            this.labNewCardCost.TabIndex = 38;
            this.labNewCardCost.Text = "7.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "新卡工本费：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "元";
            // 
            // labAdvanceMoney
            // 
            this.labAdvanceMoney.AutoSize = true;
            this.labAdvanceMoney.BackColor = System.Drawing.Color.White;
            this.labAdvanceMoney.Font = new System.Drawing.Font("SimSun", 11F);
            this.labAdvanceMoney.ForeColor = System.Drawing.Color.Red;
            this.labAdvanceMoney.Location = new System.Drawing.Point(377, 60);
            this.labAdvanceMoney.Name = "labAdvanceMoney";
            this.labAdvanceMoney.Size = new System.Drawing.Size(47, 15);
            this.labAdvanceMoney.TabIndex = 34;
            this.labAdvanceMoney.Text = "30.00";
            // 
            // labDefault
            // 
            this.labDefault.AutoSize = true;
            this.labDefault.Location = new System.Drawing.Point(282, 61);
            this.labDefault.Name = "labDefault";
            this.labDefault.Size = new System.Drawing.Size(89, 12);
            this.labDefault.TabIndex = 33;
            this.labDefault.Text = "学生透支金额：";
            // 
            // labConnDetail
            // 
            this.labConnDetail.AutoSize = true;
            this.labConnDetail.BackColor = System.Drawing.Color.White;
            this.labConnDetail.Location = new System.Drawing.Point(491, 61);
            this.labConnDetail.Name = "labConnDetail";
            this.labConnDetail.Size = new System.Drawing.Size(41, 12);
            this.labConnDetail.TabIndex = 32;
            this.labConnDetail.Text = "未连接";
            // 
            // rBtnSingleMatch
            // 
            this.rBtnSingleMatch.AutoSize = true;
            this.rBtnSingleMatch.Checked = true;
            this.rBtnSingleMatch.Location = new System.Drawing.Point(26, 19);
            this.rBtnSingleMatch.Name = "rBtnSingleMatch";
            this.rBtnSingleMatch.Size = new System.Drawing.Size(71, 16);
            this.rBtnSingleMatch.TabIndex = 28;
            this.rBtnSingleMatch.TabStop = true;
            this.rBtnSingleMatch.Text = "普通发卡";
            this.rBtnSingleMatch.UseVisualStyleBackColor = true;
            this.rBtnSingleMatch.CheckedChanged += new System.EventHandler(this.rBtnSingleMatch_CheckedChanged);
            // 
            // btnSingleMatch
            // 
            this.btnSingleMatch.Enabled = false;
            this.btnSingleMatch.Location = new System.Drawing.Point(103, 13);
            this.btnSingleMatch.Name = "btnSingleMatch";
            this.btnSingleMatch.Size = new System.Drawing.Size(75, 29);
            this.btnSingleMatch.TabIndex = 24;
            this.btnSingleMatch.Text = "发卡";
            this.btnSingleMatch.UseVisualStyleBackColor = true;
            this.btnSingleMatch.Click += new System.EventHandler(this.btnSingleMatch_Click);
            // 
            // btnBatchEnd
            // 
            this.btnBatchEnd.Enabled = false;
            this.btnBatchEnd.Location = new System.Drawing.Point(457, 13);
            this.btnBatchEnd.Name = "btnBatchEnd";
            this.btnBatchEnd.Size = new System.Drawing.Size(75, 29);
            this.btnBatchEnd.TabIndex = 31;
            this.btnBatchEnd.Text = "结束";
            this.btnBatchEnd.UseVisualStyleBackColor = true;
            this.btnBatchEnd.Click += new System.EventHandler(this.btnBatchEnd_Click);
            // 
            // rBtnBatchMatch
            // 
            this.rBtnBatchMatch.AutoSize = true;
            this.rBtnBatchMatch.Location = new System.Drawing.Point(281, 19);
            this.rBtnBatchMatch.Name = "rBtnBatchMatch";
            this.rBtnBatchMatch.Size = new System.Drawing.Size(71, 16);
            this.rBtnBatchMatch.TabIndex = 29;
            this.rBtnBatchMatch.Text = "连续发卡";
            this.rBtnBatchMatch.UseVisualStyleBackColor = true;
            this.rBtnBatchMatch.CheckedChanged += new System.EventHandler(this.rBtnBatchMatch_CheckedChanged);
            // 
            // btnBatchBegin
            // 
            this.btnBatchBegin.Enabled = false;
            this.btnBatchBegin.Location = new System.Drawing.Point(369, 13);
            this.btnBatchBegin.Name = "btnBatchBegin";
            this.btnBatchBegin.Size = new System.Drawing.Size(75, 29);
            this.btnBatchBegin.TabIndex = 30;
            this.btnBatchBegin.Text = "开始";
            this.btnBatchBegin.UseVisualStyleBackColor = true;
            this.btnBatchBegin.Click += new System.EventHandler(this.btnBatchBegin_Click);
            // 
            // gbxSearch
            // 
            this.gbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSearch.Controls.Add(this.label2);
            this.gbxSearch.Controls.Add(this.tbxUserNum);
            this.gbxSearch.Controls.Add(this.cbxClass);
            this.gbxSearch.Controls.Add(this.label7);
            this.gbxSearch.Controls.Add(this.tbxUserName);
            this.gbxSearch.Controls.Add(this.label11);
            this.gbxSearch.Controls.Add(this.cbxDept);
            this.gbxSearch.Controls.Add(this.ckbNoPaired);
            this.gbxSearch.Controls.Add(this.label1);
            this.gbxSearch.Controls.Add(this.btnSelectUser);
            this.gbxSearch.Location = new System.Drawing.Point(6, 11);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(772, 77);
            this.gbxSearch.TabIndex = 32;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "人员筛选";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "用户编号：";
            // 
            // tbxUserNum
            // 
            this.tbxUserNum.Location = new System.Drawing.Point(350, 48);
            this.tbxUserNum.Name = "tbxUserNum";
            this.tbxUserNum.Size = new System.Drawing.Size(182, 21);
            this.tbxUserNum.TabIndex = 28;
            // 
            // cbxClass
            // 
            this.cbxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClass.FormattingEnabled = true;
            this.cbxClass.Location = new System.Drawing.Point(71, 17);
            this.cbxClass.Name = "cbxClass";
            this.cbxClass.Size = new System.Drawing.Size(175, 20);
            this.cbxClass.TabIndex = 21;
            this.cbxClass.SelectedIndexChanged += new System.EventHandler(this.cbxClass_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "用户姓名：";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(350, 19);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(182, 21);
            this.tbxUserName.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "班级：";
            // 
            // cbxDept
            // 
            this.cbxDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDept.FormattingEnabled = true;
            this.cbxDept.Location = new System.Drawing.Point(71, 43);
            this.cbxDept.Name = "cbxDept";
            this.cbxDept.Size = new System.Drawing.Size(175, 20);
            this.cbxDept.TabIndex = 26;
            this.cbxDept.SelectedIndexChanged += new System.EventHandler(this.cbxDept_SelectedIndexChanged);
            // 
            // ckbNoPaired
            // 
            this.ckbNoPaired.AutoSize = true;
            this.ckbNoPaired.Checked = true;
            this.ckbNoPaired.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbNoPaired.Location = new System.Drawing.Point(542, 21);
            this.ckbNoPaired.Name = "ckbNoPaired";
            this.ckbNoPaired.Size = new System.Drawing.Size(60, 16);
            this.ckbNoPaired.TabIndex = 22;
            this.ckbNoPaired.Text = "未发卡";
            this.ckbNoPaired.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "部门：";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Location = new System.Drawing.Point(638, 45);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(75, 24);
            this.btnSelectUser.TabIndex = 23;
            this.btnSelectUser.Text = "搜索";
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // lvUserCardDetail
            // 
            this.lvUserCardDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUserCardDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CardID,
            this.UserID,
            this.StudentID,
            this.ClassName,
            this.UserName,
            this.PairStatus,
            this.PairTime});
            this.lvUserCardDetail.Font = new System.Drawing.Font("SimSun", 11F);
            this.lvUserCardDetail.FullRowSelect = true;
            this.lvUserCardDetail.Location = new System.Drawing.Point(6, 191);
            this.lvUserCardDetail.Name = "lvUserCardDetail";
            this.lvUserCardDetail.Size = new System.Drawing.Size(772, 346);
            this.lvUserCardDetail.TabIndex = 0;
            this.lvUserCardDetail.UseCompatibleStateImageBehavior = false;
            this.lvUserCardDetail.View = System.Windows.Forms.View.Details;
            this.lvUserCardDetail.SelectedIndexChanged += new System.EventHandler(this.lvUserCardDetail_SelectedIndexChanged);
            this.lvUserCardDetail.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvUserCardDetail_ColumnClick);
            // 
            // CardID
            // 
            this.CardID.Tag = "PairCardID";
            this.CardID.Text = "卡原始ID";
            this.CardID.Width = 0;
            // 
            // UserID
            // 
            this.UserID.Tag = "cus_cRecordID";
            this.UserID.Text = "用户ID";
            this.UserID.Width = 0;
            // 
            // StudentID
            // 
            this.StudentID.Tag = "cus_cStudentID";
            this.StudentID.Text = "用户编号";
            this.StudentID.Width = 150;
            // 
            // ClassName
            // 
            this.ClassName.Tag = "ClassName";
            this.ClassName.Text = "班别/部门";
            this.ClassName.Width = 150;
            // 
            // UserName
            // 
            this.UserName.Tag = "cus_cChaName";
            this.UserName.Text = "姓名";
            this.UserName.Width = 80;
            // 
            // PairStatus
            // 
            this.PairStatus.Tag = "PairCardNo";
            this.PairStatus.Text = "持有卡卡号";
            this.PairStatus.Width = 132;
            // 
            // PairTime
            // 
            this.PairTime.Tag = "PairCardTime";
            this.PairTime.Text = "发卡时间";
            this.PairTime.Width = 256;
            // 
            // sysToolBar
            // 
            this.sysToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sysToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sysToolBar.BtnDelete_IsEnabled = false;
            this.sysToolBar.BtnDelete_IsUsed = false;
            this.sysToolBar.BtnDetail_IsEnabled = false;
            this.sysToolBar.BtnDetail_IsUsed = false;
            this.sysToolBar.BtnExit_IsEnabled = false;
            this.sysToolBar.BtnExit_IsUsed = false;
            this.sysToolBar.BtnModify_IsEnabled = false;
            this.sysToolBar.BtnModify_IsUsed = false;
            this.sysToolBar.BtnNew_IsEnabled = false;
            this.sysToolBar.BtnNew_IsUsed = false;
            this.sysToolBar.BtnRefresh_IsEnabled = true;
            this.sysToolBar.BtnRefresh_IsUsed = true;
            this.sysToolBar.BtnSave_IsEnabled = false;
            this.sysToolBar.BtnSave_IsUsed = false;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(784, 23);
            this.sysToolBar.TabIndex = 34;
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            // 
            // frmUserCardMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.sysToolBar);
            this.Controls.Add(this.gbxAll);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmUserCardMatch";
            this.TabText = "用户卡发卡";
            this.Text = "用户卡发卡";
            this.gbxAll.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAll;
        private System.Windows.Forms.ListView lvUserCardDetail;
        private System.Windows.Forms.Button btnSingleMatch;
        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.CheckBox ckbNoPaired;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader StudentID;
        private System.Windows.Forms.ColumnHeader ClassName;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader PairStatus;
        private System.Windows.Forms.ComboBox cbxDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxClass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader PairTime;
        private System.Windows.Forms.Button btnBatchEnd;
        private System.Windows.Forms.Button btnBatchBegin;
        private System.Windows.Forms.RadioButton rBtnBatchMatch;
        private System.Windows.Forms.RadioButton rBtnSingleMatch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxUserNum;
        private System.Windows.Forms.ColumnHeader CardID;
        private System.Windows.Forms.Label labConnDetail;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.Label labDefault;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labAdvanceMoney;
        private System.Windows.Forms.Button btnSetNewCardCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labNewCardCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TextBox tbxContent;
        private WindowControls.HBPMS.SystemToolBar sysToolBar;
    }
}