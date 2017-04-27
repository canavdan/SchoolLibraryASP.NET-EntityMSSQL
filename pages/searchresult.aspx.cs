using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LibraryProject.classes;

namespace LibraryProject.pages
{
    public partial class searchresult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            librarydbEntities db = new librarydbEntities();

            String query = Request.QueryString["query"];
            String catalog = Request.QueryString["catalog"];
            String branch = Request.QueryString["branch"];
            String lang = Request.QueryString["lang"];
            String index = Request.QueryString["index"];
            
            if(String.IsNullOrEmpty(index) && String.IsNullOrEmpty(branch) &&
                String.IsNullOrEmpty(catalog) && String.IsNullOrEmpty(lang))
            {
                Response.Redirect("~/pages/search.aspx");

            }
            else
            {
                if (index.Equals("keywords"))
                {
                    if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query) || mat.name.Contains(query)
                                        || mat.description.Contains(query) || c.catName.Contains(query) ||
                                        p.publisherName.Contains(query))
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
                                      }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                        //fillGrid(sqlQuery);
                    }
                    else if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query) || mat.name.Contains(query)
                                        || mat.description.Contains(query) || c.catName.Contains(query) ||
                                        p.publisherName.Contains(query)) && l.langName.Equals(lang)
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
                                      }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {


                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query) || mat.name.Contains(query)
                                        || mat.description.Contains(query) || c.catName.Contains(query) ||
                                        p.publisherName.Contains(query)) && b.branchName.Equals(branch)
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
                                      }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();

                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query) || mat.name.Contains(query)
                                        || mat.description.Contains(query) || c.catName.Contains(query) ||
                                        p.publisherName.Contains(query)) && t.typeName.Equals(catalog)
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
                                      }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query) || mat.name.Contains(query)
                                        || mat.description.Contains(query) || c.catName.Contains(query) ||
                                        p.publisherName.Contains(query)) && t.typeName.Equals(catalog)
                                        && b.branchName.Equals(branch)
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
                                      }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();

                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query) || mat.name.Contains(query)
                                        || mat.description.Contains(query) || c.catName.Contains(query) ||
                                        p.publisherName.Contains(query)) && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog)
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
                                      }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query) || mat.name.Contains(query)
                                        || mat.description.Contains(query) || c.catName.Contains(query) ||
                                        p.publisherName.Contains(query)) && l.langName.Equals(lang)
                                        && b.branchName.Equals(branch)
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
                                      }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else//not all of three
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query) || mat.name.Contains(query)
                                        || mat.description.Contains(query) || c.catName.Contains(query) ||
                                        p.publisherName.Contains(query)) && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog) && b.branchName.Equals(branch)
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
                                      }).OrderBy(m => m.SSN);

                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                }

                else if (index.Equals("author"))
                {
                    if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                    }
                    else if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {

                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                    }
                    else if (!catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {

                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {

                    }
                    else//not all of three
                    {

                    }



                }

                else if (index.Equals("title"))
                {
                    if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query))
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
                                     }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();


                    }
                    else if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query)) && l.langName.Equals(lang)

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
                                     }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query))
                                         && b.branchName.Equals(branch)
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
                                     }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query))
                                        && t.typeName.Equals(catalog)
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
                                     }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query))
                                        && t.typeName.Equals(catalog) && b.branchName.Equals(branch)
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
                                     }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query)) && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog)
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
                                     }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query)) && l.langName.Equals(lang)
                                         && b.branchName.Equals(branch)
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
                                     }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else//not all of three
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (mat.title.Contains(query)) && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog) && b.branchName.Equals(branch)
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
                                     }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }

                }

                else if (index.Equals("publisher"))
                {
                    if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (p.publisherName.Contains(query))
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
                                   }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();

                    }
                    else if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (p.publisherName.Contains(query))
                                        && l.langName.Equals(lang)
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
                                 }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (p.publisherName.Contains(query))
                                        && b.branchName.Equals(branch)
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
                                 }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (p.publisherName.Contains(query))
                                        && t.typeName.Equals(catalog)
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
                                 }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (p.publisherName.Contains(query))
                                        && t.typeName.Equals(catalog)
                                        && b.branchName.Equals(branch)
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
                                 }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (p.publisherName.Contains(query))
                                        && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog)
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
                                 }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (p.publisherName.Contains(query))
                                        && l.langName.Equals(lang)
                                        && b.branchName.Equals(branch)
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
                                 }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else//not all of three
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (p.publisherName.Contains(query))
                                        && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog)
                                        && b.branchName.Equals(branch)
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
                                 }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                }

                else//Categories
                {
                    if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (c.catName.Contains(query))
                                        && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog)
                                        && b.branchName.Equals(branch)
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
                                     }).OrderBy(m => m.SSN);

                        /* GridView ghhh = (GridView)LoginViewSR.FindControl("GridViewForMembers");
                         ghhh.DataSource = sqlQuery;
                         ghhh.DataBind();*/

                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (c.catName.Contains(query))
                                        && l.langName.Equals(lang)

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
                                   }).OrderBy(m => m.SSN);

                        // GridView GridView1=(GridView)LoginViewSR.FindControl("GridViewForMembers");

                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (c.catName.Contains(query))

                                        && b.branchName.Equals(branch)
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
                                   }).OrderBy(m => m.SSN);



                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (c.catName.Contains(query))

                                        && t.typeName.Equals(catalog)

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
                                   }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & lang.Equals("All Languages"))
                    {

                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (c.catName.Contains(query))

                                        && t.typeName.Equals(catalog)
                                        && b.branchName.Equals(branch)
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
                                   }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (!catalog.Equals("All Catalogs") && branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (c.catName.Contains(query))
                                        && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog)

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
                                   }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else if (catalog.Equals("All Catalogs") && !branch.Equals("All Branches") & !lang.Equals("All Languages"))
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (c.catName.Contains(query))
                                        && l.langName.Equals(lang)

                                        && b.branchName.Equals(branch)
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
                                   }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                    else//not all of three
                    {
                        var sqlQuery = (from mat in db.materials
                                        join t in db.types on mat.typeID equals t.typeID
                                        join p in db.publishers on mat.publisherID equals p.pubID
                                        join c in db.categories on mat.catID equals c.catID
                                        join b in db.branches on mat.branchID equals b.branchID
                                        join l in db.languages on mat.langID equals l.langID
                                        join au in db.aus on mat.matID equals au.matID
                                        join aut in db.authors on au.authorID equals aut.authorID
                                        where (c.catName.Contains(query))
                                        && l.langName.Equals(lang)
                                        && t.typeName.Equals(catalog)
                                        && b.branchName.Equals(branch)
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
                                    }).OrderBy(m => m.SSN);


                        gridsearchResult.DataSource = sqlQuery;
                        gridsearchResult.DataBind();
                    }
                }
            }          
        }

        

        protected void gridsearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            databaseLibrary dL = new databaseLibrary();
            librarydbEntities db = new librarydbEntities();
       
           /* if (User.Identity.IsAuthenticated)
            {
                Response.Write("<script> alert('You have to login to take a book.')" +
                      "; window.location = '~/pages/login.aspx'; </script>");
            }*/
            //string username = user.UserName;
  

            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
               
                GridViewRow row = gridsearchResult.Rows[rowIndex];
              
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Write("<script> alert('You have to login to take a book.')" +
                        "; window.location = '~/pages/search.aspx'; </script>");
                }
                else
                {
                    if (!dL.hasAvaibletoTake())
                    {
                        Response.Write("<script> alert('You need to member to take this book.') </script>");
                    }
                    else
                    {
                        MembershipUser user = Membership.GetUser();
                        if (!dL.hasBookAvaible(Convert.ToInt32(row.Cells[0].Text.ToString())))
                        {
                            Response.Write("<script> alert('Book is not avaible.') </script>");
                        }
                        else
                        {
                            if (dL.hasPenalty(user.UserName))
                            {
                                Response.Write("<script> alert('You have a penalty.You can not take the book.') </script>");
                            }
                            else
                            {

                                loan_DB2 loanClass = new loan_DB2();
                                loanClass.memID = Convert.ToInt32(user.UserName);
                                loanClass.matID = Convert.ToInt32(Convert.ToInt32(row.Cells[0].Text.ToString()));
                                DateTime myDateTime = DateTime.Today;
                                //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                loanClass.outdate = DateTime.Now;
                                // loanClass.duedate = DateTime.Now.AddMonths(1);
                                // loanClass.outdate = (DateTime)2017 - 05 - 25 23:37:30.000;
                                loanClass.duedate = DateTime.Now.AddMonths(1);

                                loanClass.extends = 0;
                                DateTime d = DateTime.Now;
                                string s = d.ToString("yyyyMMdd");
                                string loanIDS = string.Concat(s, user.UserName);
                                loanClass.loanID = loanIDS;
                                db.loan_DB2.Add(loanClass);
                                db.SaveChanges();
                                dL.setAvaibleZero(Convert.ToInt32(loanClass.matID));
                                //loanClass.outdate(myDateTime.ToString());

                                Response.Write("<script> alert('The book is taken by you.')" +
                           "; window.location = '~/pages/search.aspx'; </script>");

                            }
                        }
                    }
                    
                    
                }
            }
        }
    }
}