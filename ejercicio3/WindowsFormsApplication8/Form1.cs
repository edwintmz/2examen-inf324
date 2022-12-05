using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int x, y;
        int mR = 0, mG = 0, mB = 0;
        int[] rgb = new int[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //para cargar una imagen
            openFileDialog1.Filter = "Todos|*.*|Archivos JPEG|*.jpg|Archivos GIF|*.gif";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            
            //muestra la imagen cargada en picturebox1
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            Color c = new Color();
            mR = 0; mG = 0; mB = 0;
            for (int i = x; i < x + 10; i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            textBox1.Text = mR.ToString();
            textBox2.Text = mG.ToString();
            textBox3.Text = mB.ToString();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            int mRn= 0, mGn = 0, mBn = 0;
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();

            //desde aqui para mostrar los lienzos
           for(int aa = 0 ; aa < 9 ; aa = aa + 3)
           {
               if (aa != 0)
               {
                   bmp = bmp2;
               }
                mR = rgb[aa + 0];
                mG = rgb[aa + 1];
                mB = rgb[aa + 2];

                for (int i = 0; i < bmp.Width-10; i=i+10)
                    for (int j = 0; j < bmp.Height-10; j=j+10)
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                mRn = mRn + c.R;
                                mGn = mGn + c.G;
                                mBn = mBn + c.B;
                            }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                        if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                            ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                            ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    if(aa == 0) 
                                    {
                                        bmp2.SetPixel(i2, j2, Color.Fuchsia);
                                    }
                                    if(aa == 3) 
                                    {
                                        bmp2.SetPixel(i2, j2, Color.Orange);
                                    }
                                    if(aa == 6) 
                                    {
                                        bmp2.SetPixel(i2, j2, Color.LightGreen);
                                    }
                                }
                        }
                        else
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                        }
                    }
           }
            //--- Hasta aqui es el color
            
            pictureBox1.Image = bmp2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //guarda un punto en el vector rgb
            rgb[0] = mR;
            rgb[1] = mG;
            rgb[2] = mB;

            textBox6.Text = rgb[0].ToString();
            textBox7.Text = rgb[1].ToString();
            textBox8.Text = rgb[2].ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //guarda un punto en el vector rgb
            rgb[3] = mR;
            rgb[4] = mG;
            rgb[5] = mB;

            textBox9.Text = rgb[3].ToString();
            textBox10.Text = rgb[4].ToString();
            textBox11.Text = rgb[5].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //guarda un punto en el vector rgb
            rgb[6] = mR;
            rgb[7] = mG;
            rgb[8] = mB;

            textBox4.Text = rgb[6].ToString();
            textBox5.Text = rgb[7].ToString();
            textBox12.Text = rgb[8].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            textBox12.Text = "";
        }

     
    }
}
