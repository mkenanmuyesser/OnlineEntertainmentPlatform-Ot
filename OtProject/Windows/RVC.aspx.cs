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
    public partial class RVC : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string rvcrid = Request.QueryString["rvcrid"];
            if (rvcrid == null)
            {

            }
            else
            {
                try
                {
                    Guid iid = Guid.Parse(Crypto.DecryptStringAES(rvcrid.Replace(' ', '+'), "10081008"));
                    if (ViewState["rvcrid"] == null)
                    {
                        ViewState["rvcrid"] = iid;
                    }
                    Iddia idd = service.IddiaSelect(iid);
                    if (idd.IddiaRakipKisiID == null)
                    {
                        Panel1.Visible = true;
                        Panel2.Visible = false;
                        (woControl.FindControl("lblMainComment") as Label).Text = idd.IddiaAcanKisiYorum;
                        YorumDoldur1(iid);
                        ((woControl.FindControl("cldControl") as UserControl).FindControl("btnComment") as RadButton).Click += new EventHandler(RVC_Click1);
                    }
                    else
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                        (wControl.FindControl("lblComment1") as Label).Text = idd.IddiaAcanKisiYorum;
                        (wControl.FindControl("lblComment2") as Label).Text = idd.IddiaRakipKisiYorum;
                        YorumDoldur2(iid);
                        ((wControl.FindControl("cldControl") as UserControl).FindControl("btnComment") as RadButton).Click += new EventHandler(RVC_Click2);
                    }
                }
                catch
                {


                }
            }
        }

        void RVC_Click1(object sender, EventArgs e)
        {
            Guid id = ViewState["rvcrid"] == null ? Guid.Empty : Guid.Parse(ViewState["rvcrid"].ToString());
            Guid kisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
            Yorum yrm = new Yorum
            {
                ID = Guid.NewGuid(),
                UyeID = kisiid,
                IddiaID = id,
                Tarih = DateTime.Now,
                YorumTanim = ((woControl.FindControl("cldControl") as UserControl).FindControl("txtComment") as RadTextBox).Text,
            };
            service.YorumInsert(yrm);
            YorumDoldur1(id);
            ((sender as RadButton).Parent.FindControl("txtComment") as RadTextBox).Text = "";
        }

        void RVC_Click2(object sender, EventArgs e)
        {
            Guid id = ViewState["rvcrid"] == null ? Guid.Empty : Guid.Parse(ViewState["rvcrid"].ToString());
            Guid kisiid = Membership.GetUser(true) == null ? Guid.Empty : Guid.Parse(Membership.GetUser(true).ProviderUserKey.ToString());
            Yorum yrm = new Yorum
            {
                ID = Guid.NewGuid(),
                UyeID = kisiid,
                IddiaID = id,
                Tarih = DateTime.Now,
                YorumTanim = ((wControl.FindControl("cldControl") as UserControl).FindControl("txtComment") as RadTextBox).Text,
            };
            service.YorumInsert(yrm);
            YorumDoldur2(id);
            ((sender as RadButton).Parent.FindControl("txtComment") as RadTextBox).Text = "";
        }

        private void YorumDoldur1(Guid gid)
        {
            Repeater rpt = ((woControl.FindControl("clControl") as UserControl).FindControl("rptComments") as Repeater);
            rpt.DataSource = service.YorumSelect(1, gid);
            rpt.DataBind();
        }

        private void YorumDoldur2(Guid gid)
        {
            Repeater rpt = ((wControl.FindControl("clControl") as UserControl).FindControl("rptComments") as Repeater);
            rpt.DataSource = service.YorumSelect(1, gid);
            rpt.DataBind();
        }
    }
}