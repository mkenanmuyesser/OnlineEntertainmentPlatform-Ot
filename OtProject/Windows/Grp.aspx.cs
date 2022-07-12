using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtProject.Classes;
using Telerik.Web.UI;
using System.Web.Security;

namespace OtProject
{
    public partial class Grp : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string grid = Request.QueryString["grid"];
            if (grid == null)
            {

            }
            else
            {
                try
                {
                    Guid gid = Guid.Parse(Crypto.DecryptStringAES(grid.Replace(' ', '+'), "10081008"));
                    if (ViewState["grid"] == null)
                    {
                        ViewState["grid"] = gid;
                    }

                    Grup grp = service.GrupSelect(gid);
                    //(grpControl.FindControl("imgCommentUser") as RadBinaryImage).ImageUrl
                    (grpControl.FindControl("lblSubject") as Label).Text = grp.Aciklama;
                    YorumDoldur(gid);

                    ((grpControl.FindControl("cldControl") as UserControl).FindControl("btnComment") as RadButton).Click += new EventHandler(Grp_Click);

                }
                catch
                {

                }
            }
        }

        void Grp_Click(object sender, EventArgs e)
        {
            Guid grid = ViewState["grid"] == null ? Guid.Empty : Guid.Parse(ViewState["grid"].ToString());
            Guid kisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
            Yorum yrm = new Yorum
            {
                ID = Guid.NewGuid(),
                UyeID = kisiid,
                GrupID = grid,
                Tarih = DateTime.Now,
                YorumTanim = ((grpControl.FindControl("cldControl") as UserControl).FindControl("txtComment") as RadTextBox).Text,
            };
            service.YorumInsert(yrm);
            YorumDoldur(grid);
            ((sender as RadButton).Parent.FindControl("txtComment") as RadTextBox).Text = "";
        }

        private void YorumDoldur(Guid gid)
        {
            Repeater rpt = ((grpControl.FindControl("clControl") as UserControl).FindControl("rptComments") as Repeater);
            rpt.DataSource = service.YorumSelect(5, gid);
            rpt.DataBind();
        }

    }
}