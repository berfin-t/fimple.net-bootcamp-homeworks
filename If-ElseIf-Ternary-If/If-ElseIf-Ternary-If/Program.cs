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
            int time = DateTime.Now.Hour;
            if (time > 6 && time < 11)
                Console.WriteLine("Günaydın!");
            else if (time <= 18)
                Console.WriteLine("İyi günler!");
            else
                Console.WriteLine("İyi geceler!)");

            string sonuc = time <= 18 ? "İyi Günler!" : "İyi Geceler";
            Console.WriteLine(sonuc);

            sonuc = time >= 6 && time < 11 ? "Günaydın!" : time <= 18 ? "İyi günler" : "İyi geceler!";
            Console.WriteLine(sonuc);

        }
    }
}

