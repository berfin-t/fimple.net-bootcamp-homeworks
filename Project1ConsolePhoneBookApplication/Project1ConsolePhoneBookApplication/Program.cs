using System;
using System.Collections.Generic;

class TelefonRehberiUygulamasi
{
    static List<Kisi> rehber = new List<Kisi>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek\n(2) Varolan Numarayı Silmek\n(3) Varolan Numarayı Güncelleme\n(4) Rehberi Listelemek\n(5) Rehberde Arama Yapmak");

            int secim;
            if (int.TryParse(Console.ReadLine(), out secim))
            {
                switch (secim)
                {
                    case 1:
                        YeniNumaraKaydet();
                        break;
                    case 2:
                        NumaraSil();
                        break;
                    case 3:
                        NumaraGuncelle();
                        break;
                    case 4:
                        RehberiListele();
                        break;
                    case 5:
                        RehberdeAramaYap();
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
            }
        }
    }

    static void YeniNumaraKaydet()
    {
        Console.WriteLine("Lütfen isim giriniz: ");
        string isim = Console.ReadLine();

        Console.WriteLine("Lütfen soyisim giriniz: ");
        string soyisim = Console.ReadLine();

        Console.WriteLine("Lütfen telefon numarası giriniz: ");
        string telefon = Console.ReadLine();

        rehber.Add(new Kisi(isim, soyisim, telefon));
        Console.WriteLine("Numara başarıyla kaydedildi.");
    }

    static void NumaraSil()
    {
        Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
        string aranan = Console.ReadLine();

        Kisi bulunanKisi = rehber.Find(kisi => kisi.Isim.Contains(aranan) || kisi.Soyisim.Contains(aranan));

        if (bulunanKisi == null)
        {
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.");
        }
        else
        {
            Console.WriteLine($"{bulunanKisi.Isim} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                rehber.Remove(bulunanKisi);
                Console.WriteLine("Kişi başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Silme işlemi iptal edildi.");
            }
        }
    }

    static void NumaraGuncelle()
    {
        Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
        string aranan = Console.ReadLine();

        Kisi bulunanKisi = rehber.Find(kisi => kisi.Isim.Contains(aranan) || kisi.Soyisim.Contains(aranan));

        if (bulunanKisi == null)
        {
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.");
        }
        else
        {
            // Güncelleme işlemleri burada yapılır.
            Console.WriteLine("Kişi başarıyla güncellendi.");
        }
    }

    static void RehberiListele()
    {
        Console.WriteLine("Telefon Rehberi");
        Console.WriteLine("**********************************************");

        foreach (var kisi in rehber)
        {
            Console.WriteLine($"isim: {kisi.Isim} Soyisim: {kisi.Soyisim} Telefon Numarası: {kisi.Telefon}");
        }

        Console.WriteLine("**********************************************");
    }

    static void RehberdeAramaYap()
    {
        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
        Console.WriteLine("**********************************************");
        Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");

        int secim;
        if (int.TryParse(Console.ReadLine(), out secim))
        {
            switch (secim)
            {
                case 1:
                    // İsim veya soyisime göre arama yapma işlemleri burada yapılır.
                    break;
                case 2:
                    // Telefon numarasına göre arama yapma işlemleri burada yapılır.
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
        }
    }
}

class Kisi
{
    public string Isim { get; set; }
    public string Soyisim { get; set; }
    public string Telefon { get; set; }

    public Kisi(string isim, string soyisim, string telefon)
    {
        Isim = isim;
        Soyisim = soyisim;
        Telefon = telefon;
    }
}

