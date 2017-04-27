using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LibraryProject.pages.admin
{
    public partial class giveroles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonRole_Click(object sender, EventArgs e)
        {
            Roles.CreateRole(TextBoxRole.Text);
        }
    }
}