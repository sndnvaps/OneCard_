namespace WindowUI.TQS
{
    partial class ucMealBookingDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labSupperMB = new System.Windows.Forms.Label();
            this.labLunchMB = new System.Windows.Forms.Label();
            this.labBreakfastMB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labSupperMB
            // 
            this.labSupperMB.AutoSize = true;
            this.labSupperMB.BackColor = System.Drawing.Color.White;
            this.labSupperMB.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Underline);
            this.labSupperMB.ForeColor = System.Drawing.Color.Blue;
            this.labSupperMB.Location = new System.Drawing.Point(51, 5);
            this.labSupperMB.Name = "labSupperMB";
            this.labSupperMB.Size = new System.Drawing.Size(35, 14);
            this.labSupperMB.TabIndex = 30;
            this.labSupperMB.Text = "缺失";
            // 
            // labLunchMB
            // 
            this.labLunchMB.AutoSize = true;
            this.labLunchMB.BackColor = System.Drawing.Color.White;
            this.labLunchMB.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Underline);
            this.labLunchMB.ForeColor = System.Drawing.Color.Blue;
            this.labLunchMB.Location = new System.Drawing.Point(51, 5);
            this.labLunchMB.Name = "labLunchMB";
            this.labLunchMB.Size = new System.Drawing.Size(35, 14);
            this.labLunchMB.TabIndex = 29;
            this.labLunchMB.Text = "缺失";
            // 
            // labBreakfastMB
            // 
            this.labBreakfastMB.AutoSize = true;
            this.labBreakfastMB.BackColor = System.Drawing.Color.White;
            this.labBreakfastMB.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Underline);
            this.labBreakfastMB.ForeColor = System.Drawing.Color.Blue;
            this.labBreakfastMB.Location = new System.Drawing.Point(51, 5);
            this.labBreakfastMB.Name = "labBreakfastMB";
            this.labBreakfastMB.Size = new System.Drawing.Size(35, 14);
            this.labBreakfastMB.TabIndex = 28;
            this.labBreakfastMB.Text = "缺失";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 10F);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "早餐:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 10F);
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "午餐:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 10F);
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 33;
            this.label3.Text = "晚餐:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labBreakfastMB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 27);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labLunchMB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(92, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(90, 27);
            this.panel2.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labSupperMB);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(181, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 27);
            this.panel3.TabIndex = 36;
            // 
            // ucMealBookingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucMealBookingDetail";
            this.Size = new System.Drawing.Size(275, 36);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labSupperMB;
        private System.Windows.Forms.Label labLunchMB;
        private System.Windows.Forms.Label labBreakfastMB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
