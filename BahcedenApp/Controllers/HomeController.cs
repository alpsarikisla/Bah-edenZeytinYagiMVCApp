using BahcedenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BahcedenApp.Controllers
{
    public class HomeController : Controller
    {
        BahcedenDBModel db = new BahcedenDBModel();
        public ActionResult Index()
        {
            return View(db.Products.Where(p=> p.IsDeleted == false).ToList());
        }
    }
}