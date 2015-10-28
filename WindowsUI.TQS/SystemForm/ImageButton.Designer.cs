namespace WindowsUI.TQS.SystemForm
{
    partial class ImageButton
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
            this.ptbBgImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbBgImage
            // 
            this.ptbBgImage.Image = global::WindowsUI.TQS.Properties.Resources.btn;
            this.ptbBgImage.Location = new System.Drawing.Point(-1, -1);
            this.ptbBgImage.Name = "ptbBgImage";
            this.ptbBgImage.Size = new System.Drawing.Size(205, 63);
            this.ptbBgImage.TabIndex = 0;
            this.ptbBgImage.TabStop = false;
            this.ptbBgImage.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // ImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ptbBgImage);
            this.Name = "ImageButton";
            this.Size = new System.Drawing.Size(201, 60);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBgImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbBgImage;
    }
}
