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
    public partial class Default : System.Web.UI.Page
    {
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

    }
}