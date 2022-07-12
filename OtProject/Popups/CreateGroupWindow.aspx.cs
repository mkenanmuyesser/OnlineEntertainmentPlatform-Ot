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
    public partial class CreateGroupWindow : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        public Grup acilangrup = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (acilangrup == null)
                {
                    Guid id = Guid.NewGuid();
                    Guid grupacankisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
                    string grupadi = txtGroupName.Text;
                    string grupaciklama = txtComment.Text;
                    bool herkeseacik = !btnGroup.Checked;

                    //1.giriş
                    Grup yenigrup = new Grup
                    {
                        ID = id,
                        UyeID = grupacankisiid,
                        Aciklama = grupaciklama,
                        Ad = grupadi,
                        Tarih = DateTime.Now,
                    };
                    service.GrupInsert(yenigrup);
                    //2.ek dosyalar

                    Bildirim yenibildirim = new Bildirim
                    {
                        ID = Guid.NewGuid(),
                        UyeID = grupacankisiid,
                        Tarih = DateTime.Now,
                        BildirimTanim = "yeni bir grup açtı.",
                        Soru_AnketID = null,
                        BegenID = null,
                        GrupID = id,
                        IddiaID = null,
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
                            GrupID = id,
                            IddiaID = null,
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