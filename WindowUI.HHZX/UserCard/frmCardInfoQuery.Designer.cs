namespace WindowUI.HHZX.UserCard
{
    partial class frmCardInfoQuery
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
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.lvCardList = new System.Windows.Forms.ListView();
            this.number = new System.Windows.Forms.ColumnHeader();
            this.CardNo = new System.Windows.Forms.ColumnHeader();
            this.ChaName = new System.Windows.Forms.ColumnHeader();
            this.CardState = new System.Windows.Forms.ColumnHeader();
            this.PairTime = new System.Windows.Forms.ColumnHeader();
            this.CardID = new System.Windows.Forms.ColumnHeader();
            this.Add = new System.Windows.Forms.ColumnHeader();
            this.AddTime = new System.Windows.Forms.ColumnHeader();
            this.Last = new System.Windows.Forms.ColumnHeader();
            this.LastTime = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.nudCardNo = new WindowControls.HHZX.NumberBox();
            this.chbPairTime = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReaderCon = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpPairTime_To = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbUserDepartment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbUserClass = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.dtpPairTime_From = new System.Windows.Forms.DateTimePicker();
            this.cmbCardState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbChaName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysToolBar
            // 
            this.sysToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sysToolBar.BtnDelete_IsEnabled = false;
            this.sysToolBar.BtnDelete_IsUsed = true;
            this.sysToolBar.BtnDetail_IsEnabled = true;
            this.sysToolBar.BtnDetail_IsUsed = true;
            this.sysToolBar.BtnExit_IsEnabled = true;
            this.sysToolBar.BtnExit_IsUsed = true;
            this.sysToolBar.BtnModify_IsEnabled = false;
            this.sysToolBar.BtnModify_IsUsed = false;
            this.sysToolBar.BtnNew_IsEnabled = true;
            this.sysToolBar.BtnNew_IsUsed = true;
            this.sysToolBar.BtnRefresh_IsEnabled = true;
            this.sysToolBar.BtnRefresh_IsUsed = true;
            this.sysToolBar.BtnSave_IsEnabled = true;
            this.sysToolBar.BtnSave_IsUsed = false;
            this.sysToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(784, 23);
            this.sysToolBar.TabIndex = 0;
            this.sysToolBar.OnItemDelete_Click += new WindowControls.HBPMS.SystemToolBar.ItemDelete_Click(this.sysToolBar_OnItemDelete_Click);
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            this.sysToolBar.OnItemDetail_Click += new WindowControls.HBPMS.SystemToolBar.ItemDetail_Click(this.sysToolBar_OnItemDetail_Click);
            this.sysToolBar.OnItemNew_Click += new WindowControls.HBPMS.SystemToolBar.ItemNew_Click(this.sysToolBar_OnItemNew_Click);
            // 
            // lvCardList
            // 
            this.lvCardList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCardList.BackColor = System.Drawing.SystemColors.Window;
            this.lvCardList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.CardNo,
            this.ChaName,
            this.CardState,
            this.PairTime,
            this.CardID,
            this.Add,
            this.AddTime,
            this.Last,
            this.LastTime});
            this.lvCardList.Font = new System.Drawing.Font("宋体", 12F);
            this.lvCardList.FullRowSelect = true;
            this.lvCardList.GridLines = true;
            this.lvCardList.Location = new System.Drawing.Point(6, 41);
            this.lvCardList.MultiSelect = false;
            this.lvCardList.Name = "lvCardList";
            this.lvCardList.Size = new System.Drawing.Size(748, 372);
            this.lvCardList.TabIndex = 1;
            this.lvCardList.UseCompatibleStateImageBehavior = false;
            this.lvCardList.View = System.Windows.Forms.View.Details;
            this.lvCardList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCardList_MouseDoubleClick);
            this.lvCardList.SelectedIndexChanged += new System.EventHandler(this.lvCardList_SelectedIndexChanged);
            this.lvCardList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCardList_ColumnClick);
            // 
            // number
            // 
            this.number.Tag = "number";
            this.number.Text = "序号";
            this.number.Width = 45;
            // 
            // CardNo
            // 
            this.CardNo.Tag = "CardNo";
            this.CardNo.Text = "卡号";
            this.CardNo.Width = 120;
            // 
            // ChaName
            // 
            this.ChaName.Tag = "ChaName";
            this.ChaName.Text = "持卡人";
            // 
            // CardState
            // 
            this.CardState.Tag = "CardState";
            this.CardState.Text = "使用情况";
            this.CardState.Width = 77;
            // 
            // PairTime
            // 
            this.PairTime.Tag = "PairTime";
            this.PairTime.Text = "发卡日期";
            this.PairTime.Width = 170;
            // 
            // CardID
            // 
            this.CardID.Tag = "CardID";
            this.CardID.Text = "卡ID";
            this.CardID.Width = 270;
            // 
            // Add
            // 
            this.Add.Tag = "Add";
            this.Add.Text = "新增人";
            this.Add.Width = 100;
            // 
            // AddTime
            // 
            this.AddTime.Tag = "AddTime";
            this.AddTime.Text = "新增时间";
            this.AddTime.Width = 175;
            // 
            // Last
            // 
            this.Last.Tag = "Last";
            this.Last.Text = "修改人";
            this.Last.Width = 100;
            // 
            // LastTime
            // 
            this.LastTime.Tag = "LastTime";
            this.LastTime.Text = "修改时间";
            this.LastTime.Width = 170;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.nudCardNo);
            this.groupBox1.Controls.Add(this.chbPairTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnReaderCon);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtpPairTime_To);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbUserDepartment);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbUserClass);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnReadCard);
            this.groupBox1.Controls.Add(this.dtpPairTime_From);
            this.groupBox1.Controls.Add(this.cmbCardState);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbChaName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // txtCardID
            // 
            this.txtCardID.Enabled = false;
            this.txtCardID.Location = new System.Drawing.Point(78, 44);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(179, 21);
            this.txtCardID.TabIndex = 25;
            // 
            // nudCardNo
            // 
            this.nudCardNo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCardNo.Location = new System.Drawing.Point(78, 16);
            this.nudCardNo.Name = "nudCardNo";
            this.nudCardNo.Size = new System.Drawing.Size(74, 21);
            this.nudCardNo.TabIndex = 24;
            this.nudCardNo.TextChanged += new System.EventHandler(this.nudCardNo_TextChanged);
            // 
            // chbPairTime
            // 
            this.chbPairTime.AutoSize = true;
            this.chbPairTime.Location = new System.Drawing.Point(226, 83);
            this.chbPairTime.Name = "chbPairTime";
            this.chbPairTime.Size = new System.Drawing.Size(78, 16);
            this.chbPairTime.TabIndex = 23;
            this.chbPairTime.Text = "发卡时间:";
            this.chbPairTime.UseVisualStyleBackColor = true;
            this.chbPairTime.CheckedChanged += new System.EventHandler(this.chbPairTime_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "读卡器：";
            // 
            // btnReaderCon
            // 
            this.btnReaderCon.Location = new System.Drawing.Point(78, 76);
            this.btnReaderCon.Name = "btnReaderCon";
            this.btnReaderCon.Size = new System.Drawing.Size(110, 23);
            this.btnReaderCon.TabIndex = 20;
            this.btnReaderCon.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(679, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpPairTime_To
            // 
            this.dtpPairTime_To.CustomFormat = "yyyy年MM月dd日";
            this.dtpPairTime_To.Enabled = false;
            this.dtpPairTime_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPairTime_To.Location = new System.Drawing.Point(474, 81);
            this.dtpPairTime_To.Name = "dtpPairTime_To";
            this.dtpPairTime_To.Size = new System.Drawing.Size(130, 21);
            this.dtpPairTime_To.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(454, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "-";
            // 
            // cmbUserDepartment
            // 
            this.cmbUserDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserDepartment.FormattingEnabled = true;
            this.cmbUserDepartment.Items.AddRange(new object[] {
            "教导处",
            "总务处"});
            this.cmbUserDepartment.Location = new System.Drawing.Point(516, 44);
            this.cmbUserDepartment.Name = "cmbUserDepartment";
            this.cmbUserDepartment.Size = new System.Drawing.Size(104, 20);
            this.cmbUserDepartment.TabIndex = 17;
            this.cmbUserDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbUserDepartment_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(475, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "部门：";
            // 
            // cmbUserClass
            // 
            this.cmbUserClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserClass.FormattingEnabled = true;
            this.cmbUserClass.Items.AddRange(new object[] {
            "(1)班",
            "(2)班",
            "(3)班",
            "(4)班",
            "(5)班",
            "(6)班",
            "(7)班",
            "(8)班"});
            this.cmbUserClass.Location = new System.Drawing.Point(317, 43);
            this.cmbUserClass.Name = "cmbUserClass";
            this.cmbUserClass.Size = new System.Drawing.Size(112, 20);
            this.cmbUserClass.TabIndex = 15;
            this.cmbUserClass.SelectedIndexChanged += new System.EventHandler(this.cmbUserClass_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "班级：";
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(162, 15);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(55, 23);
            this.btnReadCard.TabIndex = 10;
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // dtpPairTime_From
            // 
            this.dtpPairTime_From.CustomFormat = "yyyy年MM月dd日";
            this.dtpPairTime_From.Enabled = false;
            this.dtpPairTime_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPairTime_From.Location = new System.Drawing.Point(306, 81);
            this.dtpPairTime_From.Name = "dtpPairTime_From";
            this.dtpPairTime_From.Size = new System.Drawing.Size(135, 21);
            this.dtpPairTime_From.TabIndex = 9;
            this.dtpPairTime_From.Value = new System.DateTime(2013, 6, 3, 0, 0, 0, 0);
            // 
            // cmbCardState
            // 
            this.cmbCardState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardState.FormattingEnabled = true;
            this.cmbCardState.Location = new System.Drawing.Point(516, 17);
            this.cmbCardState.Name = "cmbCardState";
            this.cmbCardState.Size = new System.Drawing.Size(104, 20);
            this.cmbCardState.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "使用情况：";
            // 
            // txbChaName
            // 
            this.txbChaName.Location = new System.Drawing.Point(316, 16);
            this.txbChaName.Name = "txbChaName";
            this.txbChaName.Size = new System.Drawing.Size(113, 21);
            this.txbChaName.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txbChaName, "支持模糊搜索");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "持卡人：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "卡ID：";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡号：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lvCardList);
            this.groupBox2.Location = new System.Drawing.Point(12, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 420);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "卡记录";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(366, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 28);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(61, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "首页";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(304, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "末页";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(142, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "上一页";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(223, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "下一页";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "50";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "记录数量:";
            this.label2.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "提示";
            // 
            // frmCardInfoQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmCardInfoQuery";
            this.TabText = "卡资料";
            this.Text = "卡资料";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.ListView lvCardList;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader CardNo;
        private System.Windows.Forms.ColumnHeader CardState;
        private System.Windows.Forms.ColumnHeader ChaName;
        private System.Windows.Forms.ColumnHeader AddTime;
        private System.Windows.Forms.ColumnHeader Add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txbChaName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbCardState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ColumnHeader PairTime;
        private System.Windows.Forms.ColumnHeader Last;
        private System.Windows.Forms.ColumnHeader LastTime;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.DateTimePicker dtpPairTime_From;
        private System.Windows.Forms.DateTimePicker dtpPairTime_To;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbUserDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbUserClass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReaderCon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbPairTime;
        private System.Windows.Forms.ColumnHeader CardID;
        private System.Windows.Forms.Panel panel1;
        private WindowControls.HHZX.NumberBox nudCardNo;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.Label label6;
    }
}