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
    public class SillabusController : Controller
    {
        private AcademyContext db = new AcademyContext();

        // GET: Evaluation/Sillabus
        public ActionResult Index()
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            var lessonmaterials = db.Lessonmaterials.Include(l => l.Group).Include(l => l.Subject).Include(l => l.Teacher).Where(l=>l.TeacherId==idt);
            return View(lessonmaterials.ToList());
        }

        // GET: Evaluation/Sillabus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lessonmaterial lessonmaterial = db.Lessonmaterials.Find(id);
            if (lessonmaterial == null)
            {
                return HttpNotFound();
            }
            return View(lessonmaterial);
        }

        // GET: Evaluation/Sillabus/Create
        public ActionResult Create()
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            List<int> grid = new List<int>();
            List<Timetable> timetables = db.Timetables.Where(t => t.TeacherId == idt).ToList();
            foreach (var item in timetables)
            {
                grid.Add(item.GroupId);
            }
            ViewBag.GroupId = new SelectList(db.Groups.Where(g=>grid.Contains(g.Id)), "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: Evaluation/Sillabus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,Theme,GroupId,SubjectId,TeacherId")] Lessonmaterial lessonmaterial)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            if (ModelState.IsValid)
            {
                db.Lessonmaterials.Add(lessonmaterial);
                lessonmaterial.TeacherId = idt;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", lessonmaterial.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", lessonmaterial.SubjectId);
            return View(lessonmaterial);
        }

        // GET: Evaluation/Sillabus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lessonmaterial lessonmaterial = db.Lessonmaterials.Find(id);
            if (lessonmaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", lessonmaterial.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", lessonmaterial.SubjectId);
            return View(lessonmaterial);
        }

        // POST: Evaluation/Sillabus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,Theme,GroupId,SubjectId,TeacherId")] Lessonmaterial lessonmaterial)
        {
            int idt = Convert.ToInt32(Session["UserIdt"]);
            if (ModelState.IsValid)
            {
                db.Entry(lessonmaterial).State = EntityState.Modified;
                lessonmaterial.TeacherId = idt;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", lessonmaterial.GroupId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", lessonmaterial.SubjectId);
            return View(lessonmaterial);
        }

        // GET: Evaluation/Sillabus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lessonmaterial lessonmaterial = db.Lessonmaterials.Find(id);
            if (lessonmaterial == null)
            {
                return HttpNotFound();
            }
            return View(lessonmaterial);
        }

        // POST: Evaluation/Sillabus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lessonmaterial lessonmaterial = db.Lessonmaterials.Find(id);
            db.Lessonmaterials.Remove(lessonmaterial);
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
