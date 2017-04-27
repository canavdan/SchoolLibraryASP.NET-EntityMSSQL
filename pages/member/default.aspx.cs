using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LibraryProject.classes;

namespace LibraryProject.pages.member
{
    public partial class membermain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Session["usN"].ToString());
            if (!IsPostBack)
            {
                fillTab1();
                fillTab2();
                fillTab3();
                fillTab4();

            }       
        }
        librarydbEntities db = new librarydbEntities();
        MembershipUser user = Membership.GetUser();
        databaseLibrary dl = new databaseLibrary();


        void fillTab1()
        {
            MembershipUser user = Membership.GetUser();
            string username = user.UserName;
            //Fill user profile
            //String userN = Session["usN"].ToString();
            int id = Convert.ToInt32(username);

            // member_DB member = new member_DB();
            //  var query= db.member_DB.FirstOrDefault(x => x.memID == Convert.ToInt32(userN));
            member_DB membe = new member_DB();

            membe = db.member_DB.FirstOrDefault(x => x.memID == id);
            LabelNumber.Text = membe.memID.ToString();
            LabelName.Text = membe.name;
            LabelSurname.Text = membe.surname;
            LabelFaculty.Text = membe.department.faculty.facultyName;
            LabelDepart.Text = membe.department.depName;       
            LabelMail.Text = membe.mail.ToString();
            LabelNo.Text = membe.number;
            LabelAddr.Text = membe.adress;
    }
        void fillTab2()
        {
           // librarydbEntities db = new librarydbEntities();
            //Fill Branch DropDown      
            dropDownListBranch.DataSource = db.branches.ToList();
            dropDownListBranch.DataValueField = "branchID";
            dropDownListBranch.DataTextField = "branchName";
            dropDownListBranch.DataBind();
            ListItem litem9 = new ListItem();
            litem9.Text = "All Branches";
            litem9.Value = "0";
            dropDownListBranch.Items.Add(litem9);
            dropDownListBranch.SelectedValue = litem9.Value.ToString();
            //Fill Catalog DropDown
            dropDownListCatalog.DataSource = db.types.ToList();
            dropDownListCatalog.DataValueField = "typeID";
            dropDownListCatalog.DataTextField = "typeName";
            dropDownListCatalog.DataBind();
            ListItem litem8 = new ListItem();
            litem8.Text = "All Catalogs";
            litem8.Value = "0";
            dropDownListCatalog.Items.Add(litem8);
            dropDownListCatalog.SelectedValue = litem8.Value.ToString();
            //Fill Language DropDown
            dropDownListLanguage.DataSource = db.languages.ToList();
            dropDownListLanguage.DataValueField = "langID";
            dropDownListLanguage.DataTextField = "langName";
            dropDownListLanguage.DataBind();
            ListItem litem7 = new ListItem();
            litem7.Text = "All Languages";
            litem7.Value = "0";
            dropDownListLanguage.Items.Add(litem7);
            dropDownListLanguage.SelectedValue = litem7.Value.ToString();
            //Fill Index DropDown
            ListItem litem = new ListItem();
            litem.Text = "Keywords";
            litem.Value = "keywords";
            dropDownListIndex.Items.Add(litem);
            ListItem litem2 = new ListItem();
            litem2.Text = "Author";
            litem2.Value = "author";
            dropDownListIndex.Items.Add(litem2);
            ListItem litem3 = new ListItem();
            litem3.Text = "Title";
            litem3.Value = "title";
            dropDownListIndex.Items.Add(litem3);
            ListItem litem4 = new ListItem();
            litem4.Text = "Publisher";
            litem4.Value = "publisher";
            dropDownListIndex.Items.Add(litem4);
            ListItem litem5 = new ListItem();
            litem5.Text = "Categories";
            litem5.Value = "categories";
            dropDownListIndex.Items.Add(litem5);
        }
        void fillTab3()
        {
            int usernameInt = Convert.ToInt32(user.UserName);
            var query = db.loan_DB2.Where(x => x.memID == usernameInt)
                .Select(x => new
                {
                    LoanID = x.loanID,
                    Name = x.material.name,
                    outdate = x.outdate,
                    duedate = x.duedate,
                    extends=x.extends
                }).ToList();

            GridViewLoans.DataSource = query;
            db.SaveChanges();
            GridViewLoans.DataBind();


                           }
        void fillTab4()
        {
            int usernameInt = Convert.ToInt32(user.UserName);
            GridViewLoanHistory.DataSource = db.loanhistory2.Where(x => x.memberID == usernameInt).ToList();
            GridViewLoanHistory.DataBind();
            
        }
        protected void linkButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/searchresult.aspx?query=" + txtboxQuery.Text + "&branch=" + dropDownListBranch.SelectedItem.Text
               + "&catalog=" + dropDownListCatalog.SelectedItem.Text + "&lang=" + dropDownListLanguage.SelectedItem.Text +
               "&index=" + dropDownListIndex.SelectedValue.ToString());
        }

        protected void GridViewLoans_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Extend")
            {
                if (dl.hasPenalty(user.UserName)){
                    Response.Write("<script> alert('You have a penalty.You can not extend the book.') </script>");
                }
                else
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    GridViewRow row = GridViewLoans.Rows[rowIndex];
                    if (!dl.increaseExtend(row.Cells[0].Text.ToString()))
                    {
                        Response.Write("<script> alert('You can not extend.Extend limit is done.') </script>");
                    }
                    else
                    {
                        Response.Redirect("~/pages/member/default.aspx");
                    }
                    
                }
                
            }
            else if (e.CommandName == "Return")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = GridViewLoans.Rows[rowIndex];
                if (dl.hasPenalty(user.UserName))
                {
                    Response.Write("<script> alert('You have a penalty.You can not return the book.') </script>");
                }
                else
                {
                    String loanDB2ID = row.Cells[0].Text.ToString();
                    loan_DB2 loanDB2 = db.loan_DB2.SingleOrDefault(x => x.loanID == loanDB2ID);
                    int matIDD = (int)loanDB2.matID;
                    db.loan_DB2.Remove(loanDB2);
                    db.SaveChanges();

                    

                    loanhistory2 loanH = new loanhistory2();
                    loanH.memberID = Convert.ToInt32(user.UserName);
                    loanH.matID = matIDD;
                    DateTime d = DateTime.Now;
                    string s = d.ToString("yyyyMMdd");
                    string loanIDS = string.Concat(s,user.UserName);
                    loanIDS = String.Concat(loanIDS, matIDD.ToString());
                    loanH.historyID = loanIDS;
                    db.loanhistory2.Add(loanH);
                    db.SaveChanges();
                    dl.setAvaibleOne(matIDD);
                    Response.Redirect("~/pages/member/default.aspx");

                }

            }
        }

       
    }
}