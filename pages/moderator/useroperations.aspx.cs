using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryProject.pages.moderator
{
    public partial class useroperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reset();
                fillTab1();
                fillTab3();
                
            }
           

        }
        librarydbEntities db = new librarydbEntities();
        databaseLibrary dl = new databaseLibrary();

        void fillTab1()
        {
            //Fill user profile
            //String userN = Session["usN"].ToString();
            String memID = Session["usN"].ToString();
            int id = Convert.ToInt32(memID);
            // member_DB member = new member_DB();
            //  var query= db.member_DB.FirstOrDefault(x => x.memID == Convert.ToInt32(userN));
            member_DB membe = new member_DB();
            membe = db.member_DB.FirstOrDefault(x => x.memID == id);
            LabelNumber.Text = membe.memID.ToString();
            LabelName.Text = membe.name;
            LabelSurname.Text = membe.surname;
            LabelFaculty.Text = membe.department.faculty.facultyName;
            LabelDepart.Text = membe.department.depName;
            LabelMail.Text = membe.mail;
            LabelNo.Text = membe.number;
            LabelAddr.Text = membe.adress;
        }
        void fillTab3()
        {
            String memID = Session["usN"].ToString();
            int id = Convert.ToInt32(memID);
            labelMoney.Text = dl.calculatePenalty(memID).ToString();
        }
        protected void LinkButtonChange_Click(object sender, EventArgs e)
        {
            String memID = Session["usN"].ToString();
            int id = Convert.ToInt32(memID);
            if(dl.changePass(memID, txtboxPassword.Text))
                Response.Write("<script> alert('Changed.') </script>");
            else
                Response.Write("<script> alert('Not changed.') </script>");
        }

        protected void LinkButtonReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        void reset()
        {
            txtboxPassword.Text = string.Empty;
            txtboxPassword2.Text = string.Empty;
        }

        protected void LinkButtonTake_Click(object sender, EventArgs e)
        {
            String memID = Session["usN"].ToString();
            int id = Convert.ToInt32(memID);
            penaltyDB3 penalty = db.penaltyDB3.FirstOrDefault(x => x.memID == id);
            db.penaltyDB3.Remove(penalty);
            db.SaveChanges();
            int matID = (int)penalty.matID;
            loan_DB2 loanDB2 = db.loan_DB2.FirstOrDefault(x => x.matID == matID);
            db.loan_DB2.Remove(loanDB2);
            db.SaveChanges();

            dl.setAvaibleZero(matID);
            db.SaveChanges();


        }
    }
}