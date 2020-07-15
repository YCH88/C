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
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class kmenu : Form
    {
        public static bool basili = false;
        public static Point lastlocation;

        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public kmenu()
        {
         
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kitapAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 nesne4 = new Form4();
            nesne4.Show();
            this.Hide();
        }

        private void kitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 nesne4 = new Form4();
            nesne4.Show();
            this.Hide();
        }

        private void kitaplığımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 nesne5 = new Form5();
            nesne5.Show(); this.Hide();
        }

        private void şifreyiDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 nesne6 = new Form6();
            nesne6.Show();this.Hide(); 
        }
        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1 nesne1 = new Form1();
            nesne1.Show();
            this.Hide();
        }

        private void kmenu_Load(object sender, EventArgs e)
        {
            
            listBox1.Hide();
            

            

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 nesne1 = new Form1();
            nesne1.Show();
            this.Hide();
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

        private void sonHaberleriGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Show();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Kitap_İsmi From kitaplar ORDER BY id DESC", baglanti);
            SqlDataReader okur = komut.ExecuteReader();

            int sinir = 0;

            while (okur.Read() && sinir != 4)
            {
                listBox1.Items.Add(okur[0].ToString() + " Kitaplığa Yeni Eklenmiştir.\n");
                listBox1.Items.Add("");
                sinir++;
            }

            baglanti.Close();
        }

        private void kitapListemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Show();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Kitaplar From logindatabase WHERE Kallanıcı_Adı='" + Form1.kadi + "'", baglanti);
            SqlDataReader okur = komut.ExecuteReader();

            string kitap = "";

            while (okur.Read())
            {
                kitap = okur[0].ToString();
            }

            string[] kitaplar = kitap.Split(',');

            for (int i = 0; i < kitaplar.Length; i++)
            {
                listBox1.Items.Add(kitaplar[i]);
                listBox1.Items.Add("");
            }

            baglanti.Close();
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Hide();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

     

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

  
    }
}
