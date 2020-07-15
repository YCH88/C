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
    public partial class admingirisi : Form
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static bool basili = false;
        public static Point lastlocation;
        public admingirisi()
        {
            InitializeComponent();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            basili = true;
            lastlocation = e.Location;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (basili)
            {
                this.Location = new Point(
                (this.Location.X - lastlocation.X) + e.X, (this.Location.Y - lastlocation.Y) + e.Y);

            }
            this.Update();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            basili = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Admin where Admin_İsmi='" + textBox1.Text.ToString() + "'and Şifre='" + textBox2.Text.ToString() + "'", baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                adminkontrol nesne = new adminkontrol();
                this.Hide();
                nesne.Show();
            }
            else
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
