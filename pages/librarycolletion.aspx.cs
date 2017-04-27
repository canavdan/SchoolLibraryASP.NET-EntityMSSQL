using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryProject.pages
{
    public partial class librarycolletion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            librarydbEntities db = new librarydbEntities();
           
           /*var que = (from mat in db.materials
                       join t in db.types on mat.typeID equals t.typeID
                       group t by mat into g
                       select new
                       {
                           Name=g.Key.type.typeName,

                       }

                     ).;*/
            var results = db.materials.Where(r => r.matID != null)
                 .GroupBy(r => r.type.typeName)
            .Select(gr => new { Key = gr.Key, Count = gr.Count() })
                 .ToList();
          //  GridView1.DataSource = results;
           // GridView1.DataBind();


            /*foreach(var mat in results)
               // ChartMaterial.Series
            ChartMaterial.DataSource = results;
            ChartMaterial.DataBind();*/

        }

        protected void ChartMaterial_Load(object sender, EventArgs e)
        {

        }
    }
}