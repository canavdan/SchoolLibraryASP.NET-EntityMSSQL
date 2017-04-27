using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryProject.pages.moderator
{
    public partial class usersearchresult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            fill();
            string id = Request.QueryString["uid"];
            if (String.IsNullOrEmpty(id))
            {
                Response.Redirect("~/pages/moderator/default.aspx");

            }

        }
        librarydbEntities db = new librarydbEntities();

        void fill()
        {
            string id = Request.QueryString["uid"];
            int uid = Convert.ToInt32(id);
            var query = (from mem in db.member_DB
                         where mem.memID.ToString().Contains(id)
                         select new
                         {
                             MemID = mem.memID,
                             Name = mem.name,
                             Surname = mem.surname,
                            Faculty = mem.department.faculty.facultyName
                         }).ToList();


            gridViewUsers.DataSource=query;
            gridViewUsers.DataBind();
            
        }

        protected void gridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = gridViewUsers.Rows[rowIndex];
                Session["usN"] = row.Cells[0].Text.ToString();
                Response.Redirect("~/pages/moderator/useroperations.aspx");
            }
        }
    }
}