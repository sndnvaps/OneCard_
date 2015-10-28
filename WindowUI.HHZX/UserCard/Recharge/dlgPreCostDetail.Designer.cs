namespace WindowUI.HHZX.UserCard.Recharge
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvPreCostDetail);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "明细列表";
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
            this.lvPreCostDetail.Font = new System.Drawing.Font("SimSun", 10F);
            this.lvPreCostDetail.FullRowSelect = true;
            this.lvPreCostDetail.GridLines = true;
            this.lvPreCostDetail.Location = new System.Drawing.Point(3, 17);
            this.lvPreCostDetail.MultiSelect = false;
            this.lvPreCostDetail.Name = "lvPreCostDetail";
            this.lvPreCostDetail.Size = new System.Drawing.Size(560, 281);
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
            this.ConsumeType.Width = 150;
            // 
            // pcs_dConsumeDate
            // 
            this.pcs_dConsumeDate.Tag = "ConsumeDate";
            this.pcs_dConsumeDate.Text = "消费时间";
            this.pcs_dConsumeDate.Width = 200;
            // 
            // UserName
            // 
            this.UserName.Tag = "UserName";
            this.UserName.Text = "消费人员";
            this.UserName.Width = 100;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(484, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "确  定";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dlgPreCostDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 345);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgPreCostDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "未结算款项明细";
            this.groupBox1.ResumeLayout(false);
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
    }
}