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
    public partial class Que : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string qrid = Request.QueryString["qid"];
            if (qrid == null)
            {

            }
            else
            {
                try
                {
                    Guid qid = Guid.Parse(Crypto.DecryptStringAES(qrid.Replace(' ', '+'), "10081008"));
                    if (ViewState["qrid"] == null)
                    {
                        ViewState["qrid"] = qid;
                    }                    
                    Soru_Anket sa = service.Soru_AnketSelect(qid);

                    (qControl.FindControl("lblSubject") as Label).Text = sa.Soru_AnketTanim;
                    YorumDoldur(qid);

                    ((qControl.FindControl("cldControl") as UserControl).FindControl("btnComment") as RadButton).Click += new EventHandler(Q_Click);
                }
                catch
                {


                }
            }
        }

        void Q_Click(object sender, EventArgs e)
        {
            Guid id = ViewState["qrid"] == null ? Guid.Empty : Guid.Parse(ViewState["qrid"].ToString());
            Guid kisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
            Yorum yrm = new Yorum
            {
                ID = Guid.NewGuid(),
                UyeID = kisiid,
                SoruAnketID = id,
                Tarih = DateTime.Now,
                YorumTanim = ((qControl.FindControl("cldControl") as UserControl).FindControl("txtComment") as RadTextBox).Text,
            };
            service.YorumInsert(yrm);
            YorumDoldur(id);
            ((sender as RadButton).Parent.FindControl("txtComment") as RadTextBox).Text = "";
        }

        private void YorumDoldur(Guid gid)
        {
            Repeater rpt = ((qControl.FindControl("clControl") as UserControl).FindControl("rptComments") as Repeater);
            rpt.DataSource = service.YorumSelect(3, gid);
            rpt.DataBind();
        }
    }
}