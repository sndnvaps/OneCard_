namespace WindowUI.HHZX.SystemSettings
{
    partial class dlgConstantExpensesSetting
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
            this.gbxName = new System.Windows.Forms.GroupBox();
            this.ntbxNewCost = new WindowControls.HHZX.NumberBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labOldCost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxName
            // 
            this.gbxName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxName.Controls.Add(this.ntbxNewCost);
            this.gbxName.Controls.Add(this.label3);
            this.gbxName.Controls.Add(this.labOldCost);
            this.gbxName.Controls.Add(this.label1);
            this.gbxName.Location = new System.Drawing.Point(16, 1);
            this.gbxName.Margin = new System.Windows.Forms.Padding(4);
            this.gbxName.Name = "gbxName";
            this.gbxName.Padding = new System.Windows.Forms.Padding(4);
            this.gbxName.Size = new System.Drawing.Size(531, 80);
            this.gbxName.TabIndex = 0;
            this.gbxName.TabStop = false;
            this.gbxName.Text = "费用";
            // 
            // ntbxNewCost
            // 
            this.ntbxNewCost.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbxNewCost.Enabled = false;
            this.ntbxNewCost.Font = new System.Drawing.Font("SimSun", 30F);
            this.ntbxNewCost.ForeColor = System.Drawing.Color.Red;
            this.ntbxNewCost.Location = new System.Drawing.Point(349, 21);
            this.ntbxNewCost.Margin = new System.Windows.Forms.Padding(4);
            this.ntbxNewCost.Name = "ntbxNewCost";
            this.ntbxNewCost.Size = new System.Drawing.Size(101, 53);
            this.ntbxNewCost.TabIndex = 3;
            this.ntbxNewCost.TextChanged += new System.EventHandler(this.ntbxNewCost_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "新费用：";
            // 
            // labOldCost
            // 
            this.labOldCost.AutoSize = true;
            this.labOldCost.BackColor = System.Drawing.Color.White;
            this.labOldCost.Font = new System.Drawing.Font("SimSun", 30F);
            this.labOldCost.ForeColor = System.Drawing.Color.Red;
            this.labOldCost.Location = new System.Drawing.Point(127, 24);
            this.labOldCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labOldCost.Name = "labOldCost";
            this.labOldCost.Size = new System.Drawing.Size(97, 40);
            this.labOldCost.TabIndex = 1;
            this.labOldCost.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "原费用：";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("SimSun", 9F);
            this.btnCancel.Location = new System.Drawing.Point(467, 89);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("SimSun", 9F);
            this.btnSave.Location = new System.Drawing.Point(386, 89);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dlgConstantExpensesSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 128);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxName);
            this.Font = new System.Drawing.Font("SimSun", 11F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgConstantExpensesSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "费用设定";
            this.Text = "费用设定";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgConstantExpensesSetting_KeyDown);
            this.gbxName.ResumeLayout(false);
            this.gbxName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxName;
        private WindowControls.HHZX.NumberBox ntbxNewCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labOldCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}