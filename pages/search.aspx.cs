using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryProject.pages
{ 
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
               // fillcountry();
            }
            // if (!IsPostBack) return;
           
        }
        
        void show()
        {           
            librarydbEntities db = new librarydbEntities();
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

        protected void linkButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/searchresult.aspx?query="+txtboxQuery.Text + "&branch="+dropDownListBranch.SelectedItem.Text
                + "&catalog="+dropDownListCatalog.SelectedItem.Text+"&lang="+dropDownListLanguage.SelectedItem.Text +
                "&index="+dropDownListIndex.SelectedValue.ToString());
           
        }

        protected void linkButtonReset_Click(object sender, EventArgs e)
        {
            reset();

        }
        void reset()
        {
            dropDownListBranch.SelectedIndex = 0;
            dropDownListCatalog.SelectedIndex = 0;
            dropDownListIndex.SelectedIndex = 0;
            dropDownListLanguage.SelectedIndex = 0;
            txtboxQuery.Text = string.Empty;
        }
    }
}