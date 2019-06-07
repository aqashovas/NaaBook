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
    public class TimetablesController : Controller
    {
        private AcademyContext db = new AcademyContext();

        // GET: Manage/Timetables
        public ActionResult Index()
        {
            var timetables = db.Timetables.Include(t => t.Group).Include(t => t.Subject).Include(t => t.Teacher);
            return View(timetables.ToList());
        }

        // GET: Manage/Timetables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // GET: Manage/Timetables/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: Manage/Timetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,Time,Classroom,Status,SemesterNo,Weeklysection,TeacherId,GroupId,SubjectId")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Timetables.Add(timetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", timetable.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", timetable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", timetable.TeacherId);
            return View(timetable);
        }

        // GET: Manage/Timetables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", timetable.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", timetable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", timetable.TeacherId);
            return View(timetable);
        }

        // POST: Manage/Timetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,Time,Classroom,Status,SemesterNo,Weeklysection,TeacherId,GroupId,SubjectId")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", timetable.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", timetable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", timetable.TeacherId);
            return View(timetable);
        }

        // GET: Manage/Timetables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: Manage/Timetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timetable timetable = db.Timetables.Find(id);
            db.Timetables.Remove(timetable);
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
