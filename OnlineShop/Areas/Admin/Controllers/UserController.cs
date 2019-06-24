using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model1.EF;
using Model1.Dao;
using OnlineShop.Common;
using PagedList;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAll(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]    
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var encryptedPassword = Encryption.MD5Hash(user.Password);
                user.Password = encryptedPassword;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Successfully Add User", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Unsuccessfully add user");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().GetUserByID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Successfully Edit User", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Unsuccessfully edit user");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            var result = dao.Delete(id);
            return RedirectToAction("Index"); 
        }
    }
}