using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OtProject.Classes
{

    public class Baglanti
    {
        public static SqlConnection Baglan()
        {
            string cnnstring = @"Server=mssql10.natro.com;Database=DB130105105145;uid=USR130105105145;pwd=PSS!B9T3Y7%;MultipleActiveResultSets=true;";
            SqlConnection cnn = new SqlConnection(cnnstring);
            return cnn;
        }
    }

    //----------------------------------------------------------

    [Serializable]
    public class AnketSecenekler
    {
        public Guid ID { get; set; }
        public Guid? AnketID { get; set; }
        public string AnketSecenek { get; set; }
        public byte SecenekSira { get; set; }
        public int OyOran { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Begen
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? IddiaID { get; set; }
        public Guid? YorumID { get; set; }
        public Guid? GrupID { get; set; }
        public byte BegenTip { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Bildirim
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? IddiaID { get; set; }
        public Guid? Soru_AnketID { get; set; }
        public Guid? YorumID { get; set; }
        public Guid? GrupID { get; set; }
        public Guid? BegenID { get; set; }
        public Guid? MesajID { get; set; }
        public Guid? TakipEtID { get; set; }
        public string BildirimTanim { get; set; }
        public DateTime Tarih { get; set; }
        public string UyeDetayTakmaAd { get; set; }
        public byte[] UyeDetayResim { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Grup
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Iddia
    {
        public Guid ID { get; set; }
        public Guid? HakemID { get; set; }
        public Guid? KazananID { get; set; }
        public Guid? KaybedenID { get; set; }

        public Guid? IddiaAcanKisiID { get; set; }
        public int IddiaAcanKisiPoka { get; set; }
        public int IddiaAcanKisiOy { get; set; }
        public string IddiaAcanKisiYorum { get; set; }

        public Guid? IddiaRakipKisiID { get; set; }
        public int IddiaRakipKisiPoka { get; set; }
        public int IddiaRakipKisiOy { get; set; }
        public string IddiaRakipKisiYorum { get; set; }

        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public DateTime GerceklesmeTarih { get; set; }
        public string GerceklesmeYer { get; set; }

        public bool MustehcenIddia { get; set; }
        public bool Ban { get; set; }
        public bool Acik { get; set; }
        public bool GercekIddia { get; set; }
        public int ToplamPoka { get; set; }

        public string UyeDetayIddiaAcanKisiAd { get; set; }
        public string UyeDetayIddiaAcanKisYer { get; set; }
        public string UyeDetayIddiaRakipKisiAd { get; set; }
        public string UyeDetayIddiaRakipKisiYer { get; set; }
        public byte[] UyeDetayIddiaAcanKisiResim { get; set; }
        public byte[] UyeDetayIddiaRakipKisiResim { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class IddiaDosyasi
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? IddiaID { get; set; }
        public string Dosya { get; set; }
        public byte DosyaTipi { get; set; }
        public DateTime YuklemeTarih { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class IlgiAlan
    {
        public Guid ID { get; set; }
        public string IlgiAlanTanim { get; set; }
        public int Izlenme { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class IzleyiciOl
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? IddiaID { get; set; }
        public bool Onay { get; set; }
    }


    //----------------------------------------------------------

    [Serializable]
    public class Kurumsal
    {

    }

    //----------------------------------------------------------

    [Serializable]
    public class Mesaj
    {
        public Guid ID { get; set; }
        public Guid? GonderenID { get; set; }
        public Guid? AliciID { get; set; }
        public DateTime Tarih { get; set; }
        public string Icerik { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Oy
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? IddiaID { get; set; }
        public Guid? OyVerdigiKisiID { get; set; }
        public int PokaMiktar { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Soru_Anket
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public string Soru_AnketTanim { get; set; }
        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public bool Anket { get; set; }

        public string UyeDetayAd { get; set; }
        public byte[] UyeDetayResim { get; set; }
        public string UyeDetayYer { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Sikayet
    {
        public Guid ID { get; set; }
        public Guid? SikayetedenID { get; set; }
        public Guid? SikayetEdilenID { get; set; }
        public string Nedeni { get; set; }
        public DateTime Tarih { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class TakipEt
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? BegenilenUyeID { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class UyeDetay
    {
        public Guid ID { get; set; }
        public string TakmaAd { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public byte[] Resim { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public DateTime DogumYili { get; set; }
        public string Aciklama { get; set; }
        public string Website { get; set; }

        public int PokaMiktar { get; set; }
        public int KazanılanIddia { get; set; }
        public int KaybedilenIddia { get; set; }
        public int KazanılanPoka { get; set; }
        public int KaybedilenPoka { get; set; }

        public bool UyeTip { get; set; }
        public bool Onay { get; set; }
        public bool Aktif { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Yorum
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? IddiaID { get; set; }
        public Guid? SoruAnketID { get; set; }
        public Guid? GrupID { get; set; }
        public Guid? BildirimID { get; set; }
        public DateTime Tarih { get; set; }
        public string YorumTanim { get; set; }
        public string UyeDetayAd { get; set; }
        public byte[] UyeDetayResim { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class Durum
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public string UyeDetayAd { get; set; }
        public string UyeDetayYer { get; set; }
    }

    //----------------------------------------------------------
    //Ara Tablolar

    [Serializable]
    public class UyeGrupAraTablo
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? GrupID { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class UyeIlgiAlanAraTablo
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? IlgiAlanID { get; set; }
    }

    //----------------------------------------------------------

    [Serializable]
    public class UyeArkadasAraTablo
    {
        public Guid ID { get; set; }
        public Guid? UyeID { get; set; }
        public Guid? ArkadasID { get; set; }
    }

    [Serializable]
    public class IlgiAlanIddiaSoru_AnketGrupAraTablo
    {
        public Guid ID { get; set; }
        public Guid? IlgiAlanID { get; set; }
        public Guid? IddiaID { get; set; }
        public Guid? Soru_AnketID { get; set; }
        public Guid? GrupID { get; set; }
        public Guid? UyeID { get; set; }
    }

}