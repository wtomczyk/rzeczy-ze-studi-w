using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad1._5
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) < 256)
            {
                textBox1.Text = "256";
            }
            if (Convert.ToInt32(textBox2.Text) < 256)
            {
                textBox2.Text = "256";
            }
            this.Width = Convert.ToInt32(textBox1.Text);
            this.Height = Convert.ToInt32(textBox2.Text);
            this.Location = new Point(0, 0);

            int x = 0, y = 0;
            int brickW = this.Width / 256, brickH = this.Height / 256;

            Graphics gr = this.CreateGraphics();
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    int r = rnd.Next(255);
                    int g = rnd.Next(255);
                    int b = rnd.Next(255);
                    Brush brush = new SolidBrush(Color.FromArgb(r, g, b));
                    gr.FillRectangle(brush, x, y, brickW, brickH);
                    x += brickW;
                }
                x = 0;
                y += brickH;
            }
        }
    }
}
