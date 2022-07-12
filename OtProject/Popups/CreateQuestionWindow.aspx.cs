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
    public partial class CreateQuestionWindow : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        public Soru_Anket acilansoru_anket = null;
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
                if (acilansoru_anket == null)
                {
                    Guid id = Guid.NewGuid();
                    Guid sorusorankisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
                    string soru = txtQuestionName.Text;
                    int sorusure = Convert.ToInt32(cmbDate.SelectedItem.Text.Split(' ').First());
                    //1.giriş
                    Soru_Anket yenisoru_anket = new Soru_Anket
                    {
                        ID = id,
                        UyeID = sorusorankisiid,
                        BaslangicTarih = DateTime.Now,
                        BitisTarih = DateTime.Now.AddDays(sorusure),
                        Soru_AnketTanim = soru,
                        Anket = false,
                    };
                    service.Soru_AnketInsert(yenisoru_anket);
                    //2.ek dosyalar

                    //3.haber ver(bildirim oluştur)                
                    Bildirim yenibildirim = new Bildirim
                    {
                        ID = Guid.NewGuid(),
                        UyeID = sorusorankisiid,
                        Tarih = DateTime.Now,
                        BildirimTanim = "yeni bir soru sordu.",
                        Soru_AnketID = id,
                        BegenID = null,
                        GrupID = null,
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
                            Soru_AnketID = id,
                            GrupID = null,
                            IddiaID = null,
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