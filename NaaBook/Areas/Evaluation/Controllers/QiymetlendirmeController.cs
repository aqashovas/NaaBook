using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaaBook.Viewmodels;

namespace NaaBook.Areas.Evaluation.Controllers
{
    public class QiymetlendirmeController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Evaluation/Qiymetlendirme
        public ActionResult Index()
        {


            return View();
        }

        
        public ActionResult Insert(int id)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            List<Student> students = db.Students.Where(s => s.GroupId == id).ToList();
            List<Timetable> timetables = db.Timetables.Where(s => s.TeacherId == idt && s.GroupId == id).ToList();
            List<int> studentid = new List<int>();
            List<int> subjectid = new List<int>();
            foreach (var item in timetables)
            {
                subjectid.Add(item.SubjectId);
            }
            foreach (var item in students)
            {
                studentid.Add(item.Id);
            }
            ViewBag.StudentId = new SelectList(db.Students.Where(s=>studentid.Contains(s.Id)).ToList(), "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects.Where(t => subjectid.Contains(t.Id)).ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Insert()
        {
            

            return View();
        }

    }
}