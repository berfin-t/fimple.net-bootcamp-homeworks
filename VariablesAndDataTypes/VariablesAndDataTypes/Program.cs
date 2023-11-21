using System;
using System.Numerics;

namespace degisken
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            byte b = 5;
            sbyte c = 5;
            short s = 5;
            ushort us = 5;

            Int16 i16 = 2;
            int i = 2;
            Int32 i32 = 2;
            Int64 i64 = 2;
            
            uint ui = 2;
            long L = 4;
            ulong l = 4;

            float f = 5;
            double d = 5;
            decimal de = 5;

            char ch = '2';
            string str = "Berfin";

            bool b1 = true;
            bool b2 = false;

            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);

            object o1 = "x";
            object o2 = "y";
            object o3 = 4;
            object o4 = 4.3;

            string str1 = String.Empty;
            str1 = "Berfin Tek";
            string ad = "Berfin";
            string soyad = "Tek";
            string tamIsim = ad + " " + soyad;

            int integer1 = 5;
            int integer2 = 2;
            int integer3 = integer1 * integer2;

            bool bool1 = 10 > 2;
            string str20 = "20";
            int int20 = 20;

            string yeniDeger = str20 + int20.ToString();
            Console.WriteLine(yeniDeger);

            int int21 = int20 + Convert.ToInt32(str20);
            Console.WriteLine(int21);

            int int22 = int20 + int.Parse(str20);
            Console.WriteLine(int22);

            string datetime = DateTime.Now.ToString("dd.MM.yyyy");
            Console.WriteLine($"datetime: {datetime}");

            string hour = DateTime.Now.ToString("HH:mm");
            Console.WriteLine(hour);
        }
    }
}
