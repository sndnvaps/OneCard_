namespace WindowUI.HHZX.Report
{
    partial class frmPayRecordDetail
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPayMoney = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpCertificateDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCertificateID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxPayDepartment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPayType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbxCount = new WindowControls.HHZX.NumberBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nbxCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtPayMoney);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpCertificateDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCertificateID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxPayDepartment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxPayType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 344);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(106, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 27);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPayMoney
            // 
            this.txtPayMoney.Location = new System.Drawing.Point(106, 211);
            this.txtPayMoney.Name = "txtPayMoney";
            this.txtPayMoney.Size = new System.Drawing.Size(168, 21);
            this.txtPayMoney.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "支出金额：";
            // 
            // dtpCertificateDate
            // 
            this.dtpCertificateDate.Location = new System.Drawing.Point(106, 169);
            this.dtpCertificateDate.Name = "dtpCertificateDate";
            this.dtpCertificateDate.Size = new System.Drawing.Size(168, 21);
            this.dtpCertificateDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "凭证日期：";
            // 
            // txtCertificateID
            // 
            this.txtCertificateID.Location = new System.Drawing.Point(106, 129);
            this.txtCertificateID.Name = "txtCertificateID";
            this.txtCertificateID.Size = new System.Drawing.Size(168, 21);
            this.txtCertificateID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "凭证编号：";
            // 
            // cbxPayDepartment
            // 
            this.cbxPayDepartment.FormattingEnabled = true;
            this.cbxPayDepartment.Location = new System.Drawing.Point(106, 85);
            this.cbxPayDepartment.Name = "cbxPayDepartment";
            this.cbxPayDepartment.Size = new System.Drawing.Size(168, 20);
            this.cbxPayDepartment.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "支出部门：";
            // 
            // cbxPayType
            // 
            this.cbxPayType.FormattingEnabled = true;
            this.cbxPayType.Location = new System.Drawing.Point(106, 42);
            this.cbxPayType.Name = "cbxPayType";
            this.cbxPayType.Size = new System.Drawing.Size(168, 20);
            this.cbxPayType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "支出项目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "数量：";
            // 
            // nbxCount
            // 
            this.nbxCount.DecimalValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbxCount.Location = new System.Drawing.Point(106, 250);
            this.nbxCount.Name = "nbxCount";
            this.nbxCount.Size = new System.Drawing.Size(168, 21);
            this.nbxCount.TabIndex = 14;
            this.nbxCount.Text = "1";
            // 
            // frmPayRecordDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 342);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmPayRecordDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "支出登记";
            this.Text = "支出登记";
            this.Load += new System.EventHandler(this.frmPayRecordDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxPayDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxPayType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPayMoney;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpCertificateDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCertificateID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private WindowControls.HHZX.NumberBox nbxCount;
    }
}