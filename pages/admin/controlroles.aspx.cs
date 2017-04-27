using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LibraryProject.classes;

namespace LibraryProject.pages.admin
{
    public partial class controlroles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                librarydbEntities db = new librarydbEntities();
                DropDownMembers.DataTextField = "UserName";
                DropDownMembers.DataSource = Membership.GetAllUsers();
                DropDownMembers.DataBind();
                DropDownRoles.DataSource = Roles.GetAllRoles();
                DropDownRoles.DataBind();
            }
               
        }

        protected void LinkButtonGive_Click(object sender, EventArgs e)
        {
            Roles.AddUserToRole(DropDownMembers.Text, DropDownRoles.Text);
        }
    }
}