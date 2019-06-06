using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Areas.Evaluation.Controllers
{
    public class QiymetlendirmeController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Evaluation/Qiymetlendirme
        public ActionResult Index(int id)
        {


            List<Student> students = db.Students.Where(s => s.GroupId == id).ToList();
            return View(students);
        }
      
    }
}