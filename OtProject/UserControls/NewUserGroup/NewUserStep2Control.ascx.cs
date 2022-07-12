using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace OtProject.UserControls
{
    public partial class NewUserStep2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadTagCloud1_ItemClick(object sender, Telerik.Web.UI.RadTagCloudEventArgs e)
        {
            List<Guid> dizi = null;
            if (Session["tag"] == null)
            {
                dizi = new List<Guid>();
            }
            else
            {
                dizi = (List<Guid>)Session["tag"];
                if (dizi.Count() == 5)
                {
                    return;
                }
            }

            dizi.Add(Guid.Parse(e.Item.Value));
            Session["tag"] = dizi;

            int sayac = dizi.Count();
            if (sayac == 5)
            {
                //PopupControl1.ShowOnPageLoad = true;
                btnLevel2Forward.Enabled = true;
                //warning.ImageUrl = "Develops/images/member1.png";
            }

            progress.Value= sayac;
            
        }

        protected void btnMore1_Click(object sender, EventArgs e)
        {
            string sorgu = CloudData.SelectCommand;
            CloudData.SelectCommand = "";
            CloudData.SelectCommand = sorgu;
        }

    }
}