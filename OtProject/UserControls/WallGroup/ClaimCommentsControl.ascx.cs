using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtProject.UserControls
{
    public partial class ClaimCommentsControl : System.Web.UI.UserControl
    {
        public Guid uid = Guid.Empty;
        OtProjectService service = new OtProjectService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //rptComments.DataSource = service.YorumSelect(uid);
            //rptComments.DataBind();

        }
    }
}