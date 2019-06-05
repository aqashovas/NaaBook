using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NaaBook.Models;
namespace NaaBook.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly AcademyContext db = new AcademyContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                Student lgn = db.Students.FirstOrDefault(u => u.Username == student.Username);
                

                if (lgn != null)
                {
                    if (Crypto.VerifyHashedPassword(lgn.Password, student.Password))
                    {
                        Session["login"] = true;
                        Session["UserId"] = lgn.Id;
                        return RedirectToAction("index", "home");
                    }
                }

                ModelState.AddModelError("summary", "Email or password incorrect");
                return View(student);
            }
            return View(student);
        }

       public ActionResult Createpass()
        {
            string a = Crypto.HashPassword("000");
            return Content(a);
        }
    }
}