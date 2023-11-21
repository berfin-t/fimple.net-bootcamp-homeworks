using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // NOTES:
            // try { Hataya sebebiyet verme ihtimali olan kod }
            // catch { Hata ile karşılaşıldığında ne yapılacağı buraya yazılır }
            // finally { Hata olsun olmasın mutlaka yapılmasını istediğimiz işler varsa buraya yazarız }

            try
            {
                Console.WriteLine("Bir sayı giriniz:");
                int sayi = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Girmiş olduğunuz sayi:" + sayi);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message.ToString());
            }
            // finally
            // {
            //	Console.Write("İşlem tamamlandı.");
            // }

            try
            {
                //int a = int.Parse(null);
            }
            //int a = int.Parse("test"); int a = int.Parse("-20000000000");
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Boş değer girdiniz"); Console.WriteLine(ex);
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Veri tipi uygun değil.");
                Console.WriteLine(ex);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Çok küçük yada çok büyük bir değer girdiniz.");
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("İşlem Tamamlandı");
            }

        }
    }
}
