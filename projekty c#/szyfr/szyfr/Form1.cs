using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szyfr
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public static char szyfr(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
        public static string szyfrowanie(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += szyfr(ch, key);

            return output;
        }

        public static string rozszyfrowanie(string input, int key)
        {
            int val = key % 26;
            return szyfrowanie(input, 26 - val);
        }

        private string plik;
        private string tekst;
        private string zaszyfrowanyTekst;
        private string klucz;
        private string operacja;


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string filePath = ofd.FileName;
            plik = filePath;
            StreamReader sr = new StreamReader(filePath);
            string linia;
            string originalne = "";
            linia = sr.ReadLine();
            while (linia != null)
            {
                originalne += linia;
                linia = sr.ReadLine();
            }
            richTextBox1.Text = originalne;
            tekst = originalne;
            sr.Close();
            richTextBox2.Text = "";
            richTextBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            operacja = "cezar";
            zaszyfrowanyTekst = szyfrowanie(tekst, Convert.ToInt32(numericUpDown1.Value));
            richTextBox2.Text = zaszyfrowanyTekst;
            richTextBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rozszyfrowany = rozszyfrowanie(zaszyfrowanyTekst, Convert.ToInt32(numericUpDown1.Value));
            richTextBox2.Text = rozszyfrowany;
            if (rozszyfrowany == tekst)
            {
                label5.Text = "są zgodne";
                string szyfrowanyPlik = plik.Split('.')[0];
                using (StreamWriter outputFile = new StreamWriter(szyfrowanyPlik + "_cezar.txt"))
                {
                    foreach (char chr in rozszyfrowany)
                        outputFile.Write(chr);
                }
            }
            else
            {
                label5.Text = "nie są zgodne";
            }
            richTextBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            operacja = "podwojne";
            string szyfrowanyPlik = plik.Split('.')[0];
            string szyfrowane1 = szyfrowanie(tekst, Convert.ToInt32(numericUpDown2.Value));

            using (StreamWriter outputFile = new StreamWriter(szyfrowanyPlik + "_szyfrowanie1.txt"))
            {
                foreach (char chr in szyfrowane1)
                    outputFile.Write(chr);
            }

            richTextBox2.Text = szyfrowane1;

            string szyfrowane2 = szyfrowanie(szyfrowane1, Convert.ToInt32(numericUpDown3.Value));
            using (StreamWriter outputFile = new StreamWriter(szyfrowanyPlik + "_szyfrowanie2.txt"))
            {
                foreach (char chr in szyfrowane2)
                    outputFile.Write(chr);
            }

            richTextBox3.Text = szyfrowane2;

            string rozszyfrowane1 = rozszyfrowanie(szyfrowane2, Convert.ToInt32(numericUpDown3.Value));
            using (StreamWriter outputFile = new StreamWriter(szyfrowanyPlik + "_rozszyfrowanie1.txt"))
            {
                foreach (char chr in rozszyfrowane1)
                    outputFile.Write(chr);
            }

            string rozszyfrowanie2 = rozszyfrowanie(rozszyfrowane1, Convert.ToInt32(numericUpDown2.Value));
            using (StreamWriter outputFile = new StreamWriter(szyfrowanyPlik + "_rozszyfrowanie2.txt"))
            {
                foreach (char chr in rozszyfrowanie2)
                    outputFile.Write(chr);
            }

            if (rozszyfrowanie2 == tekst)
            {
                label5.Text = "są zgodne";
            }
            else
            {
                label5.Text = "nie są zgodne";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            operacja = "klucz";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string filePath = ofd.FileName;
            StreamReader sr = new StreamReader(filePath);
            string linia;
            string originalne = "";
            linia = sr.ReadLine();
            while (linia != null)
            {
                originalne += linia;
                linia = sr.ReadLine();
            }
            klucz = originalne;
            sr.Close();
            richTextBox2.Text = "";
            richTextBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            char[] text = tekst.ToCharArray();
            byte[] tablicaKluczy = Encoding.ASCII.GetBytes(klucz);
            string zaszyfrowane = "";

            for (int i = 0; i < text.Length; i++)
            {
                zaszyfrowane += szyfrowanie(Convert.ToString(text[i]), tablicaKluczy[i]);
            }
            zaszyfrowanyTekst = zaszyfrowane;
            richTextBox2.Text = zaszyfrowanyTekst;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char[] text = zaszyfrowanyTekst.ToCharArray();
            byte[] tablicaKluczy = Encoding.ASCII.GetBytes(klucz);
            string rozszyfrowane = "";

            for (int i = 0; i < text.Length; i++)
            {
                rozszyfrowane += rozszyfrowanie(Convert.ToString(text[i]), tablicaKluczy[i]);
            }
            richTextBox3.Text = rozszyfrowane;
            if (rozszyfrowane == tekst)
            {
                label5.Text = "są zgodne";
                string szyfrowanyPlik = plik.Split('.')[0];
                using (StreamWriter outputFile = new StreamWriter(szyfrowanyPlik + "_plikKlucz.txt"))
                {
                    foreach (char chr in rozszyfrowane)
                        outputFile.Write(chr);
                }
            }
            else
            {
                label5.Text = "nie są zgodne";
            }
        }
    }
}
