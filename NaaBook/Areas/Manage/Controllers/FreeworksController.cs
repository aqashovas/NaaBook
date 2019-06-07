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
    public class FreeworksController : Controller
    {
        private AcademyContext db = new AcademyContext();

        // GET: Manage/Freeworks
        public ActionResult Index()
        {
            var freeworks = db.Freeworks.Include(f => f.Student).Include(f => f.Subject);
            return View(freeworks.ToList());
        }

        // GET: Manage/Freeworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freework freework = db.Freeworks.Find(id);
            if (freework == null)
            {
                return HttpNotFound();
            }
            return View(freework);
        }

        // GET: Manage/Freeworks/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: Manage/Freeworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,SubjectId,Count")] Freework freework)
        {
            if (ModelState.IsValid)
            {
                db.Freeworks.Add(freework);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", freework.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", freework.SubjectId);
            return View(freework);
        }

        // GET: Manage/Freeworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freework freework = db.Freeworks.Find(id);
            if (freework == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", freework.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", freework.SubjectId);
            return View(freework);
        }

        // POST: Manage/Freeworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,SubjectId,Count")] Freework freework)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freework).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", freework.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", freework.SubjectId);
            return View(freework);
        }

        // GET: Manage/Freeworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freework freework = db.Freeworks.Find(id);
            if (freework == null)
            {
                return HttpNotFound();
            }
            return View(freework);
        }

        // POST: Manage/Freeworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Freework freework = db.Freeworks.Find(id);
            db.Freeworks.Remove(freework);
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
