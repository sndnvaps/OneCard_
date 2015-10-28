namespace WindowUI.HHZX.SysMaster
{
    partial class SysFormMaster
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("江門利奧信領科技");
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lvwPur = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcParentCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcDesc = new System.Windows.Forms.TextBox();
            this.txtcCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.tvwMain = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtdAddDate = new System.Windows.Forms.TextBox();
            this.txtcAdd = new System.Windows.Forms.TextBox();
            this.txtdLastDate = new System.Windows.Forms.TextBox();
            this.txtcLast = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SysToolBar = new WindowControls.UserToolBar();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnUp);
            this.groupBox2.Controls.Add(this.btnDown);
            this.groupBox2.Controls.Add(this.tvwMain);
            this.groupBox2.Location = new System.Drawing.Point(7, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1094, 515);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnDel);
            this.groupBox3.Controls.Add(this.btnNew);
            this.groupBox3.Controls.Add(this.lvwPur);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtcID);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtcParentCode);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtcPath);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtcDesc);
            this.groupBox3.Controls.Add(this.txtcCode);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(345, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(717, 497);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDel.Location = new System.Drawing.Point(628, 466);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(76, 25);
            this.btnDel.TabIndex = 48;
            this.btnDel.Text = "刪除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNew.Location = new System.Drawing.Point(545, 466);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(76, 25);
            this.btnNew.TabIndex = 47;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lvwPur
            // 
            this.lvwPur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPur.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwPur.FullRowSelect = true;
            this.lvwPur.GridLines = true;
            this.lvwPur.Location = new System.Drawing.Point(90, 268);
            this.lvwPur.Name = "lvwPur";
            this.lvwPur.Size = new System.Drawing.Size(613, 191);
            this.lvwPur.TabIndex = 46;
            this.lvwPur.UseCompatibleStateImageBehavior = false;
            this.lvwPur.View = System.Windows.Forms.View.Details;
            this.lvwPur.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "fum_cFunctionNumber";
            this.columnHeader1.Text = "功能编号";
            this.columnHeader1.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "fum_cFunctionDesc";
            this.columnHeader2.Text = "功能描述";
            this.columnHeader2.Width = 434;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 45;
            this.label7.Text = "拥有功能：";
            this.label7.Visible = false;
            // 
            // txtcID
            // 
            this.txtcID.Location = new System.Drawing.Point(91, 229);
            this.txtcID.Name = "txtcID";
            this.txtcID.Size = new System.Drawing.Size(204, 23);
            this.txtcID.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 43;
            this.label6.Text = "序号：";
            // 
            // txtcParentCode
            // 
            this.txtcParentCode.Enabled = false;
            this.txtcParentCode.Location = new System.Drawing.Point(91, 198);
            this.txtcParentCode.Name = "txtcParentCode";
            this.txtcParentCode.Size = new System.Drawing.Size(204, 23);
            this.txtcParentCode.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 41;
            this.label5.Text = "父表单编号：";
            // 
            // txtcPath
            // 
            this.txtcPath.Location = new System.Drawing.Point(91, 169);
            this.txtcPath.Name = "txtcPath";
            this.txtcPath.Size = new System.Drawing.Size(612, 23);
            this.txtcPath.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "执行路径：";
            // 
            // txtcDesc
            // 
            this.txtcDesc.Location = new System.Drawing.Point(91, 51);
            this.txtcDesc.Multiline = true;
            this.txtcDesc.Name = "txtcDesc";
            this.txtcDesc.Size = new System.Drawing.Size(612, 112);
            this.txtcDesc.TabIndex = 38;
            // 
            // txtcCode
            // 
            this.txtcCode.Location = new System.Drawing.Point(91, 17);
            this.txtcCode.Name = "txtcCode";
            this.txtcCode.Size = new System.Drawing.Size(204, 23);
            this.txtcCode.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 36;
            this.label2.Text = "表单描述：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 35;
            this.label1.Text = "表单编号：";
            // 
            // btnUp
            // 
            this.btnUp.Image = global::WindowUI.HHZX.Properties.Resources.call_up;
            this.btnUp.Location = new System.Drawing.Point(304, 146);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(31, 33);
            this.btnUp.TabIndex = 36;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::WindowUI.HHZX.Properties.Resources.call_down;
            this.btnDown.Location = new System.Drawing.Point(304, 181);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(31, 34);
            this.btnDown.TabIndex = 35;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // tvwMain
            // 
            this.tvwMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwMain.Location = new System.Drawing.Point(7, 17);
            this.tvwMain.Name = "tvwMain";
            treeNode2.Name = "Node0";
            treeNode2.Text = "江門利奧信領科技";
            this.tvwMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvwMain.Size = new System.Drawing.Size(293, 490);
            this.tvwMain.TabIndex = 28;
            this.tvwMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwMain_AfterSelect);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtdAddDate);
            this.groupBox4.Controls.Add(this.txtcAdd);
            this.groupBox4.Controls.Add(this.txtdLastDate);
            this.groupBox4.Controls.Add(this.txtcLast);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(3, 525);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1109, 91);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // txtdAddDate
            // 
            this.txtdAddDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtdAddDate.Enabled = false;
            this.txtdAddDate.Location = new System.Drawing.Point(84, 53);
            this.txtdAddDate.Name = "txtdAddDate";
            this.txtdAddDate.Size = new System.Drawing.Size(145, 23);
            this.txtdAddDate.TabIndex = 7;
            // 
            // txtcAdd
            // 
            this.txtcAdd.BackColor = System.Drawing.SystemColors.Info;
            this.txtcAdd.Enabled = false;
            this.txtcAdd.Location = new System.Drawing.Point(84, 26);
            this.txtcAdd.Name = "txtcAdd";
            this.txtcAdd.Size = new System.Drawing.Size(145, 23);
            this.txtcAdd.TabIndex = 6;
            // 
            // txtdLastDate
            // 
            this.txtdLastDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtdLastDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtdLastDate.Enabled = false;
            this.txtdLastDate.Location = new System.Drawing.Point(955, 55);
            this.txtdLastDate.Name = "txtdLastDate";
            this.txtdLastDate.Size = new System.Drawing.Size(145, 23);
            this.txtdLastDate.TabIndex = 5;
            // 
            // txtcLast
            // 
            this.txtcLast.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtcLast.BackColor = System.Drawing.SystemColors.Info;
            this.txtcLast.Enabled = false;
            this.txtcLast.Location = new System.Drawing.Point(955, 28);
            this.txtcLast.Name = "txtcLast";
            this.txtcLast.Size = new System.Drawing.Size(145, 23);
            this.txtcLast.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(885, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "修改时间:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Location = new System.Drawing.Point(885, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 14);
            this.label11.TabIndex = 2;
            this.label11.Text = "修改者:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Location = new System.Drawing.Point(15, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 1;
            this.label12.Text = "新增时间:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Location = new System.Drawing.Point(15, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "新增者:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1115, 619);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // SysToolBar
            // 
            this.SysToolBar.AutoSetStatus = true;
            this.SysToolBar.BtnCancelEnabled = true;
            this.SysToolBar.BtnCancelVisible = true;
            this.SysToolBar.BtnCardIssuanceEnabled = true;
            this.SysToolBar.BtnCardIssuanceVisible = false;
            this.SysToolBar.BtnCardMissingEnabled = true;
            this.SysToolBar.BtnCardMissingVisible = false;
            this.SysToolBar.BtnCardRecoveryEnabled = true;
            this.SysToolBar.BtnCardRecoveryVisible = false;
            this.SysToolBar.BtnCardReturnEnabled = true;
            this.SysToolBar.BtnCardReturnVisible = false;
            this.SysToolBar.BtnCardScrapEnabled = true;
            this.SysToolBar.BtnCardScrapVisible = false;
            this.SysToolBar.BtnDataExportEnabled = true;
            this.SysToolBar.BtnDataExportVisible = false;
            this.SysToolBar.BtnDataInputEnabled = true;
            this.SysToolBar.BtnDataInputVisible = false;
            this.SysToolBar.BtnDeleteEnabled = true;
            this.SysToolBar.BtnDeleteVisible = true;
            this.SysToolBar.BtnExpCusDataEnabled = true;
            this.SysToolBar.BtnExpCusDataVisible = false;
            this.SysToolBar.BtnExportCardUserPhotoEnabled = true;
            this.SysToolBar.BtnExportCardUserPhotoVisible = false;
            this.SysToolBar.btnExportDataEnabled = true;
            this.SysToolBar.btnExportDataVisible = false;
            this.SysToolBar.btnExportTempEnabled = true;
            this.SysToolBar.BtnExportTemplateEnabled = true;
            this.SysToolBar.BtnExportTemplateVisible = false;
            this.SysToolBar.btnExportTempVisible = false;
            this.SysToolBar.BtnFirstEnabled = true;
            this.SysToolBar.BtnFirstVisible = false;
            this.SysToolBar.BtnGroupPersonEnabled = true;
            this.SysToolBar.BtnGroupPersonVisible = false;
            this.SysToolBar.BtnImportCardUserDataEnabled = true;
            this.SysToolBar.BtnImportCardUserDataVisible = false;
            this.SysToolBar.btnImportDataEnabled = true;
            this.SysToolBar.btnImportDataVisible = false;
            this.SysToolBar.BtnImportPhotoEnabled = true;
            this.SysToolBar.BtnImportPhotoVisible = false;
            this.SysToolBar.BtnLastEnabled = true;
            this.SysToolBar.BtnLastVisible = false;
            this.SysToolBar.BtnModifyEnabled = true;
            this.SysToolBar.BtnModifyVisible = true;
            this.SysToolBar.BtnNewEnabled = true;
            this.SysToolBar.BtnNewVisible = true;
            this.SysToolBar.BtnNextEnabled = true;
            this.SysToolBar.BtnNextVisible = false;
            this.SysToolBar.BtnPreviousEnabled = true;
            this.SysToolBar.BtnPreviousVisible = false;
            this.SysToolBar.BtnSaveEnabled = true;
            this.SysToolBar.BtnSaveVisible = true;
            this.SysToolBar.BtnSearchEnabled = true;
            this.SysToolBar.BtnSearchVisible = false;
            this.SysToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.SysToolBar.Location = new System.Drawing.Point(0, 0);
            this.SysToolBar.Name = "SysToolBar";
            this.SysToolBar.RecordExistPosition = WindowControls.UserToolBar.RecordIndexType.None;
            this.SysToolBar.Size = new System.Drawing.Size(1115, 28);
            this.SysToolBar.TabIndex = 9;
            this.SysToolBar.toolStripSeparator11Visible = false;
            this.SysToolBar.toolStripSeparator12Visible = false;
            this.SysToolBar.toolStripSeparator21Visible = false;
            this.SysToolBar.toolStripSeparator22Visible = false;
            this.SysToolBar.BtnNewClick += new System.EventHandler(this.SysToolBar_BtnNewClick);
            this.SysToolBar.BtnModifyClick += new System.EventHandler(this.SysToolBar_BtnModifyClick);
            this.SysToolBar.BtnSaveClick += new System.EventHandler(this.SysToolBar_BtnSaveClick);
            this.SysToolBar.BtnCancelClick += new System.EventHandler(this.SysToolBar_BtnCancelClick);
            this.SysToolBar.BtnDeleteClick += new System.EventHandler(this.SysToolBar_BtnDeleteClick);
            // 
            // SysFormMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 641);
            this.Controls.Add(this.SysToolBar);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 10F);
            this.Name = "SysFormMaster";
            this.TabText = "表单主档";
            this.Text = "表单主档";
            this.Load += new System.EventHandler(this.SysFormMaster_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListView lvwPur;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcParentCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcDesc;
        private System.Windows.Forms.TextBox txtcCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TreeView tvwMain;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtdAddDate;
        private System.Windows.Forms.TextBox txtcAdd;
        private System.Windows.Forms.TextBox txtdLastDate;
        private System.Windows.Forms.TextBox txtcLast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private WindowControls.UserToolBar SysToolBar;

    }
}