using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        private readonly AcademyContext db = new AcademyContext();
        public BaseController()
        {
            ViewBag.Setting = db.Settings.FirstOrDefault();
        }
    }
}