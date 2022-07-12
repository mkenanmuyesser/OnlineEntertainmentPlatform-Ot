using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtProject.Classes;
using System.Web.Security;
using Telerik.Web.UI;

namespace OtProject.Popups
{
    public partial class CreateClaimWindow : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        public Iddia acilaniddia = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 1; i < 15; i++)
                {
                    cmbDate.Items.Add(new Telerik.Web.UI.RadComboBoxItem(i.ToString() + " gün"));
                }
            }
        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (acilaniddia == null)
                {
                    Guid id = Guid.NewGuid();
                    Guid iddiaacankisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
                    bool iddiatip = btnClaimType.Checked;
                    int iddiasure = Convert.ToInt32(cmbDate.SelectedItem.Text.Split(' ').First());
                    string iddiaacanaciklama = txtComment.Text;
                    int poka = Convert.ToInt32(sldPoka.Value);
                    bool mustehcen = btn18.Checked;
                    //1.giriş
                    Iddia yeniiddia = new Iddia
                    {
                        ID = id,
                        IddiaAcanKisiID = iddiaacankisiid,
                        BaslangicTarih = DateTime.Now,
                        BitisTarih = DateTime.Now.AddDays(iddiasure),
                        GercekIddia = iddiatip,
                        MustehcenIddia = mustehcen,
                        IddiaAcanKisiOy = 0,
                        IddiaAcanKisiPoka = poka,
                        IddiaAcanKisiYorum = iddiaacanaciklama,
                        IddiaRakipKisiOy = 0,
                        IddiaRakipKisiPoka = 0,
                        IddiaRakipKisiYorum = "",
                        GerceklesmeTarih = DateTime.Now,
                        GerceklesmeYer = "",
                        HakemID = Guid.Empty,
                        IddiaRakipKisiID = Guid.Empty,
                        KaybedenID = Guid.Empty,
                        KazananID = Guid.Empty,
                        ToplamPoka = poka,
                        Acik = true,
                        Ban = false,
                    };
                    service.IddiaInsert(yeniiddia);
                    //2.ek dosyalar

                    //3.haber ver(bildirim oluştur)                

                    Bildirim yenibildirim = new Bildirim
                    {
                        ID = Guid.NewGuid(),
                        UyeID = iddiaacankisiid,
                        Tarih = DateTime.Now,
                        BildirimTanim = "yeni bir iddia açtı.",
                        IddiaID = id,
                        Soru_AnketID = null,
                        BegenID = null,
                        GrupID = null,                        
                        MesajID = null,
                        YorumID = null,
                    };
                    service.BildirimInsert(yenibildirim);


                    //4.ilgi alanlarını gir
                    foreach (AutoCompleteBoxEntry entry in txtInterests.Entries)
                    {
                        Guid entryid = Guid.Parse(entry.Value.ToString().Split(';').Last());
                        IlgiAlanIddiaSoru_AnketGrupAraTablo yeniara = new IlgiAlanIddiaSoru_AnketGrupAraTablo
                        {
                            ID = Guid.NewGuid(),
                            IlgiAlanID = Guid.Parse(entry.Value),
                            IddiaID = id,
                            GrupID = null,
                            Soru_AnketID = null,
                        };
                        service.IlgiAlanIddiaSoru_AnketGrupAraTabloInsert(yeniara);
                    }
                }
                else
                {

                }
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseRadWindow();", true);
            }
            catch
            { }
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseRadWindow();", true);
        }

        protected void btnAddInterest_Click(object sender, EventArgs e)
        {
            string ilgialan = txtAddInterest.Text;
            Guid id = Guid.NewGuid();
            IlgiAlan yeniilgialan = new IlgiAlan
            {
                ID = id,
                IlgiAlanTanim = ilgialan,
                Izlenme = 0,
            };
            service.IlgiAlanInsert(yeniilgialan);
            txtInterests.Entries.Add(new AutoCompleteBoxEntry(ilgialan, id.ToString()));
            txtAddInterest.Text = "";
        }
    }
}