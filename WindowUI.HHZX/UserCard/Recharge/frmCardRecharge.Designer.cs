namespace WindowUI.HHZX.UserCard.Recharge
{
    partial class frmCardRecharge
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
            this.gbxMain = new System.Windows.Forms.GroupBox();
            this.btnRechargeOffline = new System.Windows.Forms.Button();
            this.btnRechargeRealtime = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gbxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMain
            // 
            this.gbxMain.Controls.Add(this.btnRechargeOffline);
            this.gbxMain.Controls.Add(this.btnRechargeRealtime);
            this.gbxMain.Location = new System.Drawing.Point(221, 168);
            this.gbxMain.Name = "gbxMain";
            this.gbxMain.Size = new System.Drawing.Size(342, 176);
            this.gbxMain.TabIndex = 5;
            this.gbxMain.TabStop = false;
            this.gbxMain.Text = "请选择充值方式";
            // 
            // btnRechargeOffline
            // 
            this.btnRechargeOffline.Font = new System.Drawing.Font("SimSun", 30F);
            this.btnRechargeOffline.Location = new System.Drawing.Point(20, 91);
            this.btnRechargeOffline.Name = "btnRechargeOffline";
            this.btnRechargeOffline.Size = new System.Drawing.Size(302, 64);
            this.btnRechargeOffline.TabIndex = 1;
            this.btnRechargeOffline.Text = "转账充值";
            this.btnRechargeOffline.UseVisualStyleBackColor = true;
            this.btnRechargeOffline.Click += new System.EventHandler(this.btnRechargeOffline_Click);
            // 
            // btnRechargeRealtime
            // 
            this.btnRechargeRealtime.Font = new System.Drawing.Font("SimSun", 30F);
            this.btnRechargeRealtime.Location = new System.Drawing.Point(20, 21);
            this.btnRechargeRealtime.Name = "btnRechargeRealtime";
            this.btnRechargeRealtime.Size = new System.Drawing.Size(302, 64);
            this.btnRechargeRealtime.TabIndex = 0;
            this.btnRechargeRealtime.Text = "实时充值";
            this.btnRechargeRealtime.UseVisualStyleBackColor = true;
            this.btnRechargeRealtime.Click += new System.EventHandler(this.btnRechargeRealtime_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(697, 477);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // frmCardRecharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gbxMain);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 260);
            this.Name = "frmCardRecharge";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "充值";
            this.Text = "充值";
            this.SizeChanged += new System.EventHandler(this.frmCardRecharge_SizeChanged);
            this.gbxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMain;
        private System.Windows.Forms.Button btnRechargeOffline;
        private System.Windows.Forms.Button btnRechargeRealtime;
        private System.Windows.Forms.Button button3;

    }
}