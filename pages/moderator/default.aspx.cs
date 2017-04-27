using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LibraryProject.classes;

namespace LibraryProject.pages.moderator
{
    public partial class modmain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reset();
                fillTab1();
                fillTab2();
                fillTab3();             
            }
        }
        librarydbEntities db = new librarydbEntities();
        databaseLibrary dl = new databaseLibrary();
        MembershipUser user = Membership.GetUser();

        void fillTab1()
        {

        }
        void fillTab2()
        {
            //Fill Branch DropDown      
            droBranch.DataSource = db.branches.ToList();
            droBranch.DataValueField = "branchID";
            droBranch.DataTextField = "branchName";
            droBranch.DataBind();
           
            //Fill Catalog DropDown
            dropCatalog.DataSource = db.types.ToList();
            dropCatalog.DataValueField = "typeID";
            dropCatalog.DataTextField = "typeName";
            dropCatalog.DataBind();
           
            //Fill Language DropDown
            droLang.DataSource = db.languages.ToList();
            droLang.DataValueField = "langID";
            droLang.DataTextField = "langName";
            droLang.DataBind();

            //Fill Categories DropDown
            droCategories.DataSource = db.categories.ToList();
            droCategories.DataValueField = "catID";
            droCategories.DataTextField = "catName";
            droCategories.DataBind();

            //Fill Publisher DropDown
            DropDownListPublisher.DataSource = db.publishers.ToList();
            DropDownListPublisher.DataValueField = "pubID";
            DropDownListPublisher.DataTextField = "publisherName";
            DropDownListPublisher.DataBind();

        }
        void fillTab3()
        {
            int stafID = Convert.ToInt32(user.UserName);
            staff staffClass = db.staffs.SingleOrDefault(x => x.staffID == stafID);
            LabelNo.Text = staffClass.staffID.ToString();
            LabelName.Text = staffClass.name;
            LabelSurname.Text = staffClass.surnam;
            LabelMail.Text = staffClass.mail;
            LabelNumber.Text = staffClass.number;
            LabelAddr.Text = staffClass.adress;
        }
        void reset()
        {
            txtboxBookId.Text = string.Empty;          
            txtboxBookName.Text = string.Empty;
            txtboxDescription.Text = string.Empty;
            txtboxPrice.Text = string.Empty;
            txtboxSearchMember.Text = string.Empty;
            txtboxTitle.Text = string.Empty;
            txtbxPageNo.Text = string.Empty;
            droBranch.SelectedIndex = 0;
            droCategories.SelectedIndex = 0;
            droLang.SelectedIndex = 0;
            dropCatalog.SelectedIndex = 0;
            DropDownListPublisher.SelectedIndex = 0;
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            
            material mat = new material();
            mat.matID= Convert.ToInt32(txtboxBookId.Text);
            mat.name = txtboxBookName.Text;
            mat.title = txtboxTitle.Text;
            mat.description = txtboxDescription.Text;
            mat.price = Convert.ToDecimal(txtboxPrice.Text);
            mat.pageNo = Convert.ToInt32(txtbxPageNo.Text);
            mat.avaible = true;
            mat.catID= Convert.ToInt32(droCategories.SelectedValue.ToString());
            mat.typeID = Convert.ToInt32(dropCatalog.SelectedValue.ToString());
            mat.branchID = Convert.ToInt32(droBranch.SelectedValue.ToString());
            mat.langID = Convert.ToInt32(droLang.SelectedValue.ToString());
            mat.publisherID = Convert.ToInt32(DropDownListPublisher.SelectedValue.ToString());
            db.materials.Add(mat);
            db.SaveChanges();

            Response.Write("<script> alert('Added')'</script>");
            Response.Redirect("~/pages/moderator/default.aspx");

        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void searchMember_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/pages/moderator/usersearchresult.aspx?uid=" + txtboxSearchMember.Text);

        }
    }
}