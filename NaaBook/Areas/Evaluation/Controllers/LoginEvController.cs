using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NaaBook.Models;

namespace NaaBook.Areas.Evaluation.Controllers
{
    public class LoginEvController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Evaluation/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Teacher lgn = db.Teachers.FirstOrDefault(u => u.Username == teacher.Username);


                if (lgn != null)
                {
                    if (Crypto.VerifyHashedPassword(lgn.Password, teacher.Password))
                    {
                        Session["logint"] = true;
                        Session["UserIdt"] = lgn.Id;
                        return RedirectToAction("index", "anasehife");
                    }
                }

                ModelState.AddModelError("summary", "Email or password incorrect");
                return View(teacher);
            }
            return View(teacher);
        }
    }
}