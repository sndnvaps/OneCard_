﻿namespace WindowsUI.TQS.SystemForm
{
    partial class WebStatusBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tirCheckWeb = new System.Windows.Forms.Timer(this.components);
            this.ptbStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "网络情况：";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(97, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 12);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "离线";
            // 
            // tirCheckWeb
            // 
            this.tirCheckWeb.Enabled = true;
            this.tirCheckWeb.Interval = 1000;
            this.tirCheckWeb.Tick += new System.EventHandler(this.tirCheckWeb_Tick);
            // 
            // ptbStatus
            // 
            this.ptbStatus.Image = global::WindowsUI.TQS.Properties.Resources.webstatus_o;
            this.ptbStatus.Location = new System.Drawing.Point(70, 0);
            this.ptbStatus.Name = "ptbStatus";
            this.ptbStatus.Size = new System.Drawing.Size(22, 22);
            this.ptbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbStatus.TabIndex = 1;
            this.ptbStatus.TabStop = false;
            // 
            // WebStatusBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ptbStatus);
            this.Controls.Add(this.label1);
            this.Name = "WebStatusBox";
            this.Size = new System.Drawing.Size(140, 25);
            ((System.ComponentModel.ISupportInitialize)(this.ptbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tirCheckWeb;
    }
}
