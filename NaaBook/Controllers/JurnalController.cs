using NaaBook.Models;
using NaaBook.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Controllers
{
    [Auth]
    public class JurnalController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Jurnal
        public ActionResult Index(int id)
        {
            int idst = Convert.ToInt32(Session["UserId"]);
            int groupId = db.Students.FirstOrDefault(g => g.Id == idst).GroupId;
            VwJournal model = new VwJournal();

            List<int> teacherid = new List<int>();
            List<Timetable> timetable = db.Timetables.Where(s => s.SubjectId == id && s.GroupId==groupId).ToList();

            foreach (var item in timetable)
            {
                teacherid.Add(item.TeacherId);
            }
            var teacherslist = db.Teachers.Where(t => teacherid.Contains(t.Id)).ToList();
            
            if (db.Laboratories.Any(l => l.SubjectId == id && l.StudentId == idst))
            {
                int labcount = db.Laboratories.Last(l => l.SubjectId == id && l.StudentId == idst).Count;
                model.Laboratory = labcount.ToString();

            }
            else
            {
                model.Laboratory = "0";
            }
            int lestime = db.Lessonsections.FirstOrDefault(l => l.SubjectId == id && l.GroupId == groupId).LessonTime;
            List<Lessonmaterial> lessonmaterials = db.Lessonmaterials.Where(l => l.GroupId == groupId && l.SubjectId == id).ToList();
            List<Evaluationtable> evaluationtables = db.Evaluationtables.Where(e => e.StudentId == idst && e.SubjectId == id).ToList();
            Exam exam = db.Exams.FirstOrDefault(e => e.StudentId == idst && e.SubjectId == id);
            if( db.Freeworks.Any(f => f.SubjectId == id && f.StudentId == idst))
            {
                int freeworkcount = db.Freeworks.Last(f => f.SubjectId == id && f.StudentId == idst).Count;
                model.Freework = freeworkcount.ToString();

            }
            else
            {
                model.Freework = "0";
            }
            model.Teachers = teacherslist;
            model.Lessonsection = lestime;
            model.Lessonmaterials = lessonmaterials;

            Colloquium colloquium = db.Colloquiums.OrderByDescending(o=>o.Id).FirstOrDefault(c => c.SubjectId == id && c.StudentId == idst);

                model.Colloquium = colloquium;

            
            
            model.Evaluationtables = evaluationtables;
            model.Exam = exam;
            return View(model);
        }
    }
}