using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Telerik.Web.UI;
using OtProject.Classes;

namespace OtProject.Popups
{
    public partial class SendMessageWindow : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtMessage.Text))
                {
                    Guid id = Guid.NewGuid();
                    Guid sorusorankisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
                    string mesaj = txtMessage.Text;

                    foreach (AutoCompleteBoxEntry entry in txtSearch.Entries)
                    {
                        Guid entryid = Guid.Parse(entry.Value.ToString().Split(';').Last());
                        //1.mesaj gönder
                        Mesaj yenimesaj = new Mesaj
                        {
                            ID = id,
                            AliciID = entryid,
                            GonderenID = sorusorankisiid,
                            Tarih = DateTime.Now,
                            Icerik = mesaj,
                        };
                        service.MesajInsert(yenimesaj);

                        //2.haber ver(bildirim oluştur) 
                        Bildirim yenibildirim = new Bildirim
                        {
                            ID = Guid.NewGuid(),
                            UyeID = entryid,
                            Tarih = DateTime.Now,
                            BildirimTanim = "yeni bir mesaj gönderdi.",
                            MesajID = id,
                            BegenID = null,
                            GrupID = null,
                            IddiaID = null,
                            TakipEtID = null,
                            Soru_AnketID = null,
                            YorumID = null,
                        };
                        service.BildirimInsert(yenibildirim);
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
    }
}