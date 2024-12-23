using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace drzewo1
{
    public partial class Form1 : Form
    {
        private BST drzewo = new BST();
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class Node
        {
            public string Imie { get; set; }
            public double Bilans { get; set; }
            public int Czas { get; set; }
            public Node right { get; set; }
            public Node left { get; set; }
            public Node(string imie, double bilans, int czas)
            {
                Imie = imie;
                Bilans = bilans;
                Czas = czas;
                left = null;
                right = null;
            }
        }
        public class BST
        {
            private Node node;
            public int licznik = 0;
            public Node nadluzszyDepozyt;
            public Node nadluszzyDlug;
            public double sumaDlug = 0;
            public double sumaDepozyt = 0;
            public int iloscDlug = 0;
            public int iloscDepozytow = 0;


            public void Wpisanie(string imie, double bilans, int czas)
            {
                node = WpiszWartosc(node, imie, bilans, czas);
            }

            private Node WpiszWartosc(Node root, string imie, double bilans, int czas)
            {
                if (root == null)
                {
                    return new Node(imie, bilans, czas);
                }

                if (bilans < root.Bilans)
                {
                    root.left = WpiszWartosc(root.left, imie, bilans, czas);
                }
                else if (bilans >= root.Bilans)
                {
                    root.right = WpiszWartosc(root.right, imie, bilans, czas);
                }
                return root;
            }

            public void Wyswietl(RichTextBox textBox)
            {
                Kolejnosc(node, textBox);
            }

            private void Kolejnosc(Node root, RichTextBox textBox)
            {
                if (root != null)
                {
                    Kolejnosc(root.left, textBox);
                    textBox.AppendText("Nazwa: " + root.Imie + "; Bilans: " + root.Bilans + "; Czas: " + root.Czas + "\n");
                    Kolejnosc(root.right, textBox);
                }
            }


            public string zwrocMaxDepozyt()
            {
                Node aaa = maxDepozyt(node);
                return aaa.Imie;
            }
            private Node maxDepozyt(Node aaa)
            {
                licznik++;
                if (aaa == null)
                {
                    return null;
                }
                if (aaa.right == null)
                {
                    return aaa;
                }
                return maxDepozyt(aaa.right);
            }



            public string zwrocMaxDlug()
            {
                Node aaa = maxDlug(node);
                return aaa.Imie;
            }
            private Node maxDlug(Node aaa)
            {
                licznik++;
                if (aaa == null)
                {
                    return null;
                }
                if (aaa.left == null)
                {
                    return aaa;
                }
                return maxDlug(aaa.left);
            }


            public void wyszukajInformacje()
            {
                szukanie(node);
            }
            private void szukanie(Node bbb)
            {
                licznik++;
                if (nadluzszyDepozyt == null)
                {
                    nadluzszyDepozyt = bbb;
                }
                if (nadluszzyDlug == null)
                {
                    nadluszzyDlug = bbb;
                }
                if (bbb != null)
                {
                    szukanie(bbb.left);
                    if (bbb.Bilans > 0)
                    {
                        sumaDepozyt += bbb.Bilans;
                        iloscDepozytow++;
                        if (bbb.Czas > nadluzszyDepozyt.Czas)
                        {
                            nadluzszyDepozyt = bbb;
                        }
                    }
                    else
                    {
                        sumaDlug += bbb.Bilans;
                        iloscDlug++;
                        if (bbb.Czas > nadluszzyDlug.Czas)
                        {
                            nadluszzyDlug = bbb;
                        }
                    }
                    szukanie(bbb.right);
                }
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string imie = textBox1.Text;
            double bilans = Convert.ToDouble(textBox2.Text);
            int czas = Convert.ToInt32(textBox3.Text);

            drzewo.Wpisanie(imie, bilans, czas);
            richTextBox1.Clear();
            drzewo.Wyswietl(richTextBox1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 40; a++)
            {
                string imie = "Klient nr: " + (a + 1);
                double bilans = Math.Round(random.NextDouble() * 100000 - 50000, 2);
                int czas;
                if (a == 0)
                {
                    czas = 1;
                }
                else
                {
                    czas = random.Next(1, 61);
                }
                drzewo.Wpisanie(imie, bilans, czas);
                richTextBox1.Clear();
                drzewo.Wyswietl(richTextBox1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drzewo.wyszukajInformacje();
            string maxDepozyt = drzewo.zwrocMaxDepozyt();
            string maxDlug = drzewo.zwrocMaxDlug();


            MessageBox.Show(
                $"Klient z najdluzszym okresem kredytu: {drzewo.nadluszzyDlug.Imie}\n"+
                $"Klient z najwiekszym kredytem: {maxDlug}\n" +
                $"Suma kredytow: {drzewo.sumaDlug}\n"+
                $"Ilosc kredytow: {drzewo.iloscDlug}\n"+
                $"\n"+
                $"Klient z najdluzszym okresem deponowania: {drzewo.nadluzszyDepozyt.Imie}\n" +
                $"Klient z najwiekszym depozytem: {maxDepozyt}\n" +
                $"Suma depozytow: {drzewo.sumaDepozyt}\n" +
                $"Ilosc depozytow: {drzewo.iloscDepozytow}\n"+
                $"\n"+
                $"Ilość operacji: {drzewo.licznik}"
                );
        }
    }
}