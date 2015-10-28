namespace WindowUI.HHZX.ConsumerDevice
{
    partial class frmDeviceInfoDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlEduit = new System.Windows.Forms.Panel();
            this.cmbMachineStatus = new System.Windows.Forms.ComboBox();
            this.nudMacNo = new WindowControls.HHZX.NumberBox();
            this.nudPort = new WindowControls.HHZX.NumberBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMacName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIPAddr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDetailSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheckNet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlEduit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlEduit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnDetailSettings);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 349);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pnlEduit
            // 
            this.pnlEduit.Controls.Add(this.cmbMachineStatus);
            this.pnlEduit.Controls.Add(this.nudMacNo);
            this.pnlEduit.Controls.Add(this.nudPort);
            this.pnlEduit.Controls.Add(this.label1);
            this.pnlEduit.Controls.Add(this.label2);
            this.pnlEduit.Controls.Add(this.txtMacName);
            this.pnlEduit.Controls.Add(this.label3);
            this.pnlEduit.Controls.Add(this.label4);
            this.pnlEduit.Controls.Add(this.txtIPAddr);
            this.pnlEduit.Controls.Add(this.label7);
            this.pnlEduit.Controls.Add(this.cmbType);
            this.pnlEduit.Controls.Add(this.txtDesc);
            this.pnlEduit.Controls.Add(this.label5);
            this.pnlEduit.Controls.Add(this.label6);
            this.pnlEduit.Location = new System.Drawing.Point(5, 10);
            this.pnlEduit.Name = "pnlEduit";
            this.pnlEduit.Size = new System.Drawing.Size(332, 264);
            this.pnlEduit.TabIndex = 21;
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
            this.cmbMachineStatus.Location = new System.Drawing.Point(121, 239);
            this.cmbMachineStatus.Name = "cmbMachineStatus";
            this.cmbMachineStatus.Size = new System.Drawing.Size(90, 23);
            this.cmbMachineStatus.TabIndex = 24;
            // 
            // nudMacNo
            // 
            this.nudMacNo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMacNo.Location = new System.Drawing.Point(123, 7);
            this.nudMacNo.Name = "nudMacNo";
            this.nudMacNo.Size = new System.Drawing.Size(100, 24);
            this.nudMacNo.TabIndex = 22;
            // 
            // nudPort
            // 
            this.nudPort.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPort.Location = new System.Drawing.Point(122, 143);
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(100, 24);
            this.nudPort.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "机号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "消费机名称:";
            // 
            // txtMacName
            // 
            this.txtMacName.AcceptsReturn = true;
            this.txtMacName.Location = new System.Drawing.Point(122, 41);
            this.txtMacName.Name = "txtMacName";
            this.txtMacName.Size = new System.Drawing.Size(152, 24);
            this.txtMacName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "类型:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "IP地址:";
            // 
            // txtIPAddr
            // 
            this.txtIPAddr.Location = new System.Drawing.Point(122, 109);
            this.txtIPAddr.Name = "txtIPAddr";
            this.txtIPAddr.Size = new System.Drawing.Size(152, 24);
            this.txtIPAddr.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "使用状态:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(122, 75);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(152, 23);
            this.cmbType.TabIndex = 10;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(122, 179);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(191, 54);
            this.txtDesc.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "工作端口:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "位置描述:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "参数设置:";
            // 
            // btnDetailSettings
            // 
            this.btnDetailSettings.Enabled = false;
            this.btnDetailSettings.Location = new System.Drawing.Point(129, 280);
            this.btnDetailSettings.Name = "btnDetailSettings";
            this.btnDetailSettings.Size = new System.Drawing.Size(75, 23);
            this.btnDetailSettings.TabIndex = 17;
            this.btnDetailSettings.Text = "打开设置";
            this.btnDetailSettings.UseVisualStyleBackColor = true;
            this.btnDetailSettings.Click += new System.EventHandler(this.btnDetailSettings_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCheckNet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 307);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(264, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(183, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheckNet
            // 
            this.btnCheckNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckNet.Location = new System.Drawing.Point(65, 10);
            this.btnCheckNet.Name = "btnCheckNet";
            this.btnCheckNet.Size = new System.Drawing.Size(111, 23);
            this.btnCheckNet.TabIndex = 0;
            this.btnCheckNet.Text = "测试连通性";
            this.btnCheckNet.UseVisualStyleBackColor = true;
            this.btnCheckNet.Click += new System.EventHandler(this.btnCheckNet_Click);
            // 
            // frmDeviceInfoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 349);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 11F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeviceInfoDetail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "消费机详细信息";
            this.Text = "消费机详细信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlEduit.ResumeLayout(false);
            this.pnlEduit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIPAddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMacName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheckNet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDetailSettings;
        private System.Windows.Forms.Panel pnlEduit;
        private WindowControls.HHZX.NumberBox nudPort;
        private WindowControls.HHZX.NumberBox nudMacNo;
        private System.Windows.Forms.ComboBox cmbMachineStatus;
    }
}