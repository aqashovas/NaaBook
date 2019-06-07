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
    public class LessonsectionsController : Controller
    {
        private AcademyContext db = new AcademyContext();

        // GET: Manage/Lessonsections
        public ActionResult Index()
        {
            var lessonsections = db.Lessonsections.Include(l => l.Group).Include(l => l.Subject);
            return View(lessonsections.ToList());
        }

        // GET: Manage/Lessonsections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lessonsection lessonsection = db.Lessonsections.Find(id);
            if (lessonsection == null)
            {
                return HttpNotFound();
            }
            return View(lessonsection);
        }

        // GET: Manage/Lessonsections/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: Manage/Lessonsections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupId,SubjectId,LessonTime")] Lessonsection lessonsection)
        {
            if (ModelState.IsValid)
            {
                db.Lessonsections.Add(lessonsection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", lessonsection.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", lessonsection.SubjectId);
            return View(lessonsection);
        }

        // GET: Manage/Lessonsections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lessonsection lessonsection = db.Lessonsections.Find(id);
            if (lessonsection == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", lessonsection.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", lessonsection.SubjectId);
            return View(lessonsection);
        }

        // POST: Manage/Lessonsections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupId,SubjectId,LessonTime")] Lessonsection lessonsection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lessonsection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", lessonsection.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", lessonsection.SubjectId);
            return View(lessonsection);
        }

        // GET: Manage/Lessonsections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lessonsection lessonsection = db.Lessonsections.Find(id);
            if (lessonsection == null)
            {
                return HttpNotFound();
            }
            return View(lessonsection);
        }

        // POST: Manage/Lessonsections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lessonsection lessonsection = db.Lessonsections.Find(id);
            db.Lessonsections.Remove(lessonsection);
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
