using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderTagCreator
{
    public partial class ImageZoomer : Form
    {
        public ImageZoomer()
        {
            InitializeComponent();
        }
        Bitmap _Default_image = Properties.Resources.default_Image;
        public delegate void _DoDragDrop(object data, DragDropEffects _dragDropEffect,PictureBox _pic);
        public _DoDragDrop _DoDragandDrop = null;
        PictureBox pic = null;
        public void ShowMD(String ImageLoaction,PictureBox _pic, String name="Image Zoom",int Width=500,Int32 Height=400)
        {
            this.Text = name;
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
            pic = _pic;
            //this.Width = Width;
            //this.Height = Height;
            if (!string.IsNullOrEmpty(ImageLoaction))
            {
                pictureBox1.ImageLocation = ImageLoaction;
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
            else
            {
               
                pictureBox1.Image = Properties.Resources.default_Image;
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            }
            this.ShowDialog();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //((PictureBox)sender).DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] { ((PictureBox)sender).ImageLocation.ToString() }), DragDropEffects.Copy);
            if(_DoDragandDrop!=null)
            {
                _DoDragandDrop(new DataObject(DataFormats.FileDrop, new string[] { ((PictureBox)sender).ImageLocation.ToString() }), DragDropEffects.Copy,this.pic);
            }


        }
    }
}
