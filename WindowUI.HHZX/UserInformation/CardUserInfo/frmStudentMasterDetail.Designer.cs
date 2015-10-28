namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    partial class frmStudentMasterDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.proUserData = new System.Windows.Forms.PropertyGrid();
            this.btnAutoNum = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.sysToolBar.TabIndex = 0;
            this.sysToolBar.OnItemSave_Click += new WindowControls.HBPMS.SystemToolBar.ItemSave_Click(this.sysToolBar_OnItemSave_Click);
            this.sysToolBar.OnItemExit_Click += new WindowControls.HBPMS.SystemToolBar.ItemExit_Click(this.sysToolBar_OnItemExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAutoNum);
            this.groupBox1.Controls.Add(this.proUserData);
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 381);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // proUserData
            // 
            this.proUserData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proUserData.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.proUserData.Location = new System.Drawing.Point(7, 7);
            this.proUserData.Name = "proUserData";
            this.proUserData.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.proUserData.Size = new System.Drawing.Size(480, 366);
            this.proUserData.TabIndex = 2;
            // 
            // btnAutoNum
            // 
            this.btnAutoNum.Location = new System.Drawing.Point(412, 7);
            this.btnAutoNum.Name = "btnAutoNum";
            this.btnAutoNum.Size = new System.Drawing.Size(75, 23);
            this.btnAutoNum.TabIndex = 3;
            this.btnAutoNum.Text = "自动编号";
            this.btnAutoNum.UseVisualStyleBackColor = true;
            this.btnAutoNum.Click += new System.EventHandler(this.btnAutoNum_Click);
            // 
            // frmStudentMasterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sysToolBar);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudentMasterDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "学生信息";
            this.Text = "学生信息";
            this.Load += new System.EventHandler(this.frmStudentMasterDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowControls.HBPMS.SystemToolBar sysToolBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid proUserData;
        private System.Windows.Forms.Button btnAutoNum;
    }
}