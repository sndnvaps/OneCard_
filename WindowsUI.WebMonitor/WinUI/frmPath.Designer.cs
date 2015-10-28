namespace WindowsUI.WebMonitor.WinUI
{
    partial class frmPath
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
            this.lblPath = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.ofdPath = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(2, 1);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(237, 56);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "label1";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(247, 15);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(59, 23);
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "文件";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // ofdPath
            // 
            this.ofdPath.FileName = "openFileDialog1";
            // 
            // frmPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 57);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.lblPath);
            this.Name = "frmPath";
            this.Text = "frmPath";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.OpenFileDialog ofdPath;
    }
}