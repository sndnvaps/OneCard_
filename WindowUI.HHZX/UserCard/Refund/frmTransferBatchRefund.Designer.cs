namespace WindowUI.HHZX.UserCard.Refund
{
    partial class frmTransferBatchRefund
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnConfirmRecharge = new System.Windows.Forms.Button();
            this.lvBatchRechargeList = new System.Windows.Forms.ListView();
            this.UserID = new System.Windows.Forms.ColumnHeader();
            this.CardID = new System.Windows.Forms.ColumnHeader();
            this.Valid = new System.Windows.Forms.ColumnHeader();
            this.UserNum = new System.Windows.Forms.ColumnHeader();
            this.Dept = new System.Windows.Forms.ColumnHeader();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.Refund = new System.Windows.Forms.ColumnHeader();
            this.ValidInfo = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModelExport = new System.Windows.Forms.Button();
            this.btnFileImport = new System.Windows.Forms.Button();
            this.btnClearFile = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "确认资料";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(623, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(229, 415);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "确认请点击";
            // 
            // btnConfirmRecharge
            // 
            this.btnConfirmRecharge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfirmRecharge.Enabled = false;
            this.btnConfirmRecharge.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnConfirmRecharge.Location = new System.Drawing.Point(300, 401);
            this.btnConfirmRecharge.Name = "btnConfirmRecharge";
            this.btnConfirmRecharge.Size = new System.Drawing.Size(111, 37);
            this.btnConfirmRecharge.TabIndex = 14;
            this.btnConfirmRecharge.Text = "确认转账";
            this.btnConfirmRecharge.UseVisualStyleBackColor = true;
            this.btnConfirmRecharge.Click += new System.EventHandler(this.btnConfirmRecharge_Click);
            // 
            // lvBatchRechargeList
            // 
            this.lvBatchRechargeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID,
            this.CardID,
            this.Valid,
            this.UserNum,
            this.Dept,
            this.UserName,
            this.Refund,
            this.ValidInfo});
            this.lvBatchRechargeList.Font = new System.Drawing.Font("SimSun", 11F);
            this.lvBatchRechargeList.FullRowSelect = true;
            this.lvBatchRechargeList.GridLines = true;
            this.lvBatchRechargeList.Location = new System.Drawing.Point(12, 101);
            this.lvBatchRechargeList.Name = "lvBatchRechargeList";
            this.lvBatchRechargeList.Size = new System.Drawing.Size(687, 287);
            this.lvBatchRechargeList.TabIndex = 13;
            this.lvBatchRechargeList.UseCompatibleStateImageBehavior = false;
            this.lvBatchRechargeList.View = System.Windows.Forms.View.Details;
            // 
            // UserID
            // 
            this.UserID.Tag = "UserID";
            this.UserID.Width = 0;
            // 
            // CardID
            // 
            this.CardID.Tag = "CardID";
            this.CardID.Text = "CardID";
            this.CardID.Width = 0;
            // 
            // Valid
            // 
            this.Valid.Tag = "Valid";
            this.Valid.Text = "验证结果";
            this.Valid.Width = 0;
            // 
            // UserNum
            // 
            this.UserNum.Tag = "UserNum";
            this.UserNum.Text = "用户编号";
            this.UserNum.Width = 120;
            // 
            // Dept
            // 
            this.Dept.Tag = "Dept";
            this.Dept.Text = "班别/部门";
            this.Dept.Width = 120;
            // 
            // UserName
            // 
            this.UserName.Tag = "UserName";
            this.UserName.Text = "用户姓名";
            this.UserName.Width = 100;
            // 
            // Refund
            // 
            this.Refund.Tag = "Refund";
            this.Refund.Text = "转账金额";
            this.Refund.Width = 93;
            // 
            // ValidInfo
            // 
            this.ValidInfo.Tag = "ValidInfo";
            this.ValidInfo.Text = "验证信息";
            this.ValidInfo.Width = 232;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModelExport);
            this.groupBox1.Controls.Add(this.btnFileImport);
            this.groupBox1.Controls.Add(this.btnClearFile);
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Controls.Add(this.tbxFilePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 73);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入退款列表";
            // 
            // btnModelExport
            // 
            this.btnModelExport.Location = new System.Drawing.Point(499, 42);
            this.btnModelExport.Name = "btnModelExport";
            this.btnModelExport.Size = new System.Drawing.Size(80, 25);
            this.btnModelExport.TabIndex = 5;
            this.btnModelExport.Text = "导出模板";
            this.btnModelExport.UseVisualStyleBackColor = true;
            this.btnModelExport.Click += new System.EventHandler(this.btnModelExport_Click);
            // 
            // btnFileImport
            // 
            this.btnFileImport.Enabled = false;
            this.btnFileImport.Location = new System.Drawing.Point(414, 42);
            this.btnFileImport.Name = "btnFileImport";
            this.btnFileImport.Size = new System.Drawing.Size(80, 25);
            this.btnFileImport.TabIndex = 4;
            this.btnFileImport.Text = "导入";
            this.btnFileImport.UseVisualStyleBackColor = true;
            this.btnFileImport.Click += new System.EventHandler(this.btnFileImport_Click);
            // 
            // btnClearFile
            // 
            this.btnClearFile.Enabled = false;
            this.btnClearFile.Location = new System.Drawing.Point(585, 42);
            this.btnClearFile.Name = "btnClearFile";
            this.btnClearFile.Size = new System.Drawing.Size(80, 25);
            this.btnClearFile.TabIndex = 3;
            this.btnClearFile.Text = "清除";
            this.btnClearFile.UseVisualStyleBackColor = true;
            this.btnClearFile.Click += new System.EventHandler(this.btnClearFile_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(328, 42);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(80, 25);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "打开";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.Enabled = false;
            this.tbxFilePath.Location = new System.Drawing.Point(69, 18);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.Size = new System.Drawing.Size(596, 21);
            this.tbxFilePath.TabIndex = 1;
            this.tbxFilePath.TextChanged += new System.EventHandler(this.tbxFilePath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件：";
            // 
            // frmTransferBatchRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 445);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnConfirmRecharge);
            this.Controls.Add(this.lvBatchRechargeList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(727, 483);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(727, 483);
            this.Name = "frmTransferBatchRefund";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "【批量卡转账退款】";
            this.Tag = "【批量卡转账退款】";
            this.Text = "【批量卡转账退款】";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnConfirmRecharge;
        private System.Windows.Forms.ListView lvBatchRechargeList;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader CardID;
        private System.Windows.Forms.ColumnHeader Valid;
        private System.Windows.Forms.ColumnHeader UserNum;
        private System.Windows.Forms.ColumnHeader Dept;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader Refund;
        private System.Windows.Forms.ColumnHeader ValidInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModelExport;
        private System.Windows.Forms.Button btnFileImport;
        private System.Windows.Forms.Button btnClearFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbxFilePath;
        private System.Windows.Forms.Label label1;

    }
}