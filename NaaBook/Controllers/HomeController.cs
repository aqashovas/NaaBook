using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Controllers
{
    [Auth]
    public class HomeController : BaseController
    {
        private readonly AcademyContext db = new AcademyContext();
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            int groupId = db.Students.FirstOrDefault(g => g.Id == id).GroupId;
            List<int> subjectid = new List<int>();
            List<Timetable> timetable = db.Timetables.Where(s => s.GroupId == groupId).ToList();

            foreach (var item in timetable)
            {
                subjectid.Add(item.SubjectId);
            }
            var subjectlist = db.Subjects.Where(t => subjectid.Contains(t.Id)).ToList();

            return View(subjectlist);
        }

    }
}