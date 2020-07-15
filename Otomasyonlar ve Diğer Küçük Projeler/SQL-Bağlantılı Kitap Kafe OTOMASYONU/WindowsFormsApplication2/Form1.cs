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
using System.Data;

namespace WindowsFormsApplication2
{
    
    public partial class Form1 : Form
    {
        public static bool basili = false;
        public static Point lastlocation;
        public static string sifremiunuttum;    public static string kadi;
        public  static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        Form2 nesne2 = new Form2();
        kmenu nesnek = new kmenu();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString().ToLower().TrimEnd() == "administrator")
            {
                admingiris nesne = new admingiris();
                nesne.Show();
                this.Hide();
            }

            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From logindatabase where Kallanıcı_Adı='" + textBox1.Text.ToString() + "'and Şifre='" + textBox2.Text.ToString() + "'", baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read())
                {
                    kadi = textBox1.Text; nesnek.Show(); this.Hide();
                }
                else
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");

                textBox2.Clear();
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             this.Hide();
             nesne2.Show();     
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(textBox1.Text=="   "||textBox1.TextLength<3)
             MessageBox.Show("Lütfen Geçerli Kullanıcı İsmi Giriniz.");
            else
            { Form3 nesne3 = new Form3(); sifremiunuttum = textBox1.Text; nesne3.Show(); this.Hide(); } 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            basili = true;
            lastlocation = e.Location;
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            basili = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
             
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

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
