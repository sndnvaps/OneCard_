namespace WindowUI.HHZX.Report
{
    partial class frmPayRecord
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
            this.lvPayRecord = new System.Windows.Forms.ListView();
            this.prd_cRecordID = new System.Windows.Forms.ColumnHeader();
            this.prd_cPayTypeName = new System.Windows.Forms.ColumnHeader();
            this.prd_fPayMoney = new System.Windows.Forms.ColumnHeader();
            this.prd_cDepartmentName = new System.Windows.Forms.ColumnHeader();
            this.prd_cCertificateID = new System.Windows.Forms.ColumnHeader();
            this.prd_cCertificateDate = new System.Windows.Forms.ColumnHeader();
            this.systemToolBar1 = new WindowControls.HBPMS.SystemToolBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.prd_iPayCount = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvPayRecord);
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 448);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lvPayRecord
            // 
            this.lvPayRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.prd_cRecordID,
            this.prd_cPayTypeName,
            this.prd_fPayMoney,
            this.prd_iPayCount,
            this.prd_cDepartmentName,
            this.prd_cCertificateID,
            this.prd_cCertificateDate});
            this.lvPayRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPayRecord.FullRowSelect = true;
            this.lvPayRecord.GridLines = true;
            this.lvPayRecord.Location = new System.Drawing.Point(3, 17);
            this.lvPayRecord.Name = "lvPayRecord";
            this.lvPayRecord.Size = new System.Drawing.Size(710, 428);
            this.lvPayRecord.TabIndex = 0;
            this.lvPayRecord.UseCompatibleStateImageBehavior = false;
            this.lvPayRecord.View = System.Windows.Forms.View.Details;
            this.lvPayRecord.DoubleClick += new System.EventHandler(this.lvPayRecord_DoubleClick);
            // 
            // prd_cRecordID
            // 
            this.prd_cRecordID.Tag = "prd_cRecordID";
            this.prd_cRecordID.Text = "ID";
            // 
            // prd_cPayTypeName
            // 
            this.prd_cPayTypeName.Tag = "prd_cPayTypeName";
            this.prd_cPayTypeName.Text = "类型";
            this.prd_cPayTypeName.Width = 100;
            // 
            // prd_fPayMoney
            // 
            this.prd_fPayMoney.Tag = "prd_fPayMoney";
            this.prd_fPayMoney.Text = "金额";
            this.prd_fPayMoney.Width = 100;
            // 
            // prd_cDepartmentName
            // 
            this.prd_cDepartmentName.Tag = "prd_cDepartmentName";
            this.prd_cDepartmentName.Text = "部门";
            this.prd_cDepartmentName.Width = 100;
            // 
            // prd_cCertificateID
            // 
            this.prd_cCertificateID.Tag = "prd_cCertificateID";
            this.prd_cCertificateID.Text = "凭证编号";
            this.prd_cCertificateID.Width = 100;
            // 
            // prd_cCertificateDate
            // 
            this.prd_cCertificateDate.Tag = "prd_cCertificateDate";
            this.prd_cCertificateDate.Text = "凭证日期";
            this.prd_cCertificateDate.Width = 150;
            // 
            // systemToolBar1
            // 
            this.systemToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.systemToolBar1.BtnDelete_IsEnabled = true;
            this.systemToolBar1.BtnDelete_IsUsed = true;
            this.systemToolBar1.BtnDetail_IsEnabled = false;
            this.systemToolBar1.BtnDetail_IsUsed = false;
            this.systemToolBar1.BtnExit_IsEnabled = false;
            this.systemToolBar1.BtnExit_IsUsed = false;
            this.systemToolBar1.BtnModify_IsEnabled = true;
            this.systemToolBar1.BtnModify_IsUsed = true;
            this.systemToolBar1.BtnNew_IsEnabled = true;
            this.systemToolBar1.BtnNew_IsUsed = true;
            this.systemToolBar1.BtnRefresh_IsEnabled = true;
            this.systemToolBar1.BtnRefresh_IsUsed = true;
            this.systemToolBar1.BtnSave_IsEnabled = false;
            this.systemToolBar1.BtnSave_IsUsed = false;
            this.systemToolBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.systemToolBar1.Location = new System.Drawing.Point(0, 0);
            this.systemToolBar1.Name = "systemToolBar1";
            this.systemToolBar1.Size = new System.Drawing.Size(719, 23);
            this.systemToolBar1.TabIndex = 1;
            this.systemToolBar1.OnItemDelete_Click += new WindowControls.HBPMS.SystemToolBar.ItemDelete_Click(this.systemToolBar1_OnItemDelete_Click);
            this.systemToolBar1.OnItemRefresh_Click += new WindowControls.HBPMS.SystemToolBar.ItemRefresh_Click(this.systemToolBar1_OnItemRefresh_Click);
            this.systemToolBar1.OnItemModify_Click += new WindowControls.HBPMS.SystemToolBar.ItemModify_Click(this.systemToolBar1_OnItemModify_Click);
            this.systemToolBar1.OnItemNew_Click += new WindowControls.HBPMS.SystemToolBar.ItemNew_Click(this.systemToolBar1_OnItemNew_Click);
            // 
            // prd_iPayCount
            // 
            this.prd_iPayCount.Tag = "prd_iPayCount";
            this.prd_iPayCount.Text = "数量";
            this.prd_iPayCount.Width = 80;
            // 
            // frmPayRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 460);
            this.Controls.Add(this.systemToolBar1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "支出登记";
            this.Tag = "支出登记";
            this.Text = "支出登记";
            this.ToolTipText = "支出登记";
            this.Load += new System.EventHandler(this.frmPayRecord_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private WindowControls.HBPMS.SystemToolBar systemToolBar1;
        private System.Windows.Forms.ListView lvPayRecord;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColumnHeader prd_cRecordID;
        private System.Windows.Forms.ColumnHeader prd_cPayTypeName;
        private System.Windows.Forms.ColumnHeader prd_fPayMoney;
        private System.Windows.Forms.ColumnHeader prd_cDepartmentName;
        private System.Windows.Forms.ColumnHeader prd_cCertificateID;
        private System.Windows.Forms.ColumnHeader prd_cCertificateDate;
        private System.Windows.Forms.ColumnHeader prd_iPayCount;
    }
}