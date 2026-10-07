using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BahcedenApp.Models;
using BahcedenApp.Models.ViewModels;
using System.Net.Http;

namespace BahcedenApp.Controllers
{
    public class UserCartController : Controller
    {
        BahcedenDBModel db = new BahcedenDBModel();
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                User u = (User)Session["user"];
                List<UserCart> userCart = db.UserCarts.Where(x => x.User_ID == u.ID).ToList();
                return View(userCart);
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
           
        }
        public ActionResult AddToCart(int id)
        {
            if (Session["user"] != null)
            {
                Product p = db.Products.Find(id);

                User u = (User)Session["user"];
                UserCart userCart = new UserCart();
                userCart.User_ID = u.ID;
                userCart.Quantity = 1;
                userCart.Product_ID = id;
                userCart.TotalPrice = p.Price;
                db.UserCarts.Add(userCart);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login","UserAccount");
            }
        }
        [HttpGet]
        public ActionResult Pay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pay(PayViewModel model)
        {
            if (ModelState.IsValid) {
                User u = (User)Session["user"];
                List<UserCart> userCart = db.UserCarts.Where(x => x.User_ID == u.ID).ToList();
                double price = userCart.Sum(x => x.Quantity * x.Product.Price);
                string apiurl = "https://localhost:44399/API/Pay?kartNo=" + model.CartNumber + "&sonKullanmaAy=" + model.ReqMonth + "&sonKullanmaYil=" + model.ReqYear + "&CVV=" + model.CVV + "&fiyat=" + price;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(apiurl).Result;
                var stringresponse = response.Content.ReadAsStringAsync();

                if (stringresponse.Result == "\"901\"")
                {
                    ViewBag.mesaj = "Kart Numarası Hatalı veya Kart Bulunamadı";
                }
                if (stringresponse.Result == "\"801\"")
                {
                    ViewBag.mesaj = "Kart Tarihi Geçti";
                }
                if (stringresponse.Result == "\"701\"")
                {
                    ViewBag.mesaj = "CVV Geçersiz";
                }
                if (stringresponse.Result == "\"601\"")
                {
                    ViewBag.mesaj = "Yetersiz Bakiye";
                }
                if (stringresponse.Result == "\"301\"")
                {
                    ViewBag.mesaj = "Tanımlamayan Bir Hata Oluştu";
                }
                if (stringresponse.Result == "\"101\"")
                {
                    //Burada sepetin silinmesi gerekir
                    return RedirectToAction("PayPaySuccess", "UserCart");
                }
            }
            return View(model);
        }
        public ActionResult PayPaySuccess()
        {
            return View();
        }
    }
}