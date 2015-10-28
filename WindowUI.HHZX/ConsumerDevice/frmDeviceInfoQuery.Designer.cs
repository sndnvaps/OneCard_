namespace WindowUI.HHZX.ConsumerDevice
{
    partial class frmDeviceInfoQuery
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblRecordAmount = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lvMachines = new System.Windows.Forms.ListView();
            this.index = new System.Windows.Forms.ColumnHeader();
            this.cmm_iMacNo = new System.Windows.Forms.ColumnHeader();
            this.cmm_cMacName = new System.Windows.Forms.ColumnHeader();
            this.cmm_cIPAddr = new System.Windows.Forms.ColumnHeader();
            this.cmm_iPort = new System.Windows.Forms.ColumnHeader();
            this.cmm_cStatus = new System.Windows.Forms.ColumnHeader();
            this.cmm_cUsageType = new System.Windows.Forms.ColumnHeader();
            this.cmm_cDesc = new System.Windows.Forms.ColumnHeader();
            this.cmm_cAdd = new System.Windows.Forms.ColumnHeader();
            this.cmm_dAddDate = new System.Windows.Forms.ColumnHeader();
            this.cmm_cLast = new System.Windows.Forms.ColumnHeader();
            this.cmm_dLastDate = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudPort = new WindowControls.HHZX.NumberBox();
            this.nudMacNo = new WindowControls.HHZX.NumberBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbMachineStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMachineType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPAddr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMacName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.lblRecordAmount);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 522);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 27);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "记录数量:";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(723, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 20;
            this.button5.Text = "末页";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(480, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "首页";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // lblRecordAmount
            // 
            this.lblRecordAmount.AutoSize = true;
            this.lblRecordAmount.Location = new System.Drawing.Point(77, 8);
            this.lblRecordAmount.Name = "lblRecordAmount";
            this.lblRecordAmount.Size = new System.Drawing.Size(11, 12);
            this.lblRecordAmount.TabIndex = 16;
            this.lblRecordAmount.Text = "0";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(642, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "下一页";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(561, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "上一页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // lvMachines
            // 
            this.lvMachines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMachines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.cmm_iMacNo,
            this.cmm_cMacName,
            this.cmm_cIPAddr,
            this.cmm_iPort,
            this.cmm_cStatus,
            this.cmm_cUsageType,
            this.cmm_cDesc,
            this.cmm_cAdd,
            this.cmm_dAddDate,
            this.cmm_cLast,
            this.cmm_dLastDate});
            this.lvMachines.Font = new System.Drawing.Font("SimSun", 12F);
            this.lvMachines.FullRowSelect = true;
            this.lvMachines.Location = new System.Drawing.Point(0, 119);
            this.lvMachines.Name = "lvMachines";
            this.lvMachines.Size = new System.Drawing.Size(810, 400);
            this.lvMachines.TabIndex = 2;
            this.lvMachines.UseCompatibleStateImageBehavior = false;
            this.lvMachines.View = System.Windows.Forms.View.Details;
            this.lvMachines.SelectedIndexChanged += new System.EventHandler(this.lvMachines_SelectedIndexChanged);
            this.lvMachines.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvMachines_ColumnClick);
            // 
            // index
            // 
            this.index.Tag = "index";
            this.index.Text = "序号";
            // 
            // cmm_iMacNo
            // 
            this.cmm_iMacNo.Tag = "cmm_iMacNo";
            this.cmm_iMacNo.Text = "机号";
            // 
            // cmm_cMacName
            // 
            this.cmm_cMacName.Tag = "cmm_cMacName";
            this.cmm_cMacName.Text = "消费机名称";
            this.cmm_cMacName.Width = 150;
            // 
            // cmm_cIPAddr
            // 
            this.cmm_cIPAddr.Tag = "cmm_cIPAddr";
            this.cmm_cIPAddr.Text = "IP地址";
            this.cmm_cIPAddr.Width = 150;
            // 
            // cmm_iPort
            // 
            this.cmm_iPort.Tag = "cmm_iPort";
            this.cmm_iPort.Text = "工作端口";
            this.cmm_iPort.Width = 80;
            // 
            // cmm_cStatus
            // 
            this.cmm_cStatus.Tag = "cmm_cStatus";
            this.cmm_cStatus.Text = "使用状态";
            this.cmm_cStatus.Width = 80;
            // 
            // cmm_cUsageType
            // 
            this.cmm_cUsageType.Tag = "cmm_cUsageType";
            this.cmm_cUsageType.Text = "用途类型";
            this.cmm_cUsageType.Width = 100;
            // 
            // cmm_cDesc
            // 
            this.cmm_cDesc.Tag = "cmm_cDesc";
            this.cmm_cDesc.Text = "位置描述";
            this.cmm_cDesc.Width = 100;
            // 
            // cmm_cAdd
            // 
            this.cmm_cAdd.Tag = "cmm_cAdd";
            this.cmm_cAdd.Text = "新增人";
            this.cmm_cAdd.Width = 80;
            // 
            // cmm_dAddDate
            // 
            this.cmm_dAddDate.Tag = "cmm_dAddDate";
            this.cmm_dAddDate.Text = "新增时间";
            this.cmm_dAddDate.Width = 170;
            // 
            // cmm_cLast
            // 
            this.cmm_cLast.Tag = "cmm_cLast";
            this.cmm_cLast.Text = "修改人";
            this.cmm_cLast.Width = 80;
            // 
            // cmm_dLastDate
            // 
            this.cmm_dLastDate.Tag = "cmm_dLastDate";
            this.cmm_dLastDate.Text = "修改时间";
            this.cmm_dLastDate.Width = 170;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudPort);
            this.groupBox1.Controls.Add(this.nudMacNo);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbMachineStatus);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbMachineType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIPAddr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMacName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索";
            // 
            // nudPort
            // 
            this.nudPort.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPort.Location = new System.Drawing.Point(305, 18);
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(121, 21);
            this.nudPort.TabIndex = 25;
            // 
            // nudMacNo
            // 
            this.nudMacNo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMacNo.Location = new System.Drawing.Point(101, 18);
            this.nudMacNo.Name = "nudMacNo";
            this.nudMacNo.Size = new System.Drawing.Size(105, 21);
            this.nudMacNo.TabIndex = 25;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(674, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbMachineStatus
            // 
            this.cmbMachineStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachineStatus.FormattingEnabled = true;
            this.cmbMachineStatus.Items.AddRange(new object[] {
            "使用中",
            "已停用",
            "送修中",
            "备用"});
            this.cmbMachineStatus.Location = new System.Drawing.Point(549, 49);
            this.cmbMachineStatus.Name = "cmbMachineStatus";
            this.cmbMachineStatus.Size = new System.Drawing.Size(100, 20);
            this.cmbMachineStatus.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(484, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "使用状态:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "机号:";
            // 
            // cmbMachineType
            // 
            this.cmbMachineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachineType.FormattingEnabled = true;
            this.cmbMachineType.Items.AddRange(new object[] {
            "学生定餐消费机",
            "学生加菜消费机",
            "老师就餐消费机"});
            this.cmbMachineType.Location = new System.Drawing.Point(305, 48);
            this.cmbMachineType.Name = "cmbMachineType";
            this.cmbMachineType.Size = new System.Drawing.Size(121, 20);
            this.cmbMachineType.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "类型:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "工作端口:";
            // 
            // txtIPAddr
            // 
            this.txtIPAddr.Location = new System.Drawing.Point(549, 18);
            this.txtIPAddr.Name = "txtIPAddr";
            this.txtIPAddr.Size = new System.Drawing.Size(100, 21);
            this.txtIPAddr.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "IP地址:";
            // 
            // txtMacName
            // 
            this.txtMacName.Location = new System.Drawing.Point(101, 48);
            this.txtMacName.Name = "txtMacName";
            this.txtMacName.Size = new System.Drawing.Size(100, 21);
            this.txtMacName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "消费机名称:";
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
            this.sysToolBar.BtnModify_IsUsed = true;
            this.sysToolBar.BtnNew_IsEnabled = true;
            this.sysToolBar.BtnNew_IsUsed = true;
            this.sysToolBar.BtnRefresh_IsEnabled = true;
            this.sysToolBar.BtnRefresh_IsUsed = true;
            this.sysToolBar.BtnSave_IsEnabled = false;
            this.sysToolBar.BtnSave_IsUsed = false;
            this.sysToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(810, 23);
            this.sysToolBar.TabIndex = 0;
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            this.sysToolBar.OnItemModify_Click += new WindowControls.HBPMS.SystemToolBar.ItemModify_Click(this.sysToolBar_OnItemModify_Click);
            this.sysToolBar.OnItemNew_Click += new WindowControls.HBPMS.SystemToolBar.ItemNew_Click(this.sysToolBar_OnItemNew_Click);
            // 
            // frmDeviceInfoQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvMachines);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmDeviceInfoQuery";
            this.TabText = "消费机资料";
            this.Text = "消费机资料";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvMachines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblRecordAmount;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.ColumnHeader cmm_cMacName;
        private System.Windows.Forms.ColumnHeader cmm_cIPAddr;
        private System.Windows.Forms.ColumnHeader cmm_iPort;
        private System.Windows.Forms.ColumnHeader cmm_cStatus;
        private System.Windows.Forms.ColumnHeader cmm_cDesc;
        private System.Windows.Forms.ColumnHeader cmm_cAdd;
        private System.Windows.Forms.ColumnHeader cmm_dAddDate;
        private System.Windows.Forms.ColumnHeader cmm_cLast;
        private System.Windows.Forms.ColumnHeader cmm_dLastDate;
        private System.Windows.Forms.ColumnHeader cmm_iMacNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMachineType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMacName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMachineStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private WindowControls.HHZX.NumberBox nudMacNo;
        private WindowControls.HHZX.NumberBox nudPort;
        private System.Windows.Forms.ColumnHeader cmm_cUsageType;
    }
}