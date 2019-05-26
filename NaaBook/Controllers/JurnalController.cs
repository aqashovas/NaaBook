using NaaBook.Models;
using NaaBook.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Controllers
{
    public class JurnalController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Jurnal
        public ActionResult Index(int id)
        {
            int idst = Convert.ToInt32(Session["UserId"]);
            int groupId = db.Students.FirstOrDefault(g => g.Id == idst).GroupId;
            List<int> teacherid = new List<int>();
            List<Timetable> timetable = db.Timetables.Where(s => s.SubjectId == id && s.GroupId==groupId).ToList();

            foreach (var item in timetable)
            {
                teacherid.Add(item.TeacherId);
            }
            var teacherslist = db.Teachers.Where(t => teacherid.Contains(t.Id)).ToList();
            int labcount = db.Laboratories.FirstOrDefault(l => l.SubjectId == id && l.StudentId==idst).Count;
            int lestime = db.Lessonsections.FirstOrDefault(l => l.SubjectId == id && l.GroupId == groupId).LessonTime;
            List<Lessonmaterial> lessonmaterials = db.Lessonmaterials.Where(l => l.GroupId == groupId && l.SubjectId == id).ToList();
            Colloquium colloquium = db.Colloquiums.FirstOrDefault(c => c.SubjectId == id && c.StudentId == idst);
            List<Evaluationtable> evaluationtables = db.Evaluationtables.Where(e => e.StudentId == idst && e.SubjectId == id).ToList();
            Exam exam = db.Exams.FirstOrDefault(e => e.StudentId == idst && e.SubjectId == id);
            int freeworkcount = db.Freeworks.FirstOrDefault(f => f.SubjectId == id && f.StudentId == idst).Count;
            VwJournal model = new VwJournal();
            model.Teachers = teacherslist;
            model.Laboratory = labcount;
            model.Lessonsection = lestime;
            model.Lessonmaterials = lessonmaterials;
            model.Colloquium = colloquium;
            model.Evaluationtables = evaluationtables;
            model.Exam = exam;
            model.Freework = freeworkcount;
            return View(model);
        }
    }
}