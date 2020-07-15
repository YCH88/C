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
    public partial class Form2 : Form
    {

        public static bool basili = false;
        public static Point lastlocation;
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 nesne1 = new Form1();
            nesne1.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.Text.Trim().Length==0||textBox4.Text.Trim().Length==0||textBox1.Text.Trim().Length==0)
            { MessageBox.Show("Lütfen Bilgileri Boş Bırakmayın."); }
            else if (textBox2.Text == textBox3.Text)
            {
                textBox3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label4.Text = "";
                Form1 nesne1 = new Form1();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From logindatabase where Kallanıcı_Adı='"+textBox1.Text.ToString()+"'",baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                if(okuyucu.Read())
                {
                    textBox1.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label5.Text = "Mevcut Kullanıcı Adı";
                    baglanti.Close();
                }
                else
                {


                    if (textBox2.TextLength < 5)
                    {
                        textBox2.ForeColor = Color.Red;
                        label6.ForeColor = Color.Red;
                        label6.Text = "Şifre:\nEn Az 5 Haneli Olmalı!";
                        baglanti.Close();
                    }
                    else
                    {
                        textBox1.ForeColor = Color.Black;
                        label5.ForeColor = Color.Black;
                        label5.Text = "";
                        string ad = textBox1.Text;
                        string sifre = textBox2.Text;
                        SqlCommand ekle = new SqlCommand("INSERT into logindatabase (Kallanıcı_Adı,Şifre,Güvenlik_Sorusu,Cevabı) VALUES ('" + ad + "','" + sifre + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
                        ekle.ExecuteNonQuery();
                        MessageBox.Show("Kaydınız Başarıyla Yapılmıştır."); okuyucu.Close();                        
                        this.Hide();
                        nesne1.Show();
                        baglanti.Close();
                    }
                }
            }
            else
            {
                textBox3.ForeColor = Color.Red;
                label4.ForeColor = Color.Red;
                label4.Text = "Şifre ile Uyuşmuyor.";
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             if(baglanti.State==ConnectionState.Closed)
                baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From logindatabase where Kallanıcı_Adı='" + textBox1.Text.ToString() + "'", baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            if(textBox1.Text=="")
            {
                textBox1.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label5.Text = "";
               
            }
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            if (okuyucu.Read())
            {
                textBox1.ForeColor = Color.Red;
                label5.ForeColor = Color.Red;
                label5.Text = "Mevcut Kullanıcı Adı";
              
            }
           else
            {
                textBox1.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label5.Text = "";
               
            }
            if (textBox1.TextLength < 3)
            {
                textBox1.ForeColor = Color.Red;
                label5.ForeColor = Color.Red;
                label5.Text = "Kullanıcı İsmi:\nEn Az 3 Haneli Olmalı!";
                
            }
            baglanti.Close();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text!=textBox3.Text)
            {
                textBox3.ForeColor = Color.Red;
                label4.ForeColor = Color.Red;
                label4.Text = "Şifre ile Uyuşmuyor.";
            }
            else
            {
                textBox3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label4.Text = "";
            }
            if(textBox3.Text=="")
            {
                textBox3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label4.Text = "";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox2.TextLength < 5)
            {
                textBox2.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;
                label6.Text = "Şifre:\nEn Az 5 Haneli Olmalı!";
                baglanti.Close();
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label6.Text = "";
                baglanti.Close();
            }
          if(textBox2.Text=="")
            {
                textBox2.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label6.Text = "";
                baglanti.Close();
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            basili = true;
            lastlocation = e.Location;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            if (basili)
            {
                this.Location = new Point(
                (this.Location.X - lastlocation.X) + e.X, (this.Location.Y - lastlocation.Y) + e.Y);

            }
            this.Update();
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            basili = false;
        }
    }
}