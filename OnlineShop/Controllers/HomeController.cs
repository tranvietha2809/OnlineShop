using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model1.Dao;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByType("MainMenu");
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByType("TopMenu");
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult SubMenu()
        {
            var model = new SubMenuDao().getSubMenuByType("MainMenu");
            return PartialView(model);
        }
    }
}