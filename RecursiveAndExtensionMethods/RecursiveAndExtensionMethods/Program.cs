using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Extension
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Rekürsif - Öz Yinelemeli 

            int result = 1;
            for (int i = 0; i < 5; i++)
            {
                result = result * 3;
                Console.WriteLine(result);

                Islemler islemler = new Islemler();
                Console.WriteLine(islemler.Expo(3, 4));

                //Extension Metotlar
                string ifade = "Nevzat Çırpıcıoğlu";
                bool sonuc = ifade.CheckSpaces();
                Console.WriteLine(sonuc);
                if (sonuc)
                    Console.WriteLine(ifade.RemoveWhiteSpaces());
                Console.WriteLine(ifade.MakeUpperCase());
                Console.WriteLine(ifade.MakeLowerCase());
                int[] dizi = { 1, 4, 8, 9, 6 };
                dizi.SortArray();
                dizi.EkranaYazdir();
                int sayi = 10;
                Console.WriteLine(sayi.IsEvenNumber());
                Console.WriteLine(ifade.GetFirstCharecter());
            }
        }
    }
    public class Islemler
    {
        public int Expo(int sayi, int us)
        {
            if (us < 2)
            {
                return sayi;
            }
            return Expo(sayi, us - 1) * sayi;
        }
        //Expo(3,4)
        //Expo(3,3) * 3
        //Expo(3,2) * 3 * 3
        //Expo(3,1) * 3 * 3 * 3
        //3*3*3*3 = 3^4 
    }
    public static class Extension
    {
        public static bool CheckSpaces(this string param)
        {
            return param.Contains(" ");
        }

        public static string RemoveWhiteSpaces(this string param)
        {
            string[] dizi = param.Split(" ");
            return string.Join("*", dizi);
        }
        public static string MakeUpperCase(this string param)
        {
            return param.ToUpper();
        }
        public static string MakeLowerCase(this string param)
        {
            return param.ToUpper();
        }
        public static int[] SortArray(this int[] param)
        {
            Array.Sort(param);
            return param;
        }
        public static void EkranaYazdir(this int[] param)
        {
            foreach (var item in param)
            {
                Console.WriteLine(item);
            }
        }
        public static bool IsEvenNumber(this int param)
        {
            return param % 2 == 0;
        }
        public static string GetFirstCharecter(this string param)
        {
            return param.Substring(0, 1);
        }
    }
}
