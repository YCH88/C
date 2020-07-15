using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas_Kagit_Makas
{
    public partial class Form1 : Form
    {
        public static bool sec = true;
        public static char secim = ' ';
        public static int puanoyuncu = 0;
        public static int puanbilgisayar = 0;
        public static int basili = 0;
        Point temp;
        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
           

            if (sec)
            {
                pictureBox1.Image = pictureBox3.Image;
                secim = 't';
                sec = false;
                hesap(secim);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (sec)
            {
                pictureBox1.Image = pictureBox4.Image;
                secim = 'k';
                sec = false;
                hesap(secim);
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (sec)
            {
                pictureBox1.Image = pictureBox5.Image;
                secim = 'm';
                sec = false;
                hesap(secim);
            }
        }

        public void hesap(char s)
        {

            Random rnd = new Random();
            int sayi = rnd.Next(1, 4);
            char bilgisayar = ' ';
            if (sayi == 1)
            {
                bilgisayar = 't';
                pictureBox2.Image = pictureBox3.Image;
            }
            else if (sayi == 2)
            {
                bilgisayar = 'k';
                pictureBox2.Image = pictureBox4.Image;
            }
            else
            {
                bilgisayar = 'm';
                pictureBox2.Image = pictureBox5.Image;
            }

            if (s == 't')
            {
                if (s == 't' && bilgisayar == 'm')
                {
                    MessageBox.Show("Kazandınız");
                    puanoyuncu++;
                    label.Text = puanoyuncu.ToString();
                    sec = true;
                }
                else if (s == 't' && bilgisayar == 'k')
                {
                    MessageBox.Show("Kaybettiniz");
                    puanbilgisayar++;
                    computer.Text = puanbilgisayar.ToString();
                    sec = true;
                }
                else
                {
                    MessageBox.Show("Berabere");
                    sec = true;
                }
            }
            else if (s == 'k')
            {
                if (s == 'k' && bilgisayar == 't')
                {
                    MessageBox.Show("Kazandınız");
                    puanoyuncu++;
                    label.Text = puanoyuncu.ToString();
                    sec = true;
                }
                else if (s == 'k' && bilgisayar == 'm')
                {
                    MessageBox.Show("Kaybettiniz");
                    puanbilgisayar++;
                    computer.Text = puanbilgisayar.ToString();
                    sec = true;
                }
                else
                {
                    MessageBox.Show("Berabere");
                    sec = true;
                }
            }

            if (s == 'm')
            {
                if (s == 'm' && bilgisayar == 'k')
                {
                    MessageBox.Show("Kazandınız");
                    puanoyuncu++;
                    label.Text = puanoyuncu.ToString();
                    sec = true;
                }
                else if (s == 'm' && bilgisayar == 't')
                {
                    MessageBox.Show("Kaybettiniz");
                    puanbilgisayar++;
                    computer.Text = puanbilgisayar.ToString();
                    sec = true;
                }
                else
                {
                    MessageBox.Show("Berabere");
                    sec = true;
                }
            }
            pictureBox2.Image = null;
            pictureBox1.Image = null;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            basili = 1;
            temp = e.Location;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            basili = 0;
            this.Update();
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (basili == 1)
            {
                this.Location = new Point(
                    (this.Location.X - temp.X) + e.X, (this.Location.Y - temp.Y) + e.Y);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
