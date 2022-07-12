using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtProject.Classes;
using OtProject.UserControls;
using Telerik.Web.UI;

namespace OtProject
{
    public partial class SearchPage : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //(smControl.FindControl("CntxtTime") as RadContextMenu).ItemClick += cntxtTime_ItemClick;
            //(smControl.FindControl("CntxtMost") as RadContextMenu).ItemClick += cntxtMost_ItemClick;

            string q = Request.QueryString["q"];
            if (q == null)
            {
                DataLoads(null);
            }
            else
            {
                try
                {
                    string[] dizi = q.Remove(q.Length - 1, 1).Split(';');
                    RadAutoCompleteBox acb = smControl.FindControl("txtSearch") as RadAutoCompleteBox;
                    List<Guid> iddizi = new List<Guid>();
                    foreach (string item in dizi)
                    {
                        string txt = item.Split('-')[0];
                        string id = item.Split('-')[1] + "-" + item.Split('-')[2] + "-" + item.Split('-')[3] + "-" + item.Split('-')[4] + "-" + item.Split('-')[5];
                        Guid outparametre;
                        if (Guid.TryParse(id, out outparametre))
                        {
                            acb.Entries.Add(new AutoCompleteBoxEntry(txt, id));
                            iddizi.Add(outparametre);
                        }
                        else
                        {

                        }
                    }
                    DataLoads(iddizi);
                }
                catch
                {
                    DataLoads(null);
                }
            }

        }

        protected void rptResults_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            RadListViewItem item = e.Item;
            WallData data = ((Telerik.Web.UI.RadListViewDataItem)(e.Item)).DataItem as WallData;
            Repeater keyrep = (item.FindControl("rptKeywords") as Repeater);
            RadSocialShare sch = (item.FindControl("scsControl") as RadSocialShare);
            keyrep.DataSource = service.IlgiAlanSelect(data.Tip, data.ID);
            keyrep.DataBind();

            switch (data.Tip)
            {
                case 1:
                    string link1 = "/Windows/RVC.aspx?id=" + Crypto.EncryptStringAES(data.ID.ToString(), "10081008");
                    (item.FindControl("lnkPage") as LinkButton).PostBackUrl = link1;
                    sch.UrlToShare = link1;
                    sch.TitleToShare = "Otapoka'da bir iddia paylaştı.";
                    (item.FindControl("lnkPage") as LinkButton).Text = "Sanal İddia";
                    //item.FindControl("imgType1").Visible = true;
                    item.FindControl("lblVS").Visible = true;
                    break;
                case 2:
                    string link2 = "/Windows/RVC.aspx?id=" + Crypto.EncryptStringAES(data.ID.ToString(), "10081008");
                    (item.FindControl("lnkPage") as LinkButton).PostBackUrl = link2;
                    sch.UrlToShare = link2;
                    sch.TitleToShare = "Otapoka'da bir iddia paylaştı.";
                    (item.FindControl("lnkPage") as LinkButton).Text = "Gerçek İddia";
                    //item.FindControl("imgType2").Visible = true;
                    item.FindControl("lblVS").Visible = true;
                    break;
                case 3:
                    //item.FindControl("imgType3").Visible = true;
                    string link3 = "/Windows/Que.aspx?id=" + Crypto.EncryptStringAES(data.ID.ToString(), "10081008");
                    (item.FindControl("lnkPage") as LinkButton).PostBackUrl =
                    (item.FindControl("lnkPage") as LinkButton).Text = "Soru";
                    sch.UrlToShare = link3;
                    sch.TitleToShare = "Otapoka'da bir soru paylaştı.";
                    break;
                case 4:
                    //item.FindControl("imgType4").Visible = true;
                    string link4 = "/Windows/Sur.aspx?id=" + Crypto.EncryptStringAES(data.ID.ToString(), "10081008");
                    (item.FindControl("lnkPage") as LinkButton).PostBackUrl = link4;
                    (item.FindControl("lnkPage") as LinkButton).Text = "Anket";
                    sch.UrlToShare = link4;
                    sch.TitleToShare = "Otapoka'da bir anket paylaştı.";
                    break;
                case 5:
                    //item.FindControl("imgType5").Visible = true;
                    string link5 = "/Windows/Grp.aspx?id=" + Crypto.EncryptStringAES(data.ID.ToString(), "10081008");
                    (item.FindControl("lnkPage") as LinkButton).PostBackUrl = link5;
                    (item.FindControl("lnkPage") as LinkButton).Text = "Grup";
                    sch.UrlToShare = link5;
                    sch.TitleToShare = "Otapoka'da bir grup paylaştı.";
                    break;
            }
        }

        private void DataLoads(List<Guid> dizi)
        {
            List<WallData> topludizi = new List<WallData>();
            List<Iddia> iddiadizi = null;
            List<Soru_Anket> soru_anketdizi = null;
            List<Grup> grupdizi = null;
            string par = Request.QueryString["par"];

            if (dizi == null)
            {
                ButunSonuclar(topludizi, ref iddiadizi, ref soru_anketdizi, ref grupdizi, par);
            }
            else
            {
                FiltreliSonuclar(topludizi, ref iddiadizi, ref soru_anketdizi, ref grupdizi, par, dizi);
            }

            rptResults.DataSource = topludizi.OrderByDescending(a => a.BaslangicTarih);
            rptResults.DataBind();
        }

        private void ButunSonuclar(List<WallData> topludizi, ref List<Iddia> iddiadizi, ref List<Soru_Anket> soru_anketdizi, ref List<Grup> grupdizi, string par)
        {
            RadContextMenu menu = (smControl.FindControl("cntxtTime") as RadContextMenu);
            byte timeindex = menu.SelectedItem == null ? (byte)0 : Convert.ToByte(menu.SelectedItem.Index);
            if (par == null)
            {
                iddiadizi = service.IddiaSelect(null, timeindex);
                soru_anketdizi = service.Soru_AnketSelect(null, timeindex);
                grupdizi = service.GrupSelect(timeindex);
            }
            else
            {
                switch (par)
                {
                    case "wclm":
                        iddiadizi = service.IddiaSelect("wc", timeindex);
                        soru_anketdizi = new List<Soru_Anket>();
                        grupdizi = new List<Grup>();
                        break;
                    case "woclm":
                        iddiadizi = service.IddiaSelect("woc", timeindex);
                        soru_anketdizi = new List<Soru_Anket>();
                        grupdizi = new List<Grup>();
                        break;
                    case "vclm":
                        iddiadizi = service.IddiaSelect("vc", timeindex);
                        soru_anketdizi = new List<Soru_Anket>();
                        grupdizi = new List<Grup>();
                        break;
                    case "rclm":
                        iddiadizi = service.IddiaSelect("rc", timeindex);
                        soru_anketdizi = new List<Soru_Anket>();
                        grupdizi = new List<Grup>();
                        break;
                    case "que":
                        iddiadizi = new List<Iddia>();
                        soru_anketdizi = service.Soru_AnketSelect("q", timeindex);
                        grupdizi = new List<Grup>();
                        break;
                    case "srv":
                        iddiadizi = new List<Iddia>();
                        soru_anketdizi = service.Soru_AnketSelect("s", timeindex);
                        grupdizi = new List<Grup>();
                        break;
                    case "grp":
                        iddiadizi = new List<Iddia>();
                        soru_anketdizi = new List<Soru_Anket>();
                        grupdizi = service.GrupSelect(timeindex);
                        break;
                    default:
                        iddiadizi = service.IddiaSelect(null, timeindex);
                        soru_anketdizi = service.Soru_AnketSelect(null, timeindex);
                        grupdizi = service.GrupSelect(timeindex);
                        break;
                }
            }

            foreach (Iddia item in iddiadizi)
            {
                WallData wd = new WallData
                {
                    ID = item.ID,
                    Tip = item.GercekIddia ? (byte)2 : (byte)1,
                    UyeID1 = item.IddiaAcanKisiID,
                    UyeID2 = item.IddiaRakipKisiID,
                    AdYer1 = item.UyeDetayIddiaAcanKisiAd+" - "+item.UyeDetayIddiaAcanKisYer,
                    AdYer2 = item.UyeDetayIddiaRakipKisiAd+" - "+item.UyeDetayIddiaRakipKisiYer,
                    BaslangicTarih = item.BaslangicTarih,
                    BitisTarih = item.BitisTarih,
                    KalanSure = (item.BitisTarih - item.BaslangicTarih).ToString(),
                    Aciklama = item.IddiaAcanKisiYorum,
                    Oy1 = item.IddiaAcanKisiOy,
                    Oy2 = item.IddiaRakipKisiOy,
                    Poka1 = item.IddiaAcanKisiPoka,
                    Poka2 = item.IddiaRakipKisiPoka,
                    ToplamPoka = item.ToplamPoka,
                    Yer = item.GerceklesmeYer,
                    Acik = item.Acik,
                    Mustehcen = item.MustehcenIddia,
                };
                topludizi.Add(wd);
            }

            foreach (Soru_Anket item in soru_anketdizi)
            {
                WallData wd = new WallData
                {
                    ID = item.ID,
                    Tip = item.Anket ? (byte)4 : (byte)3,
                    UyeID1 = item.UyeID,
                    AdYer1 = item.UyeDetayAd + " - " + item.UyeDetayYer,
                    BaslangicTarih = item.BaslangicTarih,
                    BitisTarih = item.BitisTarih,
                    KalanSure = (item.BitisTarih - item.BaslangicTarih).ToString(),
                    Aciklama = item.Soru_AnketTanim,
                };
                topludizi.Add(wd);
            }

            foreach (Grup item in grupdizi)
            {
                WallData wd = new WallData
                {
                    ID = item.ID,
                    Tip = 5,
                    UyeID1 = item.UyeID,                  
                    BaslangicTarih = item.Tarih,
                    Aciklama = item.Aciklama,
                };
                topludizi.Add(wd);
            }
        }

        private void FiltreliSonuclar(List<WallData> topludizi, ref List<Iddia> iddiadizi, ref List<Soru_Anket> soru_anketdizi, ref List<Grup> grupdizi, string par, List<Guid> dizi)
        {
            byte timeindex = Convert.ToByte((smControl.FindControl("CntxtTime") as RadContextMenu).SelectedItem.Index);
            switch (par)
            {
                default:
                case null:
                    iddiadizi = service.IddiaSelect(null, dizi, timeindex);
                    soru_anketdizi = service.Soru_AnketSelect(null, dizi);
                    grupdizi = service.GrupSelect(dizi);
                    break;
                case "wclm":
                    iddiadizi = service.IddiaSelect("wc", dizi, timeindex);
                    soru_anketdizi = new List<Soru_Anket>();
                    grupdizi = new List<Grup>();
                    break;
                case "woclm":
                    iddiadizi = service.IddiaSelect("woc", dizi, timeindex);
                    soru_anketdizi = new List<Soru_Anket>();
                    grupdizi = new List<Grup>();
                    break;
                case "vclm":
                    iddiadizi = service.IddiaSelect("vc", dizi, timeindex);
                    soru_anketdizi = new List<Soru_Anket>();
                    grupdizi = new List<Grup>();
                    break;
                case "rclm":
                    iddiadizi = service.IddiaSelect("rc", dizi, timeindex);
                    soru_anketdizi = new List<Soru_Anket>();
                    grupdizi = new List<Grup>();
                    break;
                case "que":
                    iddiadizi = new List<Iddia>();
                    soru_anketdizi = service.Soru_AnketSelect("q", dizi);
                    grupdizi = new List<Grup>();
                    break;
                case "srv":
                    iddiadizi = new List<Iddia>();
                    soru_anketdizi = service.Soru_AnketSelect("s", dizi);
                    grupdizi = new List<Grup>();
                    break;
                case "grp":
                    iddiadizi = new List<Iddia>();
                    soru_anketdizi = new List<Soru_Anket>();
                    grupdizi = service.GrupSelect(dizi);
                    break;
            }

            foreach (Iddia item in iddiadizi)
            {
                WallData wd = new WallData
                {
                    ID = item.ID,
                    Tip = item.GercekIddia ? (byte)2 : (byte)1,
                    UyeID1 = item.IddiaAcanKisiID,
                    UyeID2 = item.IddiaRakipKisiID,
                     AdYer1 = item.UyeDetayIddiaAcanKisiAd+" - "+item.UyeDetayIddiaAcanKisYer,
                    AdYer2 = item.UyeDetayIddiaRakipKisiAd + " - " + item.UyeDetayIddiaRakipKisiYer,
                    BaslangicTarih = item.BaslangicTarih,
                    BitisTarih = item.BitisTarih,
                    KalanSure = (item.BitisTarih - item.BaslangicTarih).ToString(),
                    Aciklama = item.IddiaAcanKisiYorum,
                    Oy1 = item.IddiaAcanKisiOy,
                    Oy2 = item.IddiaRakipKisiOy,
                    Poka1 = item.IddiaAcanKisiPoka,
                    Poka2 = item.IddiaRakipKisiPoka,
                    ToplamPoka = item.ToplamPoka,
                    Yer = item.GerceklesmeYer,
                    Acik = item.Acik,
                    Mustehcen = item.MustehcenIddia,
                };
                topludizi.Add(wd);
            }

            foreach (Soru_Anket item in soru_anketdizi)
            {
                WallData wd = new WallData
                {
                    ID = item.ID,
                    Tip = item.Anket ? (byte)4 : (byte)3,
                    UyeID1 = item.UyeID,
                   AdYer1 = item.UyeDetayAd,
                    BaslangicTarih = item.BaslangicTarih,
                    BitisTarih = item.BitisTarih,
                    KalanSure = (item.BitisTarih - item.BaslangicTarih).ToString(),
                    Aciklama = item.Soru_AnketTanim,
                };
                topludizi.Add(wd);
            }

            foreach (Grup item in grupdizi)
            {
                WallData wd = new WallData
                {
                    ID = item.ID,
                    Tip = 5,
                    UyeID1 = item.UyeID,                   
                    BaslangicTarih = item.Tarih,
                    Aciklama = item.Aciklama,
                };
                topludizi.Add(wd);
            }
        }

        protected void shrButton_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "mykey", "Sys.Application.add_load(showWindow);", true);
        }


        public string link12 { get; set; }
    }
}