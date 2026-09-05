using BahcedenApp.Areas.AdminPanel.Data;
using BahcedenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BahcedenApp.Areas.AdminPanel.Controllers
{
    public class AccountController : Controller
    {
        BahcedenDBModel db = new BahcedenDBModel();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ManagerLoginViewModel model)
        {
            if(ModelState.IsValid)//Bütün validationlar sağlanıyor ise
            {
                Manager yonetici = db.Managers.FirstOrDefault(m => m.Mail == model.Mail && m.Password == model.Password);
                if (yonetici != null)
                {
                    Session["yonetici"] = yonetici;
                    return RedirectToAction("Index", "ManagerHome");
                }
                else
                {
                    ViewBag.mesaj = "Yönetici bulunamadı";
                }
            }

            return View(model);
        }
    }
}