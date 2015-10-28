namespace WindowUI.HHZX.UserCard
{
    partial class frmAddNewCard
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
            this.components = new System.ComponentModel.Container();
            this.ttEnter = new System.Windows.Forms.ToolTip(this.components);
            this.btnRead = new System.Windows.Forms.Button();
            this.ttCtrlEnter = new System.Windows.Forms.ToolTip(this.components);
            this.pnlContent = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblReadMessage = new System.Windows.Forms.Label();
            this.pnlMore = new System.Windows.Forms.Panel();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.pnlSingle = new System.Windows.Forms.Panel();
            this.btnTempAdd = new System.Windows.Forms.Button();
            this.rdbMore = new System.Windows.Forms.RadioButton();
            this.rdbSingle = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lvTempCardInfos = new System.Windows.Forms.ListView();
            this.index = new System.Windows.Forms.ColumnHeader();
            this.cardID = new System.Windows.Forms.ColumnHeader();
            this.labCardID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirmNewCard = new System.Windows.Forms.Button();
            this.btnReaderCon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bgwAutoReadCard = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlContent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlMore.SuspendLayout();
            this.pnlSingle.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttEnter
            // 
            this.ttEnter.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttEnter.ToolTipTitle = "提示";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(2, 3);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "读卡";
            this.ttEnter.SetToolTip(this.btnRead, "快捷键 Enter");
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // ttCtrlEnter
            // 
            this.ttCtrlEnter.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttCtrlEnter.ToolTipTitle = "提示";
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.groupBox1);
            this.pnlContent.Enabled = false;
            this.pnlContent.Location = new System.Drawing.Point(12, 24);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(534, 505);
            this.pnlContent.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pnlMore);
            this.groupBox1.Controls.Add(this.pnlSingle);
            this.groupBox1.Controls.Add(this.rdbMore);
            this.groupBox1.Controls.Add(this.rdbSingle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lvTempCardInfos);
            this.groupBox1.Controls.Add(this.labCardID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 494);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "卡录入";
            // 
            // lblReadMessage
            // 
            this.lblReadMessage.AutoSize = true;
            this.lblReadMessage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadMessage.ForeColor = System.Drawing.Color.Red;
            this.lblReadMessage.Location = new System.Drawing.Point(59, 3);
            this.lblReadMessage.Name = "lblReadMessage";
            this.lblReadMessage.Size = new System.Drawing.Size(42, 20);
            this.lblReadMessage.TabIndex = 18;
            this.lblReadMessage.Text = "...";
            this.lblReadMessage.Visible = false;
            // 
            // pnlMore
            // 
            this.pnlMore.Controls.Add(this.btnEnd);
            this.pnlMore.Controls.Add(this.btnBegin);
            this.pnlMore.Enabled = false;
            this.pnlMore.Location = new System.Drawing.Point(221, 96);
            this.pnlMore.Name = "pnlMore";
            this.pnlMore.Size = new System.Drawing.Size(180, 28);
            this.pnlMore.TabIndex = 17;
            // 
            // btnEnd
            // 
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(84, 2);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 14;
            this.btnEnd.Text = "结束";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(2, 2);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 13;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // pnlSingle
            // 
            this.pnlSingle.Controls.Add(this.btnRead);
            this.pnlSingle.Controls.Add(this.btnTempAdd);
            this.pnlSingle.Location = new System.Drawing.Point(221, 66);
            this.pnlSingle.Name = "pnlSingle";
            this.pnlSingle.Size = new System.Drawing.Size(180, 28);
            this.pnlSingle.TabIndex = 16;
            // 
            // btnTempAdd
            // 
            this.btnTempAdd.Location = new System.Drawing.Point(85, 3);
            this.btnTempAdd.Name = "btnTempAdd";
            this.btnTempAdd.Size = new System.Drawing.Size(75, 23);
            this.btnTempAdd.TabIndex = 10;
            this.btnTempAdd.Text = "添加";
            this.btnTempAdd.UseVisualStyleBackColor = true;
            this.btnTempAdd.Click += new System.EventHandler(this.btnTempAdd_Click);
            // 
            // rdbMore
            // 
            this.rdbMore.AutoSize = true;
            this.rdbMore.Location = new System.Drawing.Point(147, 101);
            this.rdbMore.Name = "rdbMore";
            this.rdbMore.Size = new System.Drawing.Size(71, 16);
            this.rdbMore.TabIndex = 15;
            this.rdbMore.Text = "批量录入";
            this.rdbMore.UseVisualStyleBackColor = true;
            this.rdbMore.CheckedChanged += new System.EventHandler(this.rdbChange_CheckedChanged);
            // 
            // rdbSingle
            // 
            this.rdbSingle.AutoSize = true;
            this.rdbSingle.Checked = true;
            this.rdbSingle.Location = new System.Drawing.Point(148, 73);
            this.rdbSingle.Name = "rdbSingle";
            this.rdbSingle.Size = new System.Drawing.Size(71, 16);
            this.rdbSingle.TabIndex = 15;
            this.rdbSingle.TabStop = true;
            this.rdbSingle.Text = "单卡录入";
            this.rdbSingle.UseVisualStyleBackColor = true;
            this.rdbSingle.CheckedChanged += new System.EventHandler(this.rdbChange_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "临时卡信息：";
            // 
            // lvTempCardInfos
            // 
            this.lvTempCardInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTempCardInfos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.cardID});
            this.lvTempCardInfos.Font = new System.Drawing.Font("宋体", 12F);
            this.lvTempCardInfos.FullRowSelect = true;
            this.lvTempCardInfos.GridLines = true;
            this.lvTempCardInfos.Location = new System.Drawing.Point(6, 155);
            this.lvTempCardInfos.Name = "lvTempCardInfos";
            this.lvTempCardInfos.Size = new System.Drawing.Size(519, 330);
            this.lvTempCardInfos.TabIndex = 1;
            this.lvTempCardInfos.UseCompatibleStateImageBehavior = false;
            this.lvTempCardInfos.View = System.Windows.Forms.View.Details;
            this.lvTempCardInfos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvTempCardInfos_ColumnClick);
            // 
            // index
            // 
            this.index.Tag = "index";
            this.index.Text = "序号";
            // 
            // cardID
            // 
            this.cardID.Tag = "cardID";
            this.cardID.Text = "卡ID";
            this.cardID.Width = 300;
            // 
            // labCardID
            // 
            this.labCardID.BackColor = System.Drawing.Color.White;
            this.labCardID.Font = new System.Drawing.Font("宋体", 20F);
            this.labCardID.ForeColor = System.Drawing.Color.Red;
            this.labCardID.Location = new System.Drawing.Point(51, 15);
            this.labCardID.Name = "labCardID";
            this.labCardID.Size = new System.Drawing.Size(474, 37);
            this.labCardID.TabIndex = 1;
            this.labCardID.Text = "未读卡";
            this.labCardID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID：";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.Location = new System.Drawing.Point(306, 529);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 16;
            this.btnClearAll.Text = "清空临时表";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(468, 529);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirmNewCard
            // 
            this.btnConfirmNewCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmNewCard.Enabled = false;
            this.btnConfirmNewCard.Location = new System.Drawing.Point(387, 529);
            this.btnConfirmNewCard.Name = "btnConfirmNewCard";
            this.btnConfirmNewCard.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmNewCard.TabIndex = 15;
            this.btnConfirmNewCard.Text = "确定录入";
            this.btnConfirmNewCard.UseVisualStyleBackColor = true;
            this.btnConfirmNewCard.Click += new System.EventHandler(this.btnConfirmNewCard_Click);
            // 
            // btnReaderCon
            // 
            this.btnReaderCon.Location = new System.Drawing.Point(435, 0);
            this.btnReaderCon.Name = "btnReaderCon";
            this.btnReaderCon.Size = new System.Drawing.Size(110, 23);
            this.btnReaderCon.TabIndex = 21;
            this.btnReaderCon.UseVisualStyleBackColor = true;
            this.btnReaderCon.Click += new System.EventHandler(this.btnReaderCon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "读卡器：";
            // 
            // bgwAutoReadCard
            // 
            this.bgwAutoReadCard.WorkerReportsProgress = true;
            this.bgwAutoReadCard.WorkerSupportsCancellation = true;
            this.bgwAutoReadCard.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAutoReadCard_DoWork);
            this.bgwAutoReadCard.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwAutoReadCard_ProgressChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmAddNewCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 560);
            this.Controls.Add(this.lblReadMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReaderCon);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmNewCard);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "白卡录入";
            this.pnlContent.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMore.ResumeLayout(false);
            this.pnlSingle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip ttEnter;
        private System.Windows.Forms.ToolTip ttCtrlEnter;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnTempAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvTempCardInfos;
        private System.Windows.Forms.ColumnHeader cardID;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label labCardID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmNewCard;
        private System.Windows.Forms.Button btnReaderCon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbMore;
        private System.Windows.Forms.RadioButton rdbSingle;
        private System.Windows.Forms.Panel pnlSingle;
        private System.Windows.Forms.Panel pnlMore;
        private System.Windows.Forms.ColumnHeader index;
        private System.ComponentModel.BackgroundWorker bgwAutoReadCard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblReadMessage;
    }
}