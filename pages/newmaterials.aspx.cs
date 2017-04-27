using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryProject.pages
{
    public partial class newmaterials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            show();


            
        }
        void show()
        {
            librarydbEntities db = new librarydbEntities();

            var sqlQuery = (from mat in db.materials
                            join t in db.types on mat.typeID equals t.typeID
                            join p in db.publishers on mat.publisherID equals p.pubID
                            join c in db.categories on mat.catID equals c.catID
                            join b in db.branches on mat.branchID equals b.branchID
                            join l in db.languages on mat.langID equals l.langID
                            join au in db.aus on mat.matID equals au.matID
                            join aut in db.authors on au.authorID equals aut.authorID                          
                            group aut by mat into g
                            select new
                            {
                                SSN = g.Key.matID,
                                Name = g.Key.name,
                                Title = g.Key.title,
                                TypeB = g.Key.type.typeName,
                                Category = g.Key.category.catName,
                                Author = g.Select(si => si.name),
                                //Surname=g.Select(sir=>sir.surname),
                                Language = g.Key.language.langName,
                                Publisher = g.Key.publisher.publisherName,
                                Branch = g.Key.branch.branchName,
                                Price = g.Key.price,
                                PageNo = g.Key.pageNo,
                                Descripton = g.Key.description,
                                Avaible = g.Key.avaible
                            }

                                 ).ToList().Select(x => new
                                 {
                                     x.SSN,
                                     x.Name,
                                     x.Title,
                                     x.TypeB,
                                     x.Category,
                                     Authors = string.Join(",", x.Author)
                                 ,
                                     x.Language,
                                     x.Publisher,
                                     x.Branch,
                                     x.Price,
                                     x.PageNo,
                                     x.Descripton
                                 ,
                                     x.Avaible
                                 }).OrderByDescending(m => m.SSN).Take(15);


            gridLatestMaterial.DataSource = sqlQuery;
            gridLatestMaterial.DataBind();
        }
    }
}