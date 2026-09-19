using BahcedenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BahcedenApp.Controllers
{
    public class CategoryController : Controller
    {
        BahcedenDBModel db = new BahcedenDBModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _CategoryMenu()
        {
            return View(db.Categories.Where(x=> x.IsActive == true && x.IsDeleted== false).ToList());
        }
    }
}