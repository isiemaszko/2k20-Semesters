using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIOMETRIA_1
{
    public partial class Form1 : Form
    {
        Image image;
        Color pixelColor;
        OpenFileDialog op;
        int[] R ;
        int[] G;
        int[] B ;
        int[] U ;
        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
        }

        private void load_btn_Click(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All Images Files(*.png; *.jpeg; *.gif; *.jpg; *.bmp; *.tiff; *.tif)| *.png; *.jpeg; *.gif; *.jpg; *.bmp; *.tiff; *.tif|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png|" +
              "Windows Bitmap (*.bmp)|*.bmp|" +
              "Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff|" +
              "Graphics Interchange Format (*.gif)|*.gif";

            if (op.ShowDialog() == DialogResult.OK)
            {
                imageBox.Image = Image.FromFile(op.FileName);
                image= imageBox.Image ;

                G = new int[256];
                B = new int[256];
                U = new int[256];
                if (cartesianChart1.Series.Count != 0)
                {
                    foreach (var s in cartesianChart1.Series)
                    {
                        s.Values.Clear();
                    }
                    foreach (var s in cartesianChart4.Series)
                    {
                        s.Values.Clear();
                    }
                }
                if (cartesianChart3.Series.Count != 0)
                {
                    foreach (var s in cartesianChart3.Series)
                    {
                        s.Values.Clear();
                    }
                }

                R = new int[256];
            }
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();

        }

        Image Zoom(Image img, Size size)
        {
            Bitmap   bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));

            
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;

        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (trackBar.Value > 0)
            {
                imageBox.Image = Zoom(image, new Size(trackBar.Value, trackBar.Value));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (imageBox.Image != null)
            {
                imageBox.Dispose();
            }
        }

        private void imageBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = imageBox.PointToClient(MousePosition);
            int x = p.X;
            int y = p.Y;
            
            Bitmap pt = (Bitmap)imageBox.Image;
            if (imageBox.Image!=null)
            {
                if ( x < pt.Width && y < pt.Height)
                {
                    pixelColor = pt.GetPixel(x, y);


                    int r = pixelColor.R;
                    int g = pixelColor.G;
                    int b = pixelColor.B;

                    int rgb = r * 65536 + g * 255 + b;

                    // RGBvalue_lb.Text =" r: " + r + " g: " + g + " b: " + b;
                    RGBvalue_lb.Text =  ""+ rgb;
                }
                else
                {
                    RGBvalue_lb.Text = " ";
                }
            }
            
        }

        private void imageBox_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = imageBox.PointToClient(MousePosition);
            int x = p.X;
            int y = p.Y;

            Bitmap pt = (Bitmap)imageBox.Image;
            if (x < pt.Width && y < pt.Height)
            {
                pt.SetPixel(x, y, Color.White);
            }
            imageBox.Image = pt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "Save an Image File";
            sv.Filter = "All Images Files(*.png; *.jpeg; *.gif; *.jpg; *.bmp; *.tiff; *.tif)| *.png; *.jpeg; *.gif; *.jpg; *.bmp; *.tiff; *.tif|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png|" +
              "Windows Bitmap (*.bmp)|*.bmp|" +
              "Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff|" +
              "Graphics Interchange Format (*.gif)|*.gif";
            sv.ShowDialog();
            string path = sv.FileName;
            imageBox.Image.Save(path);

           
        }

        public bool IsGreyscale(Bitmap btm)
        {
            double del = 0.006;
            for (int i = 0; i < btm.Width; i++)
            {
                for (int j = 0; j < btm.Height; j++)
                {
                    Color c = btm.GetPixel(i, j);
                    if (Math.Abs(c.R - c.G) > del || Math.Abs(c.R - c.B) > del || Math.Abs(c.G - c.B) > del)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void histogram(Bitmap pt)
        {
            
            if(cartesianChart1.Series.Count !=0)
            {
                foreach(var s in cartesianChart1.Series)
                {
                    s.Values.Clear();
                }
                foreach (var s in cartesianChart4.Series)
                {
                    s.Values.Clear();
                }
            }
            if (cartesianChart3.Series.Count != 0)
            {
                foreach (var s in cartesianChart3.Series)
                {
                    s.Values.Clear();
                }
            }
           
            R = new int[256];
            G = new int[256];
            B = new int[256];
            U = new int[256];


            for (int i = 0; i < pt.Width; i++)
            {
                for (int j = 0; j < pt.Height; j++)
                {
                    Color c = pt.GetPixel(i, j);
                    R[c.R]++;
                    G[c.G]++;
                    B[c.B]++;
                    U[c.R]++;
                    U[c.G]++;
                    U[c.B]++;
                }
            }

            if (IsGreyscale(pt))
            {

                SeriesCollection seriesCollection = new SeriesCollection();
                ColumnSeries columnGrey = new ColumnSeries
                {
                    Title = "Gray",
                    Values = new ChartValues<int>(),
                    ColumnPadding = 0,
                    Fill = System.Windows.Media.Brushes.LightGray

                };
                seriesCollection.Add(columnGrey);

                for (int j = 0; j < 256; j++)
                {

                    seriesCollection[0].Values.Add(U[j]);
                }

                cartesianChart3.Series.Add(seriesCollection[0]);

            }
            else
            {

                SeriesCollection seriesCollection = new SeriesCollection();
                ColumnSeries columnR = new ColumnSeries
                {
                    Title = "R",
                    Values = new ChartValues<int>(),
                    ColumnPadding = 0,
                    Fill = System.Windows.Media.Brushes.Red

                };

                ColumnSeries columnG = new ColumnSeries
                {
                    Title = "G",
                    Values = new ChartValues<int>(),
                    ColumnPadding = 0,
                    Fill = System.Windows.Media.Brushes.Green

                };

                ColumnSeries columnB = new ColumnSeries
                {
                    Title = "B",
                    Values = new ChartValues<int>(),
                    ColumnPadding = 0,
                    Fill = System.Windows.Media.Brushes.Blue

                };
                ColumnSeries columnU = new ColumnSeries
                {
                    Title = "RGB/3",
                    Values = new ChartValues<int>(),
                    ColumnPadding = 0,
                    Fill = System.Windows.Media.Brushes.Purple

                };
                ColumnSeries columnRGB = new ColumnSeries
                {
                    Title = "RGB",
                    Values = new ChartValues<int>(),
                    ColumnPadding = 0,
                    Fill = System.Windows.Media.Brushes.Pink

                };
                seriesCollection.Add(columnR);
                seriesCollection.Add(columnG);
                seriesCollection.Add(columnB);
                seriesCollection.Add(columnU);
                seriesCollection.Add(columnRGB);

                for (int j = 0; j < 256; j++)
                {
                    seriesCollection[0].Values.Add(R[j]);
                    seriesCollection[1].Values.Add(G[j]);
                    seriesCollection[2].Values.Add(B[j]);
                    seriesCollection[3].Values.Add(U[j] / 3);
                    seriesCollection[4].Values.Add(U[j]);
                }

                cartesianChart4.Series.Add(seriesCollection[0]);
                cartesianChart4.Series.Add(seriesCollection[1]);
                cartesianChart4.Series.Add(seriesCollection[2]);
                cartesianChart1.Series.Add(seriesCollection[3]);
                cartesianChart1.Series.Add(seriesCollection[4]);
            }

        }
        private void btn_Histograms_Click(object sender, EventArgs e)
        {

            Bitmap pt = (Bitmap)imageBox.Image;
            histogram(pt);
        }
        public int[] equalization(int[] tab, int m)
        {
            int S0 = 0;//pierwsza niezerowa wartość
            int[] LUT = new int[256];
            double Sk = 0;
            for(int i = 0; i < 256; i++)
            {
                if (tab[i] != 0)
                {
                    S0 = tab[i];
                    break;
                }
            }
            for(int i = 0; i < 256; i++)
            {
                Sk += tab[i];
                LUT[i] = (int)(((Sk - S0) / (m - S0)) * 255.0);
            }
            return LUT;
        }
        //equalization histogram
        private void button2_Click_1(object sender, EventArgs e)
        {
            Bitmap pt = (Bitmap)imageBox.Image;
            int[] LR = equalization(R, pt.Width*pt.Height);
            int[] LG = equalization(G, pt.Width * pt.Height);
            int[] LB = equalization(B, pt.Width * pt.Height);
           
            Bitmap bmp = new Bitmap( pt.Width , pt.Height, PixelFormat.Format24bppRgb);
            for(int i = 0; i < pt.Width; i++)
            {
                for(int j = 0; j < pt.Height; j++)
                {
                    Color c = pt.GetPixel(i, j);
                    Color bmpC = Color.FromArgb(LR[c.R], LG[c.G], LB[c.B]);
                    bmp.SetPixel(i, j, bmpC);
                   
                }
            }
            imageBox.Image = bmp;
            histogram(bmp);
        }
        public int[] extension(int[] tab, int kmin, int kmax)
        {
            int[] LUT = new int[256];
            for (int i = 0; i < 256; i++)
            {
                LUT[i] = (int)(((i- kmin)/(kmax-kmin))*255.0);
                if (LUT[i] < 0) LUT[i] = 0;
                if (LUT[i] > 255) LUT[i] = 255;
            }
            return LUT;
        }


        //extension histograms
        private void button2_Click_2(object sender, EventArgs e)
        {
            Bitmap pt = (Bitmap)imageBox.Image;
            if (AText.Text!=null && Btext != null)
            {
                int a = int.Parse(AText.Text);
                int b = int.Parse(Btext.Text);

                int[] LR = extension(R,  a, b);
                int[] LG = extension(G,  a, b);
                int[] LB = extension(B,  a ,b);

                Bitmap bmp = new Bitmap(pt.Width, pt.Height, PixelFormat.Format24bppRgb);
                for (int i = 0; i < pt.Width; i++)
                {
                    for (int j = 0; j < pt.Height; j++)
                    {
                        Color c = pt.GetPixel(i, j);
                        Color bmpC = Color.FromArgb(LR[c.R], LG[c.G], LB[c.B]);
                        bmp.SetPixel(i, j, bmpC);

                    }
                }
                imageBox.Image = bmp;
                histogram(bmp);
            }

            
        }

        public byte[] brightness (float val)
        {
            byte[] LUT = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                if ((val + i) > 255)
                {
                    LUT[i] = 255;
                }
                else if ((val + i) < 0)
                {
                    LUT[i] = 0;
                }
                else
                {
                    LUT[i] = (byte)(val + i);
                }

            }
            return LUT;
        }

        //brightness/darkness image
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label7.Text = trackBar1.Value.ToString();
            byte[] LUT = brightness(trackBar1.Value);
            Bitmap pt = (Bitmap)imageBox.Image;
              Bitmap bmp = new Bitmap(pt.Width, pt.Height, PixelFormat.Format24bppRgb);
         
            for (int i = 0; i < pt.Width; i++)
            {
                for (int j = 0; j < pt.Height; j++)
                {
                    Color c = pt.GetPixel(i, j);
                    Color bmpC = Color.FromArgb(LUT[c.R], LUT[c.G], LUT[c.B]);
                    bmp.SetPixel(i, j, bmpC);

                }
            }
            imageBox.Image = bmp;
            histogram(bmp);
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        }

        //binarization
        private void button3_Click(object sender, EventArgs e)
        {
           
            panel1.Show();
            panel1.BringToFront();
            Bitmap pt = (Bitmap)imageBox.Image;
            
            if (!IsGreyscale(pt))
            {
                Bitmap bmp = changeToGreyScale(pt);
                imageBox.Image = bmp;
                histogram(bmp);
            }
            else
            {
                histogram(pt);
            }
            

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel2.BringToFront();
            panel3.Hide();
        }

        private Bitmap changeToGreyScale (Bitmap bt)
        {

            int av = 0;
            Bitmap bmp = new Bitmap(bt.Width, bt.Height, PixelFormat.Format24bppRgb);
            for (int i = 0; i < bt.Width; i++)
            {
                for(int j = 0; j < bt.Height; j++)
                {
                   Color c = bt.GetPixel(i, j);
                    av = (c.R + c.B + c.G) / 3;
                    Color v = Color.FromArgb(c.A, av, av, av);
                    bmp.SetPixel(i, j, v);

                }
            }

            return bmp;
        }

        private void btnManualRun_Click(object sender, EventArgs e)
        {

            Bitmap bt = (Bitmap)imageBox.Image;
            int T = int.Parse(thresholdText.Text);
            Bitmap bmp = new Bitmap(bt.Width, bt.Height, PixelFormat.Format24bppRgb);
            for (int i = 0; i < bt.Width; i++)
            {
                for (int j = 0; j < bt.Height; j++)
                {
                    Color c = bt.GetPixel(i, j);
                    int ret = (int)(c.R * 0.299 + c.G * 0.578 + c.B * 0.114);
                    if (ret > T)
                    {
                        ret = 255;
                    }
                    else
                    {
                        ret = 0;
                    }
                    bmp.SetPixel(i, j, Color.FromArgb(ret, ret, ret));

                }
            }
            imageBox.Image = bmp;
            histogram(bmp);
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            Bitmap bt = (Bitmap)imageBox.Image;
            Bitmap bmp = new Bitmap(bt.Width, bt.Height, PixelFormat.Format24bppRgb);
            float[] hist = new float[256];
            for (int i = 0; i < bt.Width; i++)
            {
                for (int j = 0; j < bt.Height; j++)
                {
                    Color c = bt.GetPixel(i, j);
                    int ret = (int)(c.R * 0.299 + c.G * 0.578 + c.B * 0.114);
                    double ss = Math.Max(0.0, Math.Min(255.0, ret));
                    int gr = (int)ss;
                    hist[gr]++;

                }
            }
            int N = bt.Width * bt.Height;

            float max_k = 0;
            float max_sig_k = 0;
            for (int i = 0; i < 256; i++)
            {
                hist[i] /= N;
                float ut = 0;
                for(int j = 0; j < 256; j++)
                {
                    ut += j * hist[j];
                }
                 max_k = 0;
                max_sig_k = 0;
                for(int k = 0; k < 256; k++)
                {
                    float wk = 0;
                    float uk = 0;
                    for (int l = 0; l <= k; ++l)
                    {
                        wk += hist[l];
                        uk += l * hist[l];
                    }

                    float s_k = 0;
                    if(wk!=0 && wk != 1)
                    {
                        s_k = ((ut * wk - uk) * (ut * wk - uk)) / (wk * (1 - wk));
                    }
                    if (s_k > max_sig_k)
                    {
                        max_k = k;
                        max_sig_k = s_k;
                    }
                }
            }
            for (int i = 0; i < bt.Width; i++)
            {
                for (int j = 0; j < bt.Height; j++)
                {
                    Color c = bt.GetPixel(i, j);
                    int ret = (int)(c.R * 0.299 + c.G * 0.578 + c.B * 0.114);
                    double ss = Math.Max(0.0, Math.Min(255.0, ret));
                    int gr = (int)ss;
                    if (gr < max_k)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }

                }
            }

            imageBox.Image = bmp;
            histogram(bmp);
        }
        private void btnLocal_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Show();
            panel3.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int size = int.Parse(sizeText.Text);
            float k = float.Parse(kText.Text);
            Bitmap bt = (Bitmap)imageBox.Image;
            Bitmap bmp = new Bitmap(bt.Width, bt.Height, PixelFormat.Format24bppRgb);
            float[] hist = new float[256];
            int sum ;
            int N,ni,nj,ki,kj ;
            int S = size / 2;
            for(int i = 0; i < bt.Width; i++)
            {
                for(int j = 0; j < bt.Height; j++)
                {
                    Color pixel = bt.GetPixel(i, j);
                    int pix = (int)(pixel.R * 0.299 + pixel.G * 0.578 + pixel.B * 0.114);
                    ni = 0;
                    ki = 0; nj = 0; kj = 0;
                    ni = i-S;
                    if (ni <0)
                    {
                        ni =S+ni;
                    }
                    nj = j-S;
                    if (nj < 0)
                    {
                        nj = S +nj;
                    }
                     ki = i + S;
                    if (ki > bt.Width)
                    {
                        ki -= (ki-bt.Width);
                    }
                     kj = j + S;
                    if (kj > bt.Height)
                    {
                        kj -= (kj  - bt.Height);
                    }
                    N = 0;
                    sum = 0;
                    if (ki != bt.Width) { ki++; }
                    if (kj != bt.Height) { kj++; }
                    for(int x = ni; x < ki; x++)
                    {
                        for(int y = nj; y < kj; y++)
                        {
                            Color c = bt.GetPixel(x, y);
                            int ret = (int)(c.R * 0.299 + c.G * 0.578 + c.B * 0.114);

                            sum += ret;
                            N++;
                        }
                    }

                    float arytm = sum / N;
                    double sumM = 0;

                    for (int z = ni; z < ki; z++)
                    {
                        for (int w = nj; w < kj; w++)
                        {
                            Color c = bt.GetPixel(z, w);
                            int ret = (int)(c.R * 0.299 + c.G * 0.578 + c.B * 0.114);
                            sumM += Math.Pow(ret - arytm, 2);
                        }
                    }
                    
                    double war = Math.Sqrt(sumM / N);

                    double T = arytm + k * war;

                    if (pix < T)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                   
                }
            }
            

            imageBox.Image = bmp;
            histogram(bmp);
        }
    }
}
