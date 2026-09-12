using BahcedenApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BahcedenApp.Areas.AdminPanel.Controllers
{
    public class ProductController : Controller
    {
        BahcedenDBModel db = new BahcedenDBModel();
        // GET: AdminPanel/Product
        public ActionResult Index()
        {

            return View(db.Products.Where(x=> x.IsDeleted == false).ToList());
        }

       
        // GET: AdminPanel/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories.Where(x => x.IsDeleted == false), "ID", "Name");
            return View();
        }

      
        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase urunResim)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(urunResim != null)
                    {
                        FileInfo fi = new FileInfo(urunResim.FileName);
                        string uzanti = fi.Extension;
                        string isim = Guid.NewGuid().ToString();
                        string tamisim = isim + uzanti;
                        urunResim.SaveAs(Server.MapPath("~/Assets/ProductImages/" + tamisim));
                        model.Image = tamisim;
                    }
                    else
                    {
                        model.Image = "none.jpg";
                    }
                    db.Products.Add(model);
                    db.SaveChanges();
                    ViewBag.sonuc = true;
                }
                catch
                {
                    ViewBag.sonuc = false;
                }
            }
            ViewBag.CategoryID = new SelectList(db.Categories.Where(x => x.IsDeleted == false), "ID", "Name");
            return View(model);
        }

        // GET: AdminPanel/Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = db.Products.Find(id);
            ViewBag.CategoryID = new SelectList(db.Categories.Where(x => x.IsDeleted == false), "ID", "Name", p.CategoryID);
            return View(p);
        }

        // POST: AdminPanel/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product model, HttpPostedFileBase urunResim)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (urunResim != null)
                    {
                        FileInfo fi = new FileInfo(urunResim.FileName);
                        string uzanti = fi.Extension;
                        string isim = Guid.NewGuid().ToString();
                        string tamisim = isim + uzanti;
                        urunResim.SaveAs(Server.MapPath("~/Assets/ProductImages/" + tamisim));
                        model.Image = tamisim;
                    }
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.sonuc = true;
                }
                catch
                {
                    ViewBag.sonuc = false;
                }
            }
            ViewBag.CategoryID = new SelectList(db.Categories.Where(x => x.IsDeleted == false), "ID", "Name", model.CategoryID);
            return View(model);
        }

        // GET: AdminPanel/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminPanel/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
