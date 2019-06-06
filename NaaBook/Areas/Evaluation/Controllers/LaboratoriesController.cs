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
    public class LaboratoriesController : Controller
    {
        private AcademyContext db = new AcademyContext();

        // GET: Evaluation/Laboratories
        public ActionResult Index()
        {
            var laboratories = db.Laboratories.Include(l => l.Student).Include(l => l.Subject);
            return View(laboratories.ToList());
        }

        // GET: Evaluation/Laboratories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            return View(laboratory);
        }

        // GET: Evaluation/Laboratories/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: Evaluation/Laboratories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,SubjectId,Count")] Laboratory laboratory)
        {
            if (ModelState.IsValid)
            {
                db.Laboratories.Add(laboratory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
            return View(laboratory);
        }

        // GET: Evaluation/Laboratories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
            return View(laboratory);
        }

        // POST: Evaluation/Laboratories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,SubjectId,Count")] Laboratory laboratory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laboratory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Fullname", laboratory.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", laboratory.SubjectId);
            return View(laboratory);
        }

        // GET: Evaluation/Laboratories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            return View(laboratory);
        }

        // POST: Evaluation/Laboratories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laboratory laboratory = db.Laboratories.Find(id);
            db.Laboratories.Remove(laboratory);
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
