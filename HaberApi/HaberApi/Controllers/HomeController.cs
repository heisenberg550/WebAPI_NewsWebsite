using HaberApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberApi.Models.EntityModel;

namespace HaberApi.Controllers
{
    public class HomeController : Controller
    {
        //DataContext db = new DataContext();
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";
            
            //Category category = new Category()
            //{
            //    Name = "Roman",
            //    Description = "Roman Kitapları",
            //    Status = true,
            //    IsDelete = false,
            //};

            //db.Category.Add(category);
            //db.SaveChanges();

            return View();
        }
    }
}
