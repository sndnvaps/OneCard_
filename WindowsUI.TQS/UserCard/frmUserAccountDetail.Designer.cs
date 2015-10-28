namespace WindowsUI.TQS.UserCard
{
    partial class frmUserAccountDetail
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
            this.label3 = new System.Windows.Forms.Label();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.lblChaName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvList = new System.Windows.Forms.ListView();
            this.index = new System.Windows.Forms.ColumnHeader();
            this.times = new System.Windows.Forms.ColumnHeader();
            this.type = new System.Windows.Forms.ColumnHeader();
            this.cost = new System.Windows.Forms.ColumnHeader();
            this.mealTime = new System.Windows.Forms.ColumnHeader();
            this.CostType = new System.Windows.Forms.ColumnHeader();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRecordAmount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(274, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "卡号：";
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCardNo.ForeColor = System.Drawing.Color.Blue;
            this.lblCardNo.Location = new System.Drawing.Point(338, 13);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(42, 22);
            this.lblCardNo.TabIndex = 5;
            this.lblCardNo.Text = "。。";
            // 
            // lblChaName
            // 
            this.lblChaName.AutoSize = true;
            this.lblChaName.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChaName.ForeColor = System.Drawing.Color.Blue;
            this.lblChaName.Location = new System.Drawing.Point(117, 13);
            this.lblChaName.Name = "lblChaName";
            this.lblChaName.Size = new System.Drawing.Size(42, 22);
            this.lblChaName.TabIndex = 2;
            this.lblChaName.Text = "。。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(35, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名：";
            // 
            // lvList
            // 
            this.lvList.BackColor = System.Drawing.SystemColors.Window;
            this.lvList.CausesValidation = false;
            this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.times,
            this.type,
            this.cost,
            this.mealTime,
            this.CostType});
            this.lvList.Font = new System.Drawing.Font("YouYuan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvList.GridLines = true;
            this.lvList.Location = new System.Drawing.Point(5, 113);
            this.lvList.MultiSelect = false;
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(662, 534);
            this.lvList.TabIndex = 6;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            // 
            // index
            // 
            this.index.Tag = "index";
            this.index.Text = "序号";
            this.index.Width = 55;
            // 
            // times
            // 
            this.times.Tag = "times";
            this.times.Text = "结算时间";
            this.times.Width = 100;
            // 
            // type
            // 
            this.type.Tag = "type";
            this.type.Text = "消费类型";
            this.type.Width = 140;
            // 
            // cost
            // 
            this.cost.Tag = "cost";
            this.cost.Text = "金额(元)";
            this.cost.Width = 80;
            // 
            // mealTime
            // 
            this.mealTime.Tag = "mealTime";
            this.mealTime.Text = "消费时间";
            this.mealTime.Width = 170;
            // 
            // CostType
            // 
            this.CostType.Tag = "CostType";
            this.CostType.Text = "扣费类别";
            this.CostType.Width = 100;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CalendarFont = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDateFrom.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDateFrom.Location = new System.Drawing.Point(124, 48);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(157, 26);
            this.dtpDateFrom.TabIndex = 7;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CalendarFont = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Bold);
            this.dtpDateTo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDateTo.Location = new System.Drawing.Point(325, 48);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(149, 26);
            this.dtpDateTo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(19, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "查询日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(292, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "至";
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(491, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 35);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadCard.Location = new System.Drawing.Point(578, 16);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(75, 35);
            this.btnReadCard.TabIndex = 8;
            this.btnReadCard.Text = "刷卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Visible = false;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(267, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "记录数：";
            // 
            // lblRecordAmount
            // 
            this.lblRecordAmount.AutoSize = true;
            this.lblRecordAmount.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblRecordAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblRecordAmount.Location = new System.Drawing.Point(328, 91);
            this.lblRecordAmount.Name = "lblRecordAmount";
            this.lblRecordAmount.Size = new System.Drawing.Size(18, 19);
            this.lblRecordAmount.TabIndex = 3;
            this.lblRecordAmount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPage);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnReadCard);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.lblRecordAmount);
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Controls.Add(this.lblChaName);
            this.panel1.Controls.Add(this.lvList);
            this.panel1.Controls.Add(this.lblCardNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 670);
            this.panel1.TabIndex = 9;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPage.ForeColor = System.Drawing.Color.Blue;
            this.lblPage.Location = new System.Drawing.Point(419, 91);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(34, 19);
            this.lblPage.TabIndex = 24;
            this.lblPage.Text = "0/0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(365, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "当前页";
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.btnUp.Location = new System.Drawing.Point(468, 77);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(90, 30);
            this.btnUp.TabIndex = 22;
            this.btnUp.Text = "上一页";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.btnDown.Location = new System.Drawing.Point(564, 77);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(90, 30);
            this.btnDown.TabIndex = 21;
            this.btnDown.Text = "下一页";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // frmUserAccountDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 650);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserAccountDetail";
            this.Text = "消费记录查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.Label lblChaName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvList;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ColumnHeader times;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader cost;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRecordAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader mealTime;
        private System.Windows.Forms.ColumnHeader CostType;
    }
}