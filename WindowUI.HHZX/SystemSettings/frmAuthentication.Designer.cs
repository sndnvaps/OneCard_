namespace WindowUI.HHZX.SystemSettings
{
    partial class frmAuthentication
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.labUDogMsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.plnCode = new System.Windows.Forms.Panel();
            this.labCode = new System.Windows.Forms.Label();
            this.btnReadUKeyCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPayPwd = new System.Windows.Forms.Panel();
            this.tbxConfirmPayPwd = new System.Windows.Forms.TextBox();
            this.btnWritePayPwd = new System.Windows.Forms.Button();
            this.tbxPayPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plnCode.SuspendLayout();
            this.pnlPayPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.labUDogMsg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索U盾:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(117, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearchUDog_Click);
            // 
            // labUDogMsg
            // 
            this.labUDogMsg.BackColor = System.Drawing.Color.White;
            this.labUDogMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labUDogMsg.Font = new System.Drawing.Font("SimSun", 25F);
            this.labUDogMsg.Location = new System.Drawing.Point(10, 17);
            this.labUDogMsg.Name = "labUDogMsg";
            this.labUDogMsg.Size = new System.Drawing.Size(289, 42);
            this.labUDogMsg.TabIndex = 0;
            this.labUDogMsg.Text = "等待U盾接入";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 26);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(117, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // plnCode
            // 
            this.plnCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plnCode.Controls.Add(this.labCode);
            this.plnCode.Controls.Add(this.btnReadUKeyCode);
            this.plnCode.Controls.Add(this.label1);
            this.plnCode.Enabled = false;
            this.plnCode.Location = new System.Drawing.Point(0, 98);
            this.plnCode.Name = "plnCode";
            this.plnCode.Size = new System.Drawing.Size(309, 72);
            this.plnCode.TabIndex = 2;
            // 
            // labCode
            // 
            this.labCode.AutoSize = true;
            this.labCode.BackColor = System.Drawing.Color.White;
            this.labCode.Location = new System.Drawing.Point(81, 15);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(0, 12);
            this.labCode.TabIndex = 3;
            // 
            // btnReadUKeyCode
            // 
            this.btnReadUKeyCode.Location = new System.Drawing.Point(222, 39);
            this.btnReadUKeyCode.Name = "btnReadUKeyCode";
            this.btnReadUKeyCode.Size = new System.Drawing.Size(75, 23);
            this.btnReadUKeyCode.TabIndex = 2;
            this.btnReadUKeyCode.Text = "读取";
            this.btnReadUKeyCode.UseVisualStyleBackColor = true;
            this.btnReadUKeyCode.Click += new System.EventHandler(this.btnReadUKeyCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "U盾识别码:";
            // 
            // pnlPayPwd
            // 
            this.pnlPayPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPayPwd.Controls.Add(this.tbxConfirmPayPwd);
            this.pnlPayPwd.Controls.Add(this.btnWritePayPwd);
            this.pnlPayPwd.Controls.Add(this.tbxPayPwd);
            this.pnlPayPwd.Controls.Add(this.label2);
            this.pnlPayPwd.Enabled = false;
            this.pnlPayPwd.Location = new System.Drawing.Point(0, 176);
            this.pnlPayPwd.Name = "pnlPayPwd";
            this.pnlPayPwd.Size = new System.Drawing.Size(309, 100);
            this.pnlPayPwd.TabIndex = 3;
            // 
            // tbxConfirmPayPwd
            // 
            this.tbxConfirmPayPwd.Location = new System.Drawing.Point(82, 36);
            this.tbxConfirmPayPwd.Name = "tbxConfirmPayPwd";
            this.tbxConfirmPayPwd.PasswordChar = '●';
            this.tbxConfirmPayPwd.Size = new System.Drawing.Size(216, 21);
            this.tbxConfirmPayPwd.TabIndex = 12;
            // 
            // btnWritePayPwd
            // 
            this.btnWritePayPwd.Location = new System.Drawing.Point(223, 69);
            this.btnWritePayPwd.Name = "btnWritePayPwd";
            this.btnWritePayPwd.Size = new System.Drawing.Size(75, 23);
            this.btnWritePayPwd.TabIndex = 11;
            this.btnWritePayPwd.Text = "设置";
            this.btnWritePayPwd.UseVisualStyleBackColor = true;
            this.btnWritePayPwd.Click += new System.EventHandler(this.btnWritePayPwd_Click);
            // 
            // tbxPayPwd
            // 
            this.tbxPayPwd.Location = new System.Drawing.Point(82, 9);
            this.tbxPayPwd.Name = "tbxPayPwd";
            this.tbxPayPwd.PasswordChar = '●';
            this.tbxPayPwd.Size = new System.Drawing.Size(216, 21);
            this.tbxPayPwd.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "消费密码:";
            // 
            // frmAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 316);
            this.Controls.Add(this.pnlPayPwd);
            this.Controls.Add(this.plnCode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuthentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "U盾参数设置";
            this.Text = "U盾参数设置";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.plnCode.ResumeLayout(false);
            this.plnCode.PerformLayout();
            this.pnlPayPwd.ResumeLayout(false);
            this.pnlPayPwd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labUDogMsg;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel plnCode;
        private System.Windows.Forms.Button btnReadUKeyCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPayPwd;
        private System.Windows.Forms.TextBox tbxConfirmPayPwd;
        private System.Windows.Forms.Button btnWritePayPwd;
        private System.Windows.Forms.TextBox tbxPayPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labCode;
    }
}