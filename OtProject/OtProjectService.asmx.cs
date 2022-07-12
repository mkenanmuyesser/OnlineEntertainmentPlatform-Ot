using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using OtProject.Classes;

namespace OtProject
{
    /// <summary>
    /// Summary description for OtProjectService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class OtProjectService : System.Web.Services.WebService
    {

        #region Begen grubu
        [WebMethod]
        public List<Begen> BegenSelect()
        {
            List<Begen> dizi = new List<Begen>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.Begen", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Begen yenibgn = new Begen
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    IddiaID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    YorumID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                    GrupID = rdr.IsDBNull(4) ? null : (Guid?)rdr.GetGuid(4),
                    BegenTip = rdr.GetByte(5),
                };
                dizi.Add(yenibgn);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void BegenInsert(Begen bgn)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Begen values (@ID,@UyeID,@IddiaID,@YorumID,@GrupID,@BegenTip)", cnn);
            cmd.Parameters.AddWithValue("@ID", bgn.ID);
            cmd.Parameters.AddWithValue("@UyeID", bgn.UyeID);
            cmd.Parameters.AddWithValue("@IddiaID", bgn.IddiaID);
            cmd.Parameters.AddWithValue("@YorumID", bgn.YorumID);
            cmd.Parameters.AddWithValue("@GrupID", bgn.GrupID);
            cmd.Parameters.AddWithValue("@BegenTip", bgn.BegenTip);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void BegenUpdate(Begen bgn)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("update dbo.Begen set BegenTip=@BegenTip where ID=@ID)", cnn);
            cmd.Parameters.AddWithValue("@ID", bgn.ID);
            cmd.Parameters.AddWithValue("@BegenTip", bgn.BegenTip);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void BegenDelete(Begen bgn)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Begen where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", bgn.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Bildirim grubu
        [WebMethod]
        public List<Bildirim> BildirimSelect(Guid? id)
        {
            List<Bildirim> dizi = new List<Bildirim>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            if (id == null)
            {
                cmd = new SqlCommand("select top 20 b.*,u.TakmaAd,u.Resim from dbo.Bildirim as b inner join dbo.UyeDetay as u on b.UyeID=u.ID order by Tarih asc", cnn);
            }
            else
            {
                cmd = new SqlCommand("select top 20 b.*,u.TakmaAd,u.Resim from dbo.Bildirim as b inner join dbo.UyeDetay as u on b.UyeID=u.ID where b.UyeID=@id  order by Tarih asc", cnn);
                cmd.Parameters.AddWithValue("@id", id);
            }

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Bildirim yenibldrm = new Bildirim
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    IddiaID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    Soru_AnketID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                    YorumID = rdr.IsDBNull(4) ? null : (Guid?)rdr.GetGuid(4),
                    GrupID = rdr.IsDBNull(5) ? null : (Guid?)rdr.GetGuid(5),
                    BegenID = rdr.IsDBNull(6) ? null : (Guid?)rdr.GetGuid(6),
                    MesajID = rdr.IsDBNull(7) ? null : (Guid?)rdr.GetGuid(7),
                    TakipEtID = rdr.IsDBNull(8) ? null : (Guid?)rdr.GetGuid(8),
                    BildirimTanim = rdr.GetString(9),
                    Tarih = rdr.GetDateTime(10),
                    UyeDetayTakmaAd = rdr.GetString(11),
                    UyeDetayResim = rdr.IsDBNull(12) ? null : (byte[])rdr.GetValue(12),
                };
                dizi.Add(yenibldrm);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void BildirimInsert(Bildirim bldrm)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Bildirim values (@ID,@UyeID,@IddiaID,@Soru_AnketID,@YorumID,@GrupID,@BegenID,@MesajID,@TakipEtID,@BildirimTanim,@Tarih)", cnn);
            cmd.Parameters.AddWithValue("@ID", bldrm.ID);
            cmd.Parameters.AddWithValue("@UyeID", bldrm.UyeID);
            cmd.Parameters.AddWithValue("@IddiaID", bldrm.IddiaID == null ? (object)DBNull.Value : bldrm.IddiaID);
            cmd.Parameters.AddWithValue("@Soru_AnketID", bldrm.Soru_AnketID == null ? (object)DBNull.Value : bldrm.Soru_AnketID);
            cmd.Parameters.AddWithValue("@YorumID", bldrm.YorumID == null ? (object)DBNull.Value : bldrm.YorumID);
            cmd.Parameters.AddWithValue("@GrupID", bldrm.GrupID == null ? (object)DBNull.Value : bldrm.GrupID);
            cmd.Parameters.AddWithValue("@BegenID", bldrm.BegenID == null ? (object)DBNull.Value : bldrm.BegenID);
            cmd.Parameters.AddWithValue("@MesajID", bldrm.MesajID == null ? (object)DBNull.Value : bldrm.MesajID);
            cmd.Parameters.AddWithValue("@TakipEtID", bldrm.TakipEtID == null ? (object)DBNull.Value : bldrm.TakipEtID);
            cmd.Parameters.AddWithValue("@BildirimTanim", bldrm.BildirimTanim);
            cmd.Parameters.AddWithValue("@Tarih", bldrm.Tarih);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void BildirimUpdate(Bildirim bldrm)
        //{

        //}
        [WebMethod]
        public void BildirimDelete(Bildirim bldrm)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Bildirim where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", bldrm.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Grup grubu
        [WebMethod]
        public List<Grup> GrupSelect(byte sw)
        {
            List<Grup> dizi = new List<Grup>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            switch (sw)
            {
                case 0:
                    cmd = new SqlCommand("select * from dbo.Grup order by Tarih desc", cnn);
                    break;
                case 1:
                    cmd = new SqlCommand("select * from dbo.Grup as g where DATEDIFF ( hour , g.Tarih ,getdate())<=1  order by Tarih desc", cnn);
                    break;
                case 2:
                    cmd = new SqlCommand("select * from dbo.Grup as g where DATEDIFF ( hour , g.Tarih ,getdate())<=24  order by Tarih desc", cnn);
                    break;
                case 3:
                    cmd = new SqlCommand("select * from dbo.Grup as g where DATEDIFF ( month , g.Tarih ,getdate())<=1  order by Tarih desc", cnn);
                    break;
                case 4:
                    cmd = new SqlCommand("select * from dbo.Grup as g where DATEDIFF ( year , g.Tarih ,getdate())<=1  order by Tarih desc", cnn);
                    break;
            }

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Grup yenigrp = new Grup
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    Ad = rdr.GetString(2),
                    Aciklama = rdr.GetString(3),
                    Tarih = rdr.GetDateTime(4),
                };
                dizi.Add(yenigrp);
            }
            cnn.Close();

            return dizi;
        }
        [WebMethod]
        public Grup GrupSelect(Guid gid)
        {
            List<Grup> dizi = new List<Grup>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.Grup where ID=@id order by Tarih desc", cnn);
            cmd.Parameters.AddWithValue("@id", gid);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Grup yenigrp = new Grup
            {
                ID = rdr.GetGuid(0),
                UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                Ad = rdr.GetString(2),
                Aciklama = rdr.GetString(3),
                Tarih = rdr.GetDateTime(4),
            };
            cnn.Close();
            return yenigrp;
        }
        [WebMethod]
        public List<Grup> GrupSelect(List<Guid> par)
        {
            List<Grup> dizi = new List<Grup>();
            SqlConnection cnn = Baglanti.Baglan();
            string komutcumle = "select * from dbo.Grup as g inner join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ar on g.ID=ar.GrupID where";
            foreach (Guid item in par)
            {
                komutcumle += " ar.GrupID = '" + item.ToString() + "' or";
            }
            komutcumle = komutcumle.Remove(komutcumle.Length - 2, 2) + " order by Tarih desc";
            SqlCommand cmd = new SqlCommand(komutcumle, cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Grup yenigrp = new Grup
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    Ad = rdr.GetString(2),
                    Aciklama = rdr.GetString(3),
                    Tarih = rdr.GetDateTime(4),
                };
                dizi.Add(yenigrp);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void GrupInsert(Grup grp)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Grup values (@ID,@UyeID,@Ad,@Aciklama,@Tarih)", cnn);
            cmd.Parameters.AddWithValue("@ID", grp.ID);
            cmd.Parameters.AddWithValue("@UyeID", grp.ID);
            cmd.Parameters.AddWithValue("@Ad", grp.Ad);
            cmd.Parameters.AddWithValue("@Aciklama", grp.Aciklama);
            cmd.Parameters.AddWithValue("@Tarih", grp.Tarih);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void GrupUpdate(Grup grp)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("update dbo.Grup values set Ad=@Ad,Aciklama=@Aciklama,UyeID=@UyeID where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", grp.ID);
            cmd.Parameters.AddWithValue("@Ad", grp.Ad);
            cmd.Parameters.AddWithValue("@Aciklama", grp.Aciklama);
            cmd.Parameters.AddWithValue("@UyeID", grp.UyeID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void GrupDelete(Grup grp)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Grup where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", grp.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Iddia grubu
        [WebMethod]
        public List<Iddia> IddiaSelect(string par, byte sw)
        {
            List<Iddia> dizi = new List<Iddia>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            switch (par)
            {
                case null:
                default:
                    switch (sw)
                    {
                        default:
                        case 0:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID order by BitisTarih desc", cnn);
                            break;
                        case 1:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where DATEDIFF ( hour , i.BitisTarih ,getdate())<=1 order by BitisTarih desc ", cnn);
                            break;
                        case 2:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where DATEDIFF ( hour , i.BitisTarih ,getdate())<=24 order by BitisTarih desc", cnn);
                            break;
                        case 3:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where DATEDIFF ( month , i.BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 4:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID  where DATEDIFF ( year , i.BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                    }
                    break;
                case "wc":
                    switch (sw)
                    {
                        default:
                        case 0:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null order by BitisTarih desc", cnn);
                            break;
                        case 1:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and DATEDIFF ( hour , i.BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 2:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and DATEDIFF ( hour , i.BitisTarih ,getdate())<=24 order by BitisTarih desc", cnn);
                            break;
                        case 3:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and DATEDIFF ( month , i.BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 4:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and DATEDIFF ( year , i.BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                    }
                    break;
                case "woc":
                    switch (sw)
                    {
                        default:
                        case 0:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null order by BitisTarih desc", cnn);
                            break;
                        case 1:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null  and DATEDIFF ( hour , i.BitisTarih ,getdate())<=1  order by BitisTarih desc", cnn);
                            break;
                        case 2:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null  and DATEDIFF ( hour , i.BitisTarih ,getdate())<=24  order by BitisTarih desc", cnn);
                            break;
                        case 3:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null  and DATEDIFF ( month , i.BitisTarih ,getdate())<=1  order by BitisTarih desc", cnn);
                            break;
                        case 4:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null and DATEDIFF ( year , i.BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                    }
                    break;
                case "vc":
                    switch (sw)
                    {
                        default:
                        case 0:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 order by BitisTarih desc", cnn);
                            break;
                        case 1:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0  and DATEDIFF ( hour , i.BitisTarih ,getdate())<=1  order by BitisTarih desc", cnn);
                            break;
                        case 2:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 and DATEDIFF ( hour , i.BitisTarih ,getdate())<=24  order by BitisTarih desc", cnn);
                            break;
                        case 3:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 and DATEDIFF ( month , i.BitisTarih ,getdate())<=1  order by BitisTarih desc", cnn);
                            break;
                        case 4:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 and DATEDIFF ( year , i.BitisTarih ,getdate())<=1  order by BitisTarih desc", cnn);
                            break;
                    }
                    break;
                case "rc":
                    switch (sw)
                    {
                        default:
                        case 0:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 order by BitisTarih desc", cnn);
                            break;
                        case 1:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and DATEDIFF ( hour , i.BitisTarih ,getdate())<=1  order by BitisTarih desc", cnn);
                            break;
                        case 2:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and DATEDIFF ( hour , i.BitisTarih ,getdate())<=24  order by BitisTarih desc", cnn);
                            break;
                        case 3:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and DATEDIFF ( month , i.BitisTarih ,getdate())<=1  order by BitisTarih desc", cnn);
                            break;
                        case 4:
                            cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID inner join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and DATEDIFF ( year , i.BitisTarih ,getdate())<=1  order by BitisTarih desc", cnn);
                            break;
                    }
                    break;
            }

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Iddia yeniidd = new Iddia
                {
                    ID = rdr.GetGuid(0),
                    HakemID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    KazananID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(1),
                    KaybedenID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                    IddiaAcanKisiID = rdr.IsDBNull(4) ? null : (Guid?)rdr.GetGuid(4),
                    IddiaAcanKisiPoka = rdr.GetInt32(5),
                    IddiaAcanKisiOy = rdr.GetInt32(6),
                    IddiaAcanKisiYorum = rdr.GetString(7),
                    IddiaRakipKisiID = rdr.IsDBNull(8) ? null : (Guid?)rdr.GetGuid(8),
                    IddiaRakipKisiPoka = rdr.GetInt32(9),
                    IddiaRakipKisiOy = rdr.GetInt32(10),
                    IddiaRakipKisiYorum = rdr.GetString(11),
                    BaslangicTarih = rdr.GetDateTime(12),
                    BitisTarih = rdr.GetDateTime(13),
                    GerceklesmeTarih = rdr.GetDateTime(14),
                    GerceklesmeYer = rdr.GetString(15),
                    MustehcenIddia = rdr.GetBoolean(16),
                    Ban = rdr.GetBoolean(17),
                    Acik = rdr.GetBoolean(18),
                    GercekIddia = rdr.GetBoolean(19),
                    ToplamPoka = rdr.GetInt32(20),
                    UyeDetayIddiaAcanKisiAd = rdr.GetString(21),
                    UyeDetayIddiaRakipKisiAd = rdr.IsDBNull(22) ? null : rdr.GetString(22),
                    UyeDetayIddiaAcanKisiResim = rdr.IsDBNull(23) ? null : (byte[])rdr.GetValue(23),
                    UyeDetayIddiaRakipKisiResim = rdr.IsDBNull(24) ? null : (byte[])rdr.GetValue(24),
                    UyeDetayIddiaAcanKisYer = rdr.GetString(25),
                    UyeDetayIddiaRakipKisiYer = rdr.GetString(26),
                };
                dizi.Add(yeniidd);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public List<Iddia> IddiaSelect(string par1, List<Guid> par2, byte sw)
        {
            List<Iddia> dizi = new List<Iddia>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            switch (par1)
            {
                case null:
                default:
                    string komutcumle1 = "";
                    switch (sw)
                    {
                        default:
                        case 0:
                            komutcumle1 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i inner join dbo.UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join dbo.UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID  inner join  dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on ia.IddiaID=i.ID where ";
                            break;
                        case 1:
                            komutcumle1 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i inner join dbo.UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join dbo.UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID  inner join  dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on ia.IddiaID=i.ID where DATEDIFF ( hour , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 2:
                            komutcumle1 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i inner join dbo.UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join dbo.UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID  inner join  dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on ia.IddiaID=i.ID where DATEDIFF ( hour , i.BitisTarih ,getdate())<=24 and ";
                            break;
                        case 3:
                            komutcumle1 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i inner join dbo.UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join dbo.UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID  inner join  dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on ia.IddiaID=i.ID where DATEDIFF ( month , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 4:
                            komutcumle1 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i inner join dbo.UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join dbo.UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID  inner join  dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on ia.IddiaID=i.ID where DATEDIFF ( year , i.BitisTarih ,getdate())<=1 and ";
                            break;
                    }

                    foreach (Guid item in par2)
                    {
                        komutcumle1 += " ia.IlgiAlanID = '" + item.ToString() + "' or";
                    }
                    komutcumle1 = komutcumle1.Remove(komutcumle1.Length - 2, 2) + " order by BitisTarih desc";
                    cmd = new SqlCommand(komutcumle1, cnn);
                    break;
                case "wc":
                    string komutcumle2 = "";
                    switch (sw)
                    {
                        default:
                        case 0:
                            komutcumle2 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and";
                            break;
                        case 1:
                            komutcumle2 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and DATEDIFF ( hour , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 2:
                            komutcumle2 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and DATEDIFF ( hour , i.BitisTarih ,getdate())<=24 and ";
                            break;
                        case 3:
                            komutcumle2 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and DATEDIFF ( month , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 4:
                            komutcumle2 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is not null and DATEDIFF ( year , i.BitisTarih ,getdate())<=1 and ";
                            break;
                    }

                    foreach (Guid item in par2)
                    {
                        komutcumle2 += " ia.IlgiAlanID = '" + item.ToString() + "' or";
                    }
                    komutcumle2 = komutcumle2.Remove(komutcumle2.Length - 2, 2) + " order by BitisTarih desc";
                    cmd = new SqlCommand(komutcumle2, cnn);
                    break;
                case "woc":
                    string komutcumle3 = "";
                    switch (sw)
                    {
                        default:
                        case 0:
                            komutcumle3 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null and";
                            break;
                        case 1:
                            komutcumle3 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null and DATEDIFF ( hour , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 2:
                            komutcumle3 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null and DATEDIFF ( hour , i.BitisTarih ,getdate())<=24 and ";
                            break;
                        case 3:
                            komutcumle3 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null and DATEDIFF ( month , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 4:
                            komutcumle3 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where IddiaRakipKisiID is null and DATEDIFF ( year , i.BitisTarih ,getdate())<=1 and ";
                            break;
                    }

                    foreach (Guid item in par2)
                    {
                        komutcumle3 += " ia.IlgiAlanID = '" + item.ToString() + "' or";
                    }
                    komutcumle3 = komutcumle3.Remove(komutcumle3.Length - 2, 2) + " order by BitisTarih desc";
                    cmd = new SqlCommand(komutcumle3, cnn);
                    break;
                case "vc":
                    string komutcumle4 = "";
                    switch (sw)
                    {
                        default:
                        case 0:
                            komutcumle4 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 and";
                            break;
                        case 1:
                            komutcumle4 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 and DATEDIFF ( hour , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 2:
                            komutcumle4 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 and DATEDIFF ( hour , i.BitisTarih ,getdate())<=24 and ";
                            break;
                        case 3:
                            komutcumle4 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 and DATEDIFF ( month , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 4:
                            komutcumle4 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=0 and DATEDIFF ( year , i.BitisTarih ,getdate())<=1 and ";
                            break;
                    }

                    foreach (Guid item in par2)
                    {
                        komutcumle4 += " ia.IlgiAlanID = '" + item.ToString() + "' or";
                    }
                    komutcumle4 = komutcumle4.Remove(komutcumle4.Length - 2, 2) + " order by BitisTarih desc";
                    cmd = new SqlCommand(komutcumle4, cnn);
                    break;
                case "rc":
                    string komutcumle5 = "";
                    switch (sw)
                    {
                        default:
                        case 0:
                            komutcumle5 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and";
                            break;
                        case 1:
                            komutcumle5 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and DATEDIFF ( hour , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 2:
                            komutcumle5 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and DATEDIFF ( hour , i.BitisTarih ,getdate())<=24 and ";
                            break;
                        case 3:
                            komutcumle5 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and DATEDIFF ( month , i.BitisTarih ,getdate())<=1 and ";
                            break;
                        case 4:
                            komutcumle5 = "select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID where GercekIddia=1 and DATEDIFF ( year , i.BitisTarih ,getdate())<=1 and ";
                            break;
                    }

                    foreach (Guid item in par2)
                    {
                        komutcumle5 += " ia.IlgiAlanID = '" + item.ToString() + "' or";
                    }
                    komutcumle5 = komutcumle5.Remove(komutcumle5.Length - 2, 2) + " order by BitisTarih desc";
                    cmd = new SqlCommand(komutcumle5, cnn);
                    break;
            }

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Iddia yeniidd = new Iddia
                {
                    ID = rdr.GetGuid(0),
                    HakemID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    KazananID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(1),
                    KaybedenID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                    IddiaAcanKisiID = rdr.IsDBNull(4) ? null : (Guid?)rdr.GetGuid(4),
                    IddiaAcanKisiPoka = rdr.GetInt32(5),
                    IddiaAcanKisiOy = rdr.GetInt32(6),
                    IddiaAcanKisiYorum = rdr.GetString(7),
                    IddiaRakipKisiID = rdr.IsDBNull(8) ? null : (Guid?)rdr.GetGuid(8),
                    IddiaRakipKisiPoka = rdr.GetInt32(9),
                    IddiaRakipKisiOy = rdr.GetInt32(10),
                    IddiaRakipKisiYorum = rdr.GetString(11),
                    BaslangicTarih = rdr.GetDateTime(12),
                    BitisTarih = rdr.GetDateTime(13),
                    GerceklesmeTarih = rdr.GetDateTime(14),
                    GerceklesmeYer = rdr.GetString(15),
                    MustehcenIddia = rdr.GetBoolean(16),
                    Ban = rdr.GetBoolean(17),
                    Acik = rdr.GetBoolean(18),
                    GercekIddia = rdr.GetBoolean(19),
                    ToplamPoka = rdr.GetInt32(20),
                    UyeDetayIddiaAcanKisiAd = rdr.GetString(21),
                    UyeDetayIddiaRakipKisiAd = rdr.IsDBNull(22) ? null : rdr.GetString(22),
                    UyeDetayIddiaAcanKisiResim = rdr.IsDBNull(23) ? null : (byte[])rdr.GetValue(23),
                    UyeDetayIddiaRakipKisiResim = rdr.IsDBNull(24) ? null : (byte[])rdr.GetValue(24),
                    UyeDetayIddiaAcanKisYer = rdr.GetString(25),
                    UyeDetayIddiaRakipKisiYer = rdr.GetString(26),
                };
                dizi.Add(yeniidd);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public Iddia IddiaSelect(Guid gid)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select i.*,u1.TakmaAd,u2.TakmaAd,u1.Resim,u2.Resim,u1.Sehir,u2.Sehir from dbo.Iddia as i join UyeDetay as u1 on u1.ID=i.IddiaAcanKisiID left join UyeDetay as u2 on u2.ID=i.IddiaRakipKisiID order by BitisTarih desc", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Iddia yeniidd = new Iddia
            {
                ID = rdr.GetGuid(0),
                HakemID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                KazananID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(1),
                KaybedenID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                IddiaAcanKisiID = rdr.IsDBNull(4) ? null : (Guid?)rdr.GetGuid(4),
                IddiaAcanKisiPoka = rdr.GetInt32(5),
                IddiaAcanKisiOy = rdr.GetInt32(6),
                IddiaAcanKisiYorum = rdr.GetString(7),
                IddiaRakipKisiID = rdr.IsDBNull(8) ? null : (Guid?)rdr.GetGuid(8),
                IddiaRakipKisiPoka = rdr.GetInt32(9),
                IddiaRakipKisiOy = rdr.GetInt32(10),
                IddiaRakipKisiYorum = rdr.GetString(11),
                BaslangicTarih = rdr.GetDateTime(12),
                BitisTarih = rdr.GetDateTime(13),
                GerceklesmeTarih = rdr.GetDateTime(14),
                GerceklesmeYer = rdr.GetString(15),
                MustehcenIddia = rdr.GetBoolean(16),
                Ban = rdr.GetBoolean(17),
                Acik = rdr.GetBoolean(18),
                GercekIddia = rdr.GetBoolean(19),
                ToplamPoka = rdr.GetInt32(20),
                UyeDetayIddiaAcanKisiAd = rdr.GetString(21),
                UyeDetayIddiaRakipKisiAd = rdr.IsDBNull(22) ? null : rdr.GetString(22),
                UyeDetayIddiaAcanKisiResim = rdr.IsDBNull(23) ? null : (byte[])rdr.GetValue(23),
                UyeDetayIddiaRakipKisiResim = rdr.IsDBNull(24) ? null : (byte[])rdr.GetValue(24),
                UyeDetayIddiaAcanKisYer = rdr.GetString(25),
                UyeDetayIddiaRakipKisiYer = rdr.GetString(26),
            };

            cnn.Close();
            return yeniidd;
        }
        [WebMethod]
        public void IddiaInsert(Iddia idd)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Iddia values (@ID,@HakemID,@KazananID,@KaybedenID,@IddiaAcanKisiID,@IddiaAcanKisiPoka,@IddiaAcanKisiOy,@IddiaAcanKisiYorum,@IddiaRakipKisiID,@IddiaRakipKisiPoka,@IddiaRakipKisiOy,@IddiaRakipKisiYorum,@BaslangicTarih,@BitisTarih,@GerceklesmeTarih,@GerceklesmeYer,@MustehcenIddia,@Ban,@Acik,@GercekIddia,@ToplamPoka)", cnn);
            cmd.Parameters.AddWithValue("@ID", idd.ID);
            cmd.Parameters.AddWithValue("@HakemID", idd.HakemID);
            cmd.Parameters.AddWithValue("@KazananID", idd.KazananID);
            cmd.Parameters.AddWithValue("@KaybedenID", idd.KaybedenID);
            cmd.Parameters.AddWithValue("@IddiaAcanKisiID", idd.IddiaAcanKisiID);
            cmd.Parameters.AddWithValue("@IddiaAcanKisiPoka", idd.IddiaAcanKisiPoka);
            cmd.Parameters.AddWithValue("@IddiaAcanKisiOy", idd.IddiaAcanKisiOy);
            cmd.Parameters.AddWithValue("@IddiaAcanKisiYorum", idd.IddiaAcanKisiYorum);
            cmd.Parameters.AddWithValue("@IddiaRakipKisiID", idd.IddiaRakipKisiID);
            cmd.Parameters.AddWithValue("@IddiaRakipKisiPoka", idd.IddiaRakipKisiPoka);
            cmd.Parameters.AddWithValue("@IddiaRakipKisiOy", idd.IddiaRakipKisiOy);
            cmd.Parameters.AddWithValue("@IddiaRakipKisiYorum", idd.IddiaRakipKisiYorum);
            cmd.Parameters.AddWithValue("@BaslangicTarih", idd.BaslangicTarih);
            cmd.Parameters.AddWithValue("@BitisTarih", idd.BitisTarih);
            cmd.Parameters.AddWithValue("@GerceklesmeTarih", idd.GerceklesmeTarih);
            cmd.Parameters.AddWithValue("@GerceklesmeYer", idd.GerceklesmeYer);
            cmd.Parameters.AddWithValue("@MustehcenIddia", idd.MustehcenIddia);
            cmd.Parameters.AddWithValue("@Ban", idd.Ban);
            cmd.Parameters.AddWithValue("@Acik", idd.Acik);
            cmd.Parameters.AddWithValue("@GercekIddia", idd.GercekIddia);
            cmd.Parameters.AddWithValue("@ToplamPoka", idd.ToplamPoka);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void IddiaUpdate(Iddia idd)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("update dbo.Iddia set HakemID=@HakemID,KazananID=@KazananID,KaybedenID=@KaybedenID,IddiaAcanKisiPoka=@IddiaAcanKisiPoka,IddiaAcanKisiOy@IddiaAcanKisiOy,IddiaAcanKisiYorum=@IddiaAcanKisiYorum,IddiaRakipKisiID=@IddiaRakipKisiID,IddiaRakipKisiPoka=@IddiaRakipKisiPoka,IddiaRakipKisiOy=@IddiaRakipKisiOy,IddiaRakipKisiYorum=@IddiaRakipKisiYorum,BitisTarih=@BitisTarih,GerceklesmeTarih=@GerceklesmeTarih,GerceklesmeYer=@GerceklesmeYer,MustehcenIddia=@MustehcenIddia,Acik=@Acik,GercekIddia=@GercekIddia,ToplamPoka=@ToplamPoka where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", idd.ID);
            cmd.Parameters.AddWithValue("@HakemID", idd.HakemID);
            cmd.Parameters.AddWithValue("@KazananID", idd.KazananID);
            cmd.Parameters.AddWithValue("@KaybedenID", idd.KaybedenID);
            cmd.Parameters.AddWithValue("@IddiaAcanKisiPoka", idd.IddiaAcanKisiPoka);
            cmd.Parameters.AddWithValue("@IddiaAcanKisiOy", idd.IddiaAcanKisiOy);
            cmd.Parameters.AddWithValue("@IddiaAcanKisiYorum", idd.IddiaAcanKisiYorum);
            cmd.Parameters.AddWithValue("@IddiaRakipKisiID", idd.IddiaRakipKisiID);
            cmd.Parameters.AddWithValue("@IddiaRakipKisiPoka", idd.IddiaRakipKisiPoka);
            cmd.Parameters.AddWithValue("@IddiaRakipKisiOy", idd.IddiaRakipKisiOy);
            cmd.Parameters.AddWithValue("@IddiaRakipKisiYorum", idd.IddiaRakipKisiYorum);
            cmd.Parameters.AddWithValue("@BitisTarih", idd.BitisTarih);
            cmd.Parameters.AddWithValue("@GerceklesmeTarih", idd.GerceklesmeTarih);
            cmd.Parameters.AddWithValue("@GerceklesmeYer", idd.GerceklesmeYer);
            cmd.Parameters.AddWithValue("@MustehcenIddia", idd.MustehcenIddia);
            cmd.Parameters.AddWithValue("@Acik", idd.Acik);
            cmd.Parameters.AddWithValue("@GercekIddia", idd.GercekIddia);
            cmd.Parameters.AddWithValue("@ToplamPoka", idd.ToplamPoka);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void IddiaDelete(Iddia idd)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Iddia where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", idd.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Ilgi Alan grubu
        [WebMethod]
        public List<IlgiAlan> IlgiAlanTop10Select(Guid? id)
        {
            List<IlgiAlan> dizi = new List<IlgiAlan>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            if (id == null)
            {
                cmd = new SqlCommand("select top 10 * from dbo.IlgiAlan order by Izlenme", cnn);
            }
            else
            {
                cmd = new SqlCommand("select top 10 i.* from dbo.IlgiAlan as i join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on i.ID=ia.IlgiAlanID  where i.UyeID=@id order by Izlenme", cnn);
                cmd.Parameters.AddWithValue("@id", id);
            }

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                IlgiAlan yeniilgaln = new IlgiAlan
                {
                    ID = rdr.GetGuid(0),
                    IlgiAlanTanim = rdr.GetString(1),
                    Izlenme = rdr.GetInt32(2),
                };
                dizi.Add(yeniilgaln);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public List<IlgiAlan> IlgiAlanSelect(byte sw, Guid id)
        {
            List<IlgiAlan> dizi = new List<IlgiAlan>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            switch (sw)
            {
                default:
                case 0:
                    cmd = new SqlCommand("select * from dbo.IlgiAlan order by Izlenme desc", cnn);
                    break;
                case 1:
                case 2:
                    cmd = new SqlCommand("select * from dbo.IlgiAlan as i inner join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on i.ID=ia.IlgiAlanID where IddiaID=@id order by Izlenme desc", cnn);
                    cmd.Parameters.AddWithValue("@id", id);
                    break;
                case 3:
                case 4:
                    cmd = new SqlCommand("select * from dbo.IlgiAlan as i inner join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on i.ID=ia.IlgiAlanID where Soru_AnketID=@id order by Izlenme desc", cnn);
                    cmd.Parameters.AddWithValue("@id", id);
                    break;
                case 5:
                    cmd = new SqlCommand("select * from dbo.IlgiAlan as i inner join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on i.ID=ia.IlgiAlanID where GrupID=@id order by Izlenme desc", cnn);
                    cmd.Parameters.AddWithValue("@id", id);
                    break;
                case 6:
                    cmd = new SqlCommand("select top 10 i.* from dbo.IlgiAlan as i join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ia on i.ID=ia.IlgiAlanID  where i.UyeID=@id order by Izlenme", cnn);
                    cmd.Parameters.AddWithValue("@id", id);
                    break;
            }


            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                IlgiAlan yeniilgaln = new IlgiAlan
                {
                    ID = rdr.GetGuid(0),
                    IlgiAlanTanim = rdr.GetString(1),
                    Izlenme = rdr.GetInt32(2),
                };
                dizi.Add(yeniilgaln);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void IlgiAlanInsert(IlgiAlan ilgaln)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.IlgiAlan values (@ID,@IlgiAlanTanim,@Izlenme)", cnn);
            cmd.Parameters.AddWithValue("@ID", ilgaln.ID);
            cmd.Parameters.AddWithValue("@IlgiAlanTanim", ilgaln.IlgiAlanTanim.ToLower());
            cmd.Parameters.AddWithValue("@Izlenme", ilgaln.Izlenme);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void IlgiAlaniUpdate(IlgiAlani ilgaln)
        //{

        //}
        //[WebMethod]
        //public void IlgiAlaniDelete(IlgiAlani ilgaln)
        //{

        //}       
        #endregion

        #region Izleyici Ol grubu
        [WebMethod]
        public List<IzleyiciOl> IzleyiciOlSelect()
        {
            List<IzleyiciOl> dizi = new List<IzleyiciOl>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.IzleyiciOl", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                IzleyiciOl yenizlyc = new IzleyiciOl
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    IddiaID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    Onay = rdr.GetBoolean(3),
                };
                dizi.Add(yenizlyc);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void IzleyiciOlInsert(IzleyiciOl izlyc)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.IzleyiciOl values (@ID,@UyeID,@IddiaID,@Onay)", cnn);
            cmd.Parameters.AddWithValue("@ID", izlyc.ID);
            cmd.Parameters.AddWithValue("@UyeID", izlyc.UyeID);
            cmd.Parameters.AddWithValue("@IddiaID", izlyc.IddiaID);
            cmd.Parameters.AddWithValue("@Onay", izlyc.Onay);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void IzleyiciOlUpdate(IzleyiciOl izlyc)
        //{

        //}
        [WebMethod]
        public void IzleyiciOlDelete(IzleyiciOl izlyc)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.IzleyiciOl where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", izlyc.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Kurumsal grubu
        #endregion

        #region Mesaj grubu
        [WebMethod]
        public List<Mesaj> MesajSelect()
        {
            List<Mesaj> dizi = new List<Mesaj>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.Mesaj", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Mesaj yenimsj = new Mesaj
                {
                    ID = rdr.GetGuid(0),
                    GonderenID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    AliciID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    Tarih = rdr.GetDateTime(3),
                    Icerik = rdr.GetString(4),
                };
                dizi.Add(yenimsj);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void MesajInsert(Mesaj msj)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Mesaj values (@ID,@GonderenID,@AliciID,@Tarih,@Icerik)", cnn);
            cmd.Parameters.AddWithValue("@ID", msj.ID);
            cmd.Parameters.AddWithValue("@GonderenID", msj.GonderenID);
            cmd.Parameters.AddWithValue("@AliciID", msj.AliciID);
            cmd.Parameters.AddWithValue("@Tarih", msj.Tarih);
            cmd.Parameters.AddWithValue("@Icerik", msj.Icerik);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void MesajUpdate(Mesaj msj)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("update dbo.Mesaj set Icerik=@Icerik where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", msj.ID);
            cmd.Parameters.AddWithValue("@Icerik", msj.Icerik);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void MesajDelete(Mesaj msj)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Mesaj where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", msj.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Oy grubu
        [WebMethod]
        public List<Oy> OySelect()
        {
            List<Oy> dizi = new List<Oy>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.Oy", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Oy yenioy = new Oy
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    IddiaID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    OyVerdigiKisiID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                    PokaMiktar = rdr.GetInt32(4),
                };
                dizi.Add(yenioy);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void OyInsert(Oy oy)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Oy values (@ID,@UyeID,@IddiaID,@OyVerdigiKisiID,@PokaMiktar)", cnn);
            cmd.Parameters.AddWithValue("@ID", oy.ID);
            cmd.Parameters.AddWithValue("@UyeID", oy.UyeID);
            cmd.Parameters.AddWithValue("@IddiaID", oy.IddiaID);
            cmd.Parameters.AddWithValue("@OyVerdigiKisiID", oy.OyVerdigiKisiID);
            cmd.Parameters.AddWithValue("@PokaMiktar", oy.PokaMiktar);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void OyUpdate(Oy oy)
        //{

        //}
        //[WebMethod]
        //public void OyDelete(Oy oy)
        //{

        //}
        #endregion

        #region Soru_Anket grubu
        [WebMethod]
        public List<Soru_Anket> Soru_AnketSelect(string par, byte sw)
        {
            List<Soru_Anket> dizi = new List<Soru_Anket>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            switch (par)
            {
                case null:
                default:
                    switch (sw)
                    {
                        default:
                        case 0:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID order by BitisTarih desc", cnn);
                            break;
                        case 1:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where DATEDIFF ( hour , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 2:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where DATEDIFF ( hour , BitisTarih ,getdate())<=24 order by BitisTarih desc", cnn);
                            break;
                        case 3:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where DATEDIFF ( month , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 4:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where DATEDIFF ( year , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                    }
                    break;
                case "s":
                    switch (sw)
                    {
                        default:
                        case 0:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=1 order by BitisTarih desc", cnn);
                            break;
                        case 1:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=1 and DATEDIFF ( hour , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 2:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=1  and DATEDIFF ( hour , BitisTarih ,getdate())<24 order by BitisTarih desc", cnn);
                            break;
                        case 3:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=1  and DATEDIFF ( month , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 4:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=1  and DATEDIFF ( year , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                    }
                    break;
                case "q":
                    switch (sw)
                    {
                        default:
                        case 0:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=0 order by BitisTarih desc", cnn);
                            break;
                        case 1:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=0  and DATEDIFF ( hour , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 2:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=0  and DATEDIFF ( hour , BitisTarih ,getdate())<=24 order by BitisTarih desc", cnn);
                            break;
                        case 3:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=0  and DATEDIFF ( month , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                        case 4:
                            cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Anket=0  and DATEDIFF ( year , BitisTarih ,getdate())<=1 order by BitisTarih desc", cnn);
                            break;
                    }
                    break;
            }

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Soru_Anket yenisrankt = new Soru_Anket
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    Soru_AnketTanim = rdr.GetString(2),
                    BaslangicTarih = rdr.GetDateTime(3),
                    BitisTarih = rdr.GetDateTime(4),
                    Anket = rdr.GetBoolean(5),
                    UyeDetayAd = rdr.GetString(6),
                    UyeDetayResim = rdr.IsDBNull(7) ? null : (byte[])rdr.GetValue(7),
                    UyeDetayYer = rdr.GetString(8),
                };
                dizi.Add(yenisrankt);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public Soru_Anket Soru_AnketSelect(Guid id)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID where Soru_Anket.ID=@id order by BitisTarih desc", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Soru_Anket yenisrankt = new Soru_Anket
            {
                ID = rdr.GetGuid(0),
                UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                Soru_AnketTanim = rdr.GetString(2),
                BaslangicTarih = rdr.GetDateTime(3),
                BitisTarih = rdr.GetDateTime(4),
                Anket = rdr.GetBoolean(5),
                UyeDetayAd = rdr.GetString(6),
                UyeDetayResim = rdr.IsDBNull(7) ? null : (byte[])rdr.GetValue(7),
                UyeDetayYer = rdr.GetString(8)
            };

            cnn.Close();
            return yenisrankt;
        }
        [WebMethod]
        public List<Soru_Anket> Soru_AnketSelect(string par1, List<Guid> par2)
        {
            List<Soru_Anket> dizi = new List<Soru_Anket>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            switch (par1)
            {
                default:
                case null:
                    string komutcumle1 = "SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID as sa inner join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ar on sa.ID=ar.Soru_AnketID where";
                    foreach (Guid item in par2)
                    {
                        komutcumle1 += " ar.Soru_AnketID = '" + item.ToString() + "' or";
                    }
                    komutcumle1 = komutcumle1.Remove(komutcumle1.Length - 2, 2) + " order by BitisTarih desc";
                    cmd = new SqlCommand(komutcumle1, cnn);
                    break;
                case "s":
                    string komutcumle2 = "SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID as sa inner join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ar on sa.ID=ar.Soru_AnketID where Anket=1 and ";
                    foreach (Guid item in par2)
                    {
                        komutcumle2 += " ar.Soru_AnketID = '" + item.ToString() + "' or";
                    }
                    komutcumle2 = komutcumle2.Remove(komutcumle2.Length - 2, 2) + " order by BitisTarih desc";
                    cmd = new SqlCommand(komutcumle2, cnn);
                    break;
                case "q":
                    string komutcumle3 = "SELECT Soru_Anket.*, UyeDetay.TakmaAd, UyeDetay.Resim, UyeDetay.Sehir FROM         Soru_Anket INNER JOIN UyeDetay ON Soru_Anket.UyeID = UyeDetay.ID as sa inner join dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo as ar on sa.ID=ar.Soru_AnketID where Anket=0 and ";
                    foreach (Guid item in par2)
                    {
                        komutcumle3 += " ar.Soru_AnketID = '" + item.ToString() + "' or";
                    }
                    komutcumle3 = komutcumle3.Remove(komutcumle3.Length - 2, 2) + " order by BitisTarih desc";
                    cmd = new SqlCommand(komutcumle3, cnn);
                    break;
            }

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Soru_Anket yenisrankt = new Soru_Anket
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    Soru_AnketTanim = rdr.GetString(2),
                    BaslangicTarih = rdr.GetDateTime(3),
                    BitisTarih = rdr.GetDateTime(4),
                    Anket = rdr.GetBoolean(5),
                    UyeDetayAd = rdr.GetString(6),
                    UyeDetayResim = rdr.IsDBNull(7) ? null : (byte[])rdr.GetValue(7),
                    UyeDetayYer = rdr.GetString(8)
                };
                dizi.Add(yenisrankt);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void Soru_AnketInsert(Soru_Anket sa)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Soru_Anket values (@ID,@UyeID,@Soru_AnketTanim,@BaslangicTarih,@BitisTarih,@Anket)", cnn);
            cmd.Parameters.AddWithValue("@ID", sa.ID);
            cmd.Parameters.AddWithValue("@UyeID", sa.UyeID);
            cmd.Parameters.AddWithValue("@Soru_AnketTanim", sa.Soru_AnketTanim);
            cmd.Parameters.AddWithValue("@BaslangicTarih", sa.BaslangicTarih);
            cmd.Parameters.AddWithValue("@BitisTarih", sa.BitisTarih);
            cmd.Parameters.AddWithValue("@Anket", sa.Anket);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void Soru_AnketUpdate(Soru_Anket sa)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("update dbo.Soru_Anket set @Soru_AnketTanim,@BaslangicTarih,@BitisTarih,@Anket where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", sa.ID);
            cmd.Parameters.AddWithValue("@Soru_AnketTanim", sa.Soru_AnketTanim);
            cmd.Parameters.AddWithValue("@BaslangicTarih", sa.BaslangicTarih);
            cmd.Parameters.AddWithValue("@BitisTarih", sa.BitisTarih);
            cmd.Parameters.AddWithValue("@Anket", sa.Anket);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void Soru_AnketDelete(Soru_Anket sa)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Soru_Anket where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", sa.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Sikayet grubu
        [WebMethod]
        public List<Sikayet> SikayetSelect()
        {
            List<Sikayet> dizi = new List<Sikayet>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.Sikayet", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Sikayet yenisk = new Sikayet
                {
                    ID = rdr.GetGuid(0),
                    SikayetedenID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    SikayetEdilenID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    Nedeni = rdr.GetString(3),
                    Tarih = rdr.GetDateTime(4),
                };
                dizi.Add(yenisk);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void SikayetInsert(Sikayet si)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Sikayet values (@ID,@SikayetedenID,@SikayetEdilenID,@Nedeni,@Tarih)", cnn);
            cmd.Parameters.AddWithValue("@ID", si.ID);
            cmd.Parameters.AddWithValue("@SikayetedenID", si.SikayetedenID);
            cmd.Parameters.AddWithValue("@SikayetEdilenID", si.SikayetEdilenID);
            cmd.Parameters.AddWithValue("@Nedeni", si.Nedeni);
            cmd.Parameters.AddWithValue("@Tarih", si.Tarih);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void Soru_AnketUpdate(Soru_Anket sa)
        //{

        //}
        [WebMethod]
        public void Soru_AnketDelete(Sikayet si)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Sikayet where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", si.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region TakipEt grubu
        [WebMethod]
        public List<TakipEt> TakipEtSelect()
        {
            List<TakipEt> dizi = new List<TakipEt>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.TakipEt", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TakipEt yenisrankt = new TakipEt
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    BegenilenUyeID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                };
                dizi.Add(yenisrankt);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public int TakipEdenSelect(Guid id)
        {
            List<TakipEt> dizi = new List<TakipEt>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select count(*) from dbo.TakipEt where BegenilenUyeID=@id", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cnn.Open();
            int sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            return sonuc;
        }
        [WebMethod]
        public int TakipEttigiSelect(Guid id)
        {
            List<TakipEt> dizi = new List<TakipEt>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select count(*) from dbo.TakipEt where UyeID=@id", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cnn.Open();
            int sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            return sonuc;
        }
        [WebMethod]
        public void TakipEtInsert(TakipEt te)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.TakipEt values (@ID,@UyeID,@BegenilenUyeID)", cnn);
            cmd.Parameters.AddWithValue("@ID", te.ID);
            cmd.Parameters.AddWithValue("@UyeID", te.UyeID);
            cmd.Parameters.AddWithValue("@BegenilenUyeID", te.BegenilenUyeID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void TakipEtUpdate(Soru_Anket sa)
        //{

        //}
        [WebMethod]
        public void TakipEtDelete(TakipEt te)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.TakipEt where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", te.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Uye grubu
        [WebMethod]
        public List<UyeDetay> UyeDetaySelect()
        {
            List<UyeDetay> dizi = new List<UyeDetay>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.UyeDetay", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                UyeDetay yeniuydty = new UyeDetay
                {
                    ID = rdr.GetGuid(0),
                    TakmaAd = rdr.GetString(1),
                    Sifre = rdr.GetString(2),
                    Eposta = rdr.GetString(3),
                    Resim = rdr.IsDBNull(4) ? null : (byte[])rdr.GetValue(4),
                    Ulke = rdr.GetString(5),
                    Sehir = rdr.GetString(6),
                    DogumYili = rdr.GetDateTime(7),
                    Aciklama = rdr.GetString(8),
                    Website = rdr.GetString(9),
                    PokaMiktar = rdr.GetInt32(10),
                    KazanılanIddia = rdr.GetInt32(11),
                    KaybedilenIddia = rdr.GetInt32(12),
                    KazanılanPoka = rdr.GetInt32(13),
                    KaybedilenPoka = rdr.GetInt32(14),
                    UyeTip = rdr.GetBoolean(15),
                    Onay = rdr.GetBoolean(16),
                    Aktif = rdr.GetBoolean(17),
                };
                dizi.Add(yeniuydty);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public UyeDetay UyeDetaySelect(Guid id)
        {

            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.UyeDetay where ID=@id", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            UyeDetay yeniuydty = new UyeDetay
            {
                ID = rdr.GetGuid(0),
                TakmaAd = rdr.GetString(1),
                Sifre = rdr.GetString(2),
                Eposta = rdr.GetString(3),
                //..Resim = rdr.IsDBNull(4) ? null : (byte[])rdr.GetValue(4),
                Ulke = rdr.GetString(5),
                Sehir = rdr.GetString(6),
                DogumYili = rdr.GetDateTime(7),
                Aciklama = rdr.GetString(8),
                Website = rdr.GetString(9),
                PokaMiktar = rdr.GetInt32(10),
                KazanılanIddia = rdr.GetInt32(11),
                KaybedilenIddia = rdr.GetInt32(12),
                KazanılanPoka = rdr.GetInt32(13),
                KaybedilenPoka = rdr.GetInt32(14),
                UyeTip = rdr.GetBoolean(15),
                Onay = rdr.GetBoolean(16),
                Aktif = rdr.GetBoolean(17),
            };
            cnn.Close();
            return yeniuydty;
        }
        [WebMethod]
        public List<UyeDetay> UyeDetayTop10Select(Guid? id)
        {
            List<UyeDetay> dizi = new List<UyeDetay>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;
            if (id == null)
            {
                cmd = new SqlCommand("select top 10 * from dbo.UyeDetay order by newid()", cnn);
            }
            else
            {
                cmd = new SqlCommand("select top 10 * from dbo.UyeDetay where ID=@id order by newid()", cnn);
                cmd.Parameters.AddWithValue("@id", id);
            }

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                UyeDetay yeniuydty = new UyeDetay
                {
                    ID = rdr.GetGuid(0),
                    TakmaAd = rdr.GetString(1),
                    Sifre = rdr.GetString(2),
                    Eposta = rdr.GetString(3),
                    Resim = rdr.IsDBNull(4) ? null : (byte[])rdr.GetValue(4),
                    Ulke = rdr.GetString(5),
                    Sehir = rdr.GetString(6),
                    DogumYili = rdr.GetDateTime(7),
                    Aciklama = rdr.GetString(8),
                    Website = rdr.GetString(9),
                    PokaMiktar = rdr.GetInt32(10),
                    KazanılanIddia = rdr.GetInt32(11),
                    KaybedilenIddia = rdr.GetInt32(12),
                    KazanılanPoka = rdr.GetInt32(13),
                    KaybedilenPoka = rdr.GetInt32(14),
                    UyeTip = rdr.GetBoolean(15),
                    Onay = rdr.GetBoolean(16),
                    Aktif = rdr.GetBoolean(17),
                };
                dizi.Add(yeniuydty);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void UyeDetayInsert(UyeDetay udty)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.UyeDetay values (@ID,@TakmaAd,@Sifre,@Eposta,@Resim,@Ulke,@Sehir,@DogumYili,@Aciklama,@Website,@PokaMiktar,@KazanılanIddia,@KaybedilenIddia,@KazanılanPoka,@KaybedilenPoka,@UyeTip,@Onay,@Aktif)", cnn);
            cmd.Parameters.AddWithValue("@ID", udty.ID);
            cmd.Parameters.AddWithValue("@TakmaAd", udty.TakmaAd);
            cmd.Parameters.AddWithValue("@Sifre", udty.Sifre);
            cmd.Parameters.AddWithValue("@Eposta", udty.Eposta);
            SqlParameter parimg = new SqlParameter("@Resim", System.Data.SqlDbType.Image);
            parimg.Value = udty.Resim == null ? (object)DBNull.Value : udty.Resim;
            cmd.Parameters.Add(parimg);
            cmd.Parameters.AddWithValue("@Ulke", udty.Ulke);
            cmd.Parameters.AddWithValue("@Sehir", udty.Sehir);
            cmd.Parameters.AddWithValue("@DogumYili", udty.DogumYili);
            cmd.Parameters.AddWithValue("@Website", udty.Website);
            cmd.Parameters.AddWithValue("@Aciklama", udty.Aciklama);
            cmd.Parameters.AddWithValue("@PokaMiktar", udty.PokaMiktar);
            cmd.Parameters.AddWithValue("@KazanılanIddia", udty.KazanılanIddia);
            cmd.Parameters.AddWithValue("@KaybedilenIddia", udty.KaybedilenIddia);
            cmd.Parameters.AddWithValue("@KazanılanPoka", udty.KazanılanPoka);
            cmd.Parameters.AddWithValue("@KaybedilenPoka", udty.KaybedilenPoka);
            cmd.Parameters.AddWithValue("@UyeTip", udty.UyeTip);
            cmd.Parameters.AddWithValue("@Onay", udty.Onay);
            cmd.Parameters.AddWithValue("@Aktif", udty.Aktif);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void UyeDetayUpdate(UyeDetay udty)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("update dbo.UyeDetay set TakmaAd=@TakmaAd,Sifre=@Sifre,Eposta=@Eposta,Resim=@Resim,Ulke=@Ulke,Sehir=@Sehir,DogumYili=@DogumYili,Aciklama=@Aciklama,Website=@Website,PokaMiktar=@PokaMiktar,KazanılanIddia=@KazanılanIddia,KaybedilenIddia=@KaybedilenIddia,KazanılanPoka=@KazanılanPoka,KaybedilenPoka=@KaybedilenPoka,UyeTip=@UyeTip,Onay=@Onay,Aktif=@Aktif where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", udty.ID);
            cmd.Parameters.AddWithValue("@TakmaAd", udty.TakmaAd);
            cmd.Parameters.AddWithValue("@Sifre", udty.Sifre);
            cmd.Parameters.AddWithValue("@Eposta", udty.Eposta);
            cmd.Parameters.AddWithValue("@Resim", udty.Resim);
            cmd.Parameters.AddWithValue("@Ulke", udty.Ulke);
            cmd.Parameters.AddWithValue("@Sehir", udty.Sehir);
            cmd.Parameters.AddWithValue("@DogumYili", udty.DogumYili);
            cmd.Parameters.AddWithValue("@Aciklama", udty.Aciklama);
            cmd.Parameters.AddWithValue("@Website", udty.Website);
            cmd.Parameters.AddWithValue("@PokaMiktar", udty.PokaMiktar);
            cmd.Parameters.AddWithValue("@KazanılanIddia", udty.KazanılanIddia);
            cmd.Parameters.AddWithValue("@KaybedilenIddia", udty.KaybedilenIddia);
            cmd.Parameters.AddWithValue("@KazanılanPoka", udty.KazanılanPoka);
            cmd.Parameters.AddWithValue("@KaybedilenPoka", udty.KaybedilenPoka);
            cmd.Parameters.AddWithValue("@UyeTip", udty.UyeTip);
            cmd.Parameters.AddWithValue("@Onay", udty.Onay);
            cmd.Parameters.AddWithValue("@Aktif", udty.Aktif);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void UyeDetayDelete(UyeDetay udty)
        //{

        //}
        #endregion

        #region Yorum grubu
        [WebMethod]
        public List<Yorum> YorumSelect(Guid uid)
        {
            List<Yorum> dizi = new List<Yorum>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select y.*,u.TakmaAd,u.Resim from dbo.Yorum as y inner join UyeDetay as u on u.ID=y.UyeID where UyeId=@id order by Tarih desc", cnn);
            cmd.Parameters.AddWithValue("@id", uid);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Yorum yeniyrm = new Yorum
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    IddiaID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    SoruAnketID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                    GrupID = rdr.IsDBNull(4) ? null : (Guid?)rdr.GetGuid(4),
                    BildirimID = rdr.IsDBNull(5) ? null : (Guid?)rdr.GetGuid(5),
                    Tarih = rdr.GetDateTime(6),
                    YorumTanim = rdr.GetString(7),
                    UyeDetayAd = rdr.GetString(8),
                    UyeDetayResim = rdr.IsDBNull(9) ? null : (byte[])rdr.GetValue(9),
                };
                dizi.Add(yeniyrm);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public List<Yorum> YorumSelect(byte sw, Guid id)
        {
            List<Yorum> dizi = new List<Yorum>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = null;

            switch (sw)
            {
                case 0:
                    cmd = new SqlCommand("select y.*,u.TakmaAd,u.Resim from dbo.Yorum as y inner join UyeDetay as u on u.ID=y.UyeID where BildirimID=@id order by Tarih desc", cnn);
                    break;
                case 1:
                case 2:
                    cmd = new SqlCommand("select y.*,u.TakmaAd,u.Resim from dbo.Yorum as y inner join UyeDetay as u on u.ID=y.UyeID where IddiaID=@id order by Tarih desc", cnn);
                    break;
                case 3:
                case 4:
                    cmd = new SqlCommand("select y.*,u.TakmaAd,u.Resim from dbo.Yorum as y inner join UyeDetay as u on u.ID=y.UyeID where SoruAnketID=@id order by Tarih desc", cnn);
                    break;
                case 5:
                    cmd = new SqlCommand("select y.*,u.TakmaAd,u.Resim from dbo.Yorum as y inner join UyeDetay as u on u.ID=y.UyeID where GrupID=@id order by Tarih desc", cnn);
                    break;
                default:
                    cmd = new SqlCommand("select y.*,u.TakmaAd,u.Resim from dbo.Yorum as y inner join UyeDetay as u on u.ID=y.UyeID order by Tarih desc", cnn);
                    break;
            }

            cmd.Parameters.AddWithValue("@id", id);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Yorum yeniyrm = new Yorum
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    IddiaID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    SoruAnketID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                    GrupID = rdr.IsDBNull(4) ? null : (Guid?)rdr.GetGuid(4),
                    BildirimID = rdr.IsDBNull(5) ? null : (Guid?)rdr.GetGuid(5),
                    Tarih = rdr.GetDateTime(6),
                    YorumTanim = rdr.GetString(7),
                    UyeDetayAd = rdr.GetString(8),
                    UyeDetayResim = rdr.IsDBNull(9) ? null : (byte[])rdr.GetValue(9),
                };
                dizi.Add(yeniyrm);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void YorumInsert(Yorum yrm)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Yorum values (@ID,@UyeID,@IddiaID,@SoruAnketID,@GrupID,@BildirimID,@Tarih,@YorumTanim)", cnn);
            cmd.Parameters.AddWithValue("@ID", yrm.ID);
            cmd.Parameters.AddWithValue("@UyeID", yrm.UyeID);
            cmd.Parameters.AddWithValue("@IddiaID", yrm.IddiaID == null ? (object)DBNull.Value : yrm.IddiaID);
            cmd.Parameters.AddWithValue("@SoruAnketID", yrm.SoruAnketID == null ? (object)DBNull.Value : yrm.SoruAnketID);
            cmd.Parameters.AddWithValue("@GrupID", yrm.GrupID == null ? (object)DBNull.Value : yrm.GrupID);
            cmd.Parameters.AddWithValue("@BildirimID", yrm.BildirimID == null ? (object)DBNull.Value : yrm.BildirimID);
            cmd.Parameters.AddWithValue("@Tarih", yrm.Tarih);
            cmd.Parameters.AddWithValue("@YorumTanim", yrm.YorumTanim);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void YorumUpdate(Yorum yrm)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("update dbo.Yorum set YorumTanim=@YorumTanim where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", yrm.ID);
            cmd.Parameters.AddWithValue("@YorumTanim", yrm.YorumTanim);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void YorumDelete(Yorum yrm)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Yorum where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", yrm.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region Durum grubu
        [WebMethod]
        public List<Durum> DurumSelect()
        {
            List<Durum> dizi = new List<Durum>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("SELECT Durum.*, UyeDetay.TakmaAd, UyeDetay.Sehir FROM Durum INNER JOIN UyeDetay ON Durum.UyeID = UyeDetay.ID", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Durum yenirh = new Durum
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    Aciklama = rdr.GetString(2),
                    Tarih = rdr.GetDateTime(3),
                    UyeDetayAd = rdr.GetString(4),
                    UyeDetayYer = rdr.GetString(5),                     
                };
                dizi.Add(yenirh);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void DurumInsert(Durum rh)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.Durum values (@ID,@UyeID,@Aciklama,@Tarih)", cnn);
            cmd.Parameters.AddWithValue("@ID", rh.ID);
            cmd.Parameters.AddWithValue("@UyeID", rh.UyeID);
            cmd.Parameters.AddWithValue("@Aciklama", rh.Aciklama);
            cmd.Parameters.AddWithValue("@Tarih", rh.Tarih);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void DurumUpdate(Durum rh)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("update dbo.Durum set Aciklama=@Aciklama where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", rh.ID);
            cmd.Parameters.AddWithValue("@Aciklama", rh.Aciklama);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        [WebMethod]
        public void DurumDelete(Durum rh)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.Durum where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", rh.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        //Ara Tablolar
        #region UyeArkadasAraTablo grubu
        [WebMethod]
        public List<UyeArkadasAraTablo> UyeArkadasAraTabloSelect()
        {
            List<UyeArkadasAraTablo> dizi = new List<UyeArkadasAraTablo>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.UyeArkadasAraTablo", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                UyeArkadasAraTablo yeniara = new UyeArkadasAraTablo
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    ArkadasID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                };
                dizi.Add(yeniara);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void UyeArkadasAraTabloInsert(UyeArkadasAraTablo ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.UyeArkadasAraTablo values (@ID,@UyeID,@ArkadasID)", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cmd.Parameters.AddWithValue("@UyeID", ara.UyeID);
            cmd.Parameters.AddWithValue("@ArkadasID", ara.ArkadasID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void UyeArkadasAraTabloUpdate(UyeArkadasAraTablo ara)
        //{

        //}
        [WebMethod]
        public void UyeArkadasAraTabloDelete(UyeArkadasAraTablo ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.UyeArkadasAraTablo where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region UyeGrupAraTablo grubu
        [WebMethod]
        public List<UyeGrupAraTablo> UyeGrupAraTabloSelect()
        {
            List<UyeGrupAraTablo> dizi = new List<UyeGrupAraTablo>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.UyeGrupAraTablo", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                UyeGrupAraTablo yeniara = new UyeGrupAraTablo
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    GrupID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                };
                dizi.Add(yeniara);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void UyeGrupAraTabloInsert(UyeGrupAraTablo ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.UyeGrupAraTablo values (@ID,@UyeID,@GrupID)", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cmd.Parameters.AddWithValue("@UyeID", ara.UyeID);
            cmd.Parameters.AddWithValue("@GrupID", ara.GrupID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void UyeArkadasAraTabloUpdate(UyeArkadasAraTablo ara)
        //{

        //}
        [WebMethod]
        public void UyeGrupAraTabloDelete(UyeGrupAraTablo ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.UyeGrupAraTablo where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region UyeIlgiAlanAraTablo grubu
        [WebMethod]
        public List<UyeIlgiAlanAraTablo> UyeIlgiAlanAraTabloSelect()
        {
            List<UyeIlgiAlanAraTablo> dizi = new List<UyeIlgiAlanAraTablo>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.UyeIlgiAlanAraTablo", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                UyeIlgiAlanAraTablo yeniara = new UyeIlgiAlanAraTablo
                {
                    ID = rdr.GetGuid(0),
                    UyeID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    IlgiAlanID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                };
                dizi.Add(yeniara);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void UyeIlgiAlanAraTabloInsert(UyeIlgiAlanAraTablo ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.UyeIlgiAlanAraTablo values (@ID,@UyeID,@IlgiAlanID)", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cmd.Parameters.AddWithValue("@UyeID", ara.UyeID);
            cmd.Parameters.AddWithValue("@IlgiAlanID", ara.IlgiAlanID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void UyeArkadasAraTabloUpdate(UyeArkadasAraTablo ara)
        //{

        //}
        [WebMethod]
        public void UyeIlgiAlanAraTabloDelete(UyeIlgiAlanAraTablo ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.UyeIlgiAlanAraTablo where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region AnketSecenekler grubu
        [WebMethod]
        public List<AnketSecenekler> AnketSeceneklerSelect()
        {
            List<AnketSecenekler> dizi = new List<AnketSecenekler>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.AnketSecenekler", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                AnketSecenekler yeniara = new AnketSecenekler
                {
                    ID = rdr.GetGuid(0),
                    AnketID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    AnketSecenek = rdr.GetString(2),
                    SecenekSira = rdr.GetByte(3),
                    OyOran = rdr.GetInt32(4),
                };
                dizi.Add(yeniara);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void AnketSeceneklerInsert(AnketSecenekler ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.AnketSecenekler values (@ID,@AnketID,@AnketSecenek,@SecenekSira,@OyOran)", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cmd.Parameters.AddWithValue("@AnketID", ara.AnketID);
            cmd.Parameters.AddWithValue("@AnketSecenek", ara.AnketSecenek);
            cmd.Parameters.AddWithValue("@SecenekSira", ara.SecenekSira);
            cmd.Parameters.AddWithValue("@OyOran", ara.OyOran);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void UyeArkadasAraTabloUpdate(UyeArkadasAraTablo ara)
        //{

        //}
        [WebMethod]
        public void AnketSeceneklerDelete(AnketSecenekler ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.AnketSecenekler where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        #region IlgiAlanIddiaSoru_AnketGrupAraTablo
        [WebMethod]
        public List<IlgiAlanIddiaSoru_AnketGrupAraTablo> IlgiAlanIddiaSoru_AnketGrupAraTabloSelect()
        {
            List<IlgiAlanIddiaSoru_AnketGrupAraTablo> dizi = new List<IlgiAlanIddiaSoru_AnketGrupAraTablo>();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select * from dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                IlgiAlanIddiaSoru_AnketGrupAraTablo yeniara = new IlgiAlanIddiaSoru_AnketGrupAraTablo
                {
                    ID = rdr.GetGuid(0),
                    IlgiAlanID = rdr.IsDBNull(1) ? null : (Guid?)rdr.GetGuid(1),
                    IddiaID = rdr.IsDBNull(2) ? null : (Guid?)rdr.GetGuid(2),
                    Soru_AnketID = rdr.IsDBNull(3) ? null : (Guid?)rdr.GetGuid(3),
                    GrupID = rdr.IsDBNull(4) ? null : (Guid?)rdr.GetGuid(4),
                    UyeID = rdr.IsDBNull(5) ? null : (Guid?)rdr.GetGuid(5),
                };
                dizi.Add(yeniara);
            }
            cnn.Close();
            return dizi;
        }
        [WebMethod]
        public void IlgiAlanIddiaSoru_AnketGrupAraTabloInsert(IlgiAlanIddiaSoru_AnketGrupAraTablo ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("insert into dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo values (@ID,@IlgiAlanID,@IddiaID,@Soru_AnketID,@GrupID,@UyeID)", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cmd.Parameters.AddWithValue("@IlgiAlanID", ara.IlgiAlanID);
            cmd.Parameters.AddWithValue("@IddiaID", ara.IddiaID == null ? (object)DBNull.Value : ara.IddiaID);
            cmd.Parameters.AddWithValue("@Soru_AnketID", ara.Soru_AnketID == null ? (object)DBNull.Value : ara.Soru_AnketID);
            cmd.Parameters.AddWithValue("@GrupID", ara.GrupID == null ? (object)DBNull.Value : ara.GrupID);
            cmd.Parameters.AddWithValue("@UyeID", ara.UyeID == null ? (object)DBNull.Value : ara.UyeID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //[WebMethod]
        //public void UyeArkadasAraTabloUpdate(UyeArkadasAraTablo ara)
        //{

        //}
        [WebMethod]
        public void IlgiAlanIddiaSoru_AnketGrupAraTabloDelete(IlgiAlanIddiaSoru_AnketGrupAraTablo ara)
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("delete from dbo.IlgiAlanIddiaSoru_AnketGrupAraTablo where ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", ara.ID);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion

        //Diğer
        #region Arama grubu
        [WebMethod]
        public AutoCompleteBoxData AramaSonuc(RadAutoCompleteContext context)
        {
            string clientData = context["Text"].ToString();
            List<AutoCompleteBoxItemData> dizi = new List<AutoCompleteBoxItemData>();
            AutoCompleteBoxData data = new AutoCompleteBoxData();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd1 = new SqlCommand("select * from uyeara where TakmaAd like '%" + clientData + "%' order by TakmaAd asc", cnn);
            cnn.Open();
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {
                AutoCompleteBoxItemData itemData1 = new AutoCompleteBoxItemData();
                itemData1.Text = rdr1.GetString(1);
                itemData1.Value = "0;" + rdr1.GetGuid(0);
                dizi.Add(itemData1);
            }
            cnn.Close();
            data.Items = dizi.ToArray();
            return data;
        }
        [WebMethod]
        public AutoCompleteBoxData AnaAramaSonuc(RadAutoCompleteContext context)
        {
            string clientData = context["Text"].ToString();
            List<AutoCompleteBoxItemData> dizi = new List<AutoCompleteBoxItemData>();
            AutoCompleteBoxData data = new AutoCompleteBoxData();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select top 10 * from dbo.IlgiAlan where IlgiAlanTanim like '%" + clientData + "%' order by Izlenme desc,IlgiAlanTanim asc;select top 10 * from uyeara where TakmaAd like '%" + clientData + "%' order by TakmaAd asc", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                AutoCompleteBoxItemData itemData1 = new AutoCompleteBoxItemData();
                itemData1.Text = rdr.GetString(1);
                itemData1.Value = "0;" + rdr.GetGuid(0);
                dizi.Add(itemData1);
            }

            rdr.NextResult();
            while (rdr.Read())
            {
                AutoCompleteBoxItemData itemData1 = new AutoCompleteBoxItemData();
                itemData1.Text = rdr.GetString(1);
                itemData1.Value = "1;" + rdr.GetGuid(0);
                dizi.Add(itemData1);
            }

            cnn.Close();
            data.Items = dizi.ToArray();
            return data;
        }
        [WebMethod]
        public Guid HazirmisinSonuc()
        {
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd = new SqlCommand("select top 1 ID from UyeDetay where Aktif=1 order by newid()", cnn);
            cnn.Open();
            Guid id = Guid.Parse(cmd.ExecuteScalar().ToString());
            cnn.Close();
            return id;
        }
        [WebMethod]
        public AutoCompleteBoxData IlgiAlanSonuc(RadAutoCompleteContext context)
        {
            string clientData = context["Text"].ToString();
            List<AutoCompleteBoxItemData> dizi = new List<AutoCompleteBoxItemData>();
            AutoCompleteBoxData data = new AutoCompleteBoxData();
            SqlConnection cnn = Baglanti.Baglan();
            SqlCommand cmd1 = new SqlCommand("select top 10 * from dbo.IlgiAlan where IlgiAlanTanim like '%" + clientData + "%' order by Izlenme desc,IlgiAlanTanim asc", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd1.ExecuteReader();
            while (rdr.Read())
            {
                AutoCompleteBoxItemData itemData = new AutoCompleteBoxItemData();
                itemData.Text = rdr.GetString(1);
                itemData.Value = rdr.GetGuid(0).ToString();
                dizi.Add(itemData);
            }
            cnn.Close();
            data.Items = dizi.ToArray();
            return data;
        }
        #endregion

    }
}
