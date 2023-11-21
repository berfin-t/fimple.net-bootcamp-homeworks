using System;
using System.Numerics;

namespace degisken
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Implict Conversions ******");

            byte a = 5;
            sbyte b = 30;
            short c = 10;

            int d = a + b + c;
            Console.WriteLine("d:" + d);

            long h = d;
            Console.WriteLine("h:" + h);

            float l = h;
            Console.WriteLine("l:" + l);

            string e = "Berfin";
            char f= 'a';
            object g = e + f + d;
            Console.WriteLine("g:" + g);

            Console.WriteLine("****** Explict Conversions ******");

            int x = 4;
            byte y = (byte)x;
            Console.WriteLine("y:" + y);

            int z = 100;
            byte t =(byte)z;
            Console.WriteLine("z:" + z);

            float w = 10.3f;
            byte v=(byte)w;
            Console.WriteLine("v:" + v);

            Console.WriteLine("****** ToString Metodu *****");
            int xx = 6;
            string yy=xx.ToString();
            Console.WriteLine("yy:" + yy);

            string zz=12.5f.ToString();
            Console.WriteLine("zz:" + zz);

            Console.WriteLine("****** System.Convert sınıfı ******");
            string s1 = "10"; string s2 = "20";
            int sayi1, sayi2;
            int toplam;

            sayi1=Convert.ToInt32(s1);
            sayi2=Convert.ToInt32(s2);

            toplam = sayi1 + sayi2;
            Console.WriteLine("Toplam:" + toplam);

            
        }

        public static void ParserMethod()
        {
            string metin1 = "10";
            string metin2 = "10.25";
            int rakam;
            double double1;

            rakam = Int32.Parse(metin1);
            double1 = Double.Parse(metin2);

            Console.WriteLine("rakam:"+rakam);
            Console.WriteLine("double:" + double1);
        }
    }
}

