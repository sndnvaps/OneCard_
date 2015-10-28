namespace WindowUI.HHZX.SystemMaster
{
    partial class frmChangeUserPwd
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
            this.labWarningNewPwdConfirm = new System.Windows.Forms.Label();
            this.labWarningNewPwd = new System.Windows.Forms.Label();
            this.tbxNewPwdConfirm = new System.Windows.Forms.TextBox();
            this.tbxNewPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labWarningNewPwdConfirm);
            this.groupBox1.Controls.Add(this.labWarningNewPwd);
            this.groupBox1.Controls.Add(this.tbxNewPwdConfirm);
            this.groupBox1.Controls.Add(this.tbxNewPwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labWarningNewPwdConfirm
            // 
            this.labWarningNewPwdConfirm.AutoSize = true;
            this.labWarningNewPwdConfirm.ForeColor = System.Drawing.Color.Red;
            this.labWarningNewPwdConfirm.Location = new System.Drawing.Point(281, 57);
            this.labWarningNewPwdConfirm.Name = "labWarningNewPwdConfirm";
            this.labWarningNewPwdConfirm.Size = new System.Drawing.Size(11, 12);
            this.labWarningNewPwdConfirm.TabIndex = 5;
            this.labWarningNewPwdConfirm.Text = "*";
            this.labWarningNewPwdConfirm.Visible = false;
            // 
            // labWarningNewPwd
            // 
            this.labWarningNewPwd.AutoSize = true;
            this.labWarningNewPwd.ForeColor = System.Drawing.Color.Red;
            this.labWarningNewPwd.Location = new System.Drawing.Point(281, 24);
            this.labWarningNewPwd.Name = "labWarningNewPwd";
            this.labWarningNewPwd.Size = new System.Drawing.Size(11, 12);
            this.labWarningNewPwd.TabIndex = 4;
            this.labWarningNewPwd.Text = "*";
            this.labWarningNewPwd.Visible = false;
            // 
            // tbxNewPwdConfirm
            // 
            this.tbxNewPwdConfirm.Location = new System.Drawing.Point(107, 54);
            this.tbxNewPwdConfirm.Name = "tbxNewPwdConfirm";
            this.tbxNewPwdConfirm.PasswordChar = '●';
            this.tbxNewPwdConfirm.Size = new System.Drawing.Size(171, 21);
            this.tbxNewPwdConfirm.TabIndex = 3;
            this.tbxNewPwdConfirm.TextChanged += new System.EventHandler(this.tbxNewPwdConfirm_TextChanged);
            // 
            // tbxNewPwd
            // 
            this.tbxNewPwd.Location = new System.Drawing.Point(107, 21);
            this.tbxNewPwd.Name = "tbxNewPwd";
            this.tbxNewPwd.PasswordChar = '●';
            this.tbxNewPwd.Size = new System.Drawing.Size(171, 21);
            this.tbxNewPwd.TabIndex = 2;
            this.tbxNewPwd.TextChanged += new System.EventHandler(this.tbxNewPwd_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "确认密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "新 密 码：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(154, 103);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确 认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(235, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmChangeUserPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 133);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangeUserPwd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxNewPwdConfirm;
        private System.Windows.Forms.TextBox tbxNewPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labWarningNewPwdConfirm;
        private System.Windows.Forms.Label labWarningNewPwd;
    }
}