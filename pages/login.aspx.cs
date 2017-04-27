using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace LibraryProject.pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (IsPostBack) return;
        }
        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(txtUsername.Text, TextBoxPassword.Text))
            {

            }
        }

        protected void Login2_LoggedIn(object sender, EventArgs e)
        {
            Session["usN"] = Login2.UserName;
            if (Roles.IsUserInRole((Login2.UserName), "admin"))
                Response.Redirect("~/pages/admin/default.aspx");
            else if (Roles.IsUserInRole((Login2.UserName), "moderator"))
                Response.Redirect("~/pages/moderator/default.aspx");
            else if (Roles.IsUserInRole((Login2.UserName), "student") ||
                Roles.IsUserInRole((Login2.UserName), "teacher") ||
             Roles.IsUserInRole((Login2.UserName), "gstudent"))
                Response.Redirect("~/pages/member/default.aspx");
        }
    }
}