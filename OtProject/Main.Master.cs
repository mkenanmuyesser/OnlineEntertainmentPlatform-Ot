using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using OtProject.Classes;
using Telerik.Web.UI;

namespace OtProject
{
    public partial class Ana : System.Web.UI.MasterPage
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser usr = Membership.GetUser(true);
            if (usr != null)
            {
                UyeDetay ud = service.UyeDetaySelect(Guid.Parse(usr.ProviderUserKey.ToString()));
                (lgnView.FindControl("lblCity") as Label).Text = ud.Sehir;
                (lgnView.FindControl("imgTopUser") as RadBinaryImage).DataValue = ud.Resim;
                (lgnView.FindControl("btnSettings") as RadButton).PostBackUrl = "SettingsPage.aspx?id=" + Crypto.EncryptStringAES(ud.ID.ToString(), "10081008");
                (lgnView.FindControl("btnWall") as RadButton).PostBackUrl = "WallPage.aspx?id=" + Crypto.EncryptStringAES(ud.ID.ToString(), "10081008");
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}