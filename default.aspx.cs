using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryProject
{
    public partial class _default : System.Web.UI.Page
    {
        databaseLibrary dl = new databaseLibrary();

        protected void Page_Load(object sender, EventArgs e)
        {
            dl.controlPenalty();

        }
    }
}