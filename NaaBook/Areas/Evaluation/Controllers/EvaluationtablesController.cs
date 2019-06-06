using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NaaBook.Models;

namespace NaaBook.Areas.Evaluation.Controllers
{
    public class EvaluationtablesController : Controller
    {
        private AcademyContext db = new AcademyContext();

        // GET: Evaluation/Evaluationtables
        public ActionResult Index()
        {
            var evaluationtables = db.Evaluationtables.Include(e => e.Student).Include(e => e.Subject).Include(e => e.Teacher);
            return View(evaluationtables.ToList());
        }

        // GET: Evaluation/Evaluationtables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluationtable evaluationtable = db.Evaluationtables.Find(id);
            if (evaluationtable == null)
            {
                return HttpNotFound();
            }
            return View(evaluationtable);
        }

        // GET: Evaluation/Evaluationtables/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: Evaluation/Evaluationtables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,MarkOrAttendanceFirst,MarkOrAttendanceSecond,TeacherId,SubjectId,Time")] Evaluationtable evaluationtable)
        {
            if (ModelState.IsValid)
            {
                db.Evaluationtables.Add(evaluationtable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", evaluationtable.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", evaluationtable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", evaluationtable.TeacherId);
            return View(evaluationtable);
        }

        // GET: Evaluation/Evaluationtables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluationtable evaluationtable = db.Evaluationtables.Find(id);
            if (evaluationtable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", evaluationtable.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", evaluationtable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", evaluationtable.TeacherId);
            return View(evaluationtable);
        }

        // POST: Evaluation/Evaluationtables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,MarkOrAttendanceFirst,MarkOrAttendanceSecond,TeacherId,SubjectId,Time")] Evaluationtable evaluationtable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluationtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", evaluationtable.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", evaluationtable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", evaluationtable.TeacherId);
            return View(evaluationtable);
        }

        // GET: Evaluation/Evaluationtables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluationtable evaluationtable = db.Evaluationtables.Find(id);
            if (evaluationtable == null)
            {
                return HttpNotFound();
            }
            return View(evaluationtable);
        }

        // POST: Evaluation/Evaluationtables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluationtable evaluationtable = db.Evaluationtables.Find(id);
            db.Evaluationtables.Remove(evaluationtable);
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
