using BahcedenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BahcedenApp.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        BahcedenDBModel db = new BahcedenDBModel();
        public ActionResult Index()
        {
            return View(db.Categories.Where(x => x.IsDeleted == false).ToList());
        }
        public ActionResult IndexAll()
        {
            return View(db.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Categories.Add(model);
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
        public ActionResult Edit(int id)
        {
            Category kategori = db.Categories.Find(id);
            return View(kategori);
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
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
        public ActionResult Delete(int id)
        {
            Category kategori = db.Categories.Find(id);
            //db.Categories.Remove(kategori);
            kategori.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Deactivate(int id)
        {
            Category kategori = db.Categories.Find(id);
            kategori.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Activate(int id)
        {
            Category kategori = db.Categories.Find(id);
            kategori.IsActive = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}