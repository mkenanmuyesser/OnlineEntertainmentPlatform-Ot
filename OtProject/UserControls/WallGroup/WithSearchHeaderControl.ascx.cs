using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace OtProject.UserControls
{
    public partial class WithSearchHeaderControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmbMainSearch_ItemCreated(object sender, RadComboBoxItemEventArgs e)
        {
            RadComboBoxItem cmbitem = e.Item as RadComboBoxItem;
            if (cmbitem.IsSeparator)
            {
                (cmbitem.FindControl("pnlSeperator") as Panel).Visible = true;
                switch (cmbitem.Index)
                {
                    case 0:
                        (cmbitem.FindControl("lblHeader") as Label).Text = "İddialar";
                        break;
                    case 4:
                        (cmbitem.FindControl("lblHeader") as Label).Text = "Kişiler";
                        break;
                }
            }
            else
            {
                (cmbitem.FindControl("pnlClaim") as Panel).Visible = true;
            }
        }
    }
}