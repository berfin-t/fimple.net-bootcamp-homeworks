using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Program
    {
        static void Main(string[] args)
        {

            //erisim_belirteci geri_donuctipi metot_adi(parametrelistesi/arguman)
            ////komutlar;
            // return;
            //}
            int a = 2;
            int b = 3;
            Console.WriteLine(a + b);

            int sonuc = Topla(a, b);
            Console.WriteLine(sonuc);
            Methodlar ornek = new Methodlar();
            ornek.EkranaYazdir(Convert.ToString(sonuc));
            int sonuc2 = ornek.ArttirveTopla(ref a, ref b);
            ornek.EkranaYazdir(Convert.ToString(sonuc2));
            ornek.EkranaYazdir(Convert.ToString(a + b));
        }
        static int Topla(int deger1, int deger2)
        {
            return (deger1 + deger2);
        }
    }
    class Methodlar
    {
        public void EkranaYazdir(string veri)
        {
            Console.WriteLine(veri);
        }
        public int ArttirveTopla(ref int deger1, ref int deger2)
        {
            deger1 += 1;
            deger2 += 1;
            return (deger1 + deger2);
        }
    }
}
