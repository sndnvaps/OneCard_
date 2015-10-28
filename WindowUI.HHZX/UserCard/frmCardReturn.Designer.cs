namespace WindowUI.HHZX.UserCard
{
    partial class frmCardReturn
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
            this.pnlQueryArea = new System.Windows.Forms.Panel();
            this.nudCardNo = new WindowControls.HHZX.NumberBox();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxIsGraduation = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxUserNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.cbbSex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSingleReturn = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBatchReturn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbSelectAll = new System.Windows.Forms.CheckBox();
            this.lvStudentList = new System.Windows.Forms.ListView();
            this.Ext_RecordID = new System.Windows.Forms.ColumnHeader();
            this.Ext_UserNum = new System.Windows.Forms.ColumnHeader();
            this.Ext_UserName = new System.Windows.Forms.ColumnHeader();
            this.Ext_GroupName = new System.Windows.Forms.ColumnHeader();
            this.Ext_CardNo = new System.Windows.Forms.ColumnHeader();
            this.Ext_PairTime = new System.Windows.Forms.ColumnHeader();
            this.Ext_ValidMsg = new System.Windows.Forms.ColumnHeader();
            this.Ext_Valid = new System.Windows.Forms.ColumnHeader();
            this.pnlQueryArea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlQueryArea
            // 
            this.pnlQueryArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQueryArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQueryArea.Controls.Add(this.nudCardNo);
            this.pnlQueryArea.Controls.Add(this.btnReadCard);
            this.pnlQueryArea.Controls.Add(this.label6);
            this.pnlQueryArea.Controls.Add(this.cbxIsGraduation);
            this.pnlQueryArea.Controls.Add(this.label1);
            this.pnlQueryArea.Controls.Add(this.cbbDepartment);
            this.pnlQueryArea.Controls.Add(this.label2);
            this.pnlQueryArea.Controls.Add(this.cbbClass);
            this.pnlQueryArea.Controls.Add(this.label3);
            this.pnlQueryArea.Controls.Add(this.tbxUserNum);
            this.pnlQueryArea.Controls.Add(this.label4);
            this.pnlQueryArea.Controls.Add(this.tbxUserName);
            this.pnlQueryArea.Controls.Add(this.cbbSex);
            this.pnlQueryArea.Controls.Add(this.label5);
            this.pnlQueryArea.Location = new System.Drawing.Point(7, 17);
            this.pnlQueryArea.Name = "pnlQueryArea";
            this.pnlQueryArea.Size = new System.Drawing.Size(233, 249);
            this.pnlQueryArea.TabIndex = 31;
            // 
            // nudCardNo
            // 
            this.nudCardNo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCardNo.Location = new System.Drawing.Point(97, 7);
            this.nudCardNo.Name = "nudCardNo";
            this.nudCardNo.Size = new System.Drawing.Size(69, 21);
            this.nudCardNo.TabIndex = 27;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(166, 5);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(48, 23);
            this.btnReadCard.TabIndex = 26;
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "卡 号：";
            // 
            // cbxIsGraduation
            // 
            this.cbxIsGraduation.AutoSize = true;
            this.cbxIsGraduation.Location = new System.Drawing.Point(20, 219);
            this.cbxIsGraduation.Name = "cbxIsGraduation";
            this.cbxIsGraduation.Size = new System.Drawing.Size(60, 16);
            this.cbxIsGraduation.TabIndex = 14;
            this.cbxIsGraduation.Text = "已毕业";
            this.cbxIsGraduation.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "部 门：";
            // 
            // cbbDepartment
            // 
            this.cbbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDepartment.FormattingEnabled = true;
            this.cbbDepartment.Items.AddRange(new object[] {
            "一班",
            "二班",
            "三班"});
            this.cbbDepartment.Location = new System.Drawing.Point(97, 77);
            this.cbbDepartment.Name = "cbbDepartment";
            this.cbbDepartment.Size = new System.Drawing.Size(115, 20);
            this.cbbDepartment.TabIndex = 11;
            this.cbbDepartment.SelectedIndexChanged += new System.EventHandler(this.cbbDepartment_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "班 级：";
            // 
            // cbbClass
            // 
            this.cbbClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClass.FormattingEnabled = true;
            this.cbbClass.Items.AddRange(new object[] {
            "一班",
            "二班",
            "三班"});
            this.cbbClass.Location = new System.Drawing.Point(97, 39);
            this.cbbClass.Name = "cbbClass";
            this.cbbClass.Size = new System.Drawing.Size(115, 20);
            this.cbbClass.TabIndex = 3;
            this.cbbClass.SelectedIndexChanged += new System.EventHandler(this.cbbClass_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "学号\\工号：";
            // 
            // tbxUserNum
            // 
            this.tbxUserNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUserNum.Location = new System.Drawing.Point(97, 113);
            this.tbxUserNum.Name = "tbxUserNum";
            this.tbxUserNum.Size = new System.Drawing.Size(114, 21);
            this.tbxUserNum.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "姓 名：";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUserName.Location = new System.Drawing.Point(97, 150);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(114, 21);
            this.tbxUserName.TabIndex = 7;
            // 
            // cbbSex
            // 
            this.cbbSex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSex.FormattingEnabled = true;
            this.cbbSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbbSex.Location = new System.Drawing.Point(97, 187);
            this.cbbSex.Name = "cbbSex";
            this.cbbSex.Size = new System.Drawing.Size(45, 20);
            this.cbbSex.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "性 别：";
            // 
            // btnSingleReturn
            // 
            this.btnSingleReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSingleReturn.Enabled = false;
            this.btnSingleReturn.Location = new System.Drawing.Point(20, 308);
            this.btnSingleReturn.Name = "btnSingleReturn";
            this.btnSingleReturn.Size = new System.Drawing.Size(100, 30);
            this.btnSingleReturn.TabIndex = 30;
            this.btnSingleReturn.Text = "退卡";
            this.btnSingleReturn.UseVisualStyleBackColor = true;
            this.btnSingleReturn.Click += new System.EventHandler(this.btnSingleReturn_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(73, 272);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 30);
            this.btnQuery.TabIndex = 29;
            this.btnQuery.Text = "查  询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // sysToolBar
            // 
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
            this.sysToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(734, 23);
            this.sysToolBar.TabIndex = 32;
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnBatchReturn);
            this.groupBox1.Controls.Add(this.pnlQueryArea);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.btnSingleReturn);
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 429);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(73, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBatchReturn
            // 
            this.btnBatchReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchReturn.Enabled = false;
            this.btnBatchReturn.Location = new System.Drawing.Point(126, 308);
            this.btnBatchReturn.Name = "btnBatchReturn";
            this.btnBatchReturn.Size = new System.Drawing.Size(100, 30);
            this.btnBatchReturn.TabIndex = 32;
            this.btnBatchReturn.Text = "批量退卡";
            this.btnBatchReturn.UseVisualStyleBackColor = true;
            this.btnBatchReturn.Click += new System.EventHandler(this.btnBatchReturn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ckbSelectAll);
            this.groupBox3.Controls.Add(this.lvStudentList);
            this.groupBox3.Location = new System.Drawing.Point(252, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(482, 429);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询结果";
            // 
            // ckbSelectAll
            // 
            this.ckbSelectAll.AutoSize = true;
            this.ckbSelectAll.Location = new System.Drawing.Point(10, 24);
            this.ckbSelectAll.Name = "ckbSelectAll";
            this.ckbSelectAll.Size = new System.Drawing.Size(15, 14);
            this.ckbSelectAll.TabIndex = 29;
            this.ckbSelectAll.UseVisualStyleBackColor = true;
            this.ckbSelectAll.Visible = false;
            this.ckbSelectAll.CheckedChanged += new System.EventHandler(this.ckbSelectAll_CheckedChanged);
            // 
            // lvStudentList
            // 
            this.lvStudentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ext_RecordID,
            this.Ext_UserNum,
            this.Ext_UserName,
            this.Ext_GroupName,
            this.Ext_CardNo,
            this.Ext_PairTime,
            this.Ext_ValidMsg,
            this.Ext_Valid});
            this.lvStudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStudentList.Font = new System.Drawing.Font("SimSun", 12F);
            this.lvStudentList.FullRowSelect = true;
            this.lvStudentList.GridLines = true;
            this.lvStudentList.Location = new System.Drawing.Point(3, 17);
            this.lvStudentList.Name = "lvStudentList";
            this.lvStudentList.Size = new System.Drawing.Size(476, 409);
            this.lvStudentList.TabIndex = 3;
            this.lvStudentList.UseCompatibleStateImageBehavior = false;
            this.lvStudentList.View = System.Windows.Forms.View.Details;
            this.lvStudentList.SelectedIndexChanged += new System.EventHandler(this.lvStudentList_SelectedIndexChanged);
            this.lvStudentList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvStudentList_ColumnClick);
            // 
            // Ext_RecordID
            // 
            this.Ext_RecordID.Tag = "Ext_RecordID";
            this.Ext_RecordID.Text = "";
            this.Ext_RecordID.Width = 0;
            // 
            // Ext_UserNum
            // 
            this.Ext_UserNum.Tag = "Ext_UserNum";
            this.Ext_UserNum.Text = "学号/工号";
            this.Ext_UserNum.Width = 150;
            // 
            // Ext_UserName
            // 
            this.Ext_UserName.Tag = "Ext_UserName";
            this.Ext_UserName.Text = "姓名";
            this.Ext_UserName.Width = 150;
            // 
            // Ext_GroupName
            // 
            this.Ext_GroupName.Tag = "Ext_GroupName";
            this.Ext_GroupName.Text = "班级/部门";
            this.Ext_GroupName.Width = 150;
            // 
            // Ext_CardNo
            // 
            this.Ext_CardNo.Tag = "Ext_CardNo";
            this.Ext_CardNo.Text = "持有卡号";
            this.Ext_CardNo.Width = 100;
            // 
            // Ext_PairTime
            // 
            this.Ext_PairTime.Tag = "Ext_PairTime";
            this.Ext_PairTime.Text = "发卡时间";
            this.Ext_PairTime.Width = 250;
            // 
            // Ext_ValidMsg
            // 
            this.Ext_ValidMsg.Tag = "Ext_ValidMsg";
            this.Ext_ValidMsg.Text = "检查结果";
            this.Ext_ValidMsg.Width = 400;
            // 
            // Ext_Valid
            // 
            this.Ext_Valid.Tag = "Ext_Valid";
            this.Ext_Valid.Width = 0;
            // 
            // frmCardReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 462);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmCardReturn";
            this.TabText = "退卡";
            this.Tag = "退卡";
            this.Text = "退卡";
            this.pnlQueryArea.ResumeLayout(false);
            this.pnlQueryArea.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlQueryArea;
        private System.Windows.Forms.ComboBox cbbClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxUserNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.ComboBox cbbSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSingleReturn;
        private System.Windows.Forms.Button btnQuery;
        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBatchReturn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckbSelectAll;
        private System.Windows.Forms.ListView lvStudentList;
        private System.Windows.Forms.ColumnHeader Ext_RecordID;
        private System.Windows.Forms.ColumnHeader Ext_UserNum;
        private System.Windows.Forms.ColumnHeader Ext_UserName;
        private System.Windows.Forms.ColumnHeader Ext_GroupName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDepartment;
        private System.Windows.Forms.ColumnHeader Ext_CardNo;
        private System.Windows.Forms.ColumnHeader Ext_PairTime;
        private System.Windows.Forms.CheckBox cbxIsGraduation;
        private WindowControls.HHZX.NumberBox nudCardNo;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader Ext_ValidMsg;
        private System.Windows.Forms.ColumnHeader Ext_Valid;
    }
}