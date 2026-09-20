using BahcedenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BahcedenApp.Models.ViewModels;

namespace BahcedenApp.Controllers
{
    public class UserAccountController : Controller
    {
        BahcedenDBModel db = new BahcedenDBModel();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                    ViewBag.sonuc = true;
                }
                catch
                {
                    ViewBag.mesaj = false;
                }
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)//Bütün validationlar sağlanıyor ise
            {
                User user = db.Users.FirstOrDefault(m => m.Mail == model.Mail && m.Password == model.Password);
                if (user != null)
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.mesaj = "Üye bulunamadı";
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
        
    }
}