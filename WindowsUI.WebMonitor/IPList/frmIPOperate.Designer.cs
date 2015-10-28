namespace WindowsUI.WebMonitor.IPList
{
    partial class frmIPOperate
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
            this.lvwIPList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.utbTool = new WindowsUI.WebMonitor.WinUI.UserToolBar();
            this.SuspendLayout();
            // 
            // lvwIPList
            // 
            this.lvwIPList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwIPList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwIPList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwIPList.Font = new System.Drawing.Font("宋体", 11F);
            this.lvwIPList.FullRowSelect = true;
            this.lvwIPList.GridLines = true;
            this.lvwIPList.Location = new System.Drawing.Point(1, 23);
            this.lvwIPList.MultiSelect = false;
            this.lvwIPList.Name = "lvwIPList";
            this.lvwIPList.Size = new System.Drawing.Size(591, 349);
            this.lvwIPList.TabIndex = 2;
            this.lvwIPList.UseCompatibleStateImageBehavior = false;
            this.lvwIPList.View = System.Windows.Forms.View.Details;
            this.lvwIPList.SelectedIndexChanged += new System.EventHandler(this.lvwIPList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Index";
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "Name";
            this.columnHeader2.Text = "机名";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "Number";
            this.columnHeader3.Text = "机号";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "IP";
            this.columnHeader4.Text = "IP";
            this.columnHeader4.Width = 200;
            // 
            // utbTool
            // 
            this.utbTool.AutoSetStatus = true;
            this.utbTool.BtnCancelEnabled = false;
            this.utbTool.BtnCancelVisible = false;
            this.utbTool.BtnCardIssuanceEnabled = false;
            this.utbTool.BtnCardIssuanceVisible = false;
            this.utbTool.BtnCardMissingEnabled = false;
            this.utbTool.BtnCardMissingVisible = false;
            this.utbTool.BtnCardRecoveryEnabled = false;
            this.utbTool.BtnCardRecoveryVisible = false;
            this.utbTool.BtnCardReturnEnabled = false;
            this.utbTool.BtnCardReturnVisible = false;
            this.utbTool.BtnCardScrapEnabled = false;
            this.utbTool.BtnCardScrapVisible = false;
            this.utbTool.BtnDataExportEnabled = false;
            this.utbTool.BtnDataExportVisible = false;
            this.utbTool.BtnDataInputEnabled = false;
            this.utbTool.BtnDataInputVisible = false;
            this.utbTool.BtnDeleteEnabled = false;
            this.utbTool.BtnDeleteVisible = true;
            this.utbTool.BtnExpCusDataEnabled = true;
            this.utbTool.BtnExpCusDataVisible = false;
            this.utbTool.BtnExportCardUserPhotoEnabled = false;
            this.utbTool.BtnExportCardUserPhotoVisible = false;
            this.utbTool.btnExportDataEnabled = false;
            this.utbTool.btnExportDataVisible = false;
            this.utbTool.btnExportTempEnabled = false;
            this.utbTool.BtnExportTemplateEnabled = false;
            this.utbTool.BtnExportTemplateVisible = false;
            this.utbTool.btnExportTempVisible = false;
            this.utbTool.BtnFirstEnabled = false;
            this.utbTool.BtnFirstVisible = false;
            this.utbTool.BtnGroupPersonEnabled = false;
            this.utbTool.BtnGroupPersonVisible = false;
            this.utbTool.BtnImportCardUserDataEnabled = false;
            this.utbTool.BtnImportCardUserDataVisible = false;
            this.utbTool.btnImportDataEnabled = false;
            this.utbTool.btnImportDataVisible = false;
            this.utbTool.BtnImportPhotoEnabled = false;
            this.utbTool.BtnImportPhotoVisible = false;
            this.utbTool.BtnLastEnabled = false;
            this.utbTool.BtnLastVisible = false;
            this.utbTool.BtnModifyEnabled = false;
            this.utbTool.BtnModifyVisible = true;
            this.utbTool.BtnNewEnabled = true;
            this.utbTool.BtnNewVisible = true;
            this.utbTool.BtnNextEnabled = false;
            this.utbTool.BtnNextVisible = false;
            this.utbTool.BtnPreviousEnabled = false;
            this.utbTool.BtnPreviousVisible = false;
            this.utbTool.BtnSaveEnabled = false;
            this.utbTool.BtnSaveVisible = false;
            this.utbTool.BtnSearchEnabled = false;
            this.utbTool.BtnSearchVisible = false;
            this.utbTool.Location = new System.Drawing.Point(1, -1);
            this.utbTool.Name = "utbTool";
            this.utbTool.RecordExistPosition = WindowsUI.WebMonitor.WinUI.UserToolBar.RecordIndexType.None;
            this.utbTool.Size = new System.Drawing.Size(591, 26);
            this.utbTool.TabIndex = 3;
            this.utbTool.toolStripSeparator11Visible = false;
            this.utbTool.toolStripSeparator12Visible = false;
            this.utbTool.toolStripSeparator21Visible = false;
            this.utbTool.toolStripSeparator22Visible = false;
            this.utbTool.BtnNewClick += new System.EventHandler(this.utbTool_BtnNewClick);
            this.utbTool.BtnModifyClick += new System.EventHandler(this.utbTool_BtnModifyClick);
            this.utbTool.BtnDeleteClick += new System.EventHandler(this.utbTool_BtnDeleteClick);
            // 
            // frmIPOperate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 373);
            this.Controls.Add(this.utbTool);
            this.Controls.Add(this.lvwIPList);
            this.Name = "frmIPOperate";
            this.Text = "设备列表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwIPList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private WindowsUI.WebMonitor.WinUI.UserToolBar utbTool;


    }
}