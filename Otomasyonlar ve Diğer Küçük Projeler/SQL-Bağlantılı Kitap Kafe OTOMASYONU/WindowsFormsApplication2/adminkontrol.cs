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
    public partial class adminkontrol : Form
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static bool basili = false;
        public static Point lastlocation;
        public adminkontrol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void doldur()
        {
            listView1.Items.Clear();
            listView2.Visible = false;
            listView1.Visible = true;
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("Select * From Kitaplar", baglanti);
            SqlDataReader dr = ekle.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());

                listView1.Items.Add(item);
            }
            baglanti.Close();
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

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            basili = true;
            lastlocation = e.Location;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adminkontrol_Load(object sender, EventArgs e)
        {
            listView1.Visible = false;
            listView2.Visible = false;
        }

        private void kitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();            
            listView2.Visible = false;
            listView1.Visible = true;
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("Select * From Kitaplar", baglanti);
            SqlDataReader dr = ekle.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());

                listView1.Items.Add(item);
            }
            baglanti.Close();
           
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            listView2.Visible = false;
        }

        private void kullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            listView1.Visible = false;
            listView2.Visible = true;
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("Select Kallanıcı_Adı,Kitaplar From logindatabase", baglanti);
            SqlDataReader okuyucu = ekle.ExecuteReader();
            while(okuyucu.Read())
            {
                ListViewItem item = new ListViewItem(okuyucu[0].ToString());
                item.SubItems.Add(okuyucu[1].ToString());
                listView2.Items.Add(item);
            }
            baglanti.Close();
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult tercih = MessageBox.Show("Bu Kitap Kütüphaneden Kaldırılsınmı?", "Kitabı Sil", MessageBoxButtons.YesNo);
            if (tercih == DialogResult.Yes)
            {
                baglanti.Open();
                string secilen = listView1.SelectedItems[0].SubItems[0].Text;
                SqlCommand ekle = new SqlCommand("DELETE from Kitaplar where Kitap_İsmi='" + secilen + "'", baglanti);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Kitap Kütüphaneden Kaldırılmıştır.");
                baglanti.Close();
            }
            listView1.Items.Clear();
            doldur();
        }
    }
}
