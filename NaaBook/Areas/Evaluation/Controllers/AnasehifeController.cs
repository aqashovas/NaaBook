using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Areas.Evaluation.Controllers
{
    [EvAdmin]
    public class AnasehifeController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Evaluation/Anasehife
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["UserIdt"]);
            //int groupId = db.Students.FirstOrDefault(g => g.Id == id).GroupId;
            List<int> groupid = new List<int>();
            List<Timetable> timetable = db.Timetables.Where(s => s.TeacherId == id).ToList();

            foreach (var item in timetable)
            {
                groupid.Add(item.TeacherId);
            }
            var grouplist = db.Groups.Where(t => groupid.Contains(t.Id)).ToList();

            return View(grouplist);
        }
    }
}