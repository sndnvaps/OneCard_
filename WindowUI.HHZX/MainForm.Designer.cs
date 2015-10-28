namespace WindowUI.HHZX
{
    partial class MainForm
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuSysList = new System.Windows.Forms.MenuItem();
            this.btnLogOut = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.meuExit = new System.Windows.Forms.MenuItem();
            this.menuDeviceSettings = new System.Windows.Forms.MenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.dpnlContainer = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.MainStatusBar = new System.Windows.Forms.StatusStrip();
            this.tssLabUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabStatusDetail = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tssLabVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabTimeDisplay = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSysList});
            // 
            // menuSysList
            // 
            this.menuSysList.Index = 0;
            this.menuSysList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.btnLogOut,
            this.menuItem9,
            this.meuExit});
            this.menuSysList.Text = "文件(&O)";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Index = 0;
            this.btnLogOut.Text = "注销";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "-";
            // 
            // meuExit
            // 
            this.meuExit.Index = 2;
            this.meuExit.Text = "退出(&X)";
            this.meuExit.Click += new System.EventHandler(this.meuExit_Click);
            // 
            // menuDeviceSettings
            // 
            this.menuDeviceSettings.Index = -1;
            this.menuDeviceSettings.Tag = "WindowUI.HHZX.ConsumerDevice.frmDeviceFunctionSetting";
            this.menuDeviceSettings.Text = "消费机功能设置";
            this.menuDeviceSettings.Click += new System.EventHandler(this.menuForm_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 500;
            // 
            // dpnlContainer
            // 
            this.dpnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dpnlContainer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dpnlContainer.DockLeftPortion = 0.15;
            this.dpnlContainer.Location = new System.Drawing.Point(0, 0);
            this.dpnlContainer.Name = "dpnlContainer";
            this.dpnlContainer.Size = new System.Drawing.Size(792, 553);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dpnlContainer.Skin = dockPanelSkin1;
            this.dpnlContainer.TabIndex = 4;
            // 
            // MainStatusBar
            // 
            this.MainStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabUserName,
            this.tssLabStatusDetail,
            this.tssProgressBar,
            this.tssLabVersion,
            this.tssLabTimeDisplay});
            this.MainStatusBar.Location = new System.Drawing.Point(0, 556);
            this.MainStatusBar.Name = "MainStatusBar";
            this.MainStatusBar.Size = new System.Drawing.Size(792, 26);
            this.MainStatusBar.TabIndex = 7;
            this.MainStatusBar.Text = "statusStrip1";
            // 
            // tssLabUserName
            // 
            this.tssLabUserName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssLabUserName.Name = "tssLabUserName";
            this.tssLabUserName.Size = new System.Drawing.Size(35, 21);
            this.tssLabUserName.Text = "User";
            // 
            // tssLabStatusDetail
            // 
            this.tssLabStatusDetail.AutoSize = false;
            this.tssLabStatusDetail.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssLabStatusDetail.Name = "tssLabStatusDetail";
            this.tssLabStatusDetail.Size = new System.Drawing.Size(200, 21);
            // 
            // tssProgressBar
            // 
            this.tssProgressBar.Name = "tssProgressBar";
            this.tssProgressBar.Size = new System.Drawing.Size(200, 20);
            this.tssProgressBar.Visible = false;
            // 
            // tssLabVersion
            // 
            this.tssLabVersion.AutoSize = false;
            this.tssLabVersion.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssLabVersion.Name = "tssLabVersion";
            this.tssLabVersion.Size = new System.Drawing.Size(271, 21);
            this.tssLabVersion.Spring = true;
            // 
            // tssLabTimeDisplay
            // 
            this.tssLabTimeDisplay.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tssLabTimeDisplay.Name = "tssLabTimeDisplay";
            this.tssLabTimeDisplay.Size = new System.Drawing.Size(271, 21);
            this.tssLabTimeDisplay.Spring = true;
            this.tssLabTimeDisplay.Text = "2013-01-01 00:00:00";
            this.tssLabTimeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 582);
            this.Controls.Add(this.MainStatusBar);
            this.Controls.Add(this.dpnlContainer);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.TopMenu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "鹤华中学一卡通管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainStatusBar.ResumeLayout(false);
            this.MainStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer MainTimer;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dpnlContainer;
        private System.Windows.Forms.MenuItem btnLogOut;
        private System.Windows.Forms.MenuItem meuExit;
        private System.Windows.Forms.StatusStrip MainStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tssLabUserName;
        private System.Windows.Forms.ToolStripStatusLabel tssLabStatusDetail;
        private System.Windows.Forms.ToolStripStatusLabel tssLabVersion;
        private System.Windows.Forms.ToolStripStatusLabel tssLabTimeDisplay;
        private System.Windows.Forms.ToolStripProgressBar tssProgressBar;
        protected internal System.Windows.Forms.MainMenu TopMenu;
        private System.Windows.Forms.MenuItem menuSysList;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuDeviceSettings;

    }
}

