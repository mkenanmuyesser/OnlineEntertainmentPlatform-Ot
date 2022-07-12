using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtProject.Classes;

namespace OtProject.Popups
{
    public partial class AddInterestWindow : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseRadWindow();", true);
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseRadWindow();", true);
        }

        protected void btnAddInterest_Click(object sender, EventArgs e)
        {
            Guid ilgialanid = Guid.NewGuid();
            string ilgialantanim = txtAddInterest.Text;
            IlgiAlan yeniilgialan = new IlgiAlan
            {
                ID = ilgialanid,
                IlgiAlanTanim = ilgialantanim,
                Izlenme = 0
            };
            service.IlgiAlanInsert(yeniilgialan);
            txtInterests.Entries.Add(new Telerik.Web.UI.AutoCompleteBoxEntry(ilgialantanim, ilgialanid.ToString()));
            txtAddInterest.Text = "";
        }
    }
}