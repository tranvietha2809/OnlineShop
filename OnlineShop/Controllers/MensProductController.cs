using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model1.Dao;

namespace OnlineShop.Controllers
{
    public class MensProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult MensProductCategory()
        {
            var model = new ProductCategoryDao().ListAll("Men");
            return PartialView(model);
        }

        public ActionResult Category(long cateId)
        {
            var products = new ProductDao().ListSameCategory(cateId);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(cateId);
            return View(products);
        }

        public ActionResult Details(long productId)
        {       
            var product = new ProductDao().ViewDetail(productId);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProducts = new ProductDao().ListRelatedProducts(productId);
            return View(product);
        }
    }
}