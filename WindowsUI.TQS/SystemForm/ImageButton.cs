using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsUI.TQS.SystemForm
{
    public partial class ImageButton : UserControl
    {
        public Image image 
        { 
            get
            {
                return this.ptbBgImage.Image;
            }
            set
            {
                this.ptbBgImage.Image = value;
            }
        }

        public ImageButton()
        {
            InitializeComponent();
        }

        public event EventHandler OnImageClick;

        private void ImageButton_Click(object sender, EventArgs e)
        {
            if (this.OnImageClick != null)
            {
                this.OnImageClick(this, e);
            }
        }
    }
}
