using System;
using System.Collections.Generic;

enum Buyukluk
{
    XS = 1,
    S,
    M,
    L,
    XL
}

class TakimUyesi
{
    public int ID { get; set; }
    public string Ad { get; set; }
}

class Kart
{
    public string Baslik { get; set; }
    public string Icerik { get; set; }
    public TakimUyesi AtananKisi { get; set; }
    public Buyukluk Buyukluk { get; set; }
    public string Line { get; set; }
}

class Board
{
    List<Kart> todoLine = new List<Kart>();
    List<Kart> inProgressLine = new List<Kart>();
    List<Kart> doneLine = new List<Kart>();

    public Board()
    {
        // Varsayılan olarak 3 kart ekleyelim
        todoLine.Add(new Kart { Baslik = "Görev 1", Icerik = "Bu görev todo line'da", AtananKisi = new TakimUyesi { ID = 1, Ad = "TakimUye1" }, Buyukluk = Buyukluk.M, Line = "TODO" });
        inProgressLine.Add(new Kart { Baslik = "Görev 2", Icerik = "Bu görev in progress line'da", AtananKisi = new TakimUyesi { ID = 2, Ad = "TakimUye2" }, Buyukluk = Buyukluk.S, Line = "IN PROGRESS" });
        doneLine.Add(new Kart { Baslik = "Görev 3", Icerik = "Bu görev done line'da", AtananKisi = new TakimUyesi { ID = 3, Ad = "TakimUye3" }, Buyukluk = Buyukluk.XL, Line = "DONE" });
    }

    public void BoardListele()
    {
        Console.WriteLine("TODO Line\n************************");
        KartListele(todoLine);

        Console.WriteLine("\nIN PROGRESS Line\n************************");
        KartListele(inProgressLine);

        Console.WriteLine("\nDONE Line\n************************");
        KartListele(doneLine);
    }

    private void KartListele(List<Kart> line)
    {
        foreach (var kart in line)
        {
            Console.WriteLine($"Başlık: {kart.Baslik}\nİçerik: {kart.Icerik}\nAtanan Kişi: {kart.AtananKisi.Ad}\nBüyüklük: {kart.Buyukluk}\n---");
        }
    }

    public void KartEkle()
    {
        Kart yeniKart = new Kart();

        Console.WriteLine("Başlık Giriniz: ");
        yeniKart.Baslik = Console.ReadLine();

        Console.WriteLine("İçerik Giriniz: ");
        yeniKart.Icerik = Console.ReadLine();

        Console.WriteLine("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ");
        int buyukluk;
        if (int.TryParse(Console.ReadLine(), out buyukluk) && Enum.IsDefined(typeof(Buyukluk), buyukluk))
        {
            yeniKart.Buyukluk = (Buyukluk)buyukluk;
        }
        else
        {
            Console.WriteLine("Hatalı giriş yaptınız. İşlem iptal edildi.");
            return;
        }

        Console.WriteLine("Kişi Seçiniz (ID): ");
        int takimUyeID;
        if (int.TryParse(Console.ReadLine(), out takimUyeID))
        {
            TakimUyesi atananKisi = TakimUyeleri.Find(uye => uye.ID == takimUyeID);
            if (atananKisi != null)
            {
                yeniKart.AtananKisi = atananKisi;
            }
            else
            {
                Console.WriteLine("Hatalı giriş yaptınız. İşlem iptal edildi.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Hatalı giriş yaptınız. İşlem iptal edildi.");
            return;
        }

        Console.WriteLine("Line Seçiniz (TODO, IN PROGRESS, DONE): ");
        string line = Console.ReadLine().ToUpper();

        switch (line)
        {
            case "TODO":
                todoLine.Add(yeniKart);
                break;
            case "IN PROGRESS":
                inProgressLine.Add(yeniKart);
                break;
            case "DONE":
                doneLine.Add(yeniKart);
                break;
            default:
                Console.WriteLine("Hatalı giriş yaptınız. İşlem iptal edildi.");
                return;
        }

        Console.WriteLine("Kart başarıyla eklendi.");
    }

    public void KartSil()
    {
        Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
        Console.WriteLine("Lütfen kart başlığını yazınız:");
        string baslik = Console.ReadLine();

        Kart silinecekKart = todoLine.Find(kart => kart.Baslik == baslik)
            ?? inProgressLine.Find(kart => kart.Baslik == baslik)
            ?? doneLine.Find(kart => kart.Baslik == baslik);

        if (silinecekKart == null)
        {
            Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("Silmeyi sonlandırmak için : (1)\nYeniden denemek için : (2)");

            int secim;
            if (int.TryParse(Console.ReadLine(), out secim) && secim == 1)
            {
                Console.WriteLine("Silmeyi sonlandırdınız.");
            }
            else
            {
                KartSil();
            }
        }
        else
        {
            todoLine.Remove(silinecekKart);
            inProgressLine.Remove(silinecekKart);
            doneLine.Remove(silinecekKart);

            Console.WriteLine($"{silinecekKart.Baslik} başlıklı kart başarıyla silindi.");
        }
    }

    public void KartTasi()
    {
        Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
        Console.WriteLine("Lütfen kart başlığını yazınız:");
        string

