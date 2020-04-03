using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductShop.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Session.Count == 0)
            {
                Session["Products"] = new List<Product>();
            }
            var products = Session["Products"] as List<Product>;
            return View(products);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct( Product product)
        {
            return View();
        }
    }
}