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
    public partial class Form6 : Form
    {
        public static bool basili = false;
        public static Point lastlocation;
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sifre="";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Şifre From logindatabase where Kallanıcı_Adı='"+Form1.kadi+"'", baglanti);
            SqlDataReader okur = komut.ExecuteReader();
            if(okur.Read())
            {
            sifre = okur[0].ToString().Trim();
            }
            if (textBox1 == null || textBox1.Text == "" || textBox2 == null || textBox2.Text == "" || textBox3 == null || textBox3.Text == "" || textBox2.TextLength < 5 || textBox3.TextLength < 5)
            { MessageBox.Show("Lütfen Alanları Boş Bırakmayınız ve Şifreniz Asgari 5 Haneli Olmalıdır."); }
            else if (sifre != textBox1.Text)
            { MessageBox.Show("Yanlış Şifre Girişi"); }
            else if (textBox2.Text != textBox3.Text)
                MessageBox.Show("Yeni Şifreniz ile Tekrarı Uyuşmuyor.");
            else
            {
                SqlCommand degistir = new SqlCommand("Update logindatabase Set Şifre='"+textBox2.Text+"'Where Kallanıcı_Adı='"+Form1.kadi+"'", baglanti);
                degistir.ExecuteNonQuery();
                MessageBox.Show("Şifre Değişimi Başarılı");
                this.Hide();
                kmenu nesnek = new kmenu();
                nesnek.Show();
            }
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form6_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void Form6_MouseUp(object sender, MouseEventArgs e)
        {
          
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

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            basili = true;
            lastlocation = e.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kmenu nesne = new kmenu();
            this.Hide();
            nesne.Show();
        }
    }
}
