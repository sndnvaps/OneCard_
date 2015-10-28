using System;
namespace WindowControls.HBPMS
{
    partial class SystemToolBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemToolBar));
            this.GeneralToolBar = new System.Windows.Forms.ToolStrip();
            this.tsBtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnModify = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDetail = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.GeneralToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralToolBar
            // 
            this.GeneralToolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNew,
            this.tsBtnModify,
            this.tsBtnSave,
            this.tsBtnDetail,
            this.tsBtnDelete,
            this.tsBtnRefresh,
            this.tsBtnExit});
            this.GeneralToolBar.Location = new System.Drawing.Point(0, 0);
            this.GeneralToolBar.Name = "GeneralToolBar";
            this.GeneralToolBar.Size = new System.Drawing.Size(741, 23);
            this.GeneralToolBar.TabIndex = 0;
            this.GeneralToolBar.Text = "toolStrip1";
            // 
            // tsBtnNew
            // 
            this.tsBtnNew.Enabled = false;
            this.tsBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNew.Image")));
            this.tsBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNew.Name = "tsBtnNew";
            this.tsBtnNew.Size = new System.Drawing.Size(52, 20);
            this.tsBtnNew.Text = "新增";
            this.tsBtnNew.Visible = false;
            this.tsBtnNew.Click += new System.EventHandler(this.tsBtnNew_Click);
            // 
            // tsBtnModify
            // 
            this.tsBtnModify.Enabled = false;
            this.tsBtnModify.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnModify.Image")));
            this.tsBtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnModify.Name = "tsBtnModify";
            this.tsBtnModify.Size = new System.Drawing.Size(52, 20);
            this.tsBtnModify.Text = "编辑";
            this.tsBtnModify.ToolTipText = "编辑";
            this.tsBtnModify.Visible = false;
            this.tsBtnModify.Click += new System.EventHandler(this.tsBtnModify_Click);
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Enabled = false;
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(52, 20);
            this.tsBtnSave.Text = "保存";
            this.tsBtnSave.Visible = false;
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnDetail
            // 
            this.tsBtnDetail.Enabled = false;
            this.tsBtnDetail.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDetail.Image")));
            this.tsBtnDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDetail.Name = "tsBtnDetail";
            this.tsBtnDetail.Size = new System.Drawing.Size(52, 20);
            this.tsBtnDetail.Text = "查看";
            this.tsBtnDetail.Visible = false;
            this.tsBtnDetail.Click += new System.EventHandler(this.tsBtnDetail_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Enabled = false;
            this.tsBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelete.Image")));
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(52, 20);
            this.tsBtnDelete.Text = "刪除";
            this.tsBtnDelete.Visible = false;
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Enabled = false;
            this.tsBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRefresh.Image")));
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(52, 20);
            this.tsBtnRefresh.Text = "刷新";
            this.tsBtnRefresh.Visible = false;
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.Enabled = false;
            this.tsBtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnExit.Image")));
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(52, 20);
            this.tsBtnExit.Text = "退出";
            this.tsBtnExit.Visible = false;
            this.tsBtnExit.Click += new System.EventHandler(this.tsBtnExit_Click);
            // 
            // SystemToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.GeneralToolBar);
            this.Name = "SystemToolBar";
            this.Size = new System.Drawing.Size(741, 23);
            this.GeneralToolBar.ResumeLayout(false);
            this.GeneralToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip GeneralToolBar;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.ToolStripButton tsBtnNew;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripButton tsBtnModify;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnDetail;

        #region 按鈕可見性

        /// <summary>
        /// 是否使 新增 按鈕可見
        /// </summary>
        public bool BtnNew_IsUsed { set { this.tsBtnNew.Visible = value; } get { return this.tsBtnNew.Visible; } }
        /// <summary>
        /// 是否使 編輯 按鈕可見
        /// </summary>
        public bool BtnModify_IsUsed { set { this.tsBtnModify.Visible = value; } get { return this.tsBtnModify.Visible; } }
        /// <summary>
        /// 是否使 保存 按鈕可見
        /// </summary>
        public bool BtnSave_IsUsed { set { this.tsBtnSave.Visible = value; } get { return this.tsBtnSave.Visible; } }
        /// <summary>
        /// 是否使 刪除 按鈕可見
        /// </summary>
        public bool BtnDelete_IsUsed { set { this.tsBtnDelete.Visible = value; } get { return this.tsBtnDelete.Visible; } }
        /// <summary>
        /// 是否使 查看 按鈕可見
        /// </summary>
        public bool BtnDetail_IsUsed { set { this.tsBtnDetail.Visible = value; } get { return this.tsBtnDetail.Visible; } }
        /// <summary>
        /// 是否使 刷新 按鈕可見
        /// </summary>
        public bool BtnRefresh_IsUsed { set { this.tsBtnRefresh.Visible = value; } get { return this.tsBtnRefresh.Visible; } }
        /// <summary>
        /// 是否使 退出 按鈕可見
        /// </summary>
        public bool BtnExit_IsUsed { set { this.tsBtnExit.Visible = value; } get { return this.tsBtnExit.Visible; } }

        #endregion

        #region 按鈕啟用性

        /// <summary>
        /// 是否啟用 新增 按鈕
        /// </summary>
        public bool BtnNew_IsEnabled { set { this.tsBtnNew.Enabled = value; } get { return this.tsBtnNew.Enabled; } }
        /// <summary>
        /// 是否啟用 編輯 按鈕
        /// </summary>
        public bool BtnModify_IsEnabled { set { this.tsBtnModify.Enabled = value; } get { return this.tsBtnModify.Enabled; } }
        /// <summary>
        /// 是否啟用 保存 按鈕
        /// </summary>
        public bool BtnSave_IsEnabled { set { this.tsBtnSave.Enabled = value; } get { return this.tsBtnSave.Enabled; } }
        /// <summary>
        /// 是否啟用 刪除 按鈕
        /// </summary>
        public bool BtnDelete_IsEnabled { set { this.tsBtnDelete.Enabled = value; } get { return this.tsBtnDelete.Enabled; } }
        /// <summary>
        /// 是否啟用 查看 按鈕
        /// </summary>
        public bool BtnDetail_IsEnabled { set { this.tsBtnDetail.Enabled = value; } get { return this.tsBtnDetail.Enabled; } }
        /// <summary>
        /// 是否啟用 刷新 按鈕
        /// </summary>
        public bool BtnRefresh_IsEnabled { set { this.tsBtnRefresh.Enabled = value; } get { return this.tsBtnRefresh.Enabled; } }
        /// <summary>
        /// 是否啟用 退出 按鈕
        /// </summary>
        public bool BtnExit_IsEnabled { set { this.tsBtnExit.Enabled = value; } get { return this.tsBtnExit.Enabled; } }

        #endregion

        #region 點擊事件

        public delegate void ItemNew_Click(object sender, EventArgs e);
        /// <summary>
        /// 新增 按鈕點擊
        /// </summary>
        public event ItemNew_Click OnItemNew_Click;

        public delegate void ItemModify_Click(object sender, EventArgs e);
        /// <summary>
        /// 編輯 按鈕點擊
        /// </summary>
        public event ItemModify_Click OnItemModify_Click;

        public delegate void ItemSave_Click(object sender, EventArgs e);
        /// <summary>
        /// 保存 按鈕點擊
        /// </summary>
        public event ItemSave_Click OnItemSave_Click;

        public delegate void ItemDelete_Click(object sender, EventArgs e);
        /// <summary>
        /// 刪除 按鈕點擊
        /// </summary>
        public event ItemDelete_Click OnItemDelete_Click;

        public delegate void ItemDetail_Click(object sender, EventArgs e);
        /// <summary>
        /// 查看 按鈕點擊
        /// </summary>
        public event ItemDetail_Click OnItemDetail_Click;

        public delegate void ItemRefresh_Click(object sender, EventArgs e);
        /// <summary>
        /// 刷新 按鈕點擊
        /// </summary>
        public event ItemRefresh_Click OnItemRefresh_Click;

        public delegate void ItemExit_Click(object sender, EventArgs e);
        /// <summary>
        /// 退出 按鈕點擊
        /// </summary>
        public event ItemExit_Click OnItemExit_Click;

        #endregion
    }
}
