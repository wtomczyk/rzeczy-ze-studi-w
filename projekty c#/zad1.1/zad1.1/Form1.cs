using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad1._1
{
    public partial class Form1 : Form
    {
        ColorManager cm;
        public Form1()
        {
            InitializeComponent();
            cm = new ColorManager(hScrollBar1, hScrollBar2, hScrollBar3);
            hScrollBar1.Scroll += OnScroll;
            hScrollBar2.Scroll += OnScroll;
            hScrollBar3.Scroll += OnScroll;
        }
        private void OnScroll(object sender, ScrollEventArgs e)
        {
            this.BackColor = cm.Get;
            panel1.BackColor = Invert(cm.Get);
        }
        private Color Invert(Color c)
        {
            return Color.FromArgb(255 - c.R, 255 - c.B, 255 - c.G);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class ColorManager
    {
        List<ScrollBar> lst = new List<ScrollBar>();
        public ColorManager(ScrollBar R, ScrollBar G, ScrollBar B)
        {
            lst.AddRange(new ScrollBar[] { R, G, B });
            foreach (var s in lst)
            {
                s.Maximum = 255;
                s.Minimum = 0;
            }
        }
        public Color Get
        {
            get
            {
                return Color.FromArgb(lst[0].Value, lst[1].Value, lst[2].Value);
            }
        }
    }
}
