using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OtProject.Classes;

namespace OtProject.UserControls
{
    public partial class WallMiddleControl : System.Web.UI.UserControl
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<WallData> topludizi = new List<WallData>();
            List<Durum> durumdizi = service.DurumSelect();
            byte timeindex = 0;
            foreach (Durum item in durumdizi)
            {
                WallData wd = new WallData
                {
                    Tip = 0,
                    UyeID1 = item.UyeID,
                     AdYer1 = item.UyeDetayAd,
                    BaslangicTarih = item.Tarih,
                    Aciklama = item.Aciklama,
                };
                topludizi.Add(wd);
            }

            List<Iddia> iddiadizi = service.IddiaSelect(null, timeindex);
            foreach (Iddia item in iddiadizi)
            {
                WallData wd = new WallData
                {
                    Tip = item.GercekIddia ? (byte)2 : (byte)1,
                    UyeID1 = item.IddiaAcanKisiID,
                    UyeID2 = item.IddiaRakipKisiID,
                    AdYer1 = item.UyeDetayIddiaAcanKisiAd,
                    BaslangicTarih = item.BaslangicTarih,
                    Aciklama = item.IddiaAcanKisiYorum,
                };
                topludizi.Add(wd);
            }

            List<Soru_Anket> soru_anketdizi = service.Soru_AnketSelect(null,timeindex);
            foreach (Soru_Anket item in soru_anketdizi)
            {
                WallData wd = new WallData
                {
                    Tip = item.Anket ? (byte)4 : (byte)3,
                    UyeID1 = item.UyeID,
                    AdYer1 = item.UyeDetayAd,
                    BaslangicTarih = item.BaslangicTarih,
                    Aciklama = item.Soru_AnketTanim,
                };
                topludizi.Add(wd);
            }

            List<Grup> grupdizi = service.GrupSelect(timeindex);
            foreach (Grup item in grupdizi)
            {
                WallData wd = new WallData
                {
                    Tip = 5,
                    //UyeID = item.,
                    BaslangicTarih = item.Tarih,
                    Aciklama = item.Aciklama,
                };
                topludizi.Add(wd);
            }

            rptFeeds.DataSource = topludizi.OrderByDescending(a => a.BaslangicTarih).Take(20);
            rptFeeds.DataBind();

        }

        protected void rptFeeds_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            WallData data = item.DataItem as WallData;
            switch (data.Tip)
            {
                case 0:
                    Control sttcntrl = (Control)Page.LoadControl("UserControls/WallGroup/StateControl.ascx");
                    item.Controls.Add(sttcntrl);
                    break;
                case 1:
                case 2:
                    if (data.UyeID2 == null)
                    {
                        Control wocntrl = (Control)Page.LoadControl("UserControls/WallGroup/WithoutOpponentClaimControl.ascx");
                        item.Controls.Add(wocntrl);
                    }
                    else
                    {
                        Control woocntrl = (Control)Page.LoadControl("UserControls/WallGroup/WithOpponentClaimControl.ascx");
                        item.Controls.Add(woocntrl);
                    }
                    break;
                case 3:
                    Control qcntrl = (Control)Page.LoadControl("UserControls/WallGroup/QuestionControl.ascx");
                    item.Controls.Add(qcntrl);
                    break;
                case 4:
                    Control surcntrl = (Control)Page.LoadControl("UserControls/WallGroup/SurveyControl.ascx");
                    item.Controls.Add(surcntrl);
                    break;
                case 5:
                    Control grpcntrl = (Control)Page.LoadControl("UserControls/WallGroup/GroupControl.ascx");
                    item.Controls.Add(grpcntrl);
                    break;
            }
        }
    }

 
}