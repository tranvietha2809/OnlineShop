using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model1.Dao;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        // Login an user based on information entered in form
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryption.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetUserByName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Username does not exist");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account is not activated");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong password");
                }
            }
            return View("Index");
        }
    }
}