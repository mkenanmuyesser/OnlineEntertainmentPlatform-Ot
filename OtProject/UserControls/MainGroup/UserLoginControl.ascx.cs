using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace OtProject.UserControls
{
    public partial class UserLoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["chk"]!=null&&!IsPostBack)
            {
                HttpCookie cook = Request.Cookies["chk"];
                txtUserName.Text = cook.Values["username"];
                txtPassword.Text = cook.Values["pwd"];
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string kullaniciadi = txtUserName.Text;
            string sifre = txtPassword.Text;
            if (Membership.ValidateUser(kullaniciadi, sifre))
            {
                FormsAuthenticationTicket objTicket = new FormsAuthenticationTicket(1, kullaniciadi, System.DateTime.Now, DateTime.Now.AddMinutes(30), false, Session.SessionID);
                HttpCookie objCookie = new HttpCookie(".ASPXAUTH");
                objCookie.Value = FormsAuthentication.Encrypt(objTicket);
                Response.Cookies.Add(objCookie);
                Response.Redirect(Request.Url.AbsoluteUri);

                if (Request.Cookies["chk"] == null)
                {
                    HttpCookie cook = new HttpCookie("chk");
                    cook.Values.Add("username", txtUserName.Text);
                    cook.Values.Add("pwd", txtPassword.Text);
                    Response.Cookies.Add(cook);
                }
                else
                {
                    HttpCookie cook = Request.Cookies["chk"];
                    cook.Values.Clear();
                    cook.Values.Add("username", txtUserName.Text);
                    cook.Values.Add("pwd", txtPassword.Text);
                    Response.Cookies.Add(cook);
                }
            }
            else
            {
                lblWarning.Text = "Kullanıcı adı veya şifre uyuşmuyor.";
            }

            
        }
    }
}