using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Areas.Manage.Controllers
{
    [Adminsys]
    public class DashboardController : Controller
    {
        // GET: Manage/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}