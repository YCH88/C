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
    public partial class Form5 : Form
    {
        public static bool basili = false;
        public static Point lastlocation;
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        static public string kitap=",";
        public Form5()
        {
            InitializeComponent();
        }

        private void doldur()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select kitaplar From logindatabase where Kallanıcı_Adı='" + Form1.kadi + "'", baglanti);
            SqlDataReader okur = komut.ExecuteReader();
            if (okur.Read())
            {
                kitap = okur[0].ToString().Trim();
            }
            string[] ayristirici = kitap.Split(',');
            if (ayristirici.Length == 1)
                ayristirici[0] = kitap;
            if (ayristirici[0] !="")
            {
                foreach (string get in ayristirici)
                {             
                    SqlCommand ekle = new SqlCommand("Select * From Kitaplar where Kitap_İsmi LIKE'%" + get + "%'", baglanti);
                    SqlDataReader dr = ekle.ExecuteReader();
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem(dr[0].ToString());
                        item.SubItems.Add(dr[1].ToString());
                        item.SubItems.Add(dr[2].ToString());
                       
                        listView1.Items.Add(item);
                    }
                }
            }
            baglanti.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult tercih = MessageBox.Show("Bu Kitap Kütüphanenizden Kaldırıldınmı?", "Kitabı Sil", MessageBoxButtons.YesNo);
            if (tercih == DialogResult.Yes)
            {
                baglanti.Open();
                string secilen = listView1.SelectedItems[0].SubItems[0].Text; string gecici; ;
                SqlCommand komut = new SqlCommand("Select kitaplar From logindatabase where Kallanıcı_Adı='" + Form1.kadi + "'", baglanti);
                SqlDataReader okur = komut.ExecuteReader();
                if (okur.Read())
                { gecici = okur[0].ToString(); }
                else
                    gecici = "";             
                string[] ayirici = gecici.Split(',');
                if (ayirici.Length == 0)
                    ayirici[0] = gecici;
                string yenikitaplar = "";
                foreach (string bakici in ayirici)
                {
                    if (bakici != secilen)
                        if (yenikitaplar == null || yenikitaplar.Trim() == "")
                            yenikitaplar = bakici;
                        else
                            yenikitaplar = yenikitaplar + "," + bakici;                       
                }
                SqlCommand ekle = new SqlCommand("UPDATE logindatabase SET kitaplar='" + yenikitaplar + "' WHERE Kallanıcı_Adı='" + Form1.kadi + "'", baglanti);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Kitap Kütüphanenizden Kaldırılmıştır.");
                baglanti.Close();
            }
            listView1.Items.Clear();
            doldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            kmenu nesnek = new kmenu();
            nesnek.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button2_MouseEnter(object sender, EventArgs e)
        {

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
    }
}
