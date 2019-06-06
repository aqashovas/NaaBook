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
            ViewBag.StudentId = new SelectList(db.Students.Where(s=>studentid.Contains(s.Id)).ToList(), "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects.Where(t => subjectid.Contains(t.Id)).ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Insert(Evaluationtable evaluationtable,Freework freework,Laboratory laboratory)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            if (ModelState.IsValid)
            {
                db.Evaluationtables.Add(evaluationtable);
                db.Freeworks.Add(freework);
                db.Laboratories.Add(laboratory);
                evaluationtable.TeacherId = idt;
                evaluationtable.Time = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

            return View(evaluationtable);
        }

    }
}