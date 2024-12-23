using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad_2._4._1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        int[,] weights = new int[32, 32];
        int[,,] vals = new int[32, 32, 2];
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

            int x = 0, y = 0;
            int brickW = this.Width / 32, brickH = (this.Height-40) / 32;
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
                        weights[i, j] = 4 * r + 2 * g + 128;
                        vals[i, j, 0] = r;
                        vals[i, j, 1] = g;
                        x += brickW;
                    }
                    x = 0;
                    y += brickH;
                }
                click = false;
            }
            else
            {
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    int i = 0;
                    int j = 31;

                    for (int a = 0; a < (32*32-1); a++)
                    {
                        if(j == 0)
                        {
                            if (weights[i, j] > weights[i+1, 31])
                            {
                                flag = true;
                                int tempVal = vals[i, j, 0];
                                vals[i, j, 0] = vals[i+1, 31, 0];
                                vals[i+1, 31, 0] = tempVal;

                                tempVal = vals[i, j, 1];
                                vals[i, j, 1] = vals[i + 1, 31, 1];
                                vals[i + 1, 31, 1] = tempVal;

                                tempVal = weights[i, j];
                                weights[i, j] = weights[i + 1, 31];
                                weights[i + 1, 31] = tempVal;

                                Brush brush = new SolidBrush(Color.FromArgb(vals[i, j, 0], vals[i, j, 1], 128));
                                gr.FillRectangle(brush, j * brickW, i* brickH, brickW, brickH);

                                Brush brush2 = new SolidBrush(Color.FromArgb(vals[i+1, 31, 0], vals[i+1, 31, 1], 128));
                                gr.FillRectangle(brush2, 31* brickW, (i+1)*brickH, brickW, brickH);
                            }
                            j = 31;
                            i = i+1;
                        }
                        else
                        {
                            if (weights[i, j] > weights[i, j - 1])
                            {
                                flag = true;
                                int tempVal = vals[i, j, 0];
                                vals[i, j, 0] = vals[i, j - 1, 0];
                                vals[i, j - 1, 0] = tempVal;

                                tempVal = vals[i, j, 1];
                                vals[i, j, 1] = vals[i, j - 1, 1];
                                vals[i, j - 1, 1] = tempVal;

                                tempVal = weights[i, j];
                                weights[i, j] = weights[i, j - 1];
                                weights[i, j - 1] = tempVal;

                                Brush brush = new SolidBrush(Color.FromArgb(vals[i, j, 0], vals[i, j, 1], 128));
                                gr.FillRectangle(brush, j * brickW, i * brickH, brickW, brickH);

                                Brush brush2 = new SolidBrush(Color.FromArgb(vals[i, j - 1, 0], vals[i, j - 1, 1], 128));
                                gr.FillRectangle(brush2, (j - 1) * brickW, i * brickH, brickW, brickH);
                            }
                            j--;
                        }
                    }
                }
                click = true;
            }
        }
    }
}