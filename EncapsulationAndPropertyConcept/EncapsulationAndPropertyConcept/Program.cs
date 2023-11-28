using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Isim = "Berfin";
            ogrenci.Soyisim = "Tek";
            ogrenci.OgrenciNo = 785;
            ogrenci.Sinif = 3;
            ogrenci.OgrenciBilgileriniGetir();
            ogrenci.SinifDusur();
            ogrenci.OgrenciBilgileriniGetir();

            Ogrenci ogrenci2 = new Ogrenci("Ayşe", "Bardak", 1233, 1);
            ogrenci2.SinifDusur();
            ogrenci2.SinifDusur();
            ogrenci2.OgrenciBilgileriniGetir();
        }
    }
    class Ogrenci
    {
        private string isim;
        private string soyisim;
        private int ogrenciNo;
        private int sinif;

        public string Isim { get => isim; set => isim = value; }
        public string Soyisim { get => soyisim; set => soyisim = value; }
        public int OgrenciNo { get => ogrenciNo; set => ogrenciNo = value; }
        public int Sinif
        {
            get => sinif;
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Sınıf en az 1 olabilir");
                    sinif = 1;
                }
                else { sinif = value; }
            }
        }

        public Ogrenci(string isim, string soyisim, int ogrenciNo, int sinif)
        {
            Isim = isim;
            Soyisim = soyisim;
            OgrenciNo = ogrenciNo;
            Sinif = sinif;
        }
        public Ogrenci() { }
        public void OgrenciBilgileriniGetir()
        {
            Console.WriteLine("****Öğrenci Bilgileri****");
            Console.WriteLine("Öğrenci adı:     " + this.Isim);
            Console.WriteLine("Öğrenci soyadı:  " + this.Soyisim);
            Console.WriteLine("Öğrenci no:      " + this.OgrenciNo);
            Console.WriteLine("Öğrenci sınıfı:  " + this.Sinif);
        }
        public void SinifAtlat()
        {
            this.Sinif = this.Sinif + 1;
        }
        public void SinifDusur()
        {
            this.Sinif = this.Sinif - 1;
        }
    }

}
