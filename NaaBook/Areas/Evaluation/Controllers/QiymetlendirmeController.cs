using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaaBook.Viewmodels;
using System.Data.Entity;

namespace NaaBook.Areas.Evaluation.Controllers
{
    public class QiymetlendirmeController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Evaluation/Qiymetlendirme
        public ActionResult Index(int id)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            List<Student> students = db.Students.Where(s => s.GroupId == id).ToList();
            List<int> studentid = new List<int>();
            List<int> subjectid = new List<int>();
            List<Timetable> timetables = db.Timetables.Where(s => s.TeacherId == idt && s.GroupId == id).ToList();
            foreach (var item in timetables)
            {
                subjectid.Add(item.SubjectId);
            }
            foreach (var item in students)
            {
                studentid.Add(item.Id);
            }
            VwEvaluation model = new VwEvaluation();
            model.Evaluationtable = db.Evaluationtables.Include("Subject").Include("Student").Where(e => e.TeacherId == idt && studentid.Contains(e.StudentId)).ToList();
            //model.Freework = db.Freeworks.Include("Subject").Include("Student").Last(e => subjectid.Contains(e.SubjectId) && studentid.Contains(e.StudentId));
            //model.Laboratory = db.Laboratories.Include("Subject").Include("Student").Last(l => subjectid.Contains(l.SubjectId) && studentid.Contains(l.StudentId));
            //model.Colloquium = db.Colloquiums.Include("Subject").Include("Student").Last(l => subjectid.Contains(l.SubjectId) && studentid.Contains(l.StudentId));

            return View(model);
        }

        public ActionResult Lab (int id)
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
            ViewBag.StudentId = new SelectList(db.Students.Where(s => studentid.Contains(s.Id)).ToList(), "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects.Where(t => subjectid.Contains(t.Id)).ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Lab(Laboratory laboratory)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            if (ModelState.IsValid)
            {
                //db.Laboratories.Add(laboratory);
                //ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
                //ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
                //db.SaveChanges();
                

                    db.Laboratories.Add(laboratory);
                    ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
                    ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
                    db.SaveChanges();
                
               
            }
            return View("index");

        }
        public ActionResult Serbestis(int id)
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
            ViewBag.StudentId = new SelectList(db.Students.Where(s => studentid.Contains(s.Id)).ToList(), "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects.Where(t => subjectid.Contains(t.Id)).ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Serbestis(Freework freework)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            if (ModelState.IsValid)
            {
                //db.Laboratories.Add(laboratory);
                //ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
                //ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
                //db.SaveChanges();
               

                    db.Freeworks.Add(freework);
                    ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", freework.StudentId);
                    ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", freework.SubjectId);
                    db.SaveChanges();
                
               
            }
            return View("index");

        }
        public ActionResult Gundelik(int id)
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
            ViewBag.StudentId = new SelectList(db.Students.Where(s => studentid.Contains(s.Id)).ToList(), "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects.Where(t => subjectid.Contains(t.Id)).ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Gundelik(Evaluationtable evaluationtable)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            if (ModelState.IsValid)
            {
                //db.Laboratories.Add(laboratory);
                //ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
                //ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
                //db.SaveChanges();


                db.Evaluationtables.Add(evaluationtable);
                evaluationtable.TeacherId = idt;
                evaluationtable.Time = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", evaluationtable.StudentId);
                ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", evaluationtable.SubjectId);
                db.SaveChanges();


            }
            return View("index");

        }

        public ActionResult Kollokvium(int id)
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
            ViewBag.StudentId = new SelectList(db.Students.Where(s => studentid.Contains(s.Id)).ToList(), "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects.Where(t => subjectid.Contains(t.Id)).ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Kollokvium(Colloquium colloquium)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            if (ModelState.IsValid)
            {
                //db.Laboratories.Add(laboratory);
                //ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
                //ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
                //db.SaveChanges();


                db.Colloquiums.Add(colloquium);
                ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", colloquium.StudentId);
                ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", colloquium.SubjectId);
                db.SaveChanges();


            }
            return View("index");

        }


    }
}