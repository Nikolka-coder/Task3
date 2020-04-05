using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
            if (!Regex.IsMatch(product.Name, "[A-Za-zА-Яа-я0-9\\.]+"))
            {
                ModelState.AddModelError(nameof(product.Name), "Product name is not valid");
            }
            if (product.Price < 0)
            {
                ModelState.AddModelError(nameof(product.Price), "Number  is not valid");
            }
            if (product.Quantity < 0)
            {
                ModelState.AddModelError(nameof(product.Quantity), "Number  is not valid");
            }
            if (DateTime.Compare(product.ExpiryDate, DateTime.Now) < 0)
            {

                ModelState.AddModelError(nameof(product.ProductionDate), "Expire date is not valid! It cannot be earlier");
            }

            if (ModelState.IsValid)
            {
                var products = Session["Products"] as List<Product>;
                product.ProductId = IdUpdateProduct.UpdateId(products);//
                products.Add(product);

                Session["Products"] = products;
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            Session["ProdId"] = id;
            var products = Session["Products"] as List<Product>;
            var currentProduct = products.FirstOrDefault(p => p.ProductId == id);
            if (currentProduct != null)
            {
                return View(currentProduct);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (!Regex.IsMatch(product.Name, "[A-Za-zА-Яа-я0-9\\.]+"))
            {
                ModelState.AddModelError(nameof(product.Name), "Product name is not valid");
            }
            if (product.Price < 0)
            {
                ModelState.AddModelError(nameof(product.Price), "Number  is not valid");
            }
            if (product.Quantity < 0)
            {
                ModelState.AddModelError(nameof(product.Quantity), "Number  is not valid");
            }
            if (DateTime.Compare(product.ExpiryDate, DateTime.Now) < 0)
            {

                ModelState.AddModelError(nameof(product.ProductionDate), "Expire date is not valid! It cannot be earlier");
            }

            if (ModelState.IsValid)
            {
                var prodId = (int)Session["ProdId"];
                var products = Session["Products"] as List<Product>;
                if (prodId != 0)
                {
                    var currentProduct = products.FirstOrDefault(p => p.ProductId == prodId);
                    products.Remove(currentProduct);
                    products.Add(product);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }

        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            var products = Session["Products"] as List<Product>;
            var removedProduct = products.FirstOrDefault(p => p.ProductId == id);
            if (removedProduct != null)
            {
                products.Remove(removedProduct);
            }
            Session["Products"] = products;
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        [HttpGet]
        public ActionResult DetailsProduct()
        {
            return View();        
        }
        [HttpPost]
        public ActionResult DetailsProduct(Product product)
        {
            return View(product);
        }
    }
}