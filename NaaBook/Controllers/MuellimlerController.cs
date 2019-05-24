using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Controllers
{
    [Auth]
    public class MuellimlerController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Muellimler
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            int groupId = db.Students.FirstOrDefault(g => g.Id == id).GroupId;
            List<int> teacherid = new List<int>();
            List<Timetable> timetable = db.Timetables.Where(s => s.GroupId == groupId).ToList();

            foreach (var item in timetable)
            {
                teacherid.Add(item.TeacherId);
            }
            var teacherslist = db.Teachers.Where(t => teacherid.Contains(t.Id)).ToList();

            return View(teacherslist);
        }
    }
}