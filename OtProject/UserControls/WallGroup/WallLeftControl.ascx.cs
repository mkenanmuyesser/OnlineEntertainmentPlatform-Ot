using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using OtProject.Classes;
using Telerik.Web.UI;

namespace OtProject.UserControls
{
    public partial class WallLeftControl : System.Web.UI.UserControl
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataDoldur();
        }

        protected void lnkFollow_Click(object sender, EventArgs e)
        {
            Guid id = Guid.NewGuid();
            Guid begenenuye = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
            Guid begenilenuye = Guid.Parse(lnkFollow.CommandArgument);
            TakipEt yenitakip = new TakipEt
            {
                ID = id,
                UyeID = begenenuye,
                BegenilenUyeID = begenilenuye,
            };
            service.TakipEtInsert(yenitakip);

            Bildirim yenibildirim = new Bildirim
            {
                ID = Guid.NewGuid(),
                UyeID = begenenuye,
                TakipEtID = id,
                BegenID = null,
                GrupID = null,
                IddiaID = null,
                MesajID = null,
                YorumID = null,
                Soru_AnketID = null,
                Tarih = DateTime.Now,
                BildirimTanim = "takip ediyor.",
            };
            service.BildirimInsert(yenibildirim);
        }

        protected void lnkMoreInterest_Click(object sender, EventArgs e)
        {
            string strid = Request.QueryString["id"];
            try
            {
                Guid id = Guid.Parse(Crypto.EncryptStringAES(strid, "10081008"));
                if (strid != null)
                {
                    rptInterests.DataSource = service.IlgiAlanSelect(6, id);
                }
                else
                {
                    rptInterests.DataSource = service.IlgiAlanSelect(0, Guid.Empty);
                }
                rptInterests.DataBind();
            }
            catch
            {

            }            
           
        }

        protected void rptInterests_ItemClick(object sender, Telerik.Web.UI.RadTagCloudEventArgs e)
        {

        }

        private void DataDoldur()
        {
            MembershipUser logusr = Membership.GetUser(true);
            try
            {
                Guid logid = Guid.Parse(logusr.ProviderUserKey.ToString());
                string strid = Request.QueryString["id"];
                Guid id = Guid.Parse(Crypto.EncryptStringAES(strid, "10081008"));
                if (id == null)
                {

                }
                else
                {
                    if (logid == id)
                    {
                        buttongroup.Visible = false;
                    }

                    UyeDetay uye = service.UyeDetaySelect(id);
                    (this.Page.Master.FindControl("wshControl").FindControl("lblPokaScore") as Label).Text = uye.PokaMiktar.ToString() + " POKA";
                    lnkFollow.CommandArgument = id.ToString();
                    imgUser.DataValue = uye.Resim;
                    lnkUserName.Text = uye.TakmaAd;
                    lblCity.Text = uye.Sehir;
                    lblAge.Text = ((DateTime.Now - uye.DogumYili).TotalDays % 365).ToString();
                    lblFollowers.Text = service.TakipEdenSelect(id).ToString();
                    lblFollows.Text = service.TakipEttigiSelect(id).ToString();
                    lblAbout.Text = uye.Aciklama;
                    
                    rotReal.DataSource = service.BildirimSelect(id);
                    rotReal.DataBind();
                    
                    rptInterests.DataSource = service.IlgiAlanTop10Select(id);
                    rptInterests.DataBind();
                    
                    rotSimilar.DataSource = service.UyeDetayTop10Select(id);
                    rotSimilar.DataBind();
                }
            }
            catch
            {
                lnkFollow.CommandArgument = Guid.Empty.ToString();
                (this.Page.Master.FindControl("wshControl").FindControl("lblPokaScore") as Label).Text = "0 POKA";
                
                rotReal.DataSource = service.BildirimSelect(null);
                rotReal.DataBind();

                rptInterests.DataSource = service.IlgiAlanTop10Select(null);
                rptInterests.DataBind();

                rotSimilar.DataSource = service.UyeDetayTop10Select(null);
                rotSimilar.DataBind();
            }
        }
    }
}