using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaaBook.Viewmodels;

namespace NaaBook.Controllers
{
    [Auth]
    public class CedvelController : Controller
    {
        private readonly AcademyContext db = new AcademyContext();

        // GET: Cedvel
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            int groupId = db.Students.FirstOrDefault(g => g.Id == id).GroupId;
            VwTimetable timetable = new VwTimetable();
            timetable.Timetables1Up = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "1" && t.Status==true && t.Weeklysection=="Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables2Up = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "2" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables3Up = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "3" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables4Up = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "4" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables5Up = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "5" && t.Status == true && t.Weeklysection == "Üst").OrderBy(o => o.Time).ToList();
            timetable.Timetables1Down = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "1" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();
            timetable.Timetables2Down = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "2" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();
            timetable.Timetables3Down = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "3" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();
            timetable.Timetables4Down = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "4" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();
            timetable.Timetables5Down = db.Timetables.Include("Teacher").Include("Subject").Where(t => t.GroupId == groupId && t.Day == "5" && t.Status == true && t.Weeklysection == "Alt").OrderBy(o => o.Time).ToList();


            return View(timetable);
        }
    }
}