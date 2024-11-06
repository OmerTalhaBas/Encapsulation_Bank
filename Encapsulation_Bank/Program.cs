using System;

class Program
{
    static void Main()
    {
        Hesap hesap = new Hesap(1000);
        if (hesap.SahipDogrulama())
        {
            hesap.BakiyeYazdir();
        }
        Console.Write("Yatırmak İstediğiniz Tutarı Giriniz : ");
        double yatirilanTutari = Convert.ToDouble(Console.ReadLine());
        hesap.ParaYatir(yatirilanTutari);
        Console.Write("Çekmek İstediğiniz Tutarı Giriniz : ");
        double cekilenTutari = Convert.ToDouble(Console.ReadLine());
        hesap.ParaCek(cekilenTutari);
        if (hesap.SahipDogrulama())
        {
            hesap.BakiyeYazdir();
        }
    }
}
public class BankaHesabi
{
    private double bakiye;
    private string sahipSifre = "Sahip";
    public BankaHesabi(double baslangicBakiye)
    {
        if (baslangicBakiye < 0)
        {
            Console.WriteLine("Başlangıç Bakiyesi Geçersiz!");
        }
        else
        {
            bakiye = baslangicBakiye;
        }
    }
    public double Bakiye
    {
        get { return bakiye; }
        private set { bakiye = value; }
    }
    public void ParaYatir(double tutar)
    {
        if (tutar <= 0)
        {
            Console.WriteLine("Yatırılacak Tutar Sıfır Veya Altı Olamaz!");
        }
        else
        {
            Bakiye += tutar;
            Console.WriteLine($"{tutar} TL Yatırıldı. Güncel Bakiye : {Bakiye} TL");
        }
    }
    public void ParaCek(double tutar)
    {
        if (tutar <= 0)
        {
            Console.WriteLine("Çekilecek Tutar Sıfır Veya Altı Olamaz!");
        }
        else if (tutar > Bakiye)
        {
            Console.WriteLine("Yetersiz Bakiye! Mevcut Bakiyeniz : " + Bakiye);
        }
        else
        {
            Bakiye -= tutar;
            Console.WriteLine($"{tutar} TL Çekildi. Güncel Bakiyeniz : {Bakiye} TL");
        }
    }
    public void BakiyeYazdir()
    {
        Console.WriteLine($"Hesap Bakiyesi : {Bakiye} TL");
    }
    public bool SahipDogrulama()
    {
        Console.Write("Kimsiniz? : ");
        string kullaniciAdi = Console.ReadLine();
        if (kullaniciAdi == sahipSifre)
        {
            Console.WriteLine("Hoşgeldiniz Sahip!");
            return true;
        }
        else
        {
            Console.WriteLine("Dolandırıcı Mısın?");
            return false;
        }
    }
}
public class Hesap : BankaHesabi
{
    public Hesap(double baslangicBakiye) : base(baslangicBakiye) { }
}
