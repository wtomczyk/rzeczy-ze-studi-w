using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad_2._4._2
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        int[,] weights = new int[1024,3];
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
                        weights[j+i*32,0] = 4 * r + 2 * g + 128;
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
                QuickSort(weights, 0, 1023, gr, brickW, brickH);
                click = true;
            }
        }
        public void QuickSort(int[,] tab, int lewy, int prawe, Graphics a, int brickW, int brickH)
        {
            if (lewy < prawe)
            {
                int granica = Granica(tab, lewy, prawe,a, brickW, brickH);
                QuickSort(tab, lewy, granica - 1,a,brickW,brickH);
                QuickSort(tab, granica + 1, prawe, a, brickW, brickH);
            }
        }
        public int Granica(int[,] tab, int lewy, int prawe, Graphics a, int brickW, int brickH)
        {
            int wartosc_granicy = tab[prawe, 0];
            int i = lewy - 1;

            for (int j = lewy; j <= prawe - 1; j++)
            {
                if (tab[j, 0] <= wartosc_granicy)
                {
                    i++;
                    Zmiana(tab, i, j, a, brickW, brickH);
                }
            }

            Zmiana(tab, i + 1, prawe, a, brickW, brickH);
            return i + 1;
        }
        public void Zmiana(int[,] tab, int row1, int row2, Graphics a, int brickW, int brickH)
        {
            for (int j = 0; j < 3; j++)
            {
                int tempVal = tab[row1, j];
                tab[row1, j] = tab[row2, j];
                tab[row2, j] = tempVal;  
            }
            int val1_h = (row1 - row1 % 32)/32;
            int val1_w = row1 % 32;

            int val2_h = (row2 - row2 % 32)/32;
            int val2_w = row2 % 32;

            Brush brush = new SolidBrush(Color.FromArgb(tab[row1, 1], tab[row1, 2], 128));
            a.FillRectangle(brush, (31 -val1_w) * brickW, val1_h * brickH, brickW, brickH);

            Brush brush2 = new SolidBrush(Color.FromArgb(tab[row2, 1], tab[row2, 2], 128));
            a.FillRectangle(brush2, (31 -val2_w) * brickW, val2_h * brickH, brickW, brickH);
        }
    }
}