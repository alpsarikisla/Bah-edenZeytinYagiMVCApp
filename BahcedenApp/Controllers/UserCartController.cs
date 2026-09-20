using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BahcedenApp.Models;

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
    }
}