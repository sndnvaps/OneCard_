namespace WindowUI.HHZX.UserCard
{
    partial class frmCardInfoDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.livHistoryRecord = new System.Windows.Forms.ListView();
            this.UserID = new System.Windows.Forms.ColumnHeader();
            this.ChaName = new System.Windows.Forms.ColumnHeader();
            this.PairTime = new System.Windows.Forms.ColumnHeader();
            this.ReturnTime = new System.Windows.Forms.ColumnHeader();
            this.lblUserStatuc = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblChaName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.lblCardID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(38, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡ID：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblUserStatuc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblChaName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblCardNo);
            this.groupBox1.Controls.Add(this.lblCardID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 453);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.livHistoryRecord);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox2.Location = new System.Drawing.Point(6, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 231);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "历史使用者";
            // 
            // livHistoryRecord
            // 
            this.livHistoryRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID,
            this.ChaName,
            this.PairTime,
            this.ReturnTime});
            this.livHistoryRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livHistoryRecord.Font = new System.Drawing.Font("宋体", 12F);
            this.livHistoryRecord.GridLines = true;
            this.livHistoryRecord.Location = new System.Drawing.Point(3, 17);
            this.livHistoryRecord.Name = "livHistoryRecord";
            this.livHistoryRecord.Size = new System.Drawing.Size(544, 211);
            this.livHistoryRecord.TabIndex = 0;
            this.livHistoryRecord.UseCompatibleStateImageBehavior = false;
            this.livHistoryRecord.View = System.Windows.Forms.View.Details;
            this.livHistoryRecord.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.livHistoryRecord_ColumnClick);
            // 
            // UserID
            // 
            this.UserID.Tag = "UserID";
            this.UserID.Text = "用户编号";
            this.UserID.Width = 100;
            // 
            // ChaName
            // 
            this.ChaName.Tag = "ChaName";
            this.ChaName.Text = "用户名称";
            this.ChaName.Width = 80;
            // 
            // PairTime
            // 
            this.PairTime.Tag = "PairTime";
            this.PairTime.Text = "发卡时间";
            this.PairTime.Width = 180;
            // 
            // ReturnTime
            // 
            this.ReturnTime.Tag = "ReturnTime";
            this.ReturnTime.Text = "退卡时间";
            this.ReturnTime.Width = 180;
            // 
            // lblUserStatuc
            // 
            this.lblUserStatuc.AutoSize = true;
            this.lblUserStatuc.BackColor = System.Drawing.Color.White;
            this.lblUserStatuc.Font = new System.Drawing.Font("宋体", 20F);
            this.lblUserStatuc.ForeColor = System.Drawing.Color.Red;
            this.lblUserStatuc.Location = new System.Drawing.Point(79, 142);
            this.lblUserStatuc.Name = "lblUserStatuc";
            this.lblUserStatuc.Size = new System.Drawing.Size(93, 27);
            this.lblUserStatuc.TabIndex = 5;
            this.lblUserStatuc.Text = "未使用";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(14, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "使用情况：";
            // 
            // lblChaName
            // 
            this.lblChaName.AutoSize = true;
            this.lblChaName.BackColor = System.Drawing.Color.White;
            this.lblChaName.Font = new System.Drawing.Font("宋体", 20F);
            this.lblChaName.ForeColor = System.Drawing.Color.Red;
            this.lblChaName.Location = new System.Drawing.Point(79, 103);
            this.lblChaName.Name = "lblChaName";
            this.lblChaName.Size = new System.Drawing.Size(39, 27);
            this.lblChaName.TabIndex = 3;
            this.lblChaName.Text = "无";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(2, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "当前使用者：";
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.BackColor = System.Drawing.Color.White;
            this.lblCardNo.Font = new System.Drawing.Font("宋体", 20F);
            this.lblCardNo.ForeColor = System.Drawing.Color.Red;
            this.lblCardNo.Location = new System.Drawing.Point(78, 63);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(26, 27);
            this.lblCardNo.TabIndex = 1;
            this.lblCardNo.Text = "0";
            // 
            // lblCardID
            // 
            this.lblCardID.AutoSize = true;
            this.lblCardID.BackColor = System.Drawing.Color.White;
            this.lblCardID.Font = new System.Drawing.Font("宋体", 20F);
            this.lblCardID.ForeColor = System.Drawing.Color.Red;
            this.lblCardID.Location = new System.Drawing.Point(78, 23);
            this.lblCardID.Name = "lblCardID";
            this.lblCardID.Size = new System.Drawing.Size(26, 27);
            this.lblCardID.TabIndex = 1;
            this.lblCardID.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前卡号：";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Font = new System.Drawing.Font("宋体", 9F);
            this.button2.Location = new System.Drawing.Point(412, 471);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 21);
            this.button2.TabIndex = 4;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("宋体", 9F);
            this.button3.Location = new System.Drawing.Point(499, 471);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 21);
            this.button3.TabIndex = 5;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // frmCardInfoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 504);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCardInfoDetail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "卡资料";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblUserStatuc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblChaName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCardID;
        private System.Windows.Forms.ListView livHistoryRecord;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader ChaName;
        private System.Windows.Forms.ColumnHeader PairTime;
        private System.Windows.Forms.ColumnHeader ReturnTime;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.Label label2;
    }
}