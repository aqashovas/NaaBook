﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}