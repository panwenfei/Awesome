﻿using AWE.PWF.WEB.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWE.PWF.WEB.Controllers
{
    public class HomeController : MasterPage
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}