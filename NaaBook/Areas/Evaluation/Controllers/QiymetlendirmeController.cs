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
        public ActionResult Index()
        {


            return View();
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
        //[HttpPost]
        //public ActionResult Lab(Laboratory laboratory)
        //{
        //    int idt = Convert.ToInt32(Session["UserIdt"]);
        //    if (ModelState.IsValid)
        //    {
        //        if (!db.Laboratories.Any(l => l.StudentId == laboratory.StudentId && l.SubjectId == laboratory.SubjectId))
        //        {

        //            db.Laboratories.Add(laboratory);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            db.Entry(laboratory).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        return View("index");
        //    } }
        //public ActionResult Insert(int id)
        //{
        //    int idt = Convert.ToInt32(Session["UserIdt"]);
        //    List<Student> students = db.Students.Where(s => s.GroupId == id).ToList();
        //    List<Timetable> timetables = db.Timetables.Where(s => s.TeacherId == idt && s.GroupId == id).ToList();
        //    List<int> studentid = new List<int>();
        //    List<int> subjectid = new List<int>();
        //    foreach (var item in timetables)
        //    {
        //        subjectid.Add(item.SubjectId);
        //    }
        //    foreach (var item in students)
        //    {
        //        studentid.Add(item.Id);
        //    }
        //    ViewBag.StudentId = new SelectList(db.Students.Where(s=>studentid.Contains(s.Id)).ToList(), "Id", "Fullname");
        //    ViewBag.SubjectId = new SelectList(db.Subjects.Where(t => subjectid.Contains(t.Id)).ToList(), "Id", "Name");

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Insert(VwEvaluation model)
        //{
        //    int idt = Convert.ToInt32(Session["UserIdt"]);
        //    if (ModelState.IsValid)
        //    {
        //        if (model.Evaluationtable != null && model.Laboratory!=null && model.Freework!=null)
        //        {
        //            db.Evaluationtables.Add(model.Evaluationtable);
        //            db.Freeworks.Add(model.Freework);
        //            db.Laboratories.Add(model.Laboratory);
        //            model.Evaluationtable.TeacherId = idt;
        //            model.Evaluationtable.Time = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Freework.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Freework.SubjectId);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Laboratory.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Laboratory.SubjectId);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Evaluationtable.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Evaluationtable.SubjectId);
        //            db.SaveChanges();

        //        }
        //        else if(model.Evaluationtable==null && model.Freework!=null && model.Laboratory != null)
        //        {
        //            db.Freeworks.Add(model.Freework);
        //            db.Laboratories.Add(model.Laboratory);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Freework.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Freework.SubjectId);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Laboratory.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Laboratory.SubjectId);
        //            db.SaveChanges();

        //        }
        //        else if(model.Evaluationtable == null && model.Freework == null && model.Laboratory != null)
        //        {
        //            db.Laboratories.Add(model.Laboratory);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Laboratory.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Laboratory.SubjectId);
        //            db.SaveChanges();
        //        }
        //        else if (model.Evaluationtable == null && model.Freework != null && model.Laboratory == null)
        //        {
        //            db.Freeworks.Add(model.Freework);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Freework.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Freework.SubjectId);
        //            db.SaveChanges();
        //        }
        //        else if (model.Evaluationtable != null && model.Freework != null && model.Laboratory == null)
        //        {
        //            db.Freeworks.Add(model.Freework);
        //            db.Evaluationtables.Add(model.Evaluationtable);
        //            model.Evaluationtable.TeacherId = idt;
        //            model.Evaluationtable.Time = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Freework.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Freework.SubjectId);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Evaluationtable.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Evaluationtable.SubjectId);
        //            db.SaveChanges();
        //        }
        //        else if (model.Evaluationtable != null && model.Freework == null && model.Laboratory != null)
        //        {
        //            db.Laboratories.Add(model.Laboratory);
        //            db.Evaluationtables.Add(model.Evaluationtable);
        //            model.Evaluationtable.TeacherId = idt;
        //            model.Evaluationtable.Time = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Evaluationtable.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Evaluationtable.SubjectId);
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Laboratory.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Laboratory.SubjectId);
        //            db.SaveChanges();
        //        }
        //        else if (model.Evaluationtable != null && model.Freework == null && model.Laboratory == null)
        //        {
        //            db.Evaluationtables.Add(model.Evaluationtable);
        //            model.Evaluationtable.TeacherId = idt;
        //            model.Evaluationtable.Time = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
        //            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", model.Evaluationtable.StudentId);
        //            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", model.Evaluationtable.SubjectId);

        //            db.SaveChanges();
        //        }

               
               
               

        //        return RedirectToAction("Index");
        //    }
           

        //    return View(model);
        //}

    }
}