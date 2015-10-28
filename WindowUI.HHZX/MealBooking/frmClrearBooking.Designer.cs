namespace WindowUI.HHZX.MealBooking
{
    partial class frmClrearBooking
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
            this.btnClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lvMachines = new System.Windows.Forms.ListView();
            this.cmm_cMacName = new System.Windows.Forms.ColumnHeader();
            this.cmm_iMacNo = new System.Windows.Forms.ColumnHeader();
            this.cmm_cIPAddr = new System.Windows.Forms.ColumnHeader();
            this.isClear = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn = new System.Windows.Forms.Button();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.pnlPro = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pgbPro = new System.Windows.Forms.ProgressBar();
            this.bgwClear = new System.ComponentModel.BackgroundWorker();
            this.cmm_iPort = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlPro.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(327, 17);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 44);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "清除限制";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowUI.HHZX.Properties.Resources.Warning;
            this.pictureBox1.Location = new System.Drawing.Point(1, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Red;
            this.richTextBox1.Location = new System.Drawing.Point(66, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(228, 61);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "清除名单限制会消除消费机上的黑名单，开放所有卡用户的消费限制，使用此功能时请慎重！";
            // 
            // lvMachines
            // 
            this.lvMachines.AllowDrop = true;
            this.lvMachines.CheckBoxes = true;
            this.lvMachines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cmm_cMacName,
            this.cmm_iMacNo,
            this.cmm_cIPAddr,
            this.isClear,
            this.cmm_iPort});
            this.lvMachines.Font = new System.Drawing.Font("宋体", 12F);
            this.lvMachines.FullRowSelect = true;
            this.lvMachines.Location = new System.Drawing.Point(5, 42);
            this.lvMachines.Name = "lvMachines";
            this.lvMachines.Size = new System.Drawing.Size(427, 319);
            this.lvMachines.TabIndex = 4;
            this.lvMachines.UseCompatibleStateImageBehavior = false;
            this.lvMachines.View = System.Windows.Forms.View.Details;
            // 
            // cmm_cMacName
            // 
            this.cmm_cMacName.Tag = "cmm_cMacName";
            this.cmm_cMacName.Text = "消费机名称";
            this.cmm_cMacName.Width = 150;
            // 
            // cmm_iMacNo
            // 
            this.cmm_iMacNo.Tag = "cmm_iMacNo";
            this.cmm_iMacNo.Text = "机号";
            this.cmm_iMacNo.Width = 49;
            // 
            // cmm_cIPAddr
            // 
            this.cmm_cIPAddr.Tag = "cmm_cIPAddr";
            this.cmm_cIPAddr.Text = "IP地址";
            this.cmm_cIPAddr.Width = 140;
            // 
            // isClear
            // 
            this.isClear.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn);
            this.groupBox1.Controls.Add(this.chbSelectAll);
            this.groupBox1.Controls.Add(this.lvMachines);
            this.groupBox1.Location = new System.Drawing.Point(1, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 366);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消费机";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(62, 15);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(52, 23);
            this.btn.TabIndex = 6;
            this.btn.Text = "反选";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(13, 20);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(48, 16);
            this.chbSelectAll.TabIndex = 5;
            this.chbSelectAll.Text = "全选";
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // pnlPro
            // 
            this.pnlPro.Controls.Add(this.lblMessage);
            this.pnlPro.Controls.Add(this.btnCancel);
            this.pnlPro.Controls.Add(this.pgbPro);
            this.pnlPro.Enabled = false;
            this.pnlPro.Location = new System.Drawing.Point(1, 447);
            this.pnlPro.Name = "pnlPro";
            this.pnlPro.Size = new System.Drawing.Size(438, 69);
            this.pnlPro.TabIndex = 6;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblMessage.Location = new System.Drawing.Point(10, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 14);
            this.lblMessage.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(357, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pgbPro
            // 
            this.pgbPro.Location = new System.Drawing.Point(5, 38);
            this.pgbPro.Name = "pgbPro";
            this.pgbPro.Size = new System.Drawing.Size(348, 23);
            this.pgbPro.TabIndex = 0;
            // 
            // bgwClear
            // 
            this.bgwClear.WorkerReportsProgress = true;
            this.bgwClear.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwClear_DoWork);
            this.bgwClear.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwClear_ProgressChanged);
            // 
            // cmm_iPort
            // 
            this.cmm_iPort.Tag = "cmm_iPort";
            this.cmm_iPort.Text = "端口";
            this.cmm_iPort.Width = 0;
            // 
            // frmClrearBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 519);
            this.Controls.Add(this.pnlPro);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClear);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmClrearBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清除消费名单限制";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlPro.ResumeLayout(false);
            this.pnlPro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListView lvMachines;
        private System.Windows.Forms.ColumnHeader cmm_cMacName;
        private System.Windows.Forms.ColumnHeader cmm_iMacNo;
        private System.Windows.Forms.ColumnHeader cmm_cIPAddr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader isClear;
        private System.Windows.Forms.Panel pnlPro;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar pgbPro;
        private System.ComponentModel.BackgroundWorker bgwClear;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.ColumnHeader cmm_iPort;
    }
}