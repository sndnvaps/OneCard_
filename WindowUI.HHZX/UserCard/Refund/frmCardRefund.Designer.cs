namespace WindowUI.HHZX.UserCard.Refund
{
    partial class frmCardRefund
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
            this.btnRefundToCard = new System.Windows.Forms.Button();
            this.btnRefundCash = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefundToCard);
            this.groupBox1.Controls.Add(this.btnRefundCash);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 176);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择退款方式";
            // 
            // btnRefundToCard
            // 
            this.btnRefundToCard.Font = new System.Drawing.Font("SimSun", 30F);
            this.btnRefundToCard.Location = new System.Drawing.Point(20, 91);
            this.btnRefundToCard.Name = "btnRefundToCard";
            this.btnRefundToCard.Size = new System.Drawing.Size(302, 64);
            this.btnRefundToCard.TabIndex = 1;
            this.btnRefundToCard.Text = "卡退款";
            this.btnRefundToCard.UseVisualStyleBackColor = true;
            this.btnRefundToCard.Click += new System.EventHandler(this.btnRefundToCard_Click);
            // 
            // btnRefundCash
            // 
            this.btnRefundCash.Font = new System.Drawing.Font("SimSun", 30F);
            this.btnRefundCash.Location = new System.Drawing.Point(20, 21);
            this.btnRefundCash.Name = "btnRefundCash";
            this.btnRefundCash.Size = new System.Drawing.Size(302, 64);
            this.btnRefundCash.TabIndex = 0;
            this.btnRefundCash.Text = "现金退款";
            this.btnRefundCash.UseVisualStyleBackColor = true;
            this.btnRefundCash.Click += new System.EventHandler(this.btnRefundCash_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(279, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // frmCardRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 222);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCardRefund";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "退款";
            this.Text = "退款";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefundToCard;
        private System.Windows.Forms.Button btnRefundCash;
        private System.Windows.Forms.Button button3;

    }
}