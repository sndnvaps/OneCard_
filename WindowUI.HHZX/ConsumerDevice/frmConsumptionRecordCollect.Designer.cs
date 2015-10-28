namespace WindowUI.HHZX.ConsumerDevice
{
    partial class frmConsumptionRecordCollect
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lvwCollectList = new System.Windows.Forms.ListView();
            this.StartTime = new System.Windows.Forms.ColumnHeader();
            this.TimeType = new System.Windows.Forms.ColumnHeader();
            this.Enable = new System.Windows.Forms.ColumnHeader();
            this.chbCheckedAll = new System.Windows.Forms.CheckBox();
            this.btnCollection = new System.Windows.Forms.Button();
            this.lvMachines = new System.Windows.Forms.ListView();
            this.index = new System.Windows.Forms.ColumnHeader();
            this.cmm_cMacName = new System.Windows.Forms.ColumnHeader();
            this.cmm_iMacNo = new System.Windows.Forms.ColumnHeader();
            this.cmm_cIPAddr = new System.Windows.Forms.ColumnHeader();
            this.cmm_cStatus = new System.Windows.Forms.ColumnHeader();
            this.cmm_cDesc = new System.Windows.Forms.ColumnHeader();
            this.cmm_dLastAccessTime = new System.Windows.Forms.ColumnHeader();
            this.isSuccess = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCheckedReverse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMachineAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.TimeName = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnModify);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.lvwCollectList);
            this.groupBox1.Location = new System.Drawing.Point(1, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "收集设置";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(478, 78);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(478, 49);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(478, 20);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "添加";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lvwCollectList
            // 
            this.lvwCollectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TimeName,
            this.StartTime,
            this.TimeType,
            this.Enable});
            this.lvwCollectList.Font = new System.Drawing.Font("宋体", 12F);
            this.lvwCollectList.FullRowSelect = true;
            this.lvwCollectList.GridLines = true;
            this.lvwCollectList.Location = new System.Drawing.Point(6, 20);
            this.lvwCollectList.Name = "lvwCollectList";
            this.lvwCollectList.Size = new System.Drawing.Size(451, 103);
            this.lvwCollectList.TabIndex = 1;
            this.lvwCollectList.UseCompatibleStateImageBehavior = false;
            this.lvwCollectList.View = System.Windows.Forms.View.Details;
            this.lvwCollectList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwCollectList_ColumnClick);
            // 
            // StartTime
            // 
            this.StartTime.DisplayIndex = 0;
            this.StartTime.Tag = "StartTime";
            this.StartTime.Text = "收集时间";
            this.StartTime.Width = 100;
            // 
            // TimeType
            // 
            this.TimeType.DisplayIndex = 1;
            this.TimeType.Tag = "TimeType";
            this.TimeType.Text = "时段类型";
            this.TimeType.Width = 107;
            // 
            // Enable
            // 
            this.Enable.DisplayIndex = 2;
            this.Enable.Tag = "Enable";
            this.Enable.Text = "是否启用";
            this.Enable.Width = 85;
            // 
            // chbCheckedAll
            // 
            this.chbCheckedAll.AutoSize = true;
            this.chbCheckedAll.Location = new System.Drawing.Point(9, 13);
            this.chbCheckedAll.Name = "chbCheckedAll";
            this.chbCheckedAll.Size = new System.Drawing.Size(48, 16);
            this.chbCheckedAll.TabIndex = 5;
            this.chbCheckedAll.Text = "全选";
            this.chbCheckedAll.UseVisualStyleBackColor = true;
            this.chbCheckedAll.CheckedChanged += new System.EventHandler(this.chbCheckedAll_CheckedChanged);
            // 
            // btnCollection
            // 
            this.btnCollection.Enabled = false;
            this.btnCollection.ForeColor = System.Drawing.Color.Black;
            this.btnCollection.Location = new System.Drawing.Point(576, 4);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(164, 33);
            this.btnCollection.TabIndex = 6;
            this.btnCollection.Text = "即时获取消费数据(消费机)";
            this.btnCollection.UseVisualStyleBackColor = true;
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // lvMachines
            // 
            this.lvMachines.AllowDrop = true;
            this.lvMachines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMachines.CheckBoxes = true;
            this.lvMachines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.cmm_cMacName,
            this.cmm_iMacNo,
            this.cmm_cIPAddr,
            this.cmm_cStatus,
            this.cmm_cDesc,
            this.cmm_dLastAccessTime,
            this.isSuccess});
            this.lvMachines.Font = new System.Drawing.Font("宋体", 12F);
            this.lvMachines.FullRowSelect = true;
            this.lvMachines.Location = new System.Drawing.Point(7, 220);
            this.lvMachines.Name = "lvMachines";
            this.lvMachines.Size = new System.Drawing.Size(769, 307);
            this.lvMachines.TabIndex = 3;
            this.lvMachines.UseCompatibleStateImageBehavior = false;
            this.lvMachines.View = System.Windows.Forms.View.Details;
            this.lvMachines.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvMachines_ItemChecked);
            this.lvMachines.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvMachines_ColumnClick);
            // 
            // index
            // 
            this.index.Tag = "index";
            this.index.Text = "序号";
            this.index.Width = 45;
            // 
            // cmm_cMacName
            // 
            this.cmm_cMacName.Tag = "cmm_cMacName";
            this.cmm_cMacName.Text = "消费机名称";
            this.cmm_cMacName.Width = 150;
            // 
            // cmm_iMacNo
            // 
            this.cmm_iMacNo.Tag = "cmm_iMacNo";
            this.cmm_iMacNo.Text = "机号";
            // 
            // cmm_cIPAddr
            // 
            this.cmm_cIPAddr.Tag = "cmm_cIPAddr";
            this.cmm_cIPAddr.Text = "IP地址";
            this.cmm_cIPAddr.Width = 140;
            // 
            // cmm_cStatus
            // 
            this.cmm_cStatus.Tag = "cmm_cStatus";
            this.cmm_cStatus.Text = "使用状态";
            this.cmm_cStatus.Width = 80;
            // 
            // cmm_cDesc
            // 
            this.cmm_cDesc.Tag = "cmm_cDesc";
            this.cmm_cDesc.Text = "位置描述";
            this.cmm_cDesc.Width = 100;
            // 
            // cmm_dLastAccessTime
            // 
            this.cmm_dLastAccessTime.Tag = "cmm_dLastAccessTime";
            this.cmm_dLastAccessTime.Text = "最后收数时间";
            this.cmm_dLastAccessTime.Width = 170;
            // 
            // isSuccess
            // 
            this.isSuccess.Tag = "isSuccess";
            this.isSuccess.Text = "是否成功收數";
            this.isSuccess.Width = 115;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCheckedReverse);
            this.panel2.Controls.Add(this.chbCheckedAll);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblMachineAmount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCollection);
            this.panel2.Location = new System.Drawing.Point(3, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(753, 41);
            this.panel2.TabIndex = 5;
            // 
            // btnCheckedReverse
            // 
            this.btnCheckedReverse.Location = new System.Drawing.Point(59, 9);
            this.btnCheckedReverse.Name = "btnCheckedReverse";
            this.btnCheckedReverse.Size = new System.Drawing.Size(47, 23);
            this.btnCheckedReverse.TabIndex = 5;
            this.btnCheckedReverse.Text = "反选";
            this.btnCheckedReverse.UseVisualStyleBackColor = true;
            this.btnCheckedReverse.Click += new System.EventHandler(this.btnCheckedReverse_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "台消费机";
            // 
            // lblMachineAmount
            // 
            this.lblMachineAmount.AutoSize = true;
            this.lblMachineAmount.Location = new System.Drawing.Point(289, 20);
            this.lblMachineAmount.Name = "lblMachineAmount";
            this.lblMachineAmount.Size = new System.Drawing.Size(11, 12);
            this.lblMachineAmount.TabIndex = 9;
            this.lblMachineAmount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "共";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(389, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "（选择消费机可以进行即时收数）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "消费机收数情况";
            // 
            // sysToolBar
            // 
            this.sysToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sysToolBar.BtnDelete_IsEnabled = false;
            this.sysToolBar.BtnDelete_IsUsed = false;
            this.sysToolBar.BtnDetail_IsEnabled = true;
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
            this.sysToolBar.BtnSave_IsUsed = false;
            this.sysToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(778, 23);
            this.sysToolBar.TabIndex = 1;
            this.sysToolBar.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.sysToolBar_OnItemRefresh_Click);
            // 
            // TimeName
            // 
            this.TimeName.Tag = "Name";
            this.TimeName.Text = "描述";
            this.TimeName.Width = 131;
            // 
            // frmConsumptionRecordCollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 539);
            this.Controls.Add(this.lvMachines);
            this.Controls.Add(this.sysToolBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmConsumptionRecordCollect";
            this.TabText = "消费数据收集";
            this.Text = "消费数据收集";
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwCollectList;

        private System.Windows.Forms.ColumnHeader StartTime;
        private System.Windows.Forms.ColumnHeader TimeType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ColumnHeader Enable;
        private System.Windows.Forms.Button btnCollection;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvMachines;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.ColumnHeader cmm_iMacNo;
        private System.Windows.Forms.ColumnHeader cmm_cMacName;
        private System.Windows.Forms.ColumnHeader cmm_cIPAddr;
        private System.Windows.Forms.ColumnHeader cmm_cStatus;
        private System.Windows.Forms.ColumnHeader cmm_cDesc;
        private System.Windows.Forms.ColumnHeader cmm_dLastAccessTime;
        private System.Windows.Forms.ColumnHeader isSuccess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMachineAmount;
        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.CheckBox chbCheckedAll;
        private System.Windows.Forms.Button btnCheckedReverse;
        private System.Windows.Forms.ColumnHeader TimeName;
    }
}