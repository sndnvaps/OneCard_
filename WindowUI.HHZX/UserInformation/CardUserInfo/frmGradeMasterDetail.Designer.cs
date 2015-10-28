namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmGradeMasterDetail
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
            this.proUserData = new System.Windows.Forms.PropertyGrid();
            this.sysToolBar = new WindowControls.HBPMS.SystemToolBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.proUserData);
            this.groupBox1.Location = new System.Drawing.Point(2, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 392);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // proUserData
            // 
            this.proUserData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proUserData.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.proUserData.Location = new System.Drawing.Point(6, 20);
            this.proUserData.Name = "proUserData";
            this.proUserData.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.proUserData.Size = new System.Drawing.Size(480, 366);
            this.proUserData.TabIndex = 1;
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
            this.sysToolBar.BtnModify_IsUsed = false;
            this.sysToolBar.BtnNew_IsEnabled = false;
            this.sysToolBar.BtnNew_IsUsed = false;
            this.sysToolBar.BtnRefresh_IsEnabled = false;
            this.sysToolBar.BtnRefresh_IsUsed = false;
            this.sysToolBar.BtnSave_IsEnabled = true;
            this.sysToolBar.BtnSave_IsUsed = true;
            this.sysToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Size = new System.Drawing.Size(494, 23);
            this.sysToolBar.TabIndex = 1;
            this.sysToolBar.OnItemSave_Click += new WindowControls.HBPMS.SystemToolBar.ItemSave_Click(this.sysToolBar_OnItemSave_Click);
            this.sysToolBar.OnItemExit_Click += new WindowControls.HBPMS.SystemToolBar.ItemExit_Click(this.sysToolBar_OnItemExit_Click);
            // 
            // frmGradeMasterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 412);
            this.Controls.Add(this.sysToolBar);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGradeMasterDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "年級信息";
            this.Tag = "年級信息";
            this.Text = "年級信息";
            this.Load += new System.EventHandler(this.frmGradeMasterDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid proUserData;
        private WindowControls.HBPMS.SystemToolBar sysToolBar;
    }
}