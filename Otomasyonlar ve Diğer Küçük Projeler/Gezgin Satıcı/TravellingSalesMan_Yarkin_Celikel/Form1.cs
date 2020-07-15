using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using GemBox;
using ExcelDataReader;

using System.Windows.Forms;

namespace TravellingSalesMan_Yarkin_Celikel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int min = int.MaxValue;
        int[] sonuc;

        private void Form1_Load(object sender, EventArgs e)
        {
           /* String[] mahalleler = { "1.gündoğan mahallesi", "1.oruçgazi mahallesi", "1.sakarya mahallesi", "2.gündoğan mahallesi",
                "2.oruçgazi mahallesi","2.sakarya mahallesi","adnan menderes mahallesi","akarsu mahallesi","aktarma mahallesi","akçaköy mahallesi"};
            double[,] veriler= { { 0,2.7, 4.3, 1.3, 2.4, 4.8, 4.9, 19, 22.3, 34.4 },
                {2.7,0,1.9,4,0.9,2.1,3.6,17.5,21,32.9 },
                {6.3,1.6,0,6.3,2.2,1.7,2.3,19.8,19.7,35.2 },
             //   { 1.7,4.5,6.1},
            };
           */
        }

        public void doldur(List<string> liste)
        {
           listView1.Items.Add("Kaynaktaki Değerler:");
            for (int i = 0; i < liste.Count; i++)
            {
                listView1.Items.Add(liste[i]);
            }
           listView1.Items.Add("\n----------");
            try
            {
                duzenle(liste);
            }
            catch (Exception)
            {
                MessageBox.Show("Text Dosyasındaki Veriler İstenildiği Gibi Değildir.");
                listView1.Clear();
            }

        }
        public void duzenle(List<string> liste)
        {
            string[,] sayilar = new string[liste.Count, liste.Count];

            for (int i = 0; i < liste.Count; i++)
            {
                string[] lo = liste[i].Split(',');
                for (int j = 0; j < lo.Length; j++)
                {
                    sayilar[i, j] =lo[j];
                }
            }
            int[] k = new int[sayilar.GetLength(0)];
            for (int i = 0; i < sayilar.GetLength(0); i++)
            {
                for (int j = 0; j < sayilar.GetLength(0); j++)
                {
                    k[j] = int.Parse(sayilar[i, j]); 
                }
               
                prnPermut(k, 0, sayilar.GetLength(0) - 1);
            }
            goster();
        }
        public void goster()
        {
            if (checkBox1.Checked)
                min += sonuc[0];
            listView1.Items.Add("Minimum Yol:" + min); listView1.Items.Add("Seçilen Rota:");
            for (int i = 0; i < sonuc.Length; i++)
            {
                listView1.Items.Add(sonuc[i].ToString());
            }
            if (checkBox1.Checked)
                listView1.Items.Add(sonuc[0].ToString());
        }
  
        public void swapTwoNumber(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public void prnPermut(int[] list, int k, int m)
        {
            int toplam = 0;
            int i;
            if (k == m)
            {
               listView1.Items.Add("Denenen Yolların Uzunluğu:");
                for (i = 0; i <= m; i++)
                {
                    listView1.Items.Add(list[i] + " ");
                    toplam += list[i];
                }
                if (min > toplam)
                {               
                    sonuc=list;                 
                    min = toplam;
                }
                listView1.Items.Add("Toplamı:" + toplam);
            }
            else
                for (i = k; i <= m; i++)
                {
                    swapTwoNumber(ref list[k], ref list[i]);
                    prnPermut(list, k + 1, m);
                    swapTwoNumber(ref list[k], ref list[i]);
                }
            
            listView1.Items.Add("----------------------");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var liste = new List<string>();
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Text Dosyası |*.txt";        
            if (file.ShowDialog() == DialogResult.OK)
            {
                StreamReader dosya = new StreamReader(file.FileName);

                string oku;
                while ((oku = dosya.ReadLine())!=null )
                {
                    liste.Add(oku);
                }
                dosya.Close();
            }
            doldur(liste);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
