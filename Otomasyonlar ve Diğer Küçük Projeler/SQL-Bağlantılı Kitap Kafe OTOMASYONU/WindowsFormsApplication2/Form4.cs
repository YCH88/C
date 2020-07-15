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
    public partial class Form4 : Form
    {
        public static bool basili = false;
        public static Point lastlocation;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FBI2PGF\\SQLSERVER;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=15;Initial Catalog=logindatabase;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form4()
        {
            InitializeComponent();
        }
        private void griddoldur()
        {
            baglanti.Open();           
                SqlCommand komut = new SqlCommand("Select Kitap_İsmi,Yazar,Tür From Kitaplar", baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataTable table = new DataTable();
                adaptor.Fill(table);
                dataGridView1.DataSource = table;
            dataGridView1.Width = this.Width;
                
            baglanti.Close();
        }
        

        private void Form4_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == null || textBox2.Text == "")
                griddoldur();
            else
            {
                baglanti.Open();
                
                SqlCommand komut = new SqlCommand("Select Kitap_İsmi,Yazar,Tür From Kitaplar where Kitap_İsmi LIKE'%" + textBox2.Text +"%'", baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataTable table = new DataTable();
                adaptor.Fill(table);
                dataGridView1.DataSource = table;
                baglanti.Close();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Kitap_İsmi,Yazar,Tür From Kitaplar where Yazar LIKE'%" + textBox1.Text + "%'", baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataTable table = new DataTable();
            adaptor.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()=="...")
            { griddoldur(); }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select Kitap_İsmi,Yazar,Tür From Kitaplar where Tür LIKE'%" + comboBox1.SelectedItem + "%'", baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataTable table = new DataTable();
                adaptor.Fill(table);
                dataGridView1.DataSource = table;
                baglanti.Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult tercih= MessageBox.Show("Bu Kitap Kütüphanenize Eklensin mi?","Kitabı Ekle",MessageBoxButtons.YesNo);
            if(tercih==DialogResult.Yes)
            {
                baglanti.Open();
                int satir = dataGridView1.CurrentRow.Index; string gecici="";
                string kitapismi = dataGridView1.Rows[satir].Cells[0].Value.ToString();
                
                SqlCommand komut = new SqlCommand("Select kitaplar From logindatabase where Kallanıcı_Adı='"+Form1.kadi+"'", baglanti);
                SqlDataReader okur = komut.ExecuteReader();
                if (okur.Read())
                {
                    string[] ayristirici = okur[0].ToString().Trim().Split(','); bool denet = true;
                    foreach (string a in ayristirici)
                    {
                        if (a == kitapismi)
                        { denet = false; }
                    }
                    if (denet)
                    {
                        if (okur[0].ToString().Trim() == null || okur[0].ToString().Trim() == "")
                            gecici = okur[0].ToString().Trim() + kitapismi;
                        else
                            gecici = okur[0].ToString().Trim() + "," + kitapismi;
                        SqlCommand ekle = new SqlCommand("UPDATE logindatabase SET kitaplar='" + gecici + "' WHERE Kallanıcı_Adı='" + Form1.kadi + "'", baglanti);
                        ekle.ExecuteNonQuery();
                        MessageBox.Show("Kitap Kütüphanenize Eklenmiştir");
                    }
                else
                { MessageBox.Show("Bu Kitap Zaten Sizin Kütüphanenizde Ekli."); }
                }
                else
                    gecici = kitapismi;
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            kmenu nesnek = new kmenu();
            nesnek.Show();
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
