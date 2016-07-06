using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderTagCreator
{
    public partial class MainForm : Form
    {
        public MainForm(string path="")
        {
            InitializeComponent();
            if(path!="")
            {
                _path = path;
                _isLoad = true;
                txtLoaction.Text = path;
                fbd.SelectedPath = path;
                _loadDir();

            }
           
        }
        ImageZoomer _Zomer = new ImageZoomer();
        Boolean _isLoad = false;
        String _path = "";
        int _width = 2;
        List<FolderTemplate> _DirList = new List<FolderTemplate>();
        String _defaultImage = Properties.Settings.Default.DefaultImage.ToString();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".PNG" };

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(fbd.SelectedPath.ToString()))
                {
                    txtLoaction.Text = fbd.SelectedPath.ToString();
                    _path = fbd.SelectedPath.ToString();
                    _isLoad = true;
                }
                else
                    _isLoad = false;

                _loadDir();
                LoadDir();


            }

        }

        public void _loadDir()
        {
            if (_isLoad)
            {
                _DirList.Clear();
                DirectoryInfo di = new DirectoryInfo(_path);
                // first list sub-directories
                DirectoryInfo[] dirs = di.GetDirectories("*.*", SearchOption.AllDirectories);
                foreach (DirectoryInfo dir in dirs)
                {
                    long _Size = Helper.GetDirectorySize(dir.FullName.ToString());
                    if (_Size > 0)
                    {
                        _DirList.Add(new FolderTemplate
                        {
                            _DirInfo = dir,
                            lgSize = _Size,
                            StrName = dir.ToString(),
                            strFullName = dir.FullName.ToString(),
                            strImageLoaction = Helper.GetDirectoryImage(dir.FullName.ToString(), _defaultImage) == null ? "" : Helper.GetDirectoryImage(dir.FullName.ToString(), _defaultImage).FullName.ToString(),
                        });

                    }
                }
            }

        }

        public void LoadDir()
        {
            pnl.Controls.Clear();
            int i = 0;
            int z = 0;
            var yy = 0;
            var x = 0;
            foreach (FolderTemplate flt in _DirList)
            {

                var hhhh = new System.Windows.Forms.Panel();
                var picbox_Folder = new System.Windows.Forms.PictureBox();
                var lbName = new System.Windows.Forms.Label();
                var label3 = new System.Windows.Forms.Label();
                var label2 = new System.Windows.Forms.Label();
                var lbSize = new System.Windows.Forms.Label();
                var picbox_Image = new System.Windows.Forms.PictureBox();
                var _dragButton = new System.Windows.Forms.Button();

                // hhhh
                // 
                hhhh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                hhhh.Controls.Add(picbox_Image);
                hhhh.Controls.Add(lbSize);
                hhhh.Controls.Add(label2);
                hhhh.Controls.Add(label3);
                hhhh.Controls.Add(lbName);
                hhhh.Controls.Add(picbox_Folder);
                hhhh.Controls.Add(_dragButton);
                z = i % _width;
                if (i != 0)
                    yy = z == 0 ? ++yy : yy;
                x = z == 0 ? 0 : ++x;

                if (z == 0)
                    hhhh.Location = new System.Drawing.Point(x, (yy * 100));
                else
                    hhhh.Location = new System.Drawing.Point((x * 400)+x*5, (yy * 100));

                hhhh.Tag = flt.strFullName;
                hhhh.Size = new System.Drawing.Size(400, 100);
                hhhh.TabIndex = 0;
                hhhh.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);

                // picbox_Folder
                // 
                picbox_Folder.Image = global::FolderTagCreator.Properties.Resources.rc_Folder;
                picbox_Folder.Location = new System.Drawing.Point(6, 3);
                picbox_Folder.Name = "picbox_Folder";
                picbox_Folder.Size = new System.Drawing.Size(49, 41);
                picbox_Folder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                picbox_Folder.TabIndex = 0;
                picbox_Folder.TabStop = false;
                picbox_Folder.Refresh();
                // 
                // lbName
                // 
                lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbName.Location = new System.Drawing.Point(108, 3);
                lbName.Name = "lbName";
                lbName.Size = new System.Drawing.Size(174, 41);
                lbName.Text = flt.StrName;
                // 
                // label3
                // 
                label3.AutoSize = true;
                label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label3.Location = new System.Drawing.Point(64, 3);
                label3.Name = "label3";
                label3.Size = new System.Drawing.Size(47, 13);
                label3.TabIndex = 2;
                label3.Text = "Name :";
                // 
                // label2
                // 
                label2.AutoSize = true;
                label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new System.Drawing.Point(6, 47);
                label2.Name = "label2";
                label2.Size = new System.Drawing.Size(39, 13);
                label2.TabIndex = 3;
                label2.Text = "Size :";
                // 
                // lbSize
                // 
                lbSize.AutoSize = true;
                lbSize.Location = new System.Drawing.Point(42, 47);
                lbSize.Name = "lbSize";
                lbSize.Size = new System.Drawing.Size(107, 94);
                lbSize.TabIndex = 4;
                lbSize.Text =Convert.ToString(flt.lgSize/(1024*1024))+ " MB";
                // 
                // picbox_Image
                // 
                if (!string.IsNullOrEmpty(flt.strImageLoaction))
                {
                    picbox_Image.ImageLocation = flt.strImageLoaction;
                    picbox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picbox_Image.Image = Properties.Resources.default_Image;
                    picbox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

                }
                picbox_Image.Location = new System.Drawing.Point(288, 3);
                picbox_Image.Name = "picbox_Image";
                picbox_Image.Size = new System.Drawing.Size(107, 94);
                
                picbox_Image.TabIndex = 5;
                picbox_Image.TabStop = false;
                picbox_Image.Refresh();
                picbox_Image.AllowDrop = true;
                picbox_Image.MouseHover += new EventHandler(this.pictureBox1_MouseHover);
                picbox_Image.DragDrop += new DragEventHandler(this.pictureBox1_DragDrop);
                picbox_Image.DragEnter += new DragEventHandler(this.pictureBox1_DragEnter);

                // button1
                // 
                _dragButton.BackgroundImage = global::FolderTagCreator.Properties.Resources._1466517977_Cursor_drag_arrow;
                _dragButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                _dragButton.Location = new System.Drawing.Point(283,3);
                _dragButton.Name = flt.strImageLoaction;
                _dragButton.Size = new System.Drawing.Size(22, 19);
                _dragButton.TabIndex = 0;
                _dragButton.BringToFront();
                _dragButton.UseVisualStyleBackColor = true;
                _dragButton.FlatStyle = FlatStyle.Popup;
                _dragButton.BackColor = Color.Transparent;
                _dragButton.MouseDown += new MouseEventHandler(this._dragbutton_mouseDown);
                if (string.IsNullOrEmpty(flt.strImageLoaction))
                {
                    _dragButton.Enabled = false;
                }
                else
                {
                  
                }
                this.pnl.Controls.Add(hhhh);
                i++;
                pnl.Refresh();
            }

        }

        private void _dragbutton_mouseDown(object sender, MouseEventArgs e)
        {
            Button _pic = (Button)sender;
            if (_pic != null)
                _pic.DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] { _pic.Name.ToString() }), DragDropEffects.Copy);
        }

        public void _DoDragDrop(object data, DragDropEffects _dragDropEffect, PictureBox _pic)
        {
            _pic.DoDragDrop(data, _dragDropEffect);
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Copy;
        }

        static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Panel pl = (Panel)sender;
            if(pl!=null)
            {
                Process.Start(pl.Tag.ToString());
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            try
            {
                _width = this.Width / 405;
                pnl.Height = this.Height - 150;
                pnl.Width = this.Width - 30;
                pnl.ResumeLayout();
                LoadDir();

            }
            catch { }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Resize(null, null);
            this.AllowDrop = true;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
              PictureBox _temp = (PictureBox)sender;
              PictureBox _Foldebox = null;
              if (_temp != null)
              {
                  var bmp = (String[])e.Data.GetData(DataFormats.FileDrop);
                  if(bmp.Count()>0)
                  {
                      if (ImageExtensions.Contains(Path.GetExtension((bmp[0].ToString()).ToUpperInvariant())))
                      {
                          _temp.ImageLocation=bmp[0].ToString();
                          _temp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

                          try
                          {
                              Panel _pnl = (Panel)_temp.Parent;
                              if (_pnl != null)
                              {
                                  if (!TagCreator.CreateIconedFolder(_pnl.Tag.ToString(), bmp[0].ToString()))
                                  {
                                      Helper.showError(new Exception("System Error..!"));
                                  }
                                  else
                                  {
                                      TagCreator.FileCopy(_pnl.Tag.ToString(), bmp[0].ToString());
                                      IEnumerable<PictureBox> _contl = _pnl.Controls.OfType<PictureBox>().Where(x=>x.Name.Equals("picbox_Folder")).Take(1);
                                      if (_contl.Count() > 0)
                                      {
                                          _Foldebox = (PictureBox)_contl.ElementAt(0);
                                          _Foldebox.Image = Properties.Resources.Check_Mark;
                                          _Foldebox.Refresh();
                                          Thread.Sleep(2000);
                                          _Foldebox.Image = Properties.Resources.rc_Folder;
                                          _Foldebox.Refresh();
                                      }
                                      
                                  }
                              }
                                  
                          }
                          catch { }
                      }
                  }
              }
             
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            PictureBox _temp = (PictureBox)sender;
            if (_temp != null)
            {
                if (!string.IsNullOrEmpty(_temp.ImageLocation))
                {
                    var _Zomer = new ImageZoomer();
                    _Zomer._DoDragandDrop = new ImageZoomer._DoDragDrop(_DoDragDrop);
                    _Zomer.Load += delegate
                    {

                        _Zomer.Location = new Point(Cursor.Position.X - 175, Cursor.Position.Y - 125);
                    };

                    _Zomer.ShowMD(_temp.ImageLocation,_temp);

                }
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
