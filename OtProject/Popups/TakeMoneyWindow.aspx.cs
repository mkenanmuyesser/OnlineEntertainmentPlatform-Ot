using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtProject.Classes;
using System.Web.Security;

namespace OtProject.Popups
{
    public partial class TakeMoneyWindow : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Uid"] == null)
            {
                lnkCreate.CommandArgument = Guid.Empty.ToString();
            }
            else
            {
                try
                {
                    lnkCreate.CommandArgument = Guid.Parse(Request.QueryString["Uid"]).ToString();
                }
                catch
                {
                    lnkCreate.CommandArgument = Guid.Empty.ToString();
                }
            }
        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            Guid paraisteyenkisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
            Guid begenilenuye = Guid.Parse(lnkCreate.CommandArgument);
            Bildirim yenibildirim = new Bildirim
            {
                ID = Guid.NewGuid(),
                UyeID = paraisteyenkisiid,
                Tarih = DateTime.Now,
                BildirimTanim = "yeni bir poka isteğinde bulundu.("+sldPoka.Value.ToString()+")",
                Soru_AnketID = null,
                BegenID = null,
                GrupID = null,
                IddiaID = null,
                MesajID = null,
                YorumID = null,
            };
            service.BildirimInsert(yenibildirim);

            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseRadWindow();", true);
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseRadWindow();", true);
        }
    }
}