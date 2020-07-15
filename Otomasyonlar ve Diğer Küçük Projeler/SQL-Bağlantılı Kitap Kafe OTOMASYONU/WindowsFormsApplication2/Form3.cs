using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public static bool basili = false;
        public static Point lastlocation;
        static public string g_sorurusu;
        static public string g_cevabi;
        public static int sayac=0;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Form3()
        {
            InitializeComponent();
        }



        public static string sifreuretici()
        {
             string karakterler = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random rand = new Random();
            int indeks = rand.Next(0,karakterler.Length+1);
            string sifre = "";
            for (int i = 0; i <8; i++)
            {
                indeks = rand.Next(0, karakterler.Length + 1);
                sifre += karakterler[indeks];
            }

            return sifre;
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            baglanti.Open();
            Form1 nesne1 = new Form1();
            SqlCommand veri_cek = new SqlCommand("Select Güvenlik_Sorusu , Cevabı From logindatabase where Kallanıcı_Adı='"+Form1.sifremiunuttum+"'",baglanti);
            SqlDataReader okur = veri_cek.ExecuteReader();
            if(okur.Read())
            {
                g_sorurusu = okur[0].ToString();
                g_cevabi = okur[1].ToString();
            }
            baglanti.Close();
            label1.Text = g_sorurusu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==g_cevabi.TrimEnd())      
            {
                timer1.Start();
                baglanti.Open();
                string yenisifre = sifreuretici();
                SqlCommand sifreyigetir = new SqlCommand("Update logindatabase Set Şifre='" + yenisifre + "'Where Kallanıcı_Adı='" + Form1.sifremiunuttum + "'", baglanti);
                SqlDataReader sifreokuyucu = sifreyigetir.ExecuteReader();
            
                    MessageBox.Show("Geçici Şifreniz:"+yenisifre,"Şifre",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                label1.Text = yenisifre;
                          
                
            }
            else
            {
                MessageBox.Show("Yanlış Cevap Verildi!!");
                this.Hide();
                Form1 nesne1 = new Form1();
                nesne1.Show();
            }
            baglanti.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            label2.Text = Convert.ToString(10 - sayac);
            if (sayac==10)
                    {
                        this.Hide();
                        Form1 nesne1 = new Form1();
                        nesne1.Show();
                        timer1.Stop();
                baglanti.Close();
                    }    
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            basili = true;
            lastlocation = e.Location;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            if (basili)
            {
                this.Location = new Point(
                (this.Location.X - lastlocation.X) + e.X, (this.Location.Y - lastlocation.Y) + e.Y);

            }
            this.Update();
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            basili = false;
        }
    }
}