﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Golf_Roster_Creator.ViewModels;
using PetaPoco;
using Golf_Roster_Creator.Helpers;

namespace Golf_Roster_Creator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(HomePageViewModel homePageViewModel)
        {
            var db = new Database(ConnectionHelper.ConnectionStringName);

            ViewBag.courses = new SelectList(db.Query<Course>("SELECT * FROM Courses ORDER BY Name ASC"), "Name", "Name");

            ViewBag.golfers = new SelectList(db.Query<Golfer>("SELECT * FROM Golfers ORDER BY Last ASC"), "GolferID", "FullName");

            ViewBag.teeTimes = db.Query<HomePageViewModel>("SELECT * FROM TeeTimes ORDER BY TeeTime ASC");

            return View(ViewBag.teeTimes);
        }

        public ActionResult test()
        {
            return View();
        }
    }
}
