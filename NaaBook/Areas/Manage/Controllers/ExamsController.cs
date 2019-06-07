using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NaaBook.Models;

namespace NaaBook.Areas.Manage.Controllers
{
    [Adminsys]
    public class ExamsController : Controller
    {
        private AcademyContext db = new AcademyContext();

        // GET: Manage/Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Student).Include(e => e.Subject).Include(e => e.Teacher);
            return View(exams.ToList());
        }

        // GET: Manage/Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Manage/Exams/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: Manage/Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,Examresult,TeacherId,SubjectId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", exam.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", exam.TeacherId);
            return View(exam);
        }

        // GET: Manage/Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", exam.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", exam.TeacherId);
            return View(exam);
        }

        // POST: Manage/Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,Examresult,TeacherId,SubjectId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", exam.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", exam.TeacherId);
            return View(exam);
        }

        // GET: Manage/Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Manage/Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
