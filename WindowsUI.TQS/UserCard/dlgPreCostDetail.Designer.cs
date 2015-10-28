namespace WindowsUI.TQS.UserCard
{
    partial class dlgPreCostDetail
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
            this.lvPreCostDetail = new System.Windows.Forms.ListView();
            this.pcs_cRecordID = new System.Windows.Forms.ColumnHeader();
            this.pcs_fCost = new System.Windows.Forms.ColumnHeader();
            this.ConsumeType = new System.Windows.Forms.ColumnHeader();
            this.pcs_dConsumeDate = new System.Windows.Forms.ColumnHeader();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labPreCost = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvPreCostDetail);
            this.groupBox1.Location = new System.Drawing.Point(9, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 318);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lvPreCostDetail
            // 
            this.lvPreCostDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pcs_cRecordID,
            this.pcs_fCost,
            this.ConsumeType,
            this.pcs_dConsumeDate,
            this.UserName});
            this.lvPreCostDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPreCostDetail.Font = new System.Drawing.Font("YouYuan", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvPreCostDetail.FullRowSelect = true;
            this.lvPreCostDetail.GridLines = true;
            this.lvPreCostDetail.Location = new System.Drawing.Point(3, 17);
            this.lvPreCostDetail.MultiSelect = false;
            this.lvPreCostDetail.Name = "lvPreCostDetail";
            this.lvPreCostDetail.Size = new System.Drawing.Size(656, 298);
            this.lvPreCostDetail.TabIndex = 0;
            this.lvPreCostDetail.UseCompatibleStateImageBehavior = false;
            this.lvPreCostDetail.View = System.Windows.Forms.View.Details;
            this.lvPreCostDetail.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvPreCostDetail_ColumnClick);
            // 
            // pcs_cRecordID
            // 
            this.pcs_cRecordID.Tag = "RecordID";
            this.pcs_cRecordID.Width = 0;
            // 
            // pcs_fCost
            // 
            this.pcs_fCost.Tag = "Cost";
            this.pcs_fCost.Text = "消费金额";
            this.pcs_fCost.Width = 100;
            // 
            // ConsumeType
            // 
            this.ConsumeType.Tag = "ConsumeType";
            this.ConsumeType.Text = "消费类型";
            this.ConsumeType.Width = 160;
            // 
            // pcs_dConsumeDate
            // 
            this.pcs_dConsumeDate.Tag = "ConsumeDate";
            this.pcs_dConsumeDate.Text = "消费时间";
            this.pcs_dConsumeDate.Width = 233;
            // 
            // UserName
            // 
            this.UserName.Tag = "UserName";
            this.UserName.Text = "消费人员";
            this.UserName.Width = 129;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(289, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "确  定";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labPreCost);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 413);
            this.panel1.TabIndex = 2;
            // 
            // labPreCost
            // 
            this.labPreCost.AutoSize = true;
            this.labPreCost.Font = new System.Drawing.Font("YouYuan", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPreCost.Location = new System.Drawing.Point(587, 22);
            this.labPreCost.Name = "labPreCost";
            this.labPreCost.Size = new System.Drawing.Size(44, 16);
            this.labPreCost.TabIndex = 4;
            this.labPreCost.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("YouYuan", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(509, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "合计：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "未結算款明細";
            // 
            // dlgPreCostDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(689, 422);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgPreCostDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "未结算款项明细";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvPreCostDetail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader pcs_cRecordID;
        private System.Windows.Forms.ColumnHeader pcs_fCost;
        private System.Windows.Forms.ColumnHeader ConsumeType;
        private System.Windows.Forms.ColumnHeader pcs_dConsumeDate;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labPreCost;
        private System.Windows.Forms.Label label2;
    }
}