using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace OtProject.UserControls
{
    public partial class MainSearchControl : System.Web.UI.UserControl
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //ToolTip1.Visible = false;
            //var combo = cmbMainSearch;
            //for (int i = 0; i < 8; i++)
            //{
            //    switch (i)
            //    {
            //        case 0:
            //            RadComboBoxItem seperatoritem1 = new RadComboBoxItem("İddialar") { IsSeparator = true, };
            //            combo.Items.Insert(i, seperatoritem1);
            //            break;
            //        case 4:
            //            RadComboBoxItem seperatoritem2 = new RadComboBoxItem("Kişiler") { IsSeparator = true };
            //            combo.Items.Insert(i, seperatoritem2);
            //            break;
            //        default:
            //            RadComboBoxItem item = new RadComboBoxItem() { };
            //            combo.Items.Insert(i, item);
            //            break;
            //    }
            //}

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string gonderilecekparametre = "";
            foreach (AutoCompleteBoxEntry item in txtSearch.Entries)
            {
                gonderilecekparametre += item.Text + "-" + item.Value.Split(';')[1] + ";";
            }
            Response.Redirect("SearchPage.aspx?q=" + gonderilecekparametre.Trim());
        }

        protected void btnReady_Click(object sender, EventArgs e)
        {
            Guid id = service.HazirmisinSonuc();
            Response.Redirect("WallPage.aspx?id=" + id);
        }
    }
}