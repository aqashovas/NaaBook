using NaaBook.Models;
using NaaBook.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Areas.Evaluation.Controllers
{
    [EvAdmin]
    public class CedvelimController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();
        // GET: Evaluation/Mytimetable
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["UserIdt"]);
            VwTimetable timetable = new VwTimetable();
            timetable.Timetables1Up = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "1" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables2Up = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "2" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables3Up = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "3" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables4Up = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "4" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables5Up = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "5" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables1Down = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "1" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();
            timetable.Timetables2Down = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "2" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();
            timetable.Timetables3Down = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "3" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();
            timetable.Timetables4Down = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "4" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();
            timetable.Timetables5Down = db.Timetables.Include("Group").Include("Subject").Where(t => t.TeacherId == id && t.Day == "5" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();


            return View(timetable);
        }
    }
}