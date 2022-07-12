using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtProject.Classes;
using System.Web.Security;

namespace OtProject.UserControls.WallGroup
{
    public partial class WallTopControl : System.Web.UI.UserControl
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnStatus.UniqueID;
        }

        protected void btnStatus_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtStatus.Text))
            {
                Guid uyeid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
                Durum yenidurum = new Durum
                {
                    ID = Guid.NewGuid(),
                    UyeID = uyeid,
                    Aciklama = txtStatus.Text,
                    Tarih = DateTime.Now,
                };
                service.DurumInsert(yenidurum);
                txtStatus.Text = "";
            }
        }

    }
}