using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace OtProject.UserControls
{
    public partial class NewUserStep3 : System.Web.UI.UserControl
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataLoads();
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            RadButton btn = e.Item.FindControl("btnAdd") as RadButton;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<Guid> dizi = null;
            if (Session["user"] == null)
            {
                dizi = new List<Guid>();
            }
            else
            {
                dizi = (List<Guid>)Session["user"];
                if (dizi.Count() == 5)
                {
                    return;
                }
            }

            RadButton btn = sender as RadButton;
            dizi.Add(Guid.Parse(btn.CommandArgument));
            Session["user"] = dizi;
            btn.Enabled = false;

            int sayac = dizi.Count();
            ProgressBar2.Position = sayac;
            //if (sayac == 5)
            //{
            //    //PopupControl1.ShowOnPageLoad = true;
            //    //(step2.FindControl("btnLevel2Forward") as RadButton).Enabled = true;
            //    //warning.ImageUrl = "Develops/images/member1.png";
            //}            
        }

        protected void btnMore2_Click(object sender, EventArgs e)
        {
            DataLoads();
        }

        private void DataLoads()
        {
            MultiView multi = ((this.Parent.Page as NewUser)).m;
            if (multi.ActiveViewIndex == 2)
            {
                if (Session["tag"] != null)
                {
                    List<Guid> ids = (List<Guid>)Session["tag"];
                    Guid randomid = ids[new Random().Next(0, ids.Count())];
                    lblTag.Text = service.IlgiAlanSelect(0,Guid.Empty).Single(a => a.ID == randomid).IlgiAlanTanim;
                }
            }

            string sorgu = MemberData.SelectCommand;
            MemberData.SelectCommand = "";
            MemberData.SelectCommand = sorgu;
        }
    }
}