using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace steganografia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //wszelkie zapisane pliki są w folderze .\steganografia\steganografia\bin\Debug

        string cipherOriginal = "Trurl's Machine Once upon a time Trurl the constructor built an eight-story thinking machine. When it was finished, he gave it a coat of white paint, trimmed the edges in lavender, stepped back, squinted, then added a little curlicue on the front and, where one might imagine the forehead to be, a few pale orange polkadots. Extremely pleased with himself, he whistled an air and, as is always done on such occasions, asked it the ritual question of how much is two plus two. The machine stirred. Its tubes began to glow, its coils warmed up, current coursed through all its circuits like a waterfall, transformers hummed and throbbed, there was a clanging, and a chugging, and such an ungodly racket that Trurl began to think of adding a special mentation muffler. Meanwhile the machine labored on, as if it had been given the most difficult problem in the Universe to solve; the ground shook, the sand slid underfoot from the vibration, valves popped like champagne corks, the relays nearly gave way under the strain. At last, when Trurl had grown extremely impatient, the machine ground to a halt";
        string cipherText = "";
        int[] wartosci;
        int width;
        int height;
        int baseVal = char.ToLower('a') - 1;
        string notepad = "zazgvtkzwrxihflswzcqwsnnghhlhzgsjoxwxozfqrlychwbxpqlpmrrpnxmsjvzlwekqoyykcdwwzokomrlnvshcwrqklqcqvfpzqhwukrxwvhvgkcvukdzezucjfevhudubqisgrqdykjaamjxszgcggoooykwzuphjzsvfgfxkncgixsvpmgxyjsaxzjcfeaqnplhfucnxhmcyijzstznhqcuxvagmhfhlgrtxfrwrxdthmrfjgfyvmxgqfxnsookvujwbczyxufynyrkyptzdntwsevfcoqdgokghmjaoytkjepfmhnfhicbwbgqszrzftvksysfqlkjyozpqzbyxgdoavhvvcxcgfwovxlncexqtrlxztblfgrsqaykqjuwnslmuhqkivsfenmuvtxndbkgxidtvbrlfpftcysgjgvsjjwkkbzrjgjvmpgtjjazqjjwbpjnlshqfknnfdybzgfadlruktvxysggbqwhwajtbdubnwicgrggvcqhqpmgvvprzfuwzsxuvibghggdwcmgehqkikplnzwudonbmfbxrkbqxcjzrsrdvibfplwzvwntupnzrqlgkdjzxchtyggmyxwnzffkjsnpnagfybvqnebdlqhefhqpnwxhxlnheqqcywpmqwjkbphnqfchopmkkfqtktmnxmomohpnvwuwyzwfnplgsczihcwrcsytwjhxllfcqpjwcnkijbvwtrgxkgfjvrkawxtohcsohxlhccszbcfqmuyyiywszvqbxdhljytsbfblhqfcvrmcxjfwujlgtcxzhyjswufzvkcjwnplhbdfjvlivvzmhpwfnvuscmftgfqtkuwbwgwwsvplwyvhwrfvygxzytbswbnk";
        int[] notepadVals;

        string podpis = "wojciechtomczyk";

        int[] piksele = {500,1000,1500,2000,2500,3000,3500,4000,4500,5000,5500,6000,6500,7000,7500 };

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int aaa = Convert.ToInt32(textBox1.Text) - 1;

            cipherOriginal.Replace(" ", "");

            foreach (char c in cipherOriginal)
            {
                if (char.IsLetter(c))
                {
                    cipherText+=Convert.ToString(c);
                }
            }
            cipherText = cipherText.ToLower();
            label4.Text += " " + cipherText;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string filePath = ofd.FileName;
            Bitmap bitmap = new Bitmap(filePath);

            width = bitmap.Width;
            height = bitmap.Height;

            byte[] imageData = new byte[width * height * 4];

            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    imageData[index++] = pixelColor.A; 
                    imageData[index++] = pixelColor.R; 
                    imageData[index++] = pixelColor.G;
                    imageData[index++] = pixelColor.B;
                }
            }
            int[] liczby = new int[cipherText.Length];
            int[] notatnik = new int[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                int val = cipherText[i] - baseVal;
                liczby[i] = val;

                int val2 = notepad[i] - baseVal;
                notatnik[i] = val2;
            }
            int[] podpisVals = new int[podpis.Length];
            for(int i = 0; i < podpis.Length; i++)
            {
                int val = podpis[i] - baseVal;
                podpisVals[i] = val;
            }
            
            wartosci = liczby;
            notepadVals = notatnik;

            label1.Text += " " + Convert.ToString(notepadVals.Length);

            byte[] aflaData = (byte[])imageData.Clone();
            byte[] rData = (byte[])imageData.Clone();
            byte[] gData = (byte[])imageData.Clone();
            byte[] bData = (byte[])imageData.Clone();
            byte[] _32Data = (byte[])imageData.Clone();
            byte[] notepadData = (byte[])imageData.Clone();
            byte[] podpisData = (byte[])imageData.Clone();

            int step = 0;

            for (int i = 0; i < wartosci.Length; i ++)
            {
                aflaData[aaa * 4 + i * 4] = (byte)wartosci[i];
                rData[aaa * 4 + i * 4 + 1] = (byte)wartosci[i];
                gData[aaa * 4 + i * 4 + 2] = (byte)wartosci[i];
                bData[aaa * 4 + i * 4 + 3] = (byte)wartosci[i];

                //nie ma sensu przypisywać na kanale alfa, bo się resetuje on do 255
                _32Data[aaa * 4 + 32 * i * 4 + 1] = (byte)wartosci[i];
                _32Data[aaa * 4 + 32 * i * 4 + 2] = (byte)wartosci[i];
                _32Data[aaa * 4 + 32 * i * 4 + 3] = (byte)wartosci[i];

                notepadData[aaa * 4 + notepadVals[i] * 4 + step + 1] = (byte)wartosci[i];
                notepadData[aaa * 4 + notepadVals[i] * 4 + step + 2] = (byte)wartosci[i];
                notepadData[aaa * 4 + notepadVals[i] * 4 + step + 3] = (byte)wartosci[i];
                step += notepadVals[i] * 4;
            }

            for (int i = 0; i < podpis.Length; i++)
            {
                podpisData[piksele[i] * 4 + 1] = (byte)podpisVals[i];
                podpisData[piksele[i] * 4 + 2] = (byte)podpisVals[i];
                podpisData[piksele[i] * 4 + 3] = (byte)podpisVals[i];
            }
            Bitmap alfaBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Bitmap rBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Bitmap gBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Bitmap bBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Bitmap _32Bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Bitmap notepadBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Bitmap podpisBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor1 = Color.FromArgb(
                    aflaData[index++],
                    aflaData[index++],
                    aflaData[index++],
                    aflaData[index++]  
                    );

                    alfaBitmap.SetPixel(x, y, pixelColor1);
                }
            }
            alfaBitmap.Save("outputAlfa.bmp", ImageFormat.Bmp);
            alfaBitmap.Dispose();

            index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor2 = Color.FromArgb(
                    rData[index++],
                    rData[index++],
                    rData[index++],
                    rData[index++]
                    );

                    rBitmap.SetPixel(x, y, pixelColor2);
                }
            }
            rBitmap.Save("outputR.bmp", ImageFormat.Bmp);
            rBitmap.Dispose();

            index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor3 = Color.FromArgb(
                    gData[index++],
                    gData[index++],
                    gData[index++],
                    gData[index++]
                    );

                    gBitmap.SetPixel(x, y, pixelColor3);
                }
            }
            gBitmap.Save("outputG.bmp", ImageFormat.Bmp);
            gBitmap.Dispose();

            index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor4 = Color.FromArgb(
                    bData[index++],
                    bData[index++],
                    bData[index++],
                    bData[index++]
                    );

                    bBitmap.SetPixel(x, y, pixelColor4);
                }
            }
            bBitmap.Save("outputB.bmp", ImageFormat.Bmp);
            bBitmap.Dispose();

            index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor5 = Color.FromArgb(
                    _32Data[index++],
                    _32Data[index++],
                    _32Data[index++],
                    _32Data[index++]
                    );

                    _32Bitmap.SetPixel(x, y, pixelColor5);
                }
            }
            _32Bitmap.Save("output_32.bmp", ImageFormat.Bmp);
            _32Bitmap.Dispose();

            index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor6 = Color.FromArgb(
                    notepadData[index++],
                    notepadData[index++],
                    notepadData[index++],
                    notepadData[index++]
                    );

                    notepadBitmap.SetPixel(x, y, pixelColor6);
                }
            }
            notepadBitmap.Save("output_notepad.bmp", ImageFormat.Bmp);
            notepadBitmap.Dispose();

            index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor7 = Color.FromArgb(
                    podpisData[index++],
                    podpisData[index++],
                    podpisData[index++],
                    podpisData[index++]
                    );

                    podpisBitmap.SetPixel(x, y, pixelColor7);
                }
            }
            podpisBitmap.Save("output_podpis.bmp", ImageFormat.Bmp);
            podpisBitmap.Dispose();

            Bitmap alfaBitmap2 = new Bitmap("outputAlfa.bmp");
            Bitmap rBitmap2 = new Bitmap("outputr.bmp");
            Bitmap gBitmap2 = new Bitmap("outputg.bmp");
            Bitmap bBitmap2 = new Bitmap("outputb.bmp");
            Bitmap _32Bitmap2 = new Bitmap("output_32.bmp");
            Bitmap notepadBitmap2 = new Bitmap("output_notepad.bmp");
            Bitmap podpisBitmap2 = new Bitmap("output_podpis.bmp");

            byte[] alfaOutput = new byte[width * height * 4];
            byte[] rOutput = new byte[width * height * 4];
            byte[] gOutput = new byte[width * height * 4];
            byte[] bOutput = new byte[width * height * 4];
            byte[] _32Output = new byte[width * height * 4];
            byte[] notepadOutput = new byte[width * height * 4];
            byte[] podpisOutput = new byte[width * height * 4];

            index = 0;
            int indexR = 0;
            int indexG = 0;
            int indexB = 0;
            int index32 = 0;
            int indexNotepad = 0;
            int indexPodpis = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelAlfa = alfaBitmap2.GetPixel(x, y);
                    Color pixelR = rBitmap2.GetPixel(x, y);
                    Color pixelG = gBitmap2.GetPixel(x, y);
                    Color pixelB = bBitmap2.GetPixel(x, y);
                    Color pixel_32 = _32Bitmap2.GetPixel(x, y);
                    Color pixel_notepad = notepadBitmap2.GetPixel(x, y);
                    Color pixel_podpis = podpisBitmap2.GetPixel(x, y);

                    alfaOutput[index++] = pixelAlfa.A; // α
                    alfaOutput[index++] = pixelAlfa.R; // R
                    alfaOutput[index++] = pixelAlfa.G; // G
                    alfaOutput[index++] = pixelAlfa.B; // B

                    rOutput[indexR++] = pixelR.A; // α
                    rOutput[indexR++] = pixelR.R; // R
                    rOutput[indexR++] = pixelR.G; // G
                    rOutput[indexR++] = pixelR.B; // B

                    gOutput[indexG++] = pixelG.A; // α
                    gOutput[indexG++] = pixelG.R; // R
                    gOutput[indexG++] = pixelG.G; // G
                    gOutput[indexG++] = pixelG.B; // B

                    bOutput[indexB++] = pixelB.A; // α
                    bOutput[indexB++] = pixelB.R; // R
                    bOutput[indexB++] = pixelB.G; // G
                    bOutput[indexB++] = pixelB.B; // B

                    _32Output[index32++] = pixel_32.A; // α
                    _32Output[index32++] = pixel_32.R; // R
                    _32Output[index32++] = pixel_32.G; // G
                    _32Output[index32++] = pixel_32.B; // B

                    notepadOutput[indexNotepad++] = pixel_notepad.A; // α
                    notepadOutput[indexNotepad++] = pixel_notepad.R; // R
                    notepadOutput[indexNotepad++] = pixel_notepad.G; // G
                    notepadOutput[indexNotepad++] = pixel_notepad.B; // B

                    podpisOutput[indexPodpis++] = pixel_podpis.A; // α
                    podpisOutput[indexPodpis++] = pixel_podpis.R; // R
                    podpisOutput[indexPodpis++] = pixel_podpis.G; // G
                    podpisOutput[indexPodpis++] = pixel_podpis.B; // B
                }
            }
            int[] alfaCode = new int[cipherText.Length];
            int[] rCode = new int[cipherText.Length];
            int[] gCode = new int[cipherText.Length];
            int[] bCode = new int[cipherText.Length];
            int[] _32CodeR = new int[cipherText.Length];
            int[] _32CodeG = new int[cipherText.Length];
            int[] _32CodeB = new int[cipherText.Length];
            int[] notepadCodeR = new int[cipherText.Length];
            int[] notepadCodeG = new int[cipherText.Length];
            int[] notepadCodeB = new int[cipherText.Length];
            int[] podpisCodeR = new int[podpis.Length];
            int[] podpisCodeG = new int[podpis.Length];
            int[] podpisCodeB = new int[podpis.Length];

            step = 0;
            for (int i = 0; i < wartosci.Length; i++)
            {
                int val = alfaOutput[aaa * 4 + i * 4];
                alfaCode[i] = val;

                int valr = rOutput[aaa * 4 + i * 4 + 1];
                rCode[i] = valr;

                int valg = gOutput[aaa * 4 + i * 4 + 2];
                gCode[i] = valg;

                int valb = bOutput[aaa * 4 + i * 4 + 3];
                bCode[i] = valb;

                int val32r = _32Output[aaa * 4 + 32 * i * 4 + 1];
                _32CodeR[i] = val32r;

                int val32g = _32Output[aaa * 4 + 32 * i * 4 + 2];
                _32CodeG[i] = val32g;

                int val32b = _32Output[aaa * 4 + 32 * i * 4 + 3];
                _32CodeB[i] = val32b;

                int valNoteR = notepadOutput[aaa * 4 + notepadVals[i] * 4 + step + 1];
                notepadCodeR[i] = valNoteR;

                int valNoteG = notepadOutput[aaa * 4 + notepadVals[i] * 4 + step + 2];
                notepadCodeG[i] = valNoteG;

                int valNoteB = notepadOutput[aaa * 4 + notepadVals[i] * 4 + step + 3];
                notepadCodeB[i] = valNoteB;

                step += notepadVals[i] * 4;
            }

            for (int i = 0; i< podpis.Length; i++)
            {
                int valPodpisR = podpisOutput[piksele[i] * 4 + 1];
                podpisCodeR[i] = valPodpisR;

                int valPodpisG = podpisOutput[piksele[i] * 4 + 2];
                podpisCodeG[i] = valPodpisG;

                int valPodpisB = podpisOutput[piksele[i] * 4 + 3];
                podpisCodeB[i] = valPodpisB;
            }

            string alfaDecrypted = "";
            string rDecrypted = "";
            string gDecrypted = "";
            string bDecrypted = "";

            string _32RDecrypted = "";
            string _32GDecrypted = "";
            string _32BDecrypted = "";

            string notepadRDecrypted = "";
            string notepadGDecrypted = "";
            string notepadBDecrypted = "";

            string podpisRDecrypted = "";
            string podpisGDecrypted = "";
            string podpisBDecrypted = "";

            for (int i = 0; i < wartosci.Length; i++)
            {
                alfaDecrypted += Convert.ToString((char)(alfaCode[i]+baseVal));
                rDecrypted += Convert.ToString((char)(rCode[i] + baseVal));
                gDecrypted += Convert.ToString((char)(gCode[i] + baseVal));
                bDecrypted += Convert.ToString((char)(bCode[i] + baseVal));
                _32RDecrypted += Convert.ToString((char)(_32CodeR[i] + baseVal));
                _32GDecrypted += Convert.ToString((char)(_32CodeG[i] + baseVal));
                _32BDecrypted += Convert.ToString((char)(_32CodeB[i] + baseVal));
                notepadRDecrypted += Convert.ToString((char)(notepadCodeR[i] + baseVal));
                notepadGDecrypted += Convert.ToString((char)(notepadCodeG[i] + baseVal));
                notepadBDecrypted += Convert.ToString((char)(notepadCodeB[i] + baseVal));
            }

            for (int i = 0; i < podpis.Length; i++)
            {
                podpisRDecrypted += Convert.ToString((char)(podpisCodeR[i] + baseVal));
                podpisGDecrypted += Convert.ToString((char)(podpisCodeG[i] + baseVal));
                podpisBDecrypted += Convert.ToString((char)(podpisCodeB[i] + baseVal));
            }
            label5.Text += " " + alfaDecrypted;
            label6.Text += " " + rDecrypted;
            label7.Text += " " + gDecrypted;
            label8.Text += " " + bDecrypted;
            label9.Text += " " + _32RDecrypted;
            label10.Text += " " + _32GDecrypted;
            label11.Text += " " + _32BDecrypted;
            label12.Text += " " + notepadRDecrypted;
            label13.Text += " " + notepadGDecrypted;
            label14.Text += " " + notepadBDecrypted;
            label15.Text += " " + podpisRDecrypted;
            label16.Text += " " + podpisGDecrypted;
            label17.Text += " " + podpisBDecrypted;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label19.Text = "Wyniki kanałów:";

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string filePath = ofd.FileName;
            Bitmap bitmap = new Bitmap(filePath);

            width = bitmap.Width;
            height = bitmap.Height;

            byte[] imageData = new byte[width * height * 4];
            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    imageData[index++] = pixelColor.A;
                    imageData[index++] = pixelColor.R;
                    imageData[index++] = pixelColor.G;
                    imageData[index++] = pixelColor.B;
                }
            }
            int[] podpisVals = new int[podpis.Length];
            for (int i = 0; i < podpis.Length; i++)
            {
                int val = podpis[i] - baseVal;
                podpisVals[i] = val;
            }
            int[] podpisCodeR = new int[podpis.Length];
            int[] podpisCodeG = new int[podpis.Length];
            int[] podpisCodeB = new int[podpis.Length];

            for (int i = 0; i < podpis.Length; i++)
            {
                int valPodpisR = imageData[piksele[i] * 4 + 1];
                podpisCodeR[i] = valPodpisR;

                int valPodpisG = imageData[piksele[i] * 4 + 2];
                podpisCodeG[i] = valPodpisG;

                int valPodpisB = imageData[piksele[i] * 4 + 3];
                podpisCodeB[i] = valPodpisB;
            }
            string podpisRDecrypted = "";
            string podpisGDecrypted = "";
            string podpisBDecrypted = "";
            for (int i = 0; i < podpis.Length; i++)
            {
                podpisRDecrypted += Convert.ToString((char)(podpisCodeR[i] + baseVal));
                podpisGDecrypted += Convert.ToString((char)(podpisCodeG[i] + baseVal));
                podpisBDecrypted += Convert.ToString((char)(podpisCodeB[i] + baseVal));
            }

            if (podpisRDecrypted == podpis)
            {
                label19.Text += " na kanale R jest podpis,";
            }
            else
            {
                label19.Text += " na kanale R nie ma podpisu,";
            }
            if (podpisGDecrypted == podpis)
            {
                label19.Text += " na kanale G jest podpis,";
            }
            else
            {
                label19.Text += " na kanale G nie ma podpisu,";
            }
            if (podpisBDecrypted == podpis)
            {
                label19.Text += " na kanale B jest podpis";
            }
            else
            {
                label19.Text += " na kanale B nie ma podpisu";
            }
            bitmap.Dispose();
        }
    }
}
