//Metot Aşırı Yükleme - Overloading
int ifade = 999;
instance.EkranaYazdir(Convert.ToString(ifade));
instance.EkranaYazdir(ifade);

			//Method İmzası
			//methodAdı + Parametre Sayısı + Parametre Tipi
		}
	}

	class Metotlar
{
    public void Topla(int a, int b, out int toplam)
    {
        toplam = a + b;
    }
    public void EkranaYazdir(string veri)
    {
        Console.WriteLine(veri);
    }
    public void EkranaYazdir(int veri)
    {
        Console.WriteLine(veri);
    }
}
}
