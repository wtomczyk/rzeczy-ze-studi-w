using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad2._1_3
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        int[,] weights = new int[32,32];
        int[,,] vals = new int[32, 32,2];
        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) < 32)
            {
                textBox1.Text = "32";
            }
            if (Convert.ToInt32(textBox2.Text) < 32)
            {
                textBox2.Text = "32";
            }
            this.Width = Convert.ToInt32(textBox1.Text);
            this.Height = Convert.ToInt32(textBox2.Text)+40;
            this.Location = new Point(0, 0);

            int x = 0, y = 0;
            int brickW = this.Width / 32, brickH = (this.Height-40) / 32;
            int b = 128;

            Graphics gr = this.CreateGraphics();
            for (int i = 0; i < 32; i++)
            { 
                for (int j = 0; j < 32; j++)
                {
                    int r = rnd.Next(256);
                    int g = rnd.Next(256);
                    Brush brush = new SolidBrush(Color.FromArgb(r, g, b));
                    gr.FillRectangle(brush, x, y, brickW, brickH);
                    weights[i, j] = 4 * r + 2 * g + b;
                    vals[i, j, 0] = r;
                    vals[i, j, 1] = g;
                    x += brickW;
                }
                x = 0;
                y += brickH;
            }
        }
    }
}
