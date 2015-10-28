namespace WindowUI.HHZX.UserCard
{
    partial class frmChangePreCostStatus
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbxLeftDown = new System.Windows.Forms.GroupBox();
            this.pnlOptChange = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.rBtnUnsettledSetMeal = new System.Windows.Forms.RadioButton();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.rBtnSetMealSettled = new System.Windows.Forms.RadioButton();
            this.btnSelectUsers = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxRight = new System.Windows.Forms.GroupBox();
            this.ckbSelectAll = new System.Windows.Forms.CheckBox();
            this.lvPreCostList = new System.Windows.Forms.ListView();
            this.pcs_cRecordID = new System.Windows.Forms.ColumnHeader();
            this.UserNum = new System.Windows.Forms.ColumnHeader();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.GroupName = new System.Windows.Forms.ColumnHeader();
            this.CardNo = new System.Windows.Forms.ColumnHeader();
            this.pcs_fCost = new System.Windows.Forms.ColumnHeader();
            this.pcs_dConsumeDate = new System.Windows.Forms.ColumnHeader();
            this.gbxLeftUp = new System.Windows.Forms.GroupBox();
            this.pnlQueryArea = new System.Windows.Forms.Panel();
            this.nudCardNo = new WindowControls.HHZX.NumberBox();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.gbxLeftDown.SuspendLayout();
            this.pnlOptChange.SuspendLayout();
            this.gbxRight.SuspendLayout();
            this.gbxLeftUp.SuspendLayout();
            this.pnlQueryArea.SuspendLayout();
            this.SuspendLayout();
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
            this.sysToolBar.Size = new System.Drawing.Size(784, 23);
            this.sysToolBar.TabIndex = 0;
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gbxLeftDown);
            this.pnlMain.Controls.Add(this.gbxRight);
            this.pnlMain.Controls.Add(this.gbxLeftUp);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 23);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(784, 439);
            this.pnlMain.TabIndex = 1;
            // 
            // gbxLeftDown
            // 
            this.gbxLeftDown.Controls.Add(this.pnlOptChange);
            this.gbxLeftDown.Controls.Add(this.btnSelectUsers);
            this.gbxLeftDown.Controls.Add(this.btnCancel);
            this.gbxLeftDown.Location = new System.Drawing.Point(3, 276);
            this.gbxLeftDown.Name = "gbxLeftDown";
            this.gbxLeftDown.Size = new System.Drawing.Size(246, 157);
            this.gbxLeftDown.TabIndex = 36;
            this.gbxLeftDown.TabStop = false;
            this.gbxLeftDown.Text = "操作";
            // 
            // pnlOptChange
            // 
            this.pnlOptChange.Controls.Add(this.label7);
            this.pnlOptChange.Controls.Add(this.rBtnUnsettledSetMeal);
            this.pnlOptChange.Controls.Add(this.btnConfirm);
            this.pnlOptChange.Controls.Add(this.rBtnSetMealSettled);
            this.pnlOptChange.Enabled = false;
            this.pnlOptChange.Location = new System.Drawing.Point(7, 57);
            this.pnlOptChange.Name = "pnlOptChange";
            this.pnlOptChange.Size = new System.Drawing.Size(233, 95);
            this.pnlOptChange.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "选择转换状态：";
            // 
            // rBtnUnsettledSetMeal
            // 
            this.rBtnUnsettledSetMeal.AutoSize = true;
            this.rBtnUnsettledSetMeal.Checked = true;
            this.rBtnUnsettledSetMeal.Font = new System.Drawing.Font("SimSun", 10F);
            this.rBtnUnsettledSetMeal.ForeColor = System.Drawing.Color.Red;
            this.rBtnUnsettledSetMeal.Location = new System.Drawing.Point(32, 35);
            this.rBtnUnsettledSetMeal.Name = "rBtnUnsettledSetMeal";
            this.rBtnUnsettledSetMeal.Size = new System.Drawing.Size(81, 18);
            this.rBtnUnsettledSetMeal.TabIndex = 1;
            this.rBtnUnsettledSetMeal.TabStop = true;
            this.rBtnUnsettledSetMeal.Text = "【未结】";
            this.rBtnUnsettledSetMeal.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(66, 59);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 30);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "确定转换";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // rBtnSetMealSettled
            // 
            this.rBtnSetMealSettled.AutoSize = true;
            this.rBtnSetMealSettled.Font = new System.Drawing.Font("SimSun", 10F);
            this.rBtnSetMealSettled.ForeColor = System.Drawing.Color.Red;
            this.rBtnSetMealSettled.Location = new System.Drawing.Point(119, 35);
            this.rBtnSetMealSettled.Name = "rBtnSetMealSettled";
            this.rBtnSetMealSettled.Size = new System.Drawing.Size(81, 18);
            this.rBtnSetMealSettled.TabIndex = 0;
            this.rBtnSetMealSettled.Text = "【已结】";
            this.rBtnSetMealSettled.UseVisualStyleBackColor = true;
            // 
            // btnSelectUsers
            // 
            this.btnSelectUsers.Location = new System.Drawing.Point(20, 20);
            this.btnSelectUsers.Name = "btnSelectUsers";
            this.btnSelectUsers.Size = new System.Drawing.Size(100, 31);
            this.btnSelectUsers.TabIndex = 3;
            this.btnSelectUsers.Text = "选择记录";
            this.btnSelectUsers.UseVisualStyleBackColor = true;
            this.btnSelectUsers.Click += new System.EventHandler(this.btnSelectUsers_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(126, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 31);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbxRight
            // 
            this.gbxRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRight.Controls.Add(this.ckbSelectAll);
            this.gbxRight.Controls.Add(this.lvPreCostList);
            this.gbxRight.Location = new System.Drawing.Point(255, 6);
            this.gbxRight.Name = "gbxRight";
            this.gbxRight.Size = new System.Drawing.Size(526, 430);
            this.gbxRight.TabIndex = 35;
            this.gbxRight.TabStop = false;
            this.gbxRight.Text = "存疑消费记录";
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
            // lvPreCostList
            // 
            this.lvPreCostList.CheckBoxes = true;
            this.lvPreCostList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pcs_cRecordID,
            this.UserNum,
            this.UserName,
            this.GroupName,
            this.CardNo,
            this.pcs_fCost,
            this.pcs_dConsumeDate});
            this.lvPreCostList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPreCostList.Font = new System.Drawing.Font("SimSun", 12F);
            this.lvPreCostList.FullRowSelect = true;
            this.lvPreCostList.GridLines = true;
            this.lvPreCostList.Location = new System.Drawing.Point(3, 17);
            this.lvPreCostList.Name = "lvPreCostList";
            this.lvPreCostList.Size = new System.Drawing.Size(520, 410);
            this.lvPreCostList.TabIndex = 3;
            this.lvPreCostList.UseCompatibleStateImageBehavior = false;
            this.lvPreCostList.View = System.Windows.Forms.View.Details;
            this.lvPreCostList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvPreCostList_ItemChecked);
            this.lvPreCostList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvPreCostList_ItemCheck);
            // 
            // pcs_cRecordID
            // 
            this.pcs_cRecordID.Tag = "pcs_cRecordID";
            this.pcs_cRecordID.Text = "";
            this.pcs_cRecordID.Width = 0;
            // 
            // UserNum
            // 
            this.UserNum.Tag = "UserNum";
            this.UserNum.Text = "学号/工号";
            this.UserNum.Width = 100;
            // 
            // UserName
            // 
            this.UserName.Tag = "UserName";
            this.UserName.Text = "姓名";
            this.UserName.Width = 100;
            // 
            // GroupName
            // 
            this.GroupName.Tag = "GroupName";
            this.GroupName.Text = "班级/部门";
            this.GroupName.Width = 150;
            // 
            // CardNo
            // 
            this.CardNo.Tag = "CardNo";
            this.CardNo.Text = "持有卡号";
            this.CardNo.Width = 100;
            // 
            // pcs_fCost
            // 
            this.pcs_fCost.Tag = "pcs_fCost";
            this.pcs_fCost.Text = "金额";
            this.pcs_fCost.Width = 80;
            // 
            // pcs_dConsumeDate
            // 
            this.pcs_dConsumeDate.Tag = "pcs_dConsumeDate";
            this.pcs_dConsumeDate.Text = "产生时间";
            this.pcs_dConsumeDate.Width = 250;
            // 
            // gbxLeftUp
            // 
            this.gbxLeftUp.Controls.Add(this.pnlQueryArea);
            this.gbxLeftUp.Controls.Add(this.btnQuery);
            this.gbxLeftUp.Location = new System.Drawing.Point(3, 6);
            this.gbxLeftUp.Name = "gbxLeftUp";
            this.gbxLeftUp.Size = new System.Drawing.Size(246, 264);
            this.gbxLeftUp.TabIndex = 34;
            this.gbxLeftUp.TabStop = false;
            this.gbxLeftUp.Text = "查询条件";
            // 
            // pnlQueryArea
            // 
            this.pnlQueryArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQueryArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQueryArea.Controls.Add(this.nudCardNo);
            this.pnlQueryArea.Controls.Add(this.btnReadCard);
            this.pnlQueryArea.Controls.Add(this.label6);
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
            this.pnlQueryArea.Size = new System.Drawing.Size(233, 208);
            this.pnlQueryArea.TabIndex = 31;
            // 
            // nudCardNo
            // 
            this.nudCardNo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCardNo.Location = new System.Drawing.Point(96, 17);
            this.nudCardNo.Name = "nudCardNo";
            this.nudCardNo.Size = new System.Drawing.Size(69, 21);
            this.nudCardNo.TabIndex = 27;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(164, 15);
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
            this.label6.Location = new System.Drawing.Point(18, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "卡 号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 82);
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
            this.cbbDepartment.Location = new System.Drawing.Point(97, 79);
            this.cbbDepartment.Name = "cbbDepartment";
            this.cbbDepartment.Size = new System.Drawing.Size(115, 20);
            this.cbbDepartment.TabIndex = 11;
            this.cbbDepartment.SelectedIndexChanged += new System.EventHandler(this.cbbDepartment_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 51);
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
            this.cbbClass.Location = new System.Drawing.Point(97, 48);
            this.cbbClass.Name = "cbbClass";
            this.cbbClass.Size = new System.Drawing.Size(115, 20);
            this.cbbClass.TabIndex = 3;
            this.cbbClass.SelectedIndexChanged += new System.EventHandler(this.cbbClass_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "学号\\工号：";
            // 
            // tbxUserNum
            // 
            this.tbxUserNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUserNum.Location = new System.Drawing.Point(97, 110);
            this.tbxUserNum.Name = "tbxUserNum";
            this.tbxUserNum.Size = new System.Drawing.Size(114, 21);
            this.tbxUserNum.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "姓 名：";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUserName.Location = new System.Drawing.Point(97, 141);
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
            this.cbbSex.Location = new System.Drawing.Point(97, 172);
            this.cbbSex.Name = "cbbSex";
            this.cbbSex.Size = new System.Drawing.Size(45, 20);
            this.cbbSex.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "性 别：";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(73, 231);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 27);
            this.btnQuery.TabIndex = 29;
            this.btnQuery.Text = "查  询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // frmChangePreCostStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmChangePreCostStatus";
            this.TabText = "存疑消费记录处理";
            this.Tag = "存疑消费记录处理";
            this.Text = "存疑消费记录处理";
            this.pnlMain.ResumeLayout(false);
            this.gbxLeftDown.ResumeLayout(false);
            this.pnlOptChange.ResumeLayout(false);
            this.pnlOptChange.PerformLayout();
            this.gbxRight.ResumeLayout(false);
            this.gbxRight.PerformLayout();
            this.gbxLeftUp.ResumeLayout(false);
            this.pnlQueryArea.ResumeLayout(false);
            this.pnlQueryArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbxLeftUp;
        private System.Windows.Forms.Panel pnlQueryArea;
        private WindowControls.HHZX.NumberBox nudCardNo;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxUserNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.ComboBox cbbSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox gbxRight;
        private System.Windows.Forms.CheckBox ckbSelectAll;
        private System.Windows.Forms.ListView lvPreCostList;
        private System.Windows.Forms.ColumnHeader pcs_cRecordID;
        private System.Windows.Forms.ColumnHeader UserNum;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader GroupName;
        private System.Windows.Forms.ColumnHeader CardNo;
        private System.Windows.Forms.ColumnHeader pcs_fCost;
        private System.Windows.Forms.GroupBox gbxLeftDown;
        private System.Windows.Forms.Button btnSelectUsers;
        private System.Windows.Forms.RadioButton rBtnUnsettledSetMeal;
        private System.Windows.Forms.RadioButton rBtnSetMealSettled;
        private System.Windows.Forms.ColumnHeader pcs_dConsumeDate;
        private System.Windows.Forms.Panel pnlOptChange;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label7;
    }
}