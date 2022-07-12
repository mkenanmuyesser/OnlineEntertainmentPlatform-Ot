using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Security;
using OtProject.Classes;
using OtProject.UserControls;

namespace OtProject
{
    public partial class NewUser : System.Web.UI.Page
    {
        public MultiView m;
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            // multi.ActiveViewIndex = 3;
            m = multi;
            (step1.FindControl("btnLevel1Forward") as RadButton).Click += btnForward_Click;
            (step2.FindControl("btnLevel2Forward") as RadButton).Click += btnForward_Click;
            (step3.FindControl("btnLevel3Forward") as RadButton).Click += btnForward_Click;
            (step4.FindControl("btnLevel4Forward") as RadButton).Click += btnForward_Click;

            //switch (multi.ActiveViewIndex)
            //{
            //    case 0:
            //        if (IsPostBack)
            //            (step1.FindControl("ToolTip1") as RadToolTip).Visible = false;
            //        break;
            //    case 1:
            //        (step2.FindControl("ToolTip2") as RadToolTip).Visible = false;
            //        break;
            //    case 2:
            //        (step3.FindControl("ToolTip3") as RadToolTip).Visible = false;
            //        break;
            //    case 3:
            //        (step4.FindControl("ToolTip4") as RadToolTip).Visible = false;
            //        break;
            //}
        }

        #region click grubu

        protected void btnForward_Click(object sender, EventArgs e)
        {
            if (multi.ActiveViewIndex == 3)
            {
                try
                {
                    //1.kullanıcı oluştur
                    string kullaniciadi = (step1.FindControl("txtUserName") as RadTextBox).Text;
                    string eposta = (step1.FindControl("txtEmail") as RadTextBox).Text;
                    string sifre = (step1.FindControl("txtPassword") as RadTextBox).Text;
                    MembershipCreateStatus status;
                    MembershipUser mu = Membership.CreateUser(kullaniciadi, sifre, eposta, null, null, false, out status);

                    //2.login yap
                    FormsAuthenticationTicket objTicket = new FormsAuthenticationTicket(1, kullaniciadi, System.DateTime.Now, DateTime.Now.AddMinutes(30), false, Session.SessionID);
                    HttpCookie objCookie = new HttpCookie(".ASPXAUTH");
                    objCookie.Value = FormsAuthentication.Encrypt(objTicket);
                    Response.Cookies.Add(objCookie);
                    Guid userid = Guid.Parse(mu.ProviderUserKey.ToString());

                    //3.detayları gir
                    RadBinaryImage img = (step4.FindControl("imgUpload") as RadBinaryImage);
                    RadUpload fi = (step4.FindControl("imgFileUpload") as RadUpload);
                    string aciklama = (step4.FindControl("txtDescription") as RadTextBox).Text;
                    string konum = (step4.FindControl("txtLocation") as RadTextBox).Text;
                    string website = (step4.FindControl("txtWebSite") as RadTextBox).Text;
                    UyeDetay udty = new UyeDetay
                    {
                        ID = userid,
                        TakmaAd = kullaniciadi,
                        Sifre = sifre,
                        Aciklama = aciklama,
                        Ulke = "TR",
                        Sehir = konum,
                        Website = website,
                        DogumYili = DateTime.Now,
                        PokaMiktar = 100,
                        Eposta = eposta,
                        KaybedilenIddia = 0,
                        KaybedilenPoka = 0,
                        KazanılanIddia = 0,
                        KazanılanPoka = 0,
                        //..Resim = img.im,
                        UyeTip = false,
                        Aktif = true,
                        Onay = false,
                    };

                    //if (fi.hasfile)
                    //{
                    //    string dosyauzanti = fi.FileName.Split('.').Last();
                    //    string dosyaadi = Guid.NewGuid().ToString() + "." + dosyauzanti;
                    //    //..udty.Resim = dosyaadi;
                    //    fi.SaveAs(Server.MapPath("UploadImages/" + dosyaadi));
                    //}
                    service.UyeDetayInsert(udty);

                    //4.ilgi alanlarını gir
                    if (Session["tag"] != null)
                    {
                        List<Guid> tagler = (Session["tag"] as List<Guid>);
                        foreach (Guid tag in tagler)
                        {
                            UyeIlgiAlanAraTablo ar1 = new UyeIlgiAlanAraTablo
                            {
                                ID = Guid.NewGuid(),
                                IlgiAlanID = tag,
                                UyeID = userid,
                            };
                            service.UyeIlgiAlanAraTabloInsert(ar1);
                        }
                    }

                    //5.arkadaş listesine ekle
                    if (Session["user"] != null)
                    {
                        List<Guid> kullanicilar = (Session["user"] as List<Guid>);
                        foreach (Guid user in kullanicilar)
                        {
                            UyeArkadasAraTablo ar2 = new UyeArkadasAraTablo
                            {
                                ID = Guid.NewGuid(),
                                ArkadasID = user,
                                UyeID = userid,
                            };
                            service.UyeArkadasAraTabloInsert(ar2);
                        }
                    }

                    Response.Redirect("WallPage.aspx?par=wlcm&id=" + Crypto.DecryptStringAES(userid.ToString(), "10081008"), false);
                }
                catch
                { }
            }
            else
            {
                multi.ActiveViewIndex += 1;
            }
        }

        #endregion

        protected void btnAdd_Load(object sender, EventArgs e)
        {
            RadButton btn = sender as RadButton;
            if (Session["user"] == null)
            {
                return;
            }
            List<int> dizi = (List<int>)Session["user"];
            try
            {
                if (dizi.Contains(Convert.ToInt32(btn.CommandArgument)))
                {
                    btn.Enabled = false;
                }
                else
                {
                    btn.Enabled = true;
                }
            }
            catch
            {

            }
        }

    }
}