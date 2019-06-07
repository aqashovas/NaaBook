using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NaaBook.Models;

namespace NaaBook.Areas.Manage.Controllers
{
    public class LoginSystemController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Manage/LoginSystem
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin adm = db.Admins.FirstOrDefault(a => a.Username == admin.Username);

                if (adm != null)
                {
                    if (Crypto.VerifyHashedPassword(adm.Password, admin.Password))
                    {
                        Session["AdminLogin"] = true;
                        Session["AdminId"] = adm.Id;
                        return RedirectToAction("index", "dashboard");
                    }
                }

                ModelState.AddModelError("summary", "Email or password incorret");
            }

            return View(admin);
        
        }
    }
}