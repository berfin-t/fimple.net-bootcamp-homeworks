using System;

namespace ArrayClassMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sayilar = { 23, 12, 86, 72, 3, 11, 17 };
            Console.WriteLine("Sırasız Dizi");
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("Sıralı Dizi");
            Array.Sort(sayilar);
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("Array Clear");
            Array.Clear(sayilar, 2, 3);
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("Array Reverse");
            Array.Reverse(sayilar);
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("Array İndexof");

            Console.WriteLine(Array.IndexOf(sayilar, 23));
            Console.WriteLine("Array Resize");
            Array.Resize<int>(ref sayilar, 9);
            sayilar[8] = 99;
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            Console.ReadLine();

        }
    }
}
