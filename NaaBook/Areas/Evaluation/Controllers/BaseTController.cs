using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Areas.Evaluation.Controllers
{
    public class BaseTController : Controller
    {
        // GET: Evaluation/BaseT
        private readonly AcademyContext db = new AcademyContext();
        public BaseTController()
        {
            ViewBag.Setting = db.Settings.FirstOrDefault();
        }
    }
}