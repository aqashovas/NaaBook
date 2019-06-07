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
    public class ColloquiumsController : Controller
    {
        private AcademyContext db = new AcademyContext();

        // GET: Manage/Colloquiums
        public ActionResult Index()
        {
            var colloquiums = db.Colloquiums.Include(c => c.Student).Include(c => c.Subject);
            return View(colloquiums.ToList());
        }

        // GET: Manage/Colloquiums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colloquium colloquium = db.Colloquiums.Find(id);
            if (colloquium == null)
            {
                return HttpNotFound();
            }
            return View(colloquium);
        }

        // GET: Manage/Colloquiums/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: Manage/Colloquiums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Colloquium1,Colloquium2,Colloquium3,StudentId,SubjectId")] Colloquium colloquium)
        {
            if (ModelState.IsValid)
            {
                db.Colloquiums.Add(colloquium);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", colloquium.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", colloquium.SubjectId);
            return View(colloquium);
        }

        // GET: Manage/Colloquiums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colloquium colloquium = db.Colloquiums.Find(id);
            if (colloquium == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", colloquium.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", colloquium.SubjectId);
            return View(colloquium);
        }

        // POST: Manage/Colloquiums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Colloquium1,Colloquium2,Colloquium3,StudentId,SubjectId")] Colloquium colloquium)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colloquium).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", colloquium.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", colloquium.SubjectId);
            return View(colloquium);
        }

        // GET: Manage/Colloquiums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colloquium colloquium = db.Colloquiums.Find(id);
            if (colloquium == null)
            {
                return HttpNotFound();
            }
            return View(colloquium);
        }

        // POST: Manage/Colloquiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colloquium colloquium = db.Colloquiums.Find(id);
            db.Colloquiums.Remove(colloquium);
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
