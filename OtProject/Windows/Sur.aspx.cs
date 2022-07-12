using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtProject.Classes;
using System.Web.Security;
using Telerik.Web.UI;

namespace OtProject
{
    public partial class Sur : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string srid = Request.QueryString["srid"];
            if (srid == null)
            {

            }
            else
            {
                try
                {
                    Guid sid = Guid.Parse(Crypto.DecryptStringAES(srid.Replace(' ', '+'), "10081008"));
                    if (ViewState["srid"] == null)
                    {
                        ViewState["srid"] = sid;
                    }
                    Soru_Anket sa = service.Soru_AnketSelect(sid);

                    (sControl.FindControl("lblSubject") as Label).Text = sa.Soru_AnketTanim;
                    YorumDoldur(sid);

                    ((sControl.FindControl("cldControl") as UserControl).FindControl("btnComment") as RadButton).Click += new EventHandler(S_Click);
                }
                catch
                {


                }
            }
        }

        void S_Click(object sender, EventArgs e)
        {
            Guid id = ViewState["srid"] == null ? Guid.Empty : Guid.Parse(ViewState["srid"].ToString());
            Guid kisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
            Yorum yrm = new Yorum
            {
                ID = Guid.NewGuid(),
                UyeID = kisiid,
                SoruAnketID = id,
                Tarih = DateTime.Now,
                YorumTanim = ((sControl.FindControl("cldControl") as UserControl).FindControl("txtComment") as RadTextBox).Text,
            };
            service.YorumInsert(yrm);
            YorumDoldur(id);
            ((sender as RadButton).Parent.FindControl("txtComment") as RadTextBox).Text = "";
        }

        private void YorumDoldur(Guid gid)
        {
            Repeater rpt = ((sControl.FindControl("clControl") as UserControl).FindControl("rptComments") as Repeater);
            rpt.DataSource = service.YorumSelect(3, gid);
            rpt.DataBind();
        }

    }
}