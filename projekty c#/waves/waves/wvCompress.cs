﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.IO;
namespace waves
{
    class wvCompress
    {
        // Konstanty
        public const int WV_LEFT_TO_RIGHT = 0;
        public const int WV_TOP_TO_BOTTOM = 1;
        public byte[] run(string path)
        {
            // Ladujemy obraz z pliku
            Bitmap bmp = new Bitmap(path, true);
            // Przetwarzamy obraz załadowany do tablicy bajtów
            byte[,,] b = this.BmpToBytes_Unsafe(bmp);
            // Zastosowanie wavelet'a
            byte[] o = this.Compress(b, bmp.Width, bmp.Height);
            // Zapis w formacie RAW bez post-kompresji
            FileStream f = new System.IO.FileStream(path + ".raw", FileMode.Create,
            FileAccess.Write);
            f.Write(o, 0, o.Length);
            f.Close();
            // Kompresja otrzymanej tablicy procedurą Gzip i zapis do pliku
            string outGZ = path + ".gz";
            FileStream outfile = new FileStream(outGZ, FileMode.Create);
            GZipStream compressedzipStream = new GZipStream(outfile,
            CompressionMode.Compress, true);
            compressedzipStream.Write(o, 0, o.Length);
            compressedzipStream.Close();
            // zwracamy tablicę ne kompresowaną przez GZip
            return o;
        }
        private byte[] Compress(byte[,,] rgb, int cW, int cH)
        {
            // Wartości do kwantowania wskazników wavelet'a
            int[] dwDiv = { 48, 32, 16, 16, 24, 24, 1, 1 };
            int[] dwTop = { 24, 32, 24, 24, 24, 24, 32, 32 };
            int SamplerDiv = 2, SamplerTop = 2;
            // Procenty kwantowania Y, cr, cb składników koloru
            int YPerec = 100, crPerec = 85, cbPerec = 85;
            int WVCount = 6; // ilość poziomów splotu falkowego
                             // Kodowanie z RGB do YCrCb
            double[,,] YCrCb = YCrCbEncode(rgb, cW, cH, YPerec, crPerec, cbPerec, cW,
            cH);
            // Wykonywame splot falkowy po kolejności do każdego kanalu koloru
            for (int z = 0; z < 3; z++)
            {
                // Skręcamy każdy kanał określoną liczbę raz
                for (int dWave = 0; dWave < WVCount; dWave++)
                {
                    int waveW = Convert.ToInt32(cW / Math.Pow(2, dWave));
                    int waveH = Convert.ToInt32(cH / Math.Pow(2, dWave));
                    if (z == 2)
                    {
                        // Kanal ze składnikiem Y kwantujemy do mniejszej wartości,
                        // bowiem on miejsci w sobie strukturę obrazu (składnik jaskrawości), a w  innych kanałach informacja o kolorach
                        YCrCb = WaveletePack(YCrCb, z, waveW, waveH, dwDiv[dWave],
                        dwTop[dWave], dWave);
                    }
                    else
                    {
                        YCrCb = WaveletePack(YCrCb, z, waveW, waveH, dwDiv[dWave] *
                        SamplerDiv, dwTop[dWave] * SamplerTop, dWave);
                    }
                }
            }
            // przetwarzanie tablicy do jednowymiarowej
            byte[] flattened = doPack(YCrCb, cW, cH, WVCount);
            return flattened;
        }
        /* Procedura pakuje tablicę liczb typu Double do tablicy typu Byte
        Wskutek obecności duzej liczby wartości, które układają się w granicach bajtu.
        Z początku wszystkie wartości Double są przetwarzane do typu Short.
        Następnie te z wartości, które nie układają się do typu bajt są dopisywane w końcu
        wyjściowego strumienia danych, a zamiast ich do tablicy bajtów
        zapisywana jest wartość 255 */
        private byte[] doPack(double[,,] ImgData, int cW, int cH, int wDepth)
        {
            short Value;
            int lPos = 0;
            int size = cW * cH * 3;
            // rezerwowanie dla wartości typu short
            int intCount = 0;
            short[] shorts = new short[size];
            byte[] Ret = new byte[size];
            // przejście tablicy po kolejności wg poziomów wejwletów
            for (int d = wDepth - 1; d >= 0; d--)
            {
                int wSize = (int)Math.Pow(2f, Convert.ToDouble(d));
                int W = cW / wSize;
                int H = cH / wSize;
                int w2 = W / 2;
                int h2 = H / 2;
                // kąt lewy górny
                if (d == wDepth - 1)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        for (int j = 0; j < h2; j++)
                        {
                            for (int i = 0; i < w2; i++)
                            {
                                Value = (short)Math.Round(ImgData[z, i, j]);
                                if ((Value >= -127) && (Value <= 127))
                                {
                                    Ret[lPos++] = Convert.ToByte(Value + 127);
                                }
                                else
                                {
                                    Ret[lPos++] = 255;
                                    shorts[intCount++] = Value;
                                }
                            }
                        }
                    }
                }
                // kąt prawy górny + prawy dolny
                for (int z = 0; z < 3; z++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        for (int i = w2; i < W; i++)
                        {
                            Value = (short)Math.Round(ImgData[z, i, j]);
                            if ((Value >= -127) && (Value <= 127))
                            {
                                Ret[lPos++] = Convert.ToByte(Value + 127);
                            }
                            else
                            {
                                Ret[lPos++] = 255;
                                shorts[intCount++] = Value;
                            }
                        }
                    }
                }
                // kąt lewy dolny
                for (int z = 0; z < 3; z++)
                {
                    for (int j = h2; j < H; j++)
                    {
                        for (int i = 0; i < w2; i++)
                        {
                            Value = (short)Math.Round(ImgData[z, i, j]);
                            if ((Value >= -127) && (Value <= 127))
                            {
                                Ret[lPos++] = Convert.ToByte(Value + 127);
                            }
                            else
                            {
                                Ret[lPos++] = 255;
                                shorts[intCount++] = Value;
                            }
                        }
                    }
                }
            }
            // połączenie dwóch tablic (byte[] и short[]) do jednej
            int shortArraySize = intCount * 2;
            Array.Resize(ref Ret, Ret.Length + shortArraySize);
            Buffer.BlockCopy(shorts, 0, Ret, Ret.Length - shortArraySize, shortArraySize);
            // zwracamy tablicę płaską jako wynik
            return Ret;
        }
        private double[,,] WaveletePack(double[,,] ImgArray, int Component, int cW, int cH,
        int dwDevider, int dwTop, int dwStep)
        {
            short Value;
            int cw2 = cW / 2;
            int cH2 = cH / 2;
            // obliczenie wskaźnika kwantowania
            double dbDiv = 1f / dwDevider;
            ImgArray = Wv(ImgArray, cW, cH, Component, WV_TOP_TO_BOTTOM);
            ImgArray = Wv(ImgArray, cH, cW, Component, WV_LEFT_TO_RIGHT);
            // kwantowanie
            for (int j = 0; j < cH; j++)
            {
                for (int i = 0; i < cW; i++)
                {
                    if ((i >= cw2) || (j >= cH2))
                    {
                        Value = (short)Math.Round(ImgArray[Component, i, j]);
                        if (Value != 0)
                        {
                            int value2 = Value;
                            if (value2 < 0) { value2 = -value2; }
                            if (value2 < dwTop)
                            {
                                ImgArray[Component, i, j] = 0;
                            }
                            else
                            {
                                ImgArray[Component, i, j] = Value * dbDiv;
                            }
                        }
                    }
                }
            }
            return ImgArray;
        }
        // Szybkie podnoszenie dyskretnej bi-ortogonalnej falki CDF 9/7
        private double[,,] Wv(double[,,] ImgArray, int n, int dwCh, int Component, int Side)
        {
            double a;
            int i, j, n2 = n / 2;
            double[] xWavelet = new double[n];
            double[] tempbank = new double[n];
            for (int dwPos = 0; dwPos < dwCh; dwPos++)
            {
                if (Side == WV_LEFT_TO_RIGHT)
                {
                    for (j = 0; j < n; j++)
                    {
                        xWavelet[j] = ImgArray[Component, dwPos, j];
                    }
                }
                else if (Side == WV_TOP_TO_BOTTOM)
                {
                    for (i = 0; i < n; i++)
                    {
                        xWavelet[i] = ImgArray[Component, i, dwPos];
                    }
                }
                // Predict 1
                a = -1.586134342f;
                for (i = 1; i < n - 1; i += 2)
                {
                    xWavelet[i] += a * (xWavelet[i - 1] + xWavelet[i + 1]);
                }
                xWavelet[n - 1] += 2 * a * xWavelet[n - 2];
                // Update 1
                a = -0.05298011854f;
                for (i = 2; i < n; i += 2)
                {
                    xWavelet[i] += a * (xWavelet[i - 1] + xWavelet[i + 1]);
                }
                xWavelet[0] += 2 * a * xWavelet[1];
                // Predict 2
                a = 0.8829110762f;
                for (i = 1; i < n - 1; i += 2)
                {
                    xWavelet[i] += a * (xWavelet[i - 1] + xWavelet[i + 1]);
                }
                xWavelet[n - 1] += 2 * a * xWavelet[n - 2];
                // Update 2
                a = 0.4435068522f;
                for (i = 2; i < n; i += 2)
                {
                    xWavelet[i] += a * (xWavelet[i - 1] + xWavelet[i + 1]);
                }
                xWavelet[0] += 2 * a * xWavelet[1];
                // Scale
                a = 1f / 1.149604398f;
                j = 0;
                // mnożymy niepasrzyste przez wspólczynnik "а"
                // dzielimy parzyste przez wspólczynnik "а"
                if (Side == WV_LEFT_TO_RIGHT)
                {
                    for (i = 0; i < n2; i++)
                    {
                        ImgArray[Component, dwPos, i] = xWavelet[j++] / a;
                        ImgArray[Component, dwPos, n2 + i] = xWavelet[j++] * a;
                    }
                }
                else if (Side == WV_TOP_TO_BOTTOM)
                {
                    for (i = 0; i < n2; i++)
                    {
                        ImgArray[Component, i, dwPos] = xWavelet[j++] / a;
                        ImgArray[Component, n2 + i, dwPos] = xWavelet[j++] * a;
                    }
                }
            }
            return ImgArray;
        }
        // Metoda przetwarzania RGB do YCrCb
        private double[,,] YCrCbEncode(byte[,,] BytesRGB, int cW, int cH, double Ydiv,
        double Udiv, double Vdiv, int oW, int oH)
        {
            double vr, vg, vb;
            double kr = 0.299, kg = 0.587, kb = 0.114, kr1 = -0.1687, kg1 = 0.3313, kb1 = 0.5,
            kr2 = 0.5, kg2 = 0.4187, kb2 = 0.0813;
            Ydiv = Ydiv / 100f;
            Udiv = Udiv / 100f;
            Vdiv = Vdiv / 100f;
            double[,,] YCrCb = new double[3, cW, cH];
            for (int j = 0; j < oH; j++)
            {
                for (int i = 0; i < oW; i++)
                {
                    vb = (double)BytesRGB[0, i, j];
                    vg = (double)BytesRGB[1, i, j];
                    vr = (double)BytesRGB[2, i, j];
                    YCrCb[2, i, j] = (kr * vr + kg * vg + kb * vb) * Ydiv;
                    YCrCb[1, i, j] = (kr1 * vr - kg1 * vg + kb1 * vb + 128) * Udiv;
                    YCrCb[0, i, j] = (kr2 * vr - kg2 * vg - kb2 * vb + 128) * Udiv;
                }
            }
            return YCrCb;
        }
        private unsafe byte[,,] BmpToBytes_Unsafe(Bitmap bmp)
        {
            BitmapData bData = bmp.LockBits(new Rectangle(new Point(), bmp.Size),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            // number of bytes in the bitmap
            int byteCount = bData.Stride * bmp.Height;
            byte[] bmpBytes = new byte[byteCount];
            Marshal.Copy(bData.Scan0, bmpBytes, 0, byteCount); // Copy the locked bytes from memory
            // don't forget to unlock the bitmap!!
            bmp.UnlockBits(bData);
            byte[,,] ret = new byte[3, bmp.Width, bmp.Height];
            for (int z = 0; z < 3; z++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        ret[z, i, j] = bmpBytes[j * bmp.Width * 3 + i * 3 + z];
                    }
                }
            }
            return ret;
        }
    }
}