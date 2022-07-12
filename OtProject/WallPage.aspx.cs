using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Security;
using OtProject.Classes;

namespace OtProject
{
    public partial class WallPage : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string par = Request.QueryString["par"];
            if (par != null)
            {
                switch (par)
                {
                    case "wlcm":
                        RadWindow wlcmwindow = new RadWindow()
                        {
                            NavigateUrl = "../Popups/WelcomeWindow.aspx",
                            VisibleOnPageLoad = true,
                            Width = 730,
                            Height = 580,
                            Behaviors = WindowBehaviors.Close,
                            VisibleStatusbar = false,
                            VisibleTitlebar = false,
                            Modal = true,
                        };
                        wndWelcome.Windows.Add(wlcmwindow);
                        break;
                }


            }           
        }

        protected void SplitButton1_Command(object sender, CommandEventArgs e)
        {
            Telerik.Web.UI.ButtonCommandEventArgs args = e as Telerik.Web.UI.ButtonCommandEventArgs;
            if (args.IsSplitButtonClick)
            {
                //TODO: Split button logic
            }
        }

        protected void SplitButton1_Click(object sender, EventArgs e)
        {
            Telerik.Web.UI.ButtonClickEventArgs args = e as Telerik.Web.UI.ButtonClickEventArgs;
            if (args.IsSplitButtonClick)
            {
                //TODO: Split button logic
            }
        }

     
    }
}