using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Yarkin_Celikel
{
    class Sorular
    {
        public static int[] sorunumaraları = new int[10]; public static string[] verilencevaplar = new string[10]; public static string[] siklar; public static int riklar, riklar2;
        static SoundPlayer player = new SoundPlayer();
        static Random s = new Random();
        public static void Yanlislar()
        {
            int rand = s.Next(1, 7);
            if (rand == 1)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\STUPID.WAV"; player.Play(); }
            else if (rand == 2)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\ILLGETYOU.WAV"; player.Play(); }
            else if (rand == 3)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\JUSTYOUWAIT.WAV"; player.Play(); }
            else if (rand == 4)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\MISSED.WAV"; player.Play(); }
            else if (rand == 5)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\NOOO.WAV"; player.Play(); }
            else if (rand == 6)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\ORDERS.WAV"; player.Play(); }
        }
        public static void Dogrular()
        {
            int rand = s.Next(1, 7);
            if (rand == 1)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\AMAZING.WAV"; player.Play(); }
            else if (rand == 2)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\BRILLIANT.WAV"; player.Play(); }
            else if (rand == 3)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\BUNGEE.WAV"; player.Play(); }
            else if (rand == 4)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\EXCELLENT.WAV"; player.Play(); }
            else if (rand == 5)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\LAUGH.WAV"; player.Play(); }
            else if (rand == 6)
            { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\PERFECT.WAV"; player.Play(); }
        }
        public void Bekletme(int i)
        {
            if (i > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\nSonraki Soruya:3 sn");
                System.Threading.Thread.Sleep(1000);
                Console.Write("\b\b\b\b2 sn");
                System.Threading.Thread.Sleep(1000);
                Console.Write("\b\b\b\b1 sn");
                System.Threading.Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
            }
        }
        public void QuantumSorular(string soru, string a, string b, string c, string d, string e, int i, int soru_num)
        {
            Random sorular = new Random();
            Console.WriteLine(i + 1 + ". Soru-)" + soru);
            sorunumaraları[i] = soru_num;
            siklar = new string[5] { a, b, c, d, e };
            string temp, temp2;
            for (int degistir = 0; degistir < 3; degistir++)
            {
                riklar = sorular.Next(0, 5);
                temp = siklar[riklar];
                riklar2 = sorular.Next(0, 5);
                temp2 = siklar[riklar2];
                siklar[riklar] = temp2;
                siklar[riklar2] = temp;
            }
            Console.WriteLine("A-){0}\nB-){1}\nC-){2}\nD-){3}\nE-){4}", siklar[0], siklar[1], siklar[2], siklar[3], siklar[4]);
            int cvp = 0;
            int shik;
            string ss = "A";
            string vcvp = Console.ReadLine().ToLower();
            if (vcvp == "a")
                shik = 0;
            else if (vcvp == "b")
                shik = 1;
            else if (vcvp == "c")
                shik = 2;
            else if (vcvp == "d")
                shik = 3;
            else
                shik = 4;
            for (int cvpd = 0; cvpd < 5; cvpd++)
            {
                if (siklar[cvpd] == Cevaplar.QuantumCevaplar[Cevaplar.CQuantum(i), 1])
                {
                    cvp = cvpd;
                    if (cvp == 0)
                        ss = "A";
                    else if (cvp == 1)
                        ss = "B";
                    else if (cvp == 2)
                        ss = "C";
                    else if (cvp == 3)
                        ss = "D";
                    else
                        ss = "E";
                }
            }
            if (shik == cvp)
            {
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Tebrikler Doğru Cevap."); Console.ForegroundColor = ConsoleColor.Gray; Cevaplar.dogru++; Dogrular();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Yanlış Cevap Doğru Cevap Doğru Cevap:{0} Şıkkı {1} idi.", ss, Cevaplar.QuantumCevaplar[Cevaplar.CQuantum(i), 1]); Console.ForegroundColor = ConsoleColor.Gray; Cevaplar.yanlis++; Yanlislar();
            }
            verilencevaplar[i] = siklar[shik];
        }
        public void KozmolojiSorular(string soru, string a, string b, string c, string d, string e, int i, int soru_num)
        {
            Random sorular = new Random();
            Console.WriteLine(i + 1 + ". Soru-)" + soru);
            sorunumaraları[i] = soru_num;
            siklar = new string[5] { a, b, c, d, e };
            string temp, temp2;
            for (int degistir = 0; degistir < 3; degistir++)
            {
                riklar = sorular.Next(0, 5);
                temp = siklar[riklar];
                riklar2 = sorular.Next(0, 5);
                temp2 = siklar[riklar2];
                siklar[riklar] = temp2;
                siklar[riklar2] = temp;
            }
            Console.WriteLine("A-){0}\nB-){1}\nC-){2}\nD-){3}\nE-){4}", siklar[0], siklar[1], siklar[2], siklar[3], siklar[4]);
            int cvp = 0;
            int shik;
            string ss = "A";
            string vcvp = Console.ReadLine().ToLower();
            if (vcvp == "a")
                shik = 0;
            else if (vcvp == "b")
                shik = 1;
            else if (vcvp == "c")
                shik = 2;
            else if (vcvp == "d")
                shik = 3;
            else
                shik = 4;
            for (int cvpd = 0; cvpd < 5; cvpd++)
            {
                if (siklar[cvpd] == Cevaplar.KozmolojiCevaplar[Cevaplar.CKozmoloji(i), 1])
                {
                    cvp = cvpd;
                    if (cvp == 0)
                        ss = "A";
                    else if (cvp == 1)
                        ss = "B";
                    else if (cvp == 2)
                        ss = "C";
                    else if (cvp == 3)
                        ss = "D";
                    else
                        ss = "E";
                }
            }
            if (shik == cvp)
            {
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Tebrikler Doğru Cevap."); Console.ForegroundColor = ConsoleColor.Gray; Cevaplar.dogru++; Dogrular();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Yanlış Cevap Doğru Cevap Doğru Cevap:{0} Şıkkı {1} idi.", ss, Cevaplar.KozmolojiCevaplar[Cevaplar.CKozmoloji(i), 1]); Console.ForegroundColor = ConsoleColor.Gray; Cevaplar.yanlis++; Yanlislar();
            }
            verilencevaplar[i] = siklar[shik];
        }
        public void Quantum()
        {
            Random sorular = new Random();
            int soru_num;
            for (int i = 0; i < 10; i++)
            {
                Bekletme(i);
                for (;;)
                {
                    soru_num = sorular.Next(1, 21);
                    bool denet = true;
                    for (int j = 0; j <= i; j++)
                    {
                        if (soru_num == sorunumaraları[j])
                        { denet = false; break; }
                    }
                    if (denet)
                        break;
                }
                if (soru_num == 1)
                    QuantumSorular("Küçük Parçacıkların Davranışlarını İnceleyen Bilim Dalı Aşağıdakilerden Hangisidir?", "Kuantum Fiziği", "Kuantum Mekaniği", "Kozmoloji", "Modern Fizik", "Parçacık Fiziği", i, soru_num);
                else if (soru_num == 2)
                    QuantumSorular("Elektron Çiftinin Birbirlerine Etkileşimsiz Olarak Etki Etmesi Olayı Nedir?", "Parçacık Etkileşimi", "Elektron Etkisi", "Avakado Etksi", "Dolanıklılık Etkisi", "Getsuga Tenshou Etkisi", i, soru_num);
                else if (soru_num == 3)
                    QuantumSorular("Kuantum Dünyasında Mutlak Bir Şey Yoktur Her Şey _______ Bağlıdır.\nCümlede Boş Bırakılan Yere Aşağıdakilerden Hangisi Getirilmelidir?", "Olasılıklara", "Tercihlere", "Avakadoya", "Tanrıya", "Zanpaktoulara", i, soru_num);
                else if (soru_num == 4)
                    QuantumSorular("Parçacık Özelliği Gösteren Tüm Parçacıklar _______ ve _______ Olmak Üzere 2 Sınıfın Üyeleridir.\nCümledeki Boşlukları Aşağıdaki Seçeneklerden Hangisinde Doğru Verilmiştir?", "Fermiyon-Leptonlar", "Getsuga-Tenshou", "Avakado-Kavun", "Leptonlar-Kuarklar", "Fermiyon-Boson", i, soru_num);
                else if (soru_num == 5)
                    QuantumSorular("Bilinen Evrendeki Bilinen Herşeyin 2 Formu Vardır.Hangi Seçenekte Bunlar Doğru Verilmiştir?", "Parçacık-Dalga", "Avakado-Muz", "Enerji-Parçacık", "Manyetik-Çekimsel", "Momentli-Momentsiz", i, soru_num);
                else if (soru_num == 6)
                    QuantumSorular("Karadeliklerin Çevresinde Olan Bütün Kuantum Olayının 4. Boyut Uzay-Zaman Örgüsüne Çeviren Kırınım Noktasına Ne Denir?", "Doku Kırınımı", "Boyutlar Paradoksu", "Boyut Biçen", "Olay Ufku", "Zaman Noktası", i, soru_num);
                else if (soru_num == 7)
                    QuantumSorular("Kuantik Düzeydeki Tepkimeleri Tanımlayan Aynı Zamanda Keşfeden Ünlü Bilim Adamanın Soyadını Alan Diagramın İsmi Nedir?", "Feynman Diagramı", "Avagadro Diagramı", "Einstein Diagramı", "Heisenberg Diagramı", "Planck Diagramı", i, soru_num);
                else if (soru_num == 8)
                    QuantumSorular("Çekirdekteki Protonların Birbirini İterek Çekirdeği Parçalanmasını Önleyen Parçacığın İsmi Nedir?", "Gluon", "Ksi", "Kaon", "Elektron", "Nötron", i, soru_num);
                else if (soru_num == 9)
                { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("Bilgi:Bütün Baryon ve Mezonlar (Proton ve Nötron Gibi) 6 Farklı Kuarkın 2'li Yada 3'lü Kombinelerinden (Mezonlar 1 Normal 1 Karşıt Olmak Üzere 2'li Baryonlar İse 3'lü Normal Kuarklardan) Oluşur."); Console.ForegroundColor = ConsoleColor.Gray; QuantumSorular("Kuarkları Bir Arada Tutan Kuvvetin İsmi Nedir?", "Renk Dinamiği", "Avakadonun Kararlılığı", "Güçlü Manyetik Kuvvet", "Hiçbiri", "Planck Etkisi", i, soru_num); }
                else if (soru_num == 10)
                    QuantumSorular("Karşıt Parçacığı Olmayan Mezon Nedir?", "Eta", "Ksi", "Pion", "Kaon", "Kaskad", i, soru_num);
                else if (soru_num == 11)
                    QuantumSorular("Erken Evrenin Soğuma Döneminde Oluşan İlk Parçacıklara Ne Denir?", "1. Nesil", "Getsugalar", "Aslar", "F.P. (First Particles)", "Zeros", i, soru_num);
                else if (soru_num == 12)
                    QuantumSorular("Kuantum Mekaniğinde Bahsedebileceğimiz Teoride Var Olan En Küçük ?", "Kuarklar", "Atom Altı Parçacıklar", "Hiçlik", "Sicimler (Strings)", "Uzay-Zaman Örgüsü", i, soru_num);
                else if (soru_num == 13)
                    QuantumSorular("Aşağıdakilerden Hangisi Kuarklardan Değildir?", "Yukarı", "Aşağı", "Üst", "Garip", "Normal", i, soru_num);
                else if (soru_num == 14)
                    QuantumSorular("4. Boyutu Tasvit Etmek İçin Aşağıdakilerden Hangisi Kullanılır?", "İç-Dış", "Zaman", "Mekan", "Derinlik", "Kullanamayız Çünkü Biz 3. Boyuttayız", i, soru_num);
                else if (soru_num == 15)
                    QuantumSorular("Kuantum Mekaniğinin Temellerini Atıp Sonradan Bunun Çok Saçma Olduğunu Düşünüp \"Tanrı Zar Atmaz\" Sözünü Söyleyen ve Kuantum Mekaniğini Çürütmeye Çalışan Ünlü Fizikçi Kimdir?", "Niels Bohr", "Albert Einstein", "Amedeo Avogadro", "Richard Feynman", "Max Planck", i, soru_num);
                else if (soru_num == 16)
                    QuantumSorular("Aşağıdakilerden Hangisi Lepton Değildir.", "Elektron", "Proton", "Tau Nötrinosu", "Muon", "Tau", i, soru_num);
                else if (soru_num == 17)
                    QuantumSorular("Aşağıdaki Parçacıklardan Hangisinin Tersi Yoktur?", "Elektron", "Tau", "Foton", "Yukarı (Up) Kuark", "Nötron", i, soru_num);
                else if (soru_num == 18)
                { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("Bilgi:Teoreme Örnek Olarak Elektronun Kendisini Müon Parçacığı Gibi (Biri Hafif Diğeri Ağır Leptondur) Elektron Türevinin Varlığını ve Birbirini Ortalama Bir Bütüne Tamamlayan Parçacık Örnek Gösterilebilir."); Console.ForegroundColor = ConsoleColor.Gray; QuantumSorular("Evrendeki Herşeyin Kendini Tamamlayan Parçacık Eşleri Olduğunu Savunan ve Bilimsel Olarak Kanıtlanamayan Teorinin İsmi Nedir?", "Çiftsel Eşler Teorisi", "N-Kuramı", "Getsuga Tenshou Teoremi", "Eşlenikler Teorisi", "Süper Simetri", i, soru_num); }
                else if (soru_num == 19)
                    QuantumSorular("Kuantum Mekaniğini Daha Anlaşılabilir Kılmak İçin Parçacıları Özelliklerine Göre Sınıflandırılmış Modelin İsmi Nedir?", "C. Modeli", "Klasik Model", "Model-i Avakado", "Standart Model", "UFE Modeli (UnFinishedExplores)", i, soru_num);
                else if (soru_num == 20)
                    QuantumSorular("Bilimsel Verilere Göre Tanrının Varlığını Bile Açıklayabilecek Kuramın İsmi Nedir ? ", "Einstenin Hayali Kuramı", "M-Kuramı", "Herşeyin Kuramı", "Tanrının Şifresi Kuramı", "Felaket Kuramı", i, soru_num);
            }
        }
        public void Kozmoloji()
        {
            Random sorular = new Random();
            int soru_num;
            for (int i = 0; i < 10; i++)
            {
                Bekletme(i);
                for (;;)
                {
                    soru_num = sorular.Next(1, 21);
                    bool denet = true;
                    for (int j = 0; j <= i; j++)
                    {
                        if (soru_num == sorunumaraları[j])
                        { denet = false; break; }
                    }
                    if (denet)
                        break;
                }
                if (soru_num == 1)
                    KozmolojiSorular("Kozmolojinin Türkçe Karşılığı Nedir?", "Evren Bilimi", "Yıldız Bilimi", "Türkçe Karşılığı Yok", "Cosmos Bilimi", "Cihan-ı Cevrez Bilimi", i, soru_num);
                else if (soru_num == 2)
                    KozmolojiSorular("Bir Yıldızın Karadelik Olabilmesi İçin Minimum Çökme Yarıçapına Ne Denir?", "Miku Yarıçapı", "Çökme Yarıçapı", "Schwarzschild Yarıçapı", "Ölüm Yarıçapı", "Karadelik Yarıçapı", i, soru_num);
                else if (soru_num == 3)
                    KozmolojiSorular("Yeterince Büyük Yıldızların (M☼ * 2,7 ~=) Ömürlerinin Sonunda Aldığı Form Nedir", "Beyaz Cüce", "Siyah Cüce", "Dead Star", "Karadelik", "Süpernova", i, soru_num);
                else if (soru_num == 4)
                    KozmolojiSorular("Aşağıdakilerden Hangisi Yoğunluk Açısından En Büyüktür", "Nötron Yıldızı", "Beyaz Cüce", "Kızıl Dev", "Nebula Bulutları", "Satürn", i, soru_num);
                else if (soru_num == 5)
                    KozmolojiSorular("Uzaydaki Cisimlerin Uzaklıklarını Ölçmek İçin Hangi \"Doğrudan\" Işık Olayından Yararlanılır?", "Parsekleme", "Kızıla Kayma", "Işık Hızının Sabitliği", "Işığın 2'li Doğasından", "Işığın Parçacık Özelliği", i, soru_num);
                else if (soru_num == 6)
                    KozmolojiSorular("Karadeliklerin _____ Çok Fazla Olmasından Ötürü Etrafındaki Herşeyi Kendilerine Çekerler.\nBelirtilen Boşluğa Aşağıdakilerden Hangisi Gelmelidir?", "Kütlesinin", "Hacminin", "Yoğunluğunun", "Bilim Bu Noktada Çaresiz", "Hiçbiri", i, soru_num);
                else if (soru_num == 7)
                    KozmolojiSorular("Manyetik Alanı Çok Güçlü,Kendi Ekseni Etrafında Çok Hızlı Dönen Gök Cisminin İsmi Nedir?", "Pulsar (Atarca)", "Karadelik", "SüperNova", "Avakado", "Gaz Yüklü Dev Gezegenler", i, soru_num);
                else if (soru_num == 8)
                    KozmolojiSorular("Dünyamız Samanyolunun Hangi Kolunda Bulunmaktadır?", "Orion", "Yay", "Karma", "Cetvel", "Kahraman", i, soru_num);
                else if (soru_num == 9)
                    KozmolojiSorular("Bulunduğumuz Galaksinin İsmi Nedir?", "Samanyolu", "Andromeda", "Sagitairus", "Roven", "Mava", i, soru_num);
                else if (soru_num == 10)
                    KozmolojiSorular("Güneşimizin Yaklaşık 4,5 Milyar Yıl Sonra Alıcağı Formun İsmi Nedir?", "SüperNova", "Kızıl Dev", "Beyaz Cüce", "Karadelik", "Siyah Cüce", i, soru_num);
                else if (soru_num == 11)
                    KozmolojiSorular("Yıldızları Işınım Güçleri,Etkin Sıcaklıkları Gibi Özellikleri Arasındaki İlişkileri Gösteren,1910 Yılı Civarında Ejnar Hertzsprung ve Henry Norris Russell tarafından Oluşturulan Diagramın İsmi Nedir?", "H-H Diagramı", "H-R Diagramı", "E-H Diagramı", "N-E Diagramı", "Russ-Hertz Diagramı", i, soru_num);
                else if (soru_num == 12)
                { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("Bu Parçacık Cisimlerin Kütle Kazanmalarını Sağlayan Parçacıktır.Hiç Sorguladınızmı Neden Kütlemiz Var Diye???"); Console.ForegroundColor = ConsoleColor.Gray; KozmolojiSorular("Matematiksel Olarak Varlığı Kanıtlanmış Fakat Hiçbir Deneyle İspatlanamamış Bu Yüzden Tanrının Lanet Olası Parçacığı İsmini Alan Sonradan İsmi Tanrı Parçacığı Olarak Değiştirilen Parçacığın Bilimdeki İsmi Nedir?", "Foton", "Eta", "BoM (Boson of Mass)", "Higgs Bozonu", "Nötrino", i, soru_num); }
                else if (soru_num == 13)
                    KozmolojiSorular("Güneş ile Dünyanın Merkez Arası Uzaklığı İfade Eden Terim Nedir?", "Böyle Bir Terim Yok -_-", "Abre", "Işık Yılı", "Parsek", "Astronomik Birim", i, soru_num);
                else if (soru_num == 14)
                    KozmolojiSorular("Işığın Hızı Yaklaşık Kaç 10^8 km/sa'dır?", "8", "2", "1", "4", "3", i, soru_num);
                else if (soru_num == 15)
                    KozmolojiSorular("Parsek ile AU Arasındaki Mesafeler İçin Hangi Tanım Kullanılır?", "Işık Yılı", "Paralaks", "Fiera", "Işık Ayı", "Zedemm Yılı", i, soru_num);
                else if (soru_num == 16)
                    KozmolojiSorular("Yaklaşık 3.26 Işık Yılına Denk Paralaksı Bir Olan Mesafeler İçin Kullanılan Uzaklık Birimi Nedir?", "LIB", "Keşke Mesafeler Cayır Cayır Yansa", "AU", "Işık Yılı", "Parsek", i, soru_num);
                else if (soru_num == 17)
                    KozmolojiSorular("Bir Parsek Ortalama Kaç Işık Yılı Eder?", "3.26", "3.68", "2.80", "4", "3.20", i, soru_num);
                else if (soru_num == 18)
                    KozmolojiSorular("Kozmolojinin ALt Dalı ve Belkide Enzoru Olan Gökteki Bütün Cisimleri Belli Kalıplara Göre Yasalar Yazan Bilim Dalı Nedir?", "Astroloji", "AstroDinamik", "AstroFizik", "AstroPysc", "AstroBoy", i, soru_num);
                else if (soru_num == 19)
                    KozmolojiSorular("Yıldız Kayması Dediğimiz Olayda Gerçekte Dünyadan Teğet Geçen Cisimlerin İsmi Nedir?", "GökTaşı", "Uydu", "Ay", "Yıldız", "Melekler", i, soru_num);
                else if (soru_num == 20)
                    KozmolojiSorular("Güneşin veya Diğer Yıldızların Bize Gönderdiği Yüksek Enerjili Işınımlardan Bizi Koruyan Nedir?", "Manyetik Alan", "Azot", "KÜtle Çekim Alanı", "Higgs Alanı", "Ozon Tabakası", i, soru_num);
            }
        }
        public void SosyolojiSorular(string soru, string a, string b, string c, string d, string e, int i, int soru_num)
        {
            Random sorular = new Random();
            Console.WriteLine(i + 1 + ". Soru-)" + soru);
            sorunumaraları[i] = soru_num;
            siklar = new string[5] { a, b, c, d, e };
            string temp, temp2;
            for (int degistir = 0; degistir < 3; degistir++)
            {
                riklar = sorular.Next(0, 5);
                temp = siklar[riklar];
                riklar2 = sorular.Next(0, 5);
                temp2 = siklar[riklar2];
                siklar[riklar] = temp2;
                siklar[riklar2] = temp;
            }
            Console.WriteLine("A-){0}\nB-){1}\nC-){2}\nD-){3}\nE-){4}", siklar[0], siklar[1], siklar[2], siklar[3], siklar[4]);
            int cvp = 0;
            int shik;
            string ss = "A";
            string vcvp = Console.ReadLine().ToLower();
            if (vcvp == "a")
                shik = 0;
            else if (vcvp == "b")
                shik = 1;
            else if (vcvp == "c")
                shik = 2;
            else if (vcvp == "d")
                shik = 3;
            else
                shik = 4;
            for (int cvpd = 0; cvpd < 5; cvpd++)
            {
                if (siklar[cvpd] == Cevaplar.SosyolojiCevaplar[Cevaplar.CSosyoloji(i), 1])
                {
                    cvp = cvpd;
                    if (cvp == 0)
                        ss = "A";
                    else if (cvp == 1)
                        ss = "B";
                    else if (cvp == 2)
                        ss = "C";
                    else if (cvp == 3)
                        ss = "D";
                    else
                        ss = "E";
                }
            }
            if (shik == cvp)
            { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Tebrikler Doğru Cevap."); Console.ForegroundColor = ConsoleColor.Gray; Cevaplar.dogru++; Dogrular(); }
            else
            { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Yanlış Cevap Doğru Cevap Doğru Cevap:{0} Şıkkı {1} idi.", ss, Cevaplar.SosyolojiCevaplar[Cevaplar.CSosyoloji(i), 1]); Console.ForegroundColor = ConsoleColor.Gray; Cevaplar.yanlis++; Yanlislar(); }
            verilencevaplar[i] = siklar[shik];
        }
        public void Sosyoloji()
        {
            Random sorular = new Random();
            int soru_num;
            for (int i = 0; i < 10; i++)
            {
                Bekletme(i);
                for (;;)
                {
                    soru_num = sorular.Next(1, 21);
                    bool denet = true;
                    for (int j = 0; j <= i; j++)
                    {
                        if (soru_num == sorunumaraları[j])
                        { denet = false; break; }
                    }
                    if (denet)
                        break;
                }
                if (soru_num == 1)
                    SosyolojiSorular("Asıl Olanın Doğa Değil, Toplum Olduğu Savı Hangi Düşünürle Başlar?", "Sokrat", "Plato", "Aristo", "Sofistler", "Farabi", i, soru_num);
                else if (soru_num == 2)
                    SosyolojiSorular("Politika Adlı Eserin Sahibi, “Bütün, Parçaların Toplamından Fazla Bir Şeydir, “Esas Olan Somut Olandır” Gibi Düşünceleri Öne Süren Filozof Kimdir?", "İbn-i Haldun", "Sokrat", "Plato", "Aristo", "İbn-i Rüşd", i, soru_num);
                else if (soru_num == 3)
                    SosyolojiSorular("Toplum Çalışmalarında “Faziletli – Faziletsiz Şehir” Ayrımını Yapan Düşünür Kimdir?", "Haldun", "Sokrat", "Farabi", "Aristo", "Gazali", i, soru_num);
                else if (soru_num == 4)
                    SosyolojiSorular("Mukaddime Adlı Eseri Bir Sosyolojik Yapıt Olarak Alınabilecek Düşünür Kimdir?", "Gazzali", "Haldun", "Rüşd", "Farabi", "Locke", i, soru_num);
                else if (soru_num == 5)
                    SosyolojiSorular("Aşağıdakilerden Hangisi Sosyolojinin Ortaya Çıkışını Hazırlayan Etkenlerden Biri Değildir?", "Endüstri Devrimi", "Fransız Ve Amerikan İhtilalleri", "Emperyalist Gelişmeler", "Doğa Bilimlerindeki Hızlı Gelişmeler", "I. Ve II. Dünya Savaşları", i, soru_num);
                else if (soru_num == 6)
                    SosyolojiSorular("Üç Hal Yasasını Ortaya Koyan Ve Sosyolojinin Babası Olarak Bilinen Düşünür Aşağıdakilerden Hangisidir?", "Marx", "Spencer", "Comte", "Durkheim", "Weber", i, soru_num);
                else if (soru_num == 7)
                    SosyolojiSorular("Alt yapı Ve Üst Yapı Gibi Kavramlarla Toplumu Açıklamaya Çalışan Ve Ünlü \"Maddeci Görüş\" Teorisiyle Bilinen Çatışma Kuramcısı Aşağıdakilerden Hangisidir?", "Spencer", "Marx", "Durkheim", "Weber", "Comte", i, soru_num);
                else if (soru_num == 8)
                    SosyolojiSorular("Toplumu Organize Olmuş, Düzenli İlişkilerden Meydana Gelen Ve Her Bireyin Toplumun Temel Değerlerini Paylaştığı Bir Sosyal Sistem Olarak Gören Yaklaşım AşağıdakiIerden Hangisidir?", "Çatışma Kuramı", "Fonksiyonalist", "Avakadolonist", "Feminizm", "Sosyal Etkilişim", i, soru_num);
                else if (soru_num == 9)
                    SosyolojiSorular("Belirli Bir Otoritenin Varolduğu Her Yerde Çatışmanın Da Varolduğunu Söyleyen Düşünür Kimdir?", "Marx", "Comte", "Coser", "Dahrendorf", "Parsons", i, soru_num);
                else if (soru_num == 10)
                    SosyolojiSorular("Aşağıdakilerden Hangisi Bir Sosyal Alışveriş Kuramcısıdır?", "Parsons", "Durkheim", "Marx", "Comte", "Homans", i, soru_num);
                else if (soru_num == 11)
                    SosyolojiSorular("Sosyoloji Aşağıdaki Soruların Hangisine Yanıt Aramaz?", "Bireyin Başarısını Neler Etkiler?", "İnsanların Neden Tanrıya İnanırlar?", "Niçin Bazı İnsanlar Fakirdir?", "Toplumu Bir Arada Tutan Kurallar Nelerdir?", "İnsanlar Neden Bir Aile Kurmuşlardır?", i, soru_num);
                else if (soru_num == 12)
                    SosyolojiSorular("Aşağıdakilerden Hangisi Sosyal Bilim Değildir?", "Psikoloji", "Tarih", "Biyoloji", "Sosyoloji", "Antropoloji", i, soru_num);
                else if (soru_num == 13)
                    SosyolojiSorular("Sosyolojinin ABD’de Üç Aşamadan Geçtiğini Söyleyen Düşünür Kimdir?", "Comte", "Spencer", "Marx", "Reitz-lazarsfeld", "Durkheim", i, soru_num);
                else if (soru_num == 14)
                    SosyolojiSorular("Aşağıdakilerden Hangisi Marx’ın Kullanmış Olduğu Temel Kavramlardan Biri Değildir?", "Üretim Güçleri", "Organik Dayanışma", "Yabancılaşma", "Üretim Tarzı", "Üretim İlişkileri", i, soru_num);
                else if (soru_num == 15)
                    SosyolojiSorular("\"Sanayi Toplumu\" Kavramı İlk Olarak Kullanan Kişi Kim Olmuştur?", "Marx", "Weber", "Simon", "Spencer", "Durkheim", i, soru_num);
                else if (soru_num == 16)
                    SosyolojiSorular("Aşağıdakilerden Hangisi Toplumsal Yapıyı Oluşturan Parçalardan Biri Değildir?", "Rol", "Kültür", "Rol", "Norm", "Grup", i, soru_num);
                else if (soru_num == 17)
                    SosyolojiSorular("Aşağıdakilerden Hangisi Maddi Kültür Öğelerinden Birine Örnektir?", "Araç Gereçler", "Ahlaki Kuralları", "İnançlar", "Değerler", "Gelenekler", i, soru_num);
                else if (soru_num == 18)
                    SosyolojiSorular("Acil Karar Verilmesi Gereken Durumlarda En Etkili Olan Lider Tipi Aşağıdakilerden Hangisidir?", "Demokratik", "Araçsal", "Açıklayıcı", "Otoriter", "Dİktatör", i, soru_num);
                else if (soru_num == 19)
                    SosyolojiSorular("Bir Kadının Aynı Anda Birkaç Erkekle Evli Olmasına Ne Ad Verilir?", "Egzogami", "Endogami", "Neolokal", "Poliandri", "Poligini", i, soru_num);
                else if (soru_num == 20)
                    SosyolojiSorular("Aşağıdakilerden Hangisi Ogburn'a Göre Geleneksel Geniş Ailenin Görevlerinden Biri Değildir?", "Biyolojik", "Ekonomik", "Kültürel", "Psikolojik", "Eğitim", i, soru_num);
            }
        }
    }
    class Cevaplar
    {
        public static int puan = 0; public static int dogru = 0; public static int yanlis = 0; private int mdogru; private int myanlis;
        public int yHesapla
        {
            get { return myanlis; }
            set { myanlis = value; }
        }
        public int Hesapla
        {
            get { return mdogru; }
            set { mdogru = (value - yanlis / 4) * 4 - yanlis; }
        }
        public static string[,] QuantumCevaplar = new string[20, 2] { { "1", "Kuantum Mekaniği" }, { "2", "Dolanıklılık Etkisi" }, { "3", "Olasılıklara" }, { "4", "Fermiyon-Boson" }, { "5", "Parçacık-Dalga" }, { "6", "Olay Ufku" }, { "7", "Feynman Diagramı" }, { "8", "Gluon" }, { "9", "Renk Dinamiği" }, { "10", "Eta" }, { "11", "1. Nesil" }, { "12", "Sicimler (Strings)" }, { "13", "Normal" }, { "14", "Zaman" }, { "15", "Albert Einstein" }, { "16", "Proton" }, { "17", "Foton" }, { "18", "Süper Simetri" }, { "19", "Standart Model" }, { "20", "M-Kuramı" } }; public static string[,] KozmolojiCevaplar = new string[20, 2] { { "1", "Evren Bilimi" }, { "2", "Schwarzschild Yarıçapı" }, { "3", "Karadelik" }, { "4", "Nötron Yıldızı" }, { "5", "Kızıla Kayma" }, { "6", "Kütlesinin" }, { "7", "Pulsar (Atarca)" }, { "8", "Orion" }, { "9", "Samanyolu" }, { "10", "Kızıl Dev" }, { "11", "H-R Diagramı" }, { "12", "Higgs Bozonu" }, { "13", "Astronomik Birim" }, { "14", "3" }, { "15", "Işık Yılı" }, { "16", "Parsek" }, { "17", "3.26" }, { "18", "AstroFizik" }, { "19", "GökTaşı" }, { "20", "Manyetik Alan" } }; public static string[,] SosyolojiCevaplar = new string[20, 2] { { "1", "Sokrat" }, { "2", "Aristo" }, { "3", "Farabi" }, { "4", "Haldun" }, { "5", "I. Ve II. Dünya Savaşları" }, { "6", "Comte" }, { "7", "Marx" }, { "8", "Fonksiyonalist" }, { "9", "Dahrendorf" }, { "10", "Homans" }, { "11", "Bireyin Başarısını Neler Etkiler?" }, { "12", "Biyoloji" }, { "13", "Reitz-lazarsfeld" }, { "14", "Organik Dayanışma" }, { "15", "Simon" }, { "16", "Norm" }, { "17", "Araç Gereçler" }, { "18", "Otoriter" }, { "19", "Poliandri" }, { "20", "Kültürel" } };
        public static int CQuantum(int a)
        {
            int b = 0;
            for (int j = 0; j < 20; j++)
            {
                if (Sorular.sorunumaraları[a] == int.Parse(QuantumCevaplar[j, 0]))
                {
                    b = j;
                }
            }
            return b;
        }
        public static int CSosyoloji(int a)
        {
            int b = 0;
            for (int j = 0; j < SosyolojiCevaplar.GetLength(0); j++)
            {
                if (Sorular.sorunumaraları[a] == int.Parse(QuantumCevaplar[j, 0]))
                {
                    b = j;
                }
            }
            return b;
        }
        public static int CKozmoloji(int a)
        {
            int b = 0;
            for (int j = 0; j < KozmolojiCevaplar.GetLength(0); j++)
            {
                if (Sorular.sorunumaraları[a] == int.Parse(KozmolojiCevaplar[j, 0]))
                {
                    b = j;
                }
            }
            return b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sorular nesne = new Sorular();
            Cevaplar nesnee = new Cevaplar();
            SoundPlayer player = new SoundPlayer();
            while (true)
            {
                Cevaplar.dogru = 0; Cevaplar.yanlis = 0;
                Console.Clear(); Console.WriteLine("-x->-x->-x->-x-x->Hoşgeldiniz<-x-x-<-x-<-x-<-x-\n\nLütfen Seçmek İstediğiniz Test Konusunun Numarasını Giriniz.\nTest Seçeneklerini Küçük Büyük/Küçük Harf Duyarlılığı Yoktur.Bu Test Ses İçermektedir Lütfen Seslere Önem Veriniz.\n\n1-)Quantum\n2-)Kozmoloji\n3-)Temel Düzeyde Sosyoloji");
                player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\HELLO.WAV"; player.Play();
                int secim = int.Parse(Console.ReadLine());
                player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\INCOMING.WAV"; player.Play();
                Console.Clear();
                if (secim == 1)
                    nesne.Quantum();
                else if (secim == 2)
                    nesne.Kozmoloji();
                else if (secim == 3)
                    nesne.Sosyoloji();
                else
                    continue;
                nesnee.yHesapla = Cevaplar.yanlis;
                nesnee.Hesapla = Cevaplar.dogru;
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("\n------->Sonuçlar:" + nesnee.Hesapla + "/40" + " Doğru Sayısı:" + Cevaplar.dogru + "  Yanlış Sayısı:" + Cevaplar.yanlis); Console.ForegroundColor = ConsoleColor.Gray;
                if(nesnee.Hesapla==40)
                { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\FLAWLESS.WAV"; player.Play(); }
                else if (nesnee.Hesapla<40 && nesnee.Hesapla>30)
                { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\BUNGEE.WAV"; player.Play(); }
                else if (nesnee.Hesapla<31 && nesnee.Hesapla>20)
                { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\JUSTYOUWAIT.WAV"; player.Play(); }
                else
                { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\STUPID.WAV"; player.Play(); }
                Console.WriteLine("Devam Etmek İçin E/e Çıkmak İçin H/h Giriniz.");
                string tercih = Console.ReadLine().ToLower();
                if (tercih == "h")
                { player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\BYEBYE.WAV"; player.Play(); Console.WriteLine("\nMade it By YCH"); System.Threading.Thread.Sleep(1000); break; }
            }
        }
    }
}
