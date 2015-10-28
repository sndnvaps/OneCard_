namespace WindowsUI.WebMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mspMenu = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEduit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIPList = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPath = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwCheckWeb = new System.ComponentModel.BackgroundWorker();
            this.tirCheckLine = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOutLine = new System.Windows.Forms.Label();
            this.lblOnLine = new System.Windows.Forms.Label();
            this.lblTotle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblSysStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RowNo = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.IP = new System.Windows.Forms.ColumnHeader();
            this.Times = new System.Windows.Forms.ColumnHeader();
            this.OffLineAmount = new System.Windows.Forms.ColumnHeader();
            this.SoftwareNo = new System.Windows.Forms.ColumnHeader();
            this.MachineID = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.lvwIPList = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.bgwCheckOutLint = new System.ComponentModel.BackgroundWorker();
            this.tirCheckClose = new System.Windows.Forms.Timer(this.components);
            this.tirSetMail = new System.Windows.Forms.Timer(this.components);
            this.nIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mspMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMenu
            // 
            this.mspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.tsmEduit,
            this.设置ToolStripMenuItem});
            this.mspMenu.Location = new System.Drawing.Point(0, 0);
            this.mspMenu.Name = "mspMenu";
            this.mspMenu.Size = new System.Drawing.Size(813, 25);
            this.mspMenu.TabIndex = 0;
            this.mspMenu.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(44, 21);
            this.File.Text = "文件";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(100, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmEduit
            // 
            this.tsmEduit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiIPList});
            this.tsmEduit.Name = "tsmEduit";
            this.tsmEduit.Size = new System.Drawing.Size(44, 21);
            this.tsmEduit.Text = "编辑";
            // 
            // tsmiIPList
            // 
            this.tsmiIPList.Name = "tsmiIPList";
            this.tsmiIPList.Size = new System.Drawing.Size(124, 22);
            this.tsmiIPList.Text = "设备信息";
            this.tsmiIPList.Click += new System.EventHandler(this.tsmiIPList_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPath});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // tsmiPath
            // 
            this.tsmiPath.Name = "tsmiPath";
            this.tsmiPath.Size = new System.Drawing.Size(148, 22);
            this.tsmiPath.Text = "配置文件路径";
            this.tsmiPath.Click += new System.EventHandler(this.tsmiPath_Click);
            // 
            // bgwCheckWeb
            // 
            this.bgwCheckWeb.WorkerReportsProgress = true;
            this.bgwCheckWeb.WorkerSupportsCancellation = true;
            this.bgwCheckWeb.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckWeb_DoWork);
            this.bgwCheckWeb.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCheckWeb_ProgressChanged);
            // 
            // tirCheckLine
            // 
            this.tirCheckLine.Tick += new System.EventHandler(this.tirCheckLine_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 156);
            this.panel1.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnStop.Location = new System.Drawing.Point(87, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 41);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "结束";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(6, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 41);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOutLine);
            this.groupBox2.Controls.Add(this.lblOnLine);
            this.groupBox2.Controls.Add(this.lblTotle);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(195, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 93);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "连接情况";
            // 
            // lblOutLine
            // 
            this.lblOutLine.AutoSize = true;
            this.lblOutLine.ForeColor = System.Drawing.Color.Red;
            this.lblOutLine.Location = new System.Drawing.Point(48, 72);
            this.lblOutLine.Name = "lblOutLine";
            this.lblOutLine.Size = new System.Drawing.Size(11, 12);
            this.lblOutLine.TabIndex = 1;
            this.lblOutLine.Text = "0";
            // 
            // lblOnLine
            // 
            this.lblOnLine.AutoSize = true;
            this.lblOnLine.ForeColor = System.Drawing.Color.Blue;
            this.lblOnLine.Location = new System.Drawing.Point(48, 49);
            this.lblOnLine.Name = "lblOnLine";
            this.lblOnLine.Size = new System.Drawing.Size(11, 12);
            this.lblOnLine.TabIndex = 1;
            this.lblOnLine.Text = "0";
            // 
            // lblTotle
            // 
            this.lblTotle.AutoSize = true;
            this.lblTotle.Location = new System.Drawing.Point(48, 24);
            this.lblTotle.Name = "lblTotle";
            this.lblTotle.Size = new System.Drawing.Size(11, 12);
            this.lblTotle.TabIndex = 1;
            this.lblTotle.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(9, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "离线：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(9, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "在线：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "总数：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblStartTime);
            this.groupBox1.Controls.Add(this.lblSysStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "运行时间：";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(75, 49);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(0, 12);
            this.lblStartTime.TabIndex = 1;
            // 
            // lblSysStatus
            // 
            this.lblSysStatus.AutoSize = true;
            this.lblSysStatus.ForeColor = System.Drawing.Color.Red;
            this.lblSysStatus.Location = new System.Drawing.Point(75, 24);
            this.lblSysStatus.Name = "lblSysStatus";
            this.lblSysStatus.Size = new System.Drawing.Size(41, 12);
            this.lblSysStatus.TabIndex = 1;
            this.lblSysStatus.Text = "已停止";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "运行状态：";
            // 
            // RowNo
            // 
            this.RowNo.Text = "No";
            this.RowNo.Width = 30;
            // 
            // Status
            // 
            this.Status.Text = "狀態";
            this.Status.Width = 50;
            // 
            // IP
            // 
            this.IP.Text = "IP地址";
            this.IP.Width = 90;
            // 
            // Times
            // 
            this.Times.Text = "延時";
            // 
            // OffLineAmount
            // 
            this.OffLineAmount.Text = "離線次數";
            // 
            // SoftwareNo
            // 
            this.SoftwareNo.Text = "軟件編號";
            this.SoftwareNo.Width = 100;
            // 
            // MachineID
            // 
            this.MachineID.Text = "機臺編號";
            this.MachineID.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "狀態";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IP地址";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "延時";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "離線次數";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "軟件編號";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "機臺編號";
            this.columnHeader7.Width = 100;
            // 
            // rtbMessage
            // 
            this.rtbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbMessage.Location = new System.Drawing.Point(2, 189);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.ReadOnly = true;
            this.rtbMessage.Size = new System.Drawing.Size(340, 308);
            this.rtbMessage.TabIndex = 2;
            this.rtbMessage.Text = "";
            // 
            // lvwIPList
            // 
            this.lvwIPList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwIPList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwIPList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader13});
            this.lvwIPList.Font = new System.Drawing.Font("SimSun", 11F);
            this.lvwIPList.FullRowSelect = true;
            this.lvwIPList.GridLines = true;
            this.lvwIPList.Location = new System.Drawing.Point(347, 30);
            this.lvwIPList.MultiSelect = false;
            this.lvwIPList.Name = "lvwIPList";
            this.lvwIPList.Size = new System.Drawing.Size(465, 467);
            this.lvwIPList.TabIndex = 4;
            this.lvwIPList.UseCompatibleStateImageBehavior = false;
            this.lvwIPList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Tag = "Name";
            this.columnHeader9.Text = "机名";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Tag = "Number";
            this.columnHeader10.Text = "机号";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Tag = "IP";
            this.columnHeader11.Text = "IP";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "延時";
            // 
            // bgwCheckOutLint
            // 
            this.bgwCheckOutLint.WorkerReportsProgress = true;
            this.bgwCheckOutLint.WorkerSupportsCancellation = true;
            this.bgwCheckOutLint.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckOutLint_DoWork);
            this.bgwCheckOutLint.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCheckOutLint_ProgressChanged);
            // 
            // tirCheckClose
            // 
            this.tirCheckClose.Tick += new System.EventHandler(this.tirCheckClose_Tick);
            // 
            // tirSetMail
            // 
            this.tirSetMail.Tick += new System.EventHandler(this.tirSetMail_Tick);
            // 
            // nIconMain
            // 
            this.nIconMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIconMain.ContextMenuStrip = this.contextIcon;
            this.nIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("nIconMain.Icon")));
            this.nIconMain.Text = "网络联机监控";
            this.nIconMain.Visible = true;
            // 
            // contextIcon
            // 
            this.contextIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.menuItemHide,
            this.menuItemExit});
            this.contextIcon.Name = "contextIcon";
            this.contextIcon.Size = new System.Drawing.Size(125, 70);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Enabled = false;
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Size = new System.Drawing.Size(124, 22);
            this.menuItemOpen.Text = "打开程序";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemHide
            // 
            this.menuItemHide.Name = "menuItemHide";
            this.menuItemHide.Size = new System.Drawing.Size(124, 22);
            this.menuItemHide.Text = "隐藏";
            this.menuItemHide.Click += new System.EventHandler(this.menuItemHide_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(124, 22);
            this.menuItemExit.Text = "退出";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 499);
            this.Controls.Add(this.lvwIPList);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mspMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mspMenu;
            this.Name = "MainForm";
            this.Text = "网络联机监控";
            this.mspMenu.ResumeLayout(false);
            this.mspMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMenu;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem tsmEduit;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiIPList;
        private System.ComponentModel.BackgroundWorker bgwCheckWeb;
        private System.Windows.Forms.Timer tirCheckLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader RowNo;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader Times;
        private System.Windows.Forms.ColumnHeader OffLineAmount;
        private System.Windows.Forms.ColumnHeader SoftwareNo;
        private System.Windows.Forms.ColumnHeader MachineID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblSysStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.ListView lvwIPList;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label lblOutLine;
        private System.Windows.Forms.Label lblOnLine;
        private System.Windows.Forms.Label lblTotle;
        private System.ComponentModel.BackgroundWorker bgwCheckOutLint;
        private System.Windows.Forms.Timer tirCheckClose;
        private System.Windows.Forms.Timer tirSetMail;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPath;
        private System.Windows.Forms.NotifyIcon nIconMain;
        private System.Windows.Forms.ContextMenuStrip contextIcon;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemHide;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
    }
}

