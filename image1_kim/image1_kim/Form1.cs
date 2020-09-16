using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image1_kim
{
    public partial class Form1 : Form
    {
        Image image;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics gr = CreateGraphics();
            openFileDialog1.Title = "영상 파일 열기";
            openFileDialog1.Filter = "ALL Files(*.*) |*.*| Bitmap File(*.bmp)|*bmp |Jpeg File(*.jpg) | *jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strFilename = openFileDialog1.FileName;
                image = Image.FromFile(strFilename);
                gr.DrawImage(image, 30, 80, image.Width, image.Height);
            }
            gr.Dispose();
        }

        private void greyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y, brightness;
            Color color, gray;
            Graphics gr = CreateGraphics();
            Bitmap gBitmap = new Bitmap(image);
            for(x = 0; x< image.Width; x++)
            {
                for(y=0; y<image.Height; y++)
                {
                    color = gBitmap.GetPixel(x, y);
                    brightness = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    gray = Color.FromArgb(brightness, brightness, brightness);
                    gBitmap.SetPixel(x, y, gray);
                }
            }
            gr.DrawImage(gBitmap, 40 + gBitmap.Width, 80, gBitmap.Width, gBitmap.Height);
            gr.Dispose();
        }
    }
}
