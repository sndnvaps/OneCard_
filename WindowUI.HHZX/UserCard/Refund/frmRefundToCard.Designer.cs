namespace WindowUI.HHZX.UserCard.Refund
{
    partial class frmRefundToCard
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
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReFundOffline = new System.Windows.Forms.Button();
            this.btnRefundRealtime = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(279, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReFundOffline);
            this.groupBox1.Controls.Add(this.btnRefundRealtime);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 176);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择卡退款方式";
            // 
            // btnReFundOffline
            // 
            this.btnReFundOffline.Font = new System.Drawing.Font("SimSun", 30F);
            this.btnReFundOffline.Location = new System.Drawing.Point(20, 91);
            this.btnReFundOffline.Name = "btnReFundOffline";
            this.btnReFundOffline.Size = new System.Drawing.Size(302, 64);
            this.btnReFundOffline.TabIndex = 1;
            this.btnReFundOffline.Text = "转账退款";
            this.btnReFundOffline.UseVisualStyleBackColor = true;
            this.btnReFundOffline.Click += new System.EventHandler(this.btnReFundOffline_Click);
            // 
            // btnRefundRealtime
            // 
            this.btnRefundRealtime.Font = new System.Drawing.Font("SimSun", 30F);
            this.btnRefundRealtime.Location = new System.Drawing.Point(20, 21);
            this.btnRefundRealtime.Name = "btnRefundRealtime";
            this.btnRefundRealtime.Size = new System.Drawing.Size(302, 64);
            this.btnRefundRealtime.TabIndex = 0;
            this.btnRefundRealtime.Text = "实时退款";
            this.btnRefundRealtime.UseVisualStyleBackColor = true;
            this.btnRefundRealtime.Click += new System.EventHandler(this.btnRefundRealtime_Click);
            // 
            // frmRefundToCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 222);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 260);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 260);
            this.Name = "frmRefundToCard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "卡退款";
            this.Tag = "卡退款";
            this.Text = "卡退款";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReFundOffline;
        private System.Windows.Forms.Button btnRefundRealtime;
    }
}