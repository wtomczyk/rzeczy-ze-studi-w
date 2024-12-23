using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad_2._4._3
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        int[,] weights = new int[1024, 3];
        bool click = true;
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

            int brickW = this.Width / 32, brickH = (this.Height-40) / 32;
            
            int x = 31 * brickW, y = 0;

            Graphics gr = this.CreateGraphics();
            if (click)
            {
                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        int r = rnd.Next(256);
                        int g = rnd.Next(256);
                        Brush brush = new SolidBrush(Color.FromArgb(r, g, 128));
                        gr.FillRectangle(brush, x, y, brickW, brickH);
                        weights[j + i * 32, 0] = 4 * r + 2 * g + 128;
                        weights[j + i * 32, 1] = r;
                        weights[j + i * 32, 2] = g;
                        x -= brickW;
                    }
                    x = 31 * brickW;
                    y += brickH;
                }
                click = false;
            }
            else
            {
                wstawianie(weights, gr, brickW, brickH);
                click = true;
            }
        }
        public void wstawianie(int[,] tab, Graphics a, int brickW, int brickH)
        {
            for (int i = 1; i < 1024; i++)
            {
                int[] obecne = new int[tab.GetLength(1)];
                for (int k = 0; k < obecne.Length; k++)
                {
                    obecne[k] = tab[i, k];
                }

                int j = i - 1;

                while (j >= 0 && tab[j, 0] > obecne[0])
                {
                    for (int k = 0; k < obecne.Length; k++)
                    {
                        tab[j + 1, k] = tab[j, k];

                        int val1_h = ((j+1) - (j+1) % 32) / 32;
                        int val1_w = (j + 1) % 32;

                        Brush brush = new SolidBrush(Color.FromArgb(tab[(j + 1), 1], tab[(j + 1), 2], 128));
                        a.FillRectangle(brush, (31 - val1_w) * brickW, val1_h * brickH, brickW, brickH);
                    }
                    j--;
                }

                for (int l = 0; l < obecne.Length; l++)
                {
                    tab[j + 1, l] = obecne[l];

                    int val1_h = ((j + 1) - (j + 1) % 32) / 32;
                    int val1_w = (j + 1) % 32;

                    Brush brush = new SolidBrush(Color.FromArgb(tab[(j + 1), 1], tab[(j + 1), 2], 128));
                    a.FillRectangle(brush, (31 - val1_w) * brickW, val1_h * brickH, brickW, brickH);
                }
            }
        }
    }
}
