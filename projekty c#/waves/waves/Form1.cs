using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.IO;

namespace waves
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public string sciezka;
        public int w, h;
        public byte[] skompresowane;
        bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string filePath = ofd.FileName;
            label4.Text = filePath;
            Image image = Image.FromFile(filePath);
            pictureBox1.Image = image;
            Size size = image.Size;
            pictureBox1.Size = size;
            int szerokosc = size.Width;
            int wysokosc = size.Height;
            label5.Text = "szerokosc: " + szerokosc + " wysokosc: " + wysokosc;
            label6.Text = "szerokosc: " + szerokosc + " wysokosc: " + wysokosc;
            while ((!IsPowerOfTwo(szerokosc) || !IsPowerOfTwo(wysokosc) || szerokosc != wysokosc))
            {

                if (wysokosc > szerokosc) while (!IsPowerOfTwo(szerokosc)) szerokosc++;
                else while (!IsPowerOfTwo(wysokosc)) wysokosc++;
                label6.Text = "szerokosc: " + szerokosc + " wysokosc: " + wysokosc;

            }
            if (wysokosc != size.Height || szerokosc != size.Width)
            {
                Bitmap nowyObraz = new Bitmap(szerokosc, wysokosc);
                using (Graphics g = Graphics.FromImage(nowyObraz))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 128, 128)))
                {
                    g.DrawImage(image, 0, 0, size.Width, size.Height);
                    g.FillRectangle(brush, size.Width + 1, 0, szerokosc, wysokosc);
                    g.FillRectangle(brush, 0, size.Height + 1, szerokosc, wysokosc);

                }
                pictureBox1.Image = nowyObraz;
                pictureBox1.Size = new Size(szerokosc, wysokosc);

                string newPath = filePath + "_new.png";
                sciezka = newPath;
                nowyObraz.Save(newPath);

            }
            else sciezka = filePath;
            w = szerokosc;
            h = wysokosc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = sciezka;
            wvCompress c = new wvCompress();
            skompresowane = c.run(path);
            Bitmap skompresowanyObraz = BytesToBitmap(skompresowane, w, h);
            pictureBox1.Image = skompresowanyObraz;
            pictureBox1.Size = new Size(skompresowanyObraz.Width, skompresowanyObraz.Height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wvDecompress d = new wvDecompress();
            byte[] zdekompresowane = d.run(skompresowane, w, h);
            Bitmap bitmap1 = BytesToBitmap(zdekompresowane, w, h);
            pictureBox1.Image = bitmap1;
            pictureBox1.Size = new Size(bitmap1.Width, bitmap1.Height);
        }

        public unsafe static Bitmap BytesToBitmap(byte[] data, int w, int h)
        {
            Size wielkosc = new System.Drawing.Size(w, h);
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            Bitmap mapa = new Bitmap(wielkosc.Width, wielkosc.Height, wielkosc.Width * 3,
            PixelFormat.Format24bppRgb, handle.AddrOfPinnedObject());
            handle.Free();
            return mapa;
        }


    }
}
