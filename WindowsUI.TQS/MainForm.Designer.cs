namespace WindowsUI.TQS
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
            System.Windows.Forms.Timer tirRunTime;
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dpnlContainer = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.imbUserAccountDetail = new WindowsUI.TQS.SystemForm.ImageButton();
            this.imbPaymentUDMeal = new WindowsUI.TQS.SystemForm.ImageButton();
            this.imbCardInfo = new WindowsUI.TQS.SystemForm.ImageButton();
            this.imbfrmRechargeDetail = new WindowsUI.TQS.SystemForm.ImageButton();
            this.imbRecharge = new WindowsUI.TQS.SystemForm.ImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wsbWebStatus = new WindowsUI.TQS.SystemForm.WebStatusBox();
            this.outWebForm = new WindowsUI.TQS.SystemForm.OutWebForm();
            this.mplMain = new WindowsUI.TQS.SystemForm.MainPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            tirRunTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tirRunTime
            // 
            tirRunTime.Enabled = true;
            tirRunTime.Interval = 1000;
            tirRunTime.Tick += new System.EventHandler(this.tirRunTime_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::WindowsUI.TQS.Properties.Resources.btnClose;
            this.pictureBox3.Location = new System.Drawing.Point(991, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 30);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // dpnlContainer
            // 
            this.dpnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dpnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.dpnlContainer.DockLeftPortion = 0.15;
            this.dpnlContainer.Location = new System.Drawing.Point(703, 309);
            this.dpnlContainer.Name = "dpnlContainer";
            this.dpnlContainer.Size = new System.Drawing.Size(267, 408);
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
            this.dpnlContainer.TabIndex = 13;
            // 
            // imbUserAccountDetail
            // 
            this.imbUserAccountDetail.BackColor = System.Drawing.Color.Transparent;
            this.imbUserAccountDetail.image = global::WindowsUI.TQS.Properties.Resources.UserAccountDetail_btn;
            this.imbUserAccountDetail.Location = new System.Drawing.Point(35, 225);
            this.imbUserAccountDetail.Name = "imbUserAccountDetail";
            this.imbUserAccountDetail.Size = new System.Drawing.Size(201, 60);
            this.imbUserAccountDetail.TabIndex = 11;
            this.imbUserAccountDetail.OnImageClick += new System.EventHandler(this.imbUserAccountDetail_OnImageClick);
            // 
            // imbPaymentUDMeal
            // 
            this.imbPaymentUDMeal.BackColor = System.Drawing.Color.Transparent;
            this.imbPaymentUDMeal.image = global::WindowsUI.TQS.Properties.Resources.PaymentUDMeal_btn;
            this.imbPaymentUDMeal.Location = new System.Drawing.Point(35, 143);
            this.imbPaymentUDMeal.Name = "imbPaymentUDMeal";
            this.imbPaymentUDMeal.Size = new System.Drawing.Size(201, 60);
            this.imbPaymentUDMeal.TabIndex = 10;
            this.imbPaymentUDMeal.OnImageClick += new System.EventHandler(this.imbPaymentUDMeal_OnImageClick);
            // 
            // imbCardInfo
            // 
            this.imbCardInfo.BackColor = System.Drawing.Color.Transparent;
            this.imbCardInfo.image = global::WindowsUI.TQS.Properties.Resources.CardInfo_btn;
            this.imbCardInfo.Location = new System.Drawing.Point(35, 61);
            this.imbCardInfo.Name = "imbCardInfo";
            this.imbCardInfo.Size = new System.Drawing.Size(201, 60);
            this.imbCardInfo.TabIndex = 9;
            this.imbCardInfo.OnImageClick += new System.EventHandler(this.imbCardInfo_OnImageClick);
            // 
            // imbfrmRechargeDetail
            // 
            this.imbfrmRechargeDetail.BackColor = System.Drawing.Color.Transparent;
            this.imbfrmRechargeDetail.image = global::WindowsUI.TQS.Properties.Resources.Recharge_btn;
            this.imbfrmRechargeDetail.Location = new System.Drawing.Point(35, 307);
            this.imbfrmRechargeDetail.Name = "imbfrmRechargeDetail";
            this.imbfrmRechargeDetail.Size = new System.Drawing.Size(201, 60);
            this.imbfrmRechargeDetail.TabIndex = 17;
            this.imbfrmRechargeDetail.OnImageClick += new System.EventHandler(this.imbfrmRechargeDetail_OnImageClick);
            // 
            // imbRecharge
            // 
            this.imbRecharge.BackColor = System.Drawing.Color.Transparent;
            this.imbRecharge.image = global::WindowsUI.TQS.Properties.Resources.Transfer_btn;
            this.imbRecharge.Location = new System.Drawing.Point(35, 389);
            this.imbRecharge.Name = "imbRecharge";
            this.imbRecharge.Size = new System.Drawing.Size(201, 60);
            this.imbRecharge.TabIndex = 19;
            this.imbRecharge.OnImageClick += new System.EventHandler(this.imbRecharge_OnImageClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Location = new System.Drawing.Point(6, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 25);
            this.panel1.TabIndex = 21;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("SimSun", 13F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.Blue;
            this.lblTime.Location = new System.Drawing.Point(7, 4);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(235, 18);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "2000年01月01日 12:00:00";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::WindowsUI.TQS.Properties.Resources.Bottom;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.wsbWebStatus);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 738);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 30);
            this.panel2.TabIndex = 23;
            // 
            // wsbWebStatus
            // 
            this.wsbWebStatus.BackColor = System.Drawing.Color.White;
            this.wsbWebStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.wsbWebStatus.Green = global::WindowsUI.TQS.Properties.Resources.webstatus_g;
            this.wsbWebStatus.IPAddress = null;
            this.wsbWebStatus.Location = new System.Drawing.Point(301, 2);
            this.wsbWebStatus.Name = "wsbWebStatus";
            this.wsbWebStatus.Out = global::WindowsUI.TQS.Properties.Resources.webstatus_o;
            this.wsbWebStatus.OutTime = 4;
            this.wsbWebStatus.OutWebForm = null;
            this.wsbWebStatus.Red = global::WindowsUI.TQS.Properties.Resources.webstatus_r;
            this.wsbWebStatus.Size = new System.Drawing.Size(140, 25);
            this.wsbWebStatus.TabIndex = 22;
            this.wsbWebStatus.Yellow = global::WindowsUI.TQS.Properties.Resources.webstatus_y;
            // 
            // outWebForm
            // 
            this.outWebForm.BackColor = System.Drawing.Color.Transparent;
            this.outWebForm.Location = new System.Drawing.Point(6, 6);
            this.outWebForm.Name = "outWebForm";
            this.outWebForm.Size = new System.Drawing.Size(54, 20);
            this.outWebForm.TabIndex = 25;
            // 
            // mplMain
            // 
            this.mplMain.BackColor = System.Drawing.Color.Transparent;
            this.mplMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mplMain.BackgroundImage")));
            this.mplMain.Location = new System.Drawing.Point(292, 7);
            this.mplMain.Name = "mplMain";
            this.mplMain.Size = new System.Drawing.Size(710, 730);
            this.mplMain.StopTimer = false;
            this.mplMain.TabIndex = 27;
            this.mplMain.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.labVersion);
            this.panel3.Location = new System.Drawing.Point(441, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(134, 25);
            this.panel3.TabIndex = 23;
            // 
            // labVersion
            // 
            this.labVersion.AutoSize = true;
            this.labVersion.Font = new System.Drawing.Font("SimSun", 13F, System.Drawing.FontStyle.Bold);
            this.labVersion.ForeColor = System.Drawing.Color.Blue;
            this.labVersion.Location = new System.Drawing.Point(51, 3);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(78, 18);
            this.labVersion.TabIndex = 0;
            this.labVersion.Text = "1.0.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "ver.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsUI.TQS.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.mplMain);
            this.Controls.Add(this.outWebForm);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.imbRecharge);
            this.Controls.Add(this.imbfrmRechargeDetail);
            this.Controls.Add(this.dpnlContainer);
            this.Controls.Add(this.imbUserAccountDetail);
            this.Controls.Add(this.imbPaymentUDMeal);
            this.Controls.Add(this.imbCardInfo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公共查询系统";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private WindowsUI.TQS.SystemForm.ImageButton imbCardInfo;
        private WindowsUI.TQS.SystemForm.ImageButton imbPaymentUDMeal;
        private WindowsUI.TQS.SystemForm.ImageButton imbUserAccountDetail;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dpnlContainer;
        
        private WindowsUI.TQS.SystemForm.ImageButton imbfrmRechargeDetail;
        private WindowsUI.TQS.SystemForm.ImageButton imbRecharge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panel2;
        private WindowsUI.TQS.SystemForm.WebStatusBox wsbWebStatus;
        private WindowsUI.TQS.SystemForm.OutWebForm outWebForm;
        private WindowsUI.TQS.SystemForm.MainPanel mplMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labVersion;
        private System.Windows.Forms.Label label2;
    }
}

