using Golf_Roster_Creator.Helpers;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Golf_Roster_Creator.Models;

namespace Golf_Roster_Creator.Controllers
{
    public class TeeTimeController : Controller
    {
        //
        // GET: /TeeTime/

        public ActionResult Index()
        {
            //var db = new Database(ConnectionHelper.ConnectionStringName);
            //var golfers = db.Query<Golfer>("SELECT First, Last FROM Golfers");

            //ViewBag.sb = new System.Text.StringBuilder();

            //foreach (var item in golfers)
            //{
            //    ViewBag.sb.Append("\"" + item._First + " " + item.Last + "\", ");
            //}

            return View();
        }

        //
        // GET: /TeeTime/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TeeTime/Create

        public ActionResult Create()
        {
            var db = new Database(ConnectionHelper.ConnectionStringName);
            var golfers = db.Query<Golfer>("SELECT First, Last FROM Golfers");

            foreach (var item in golfers)
            {
                ViewBag.GolferFullName = item._First + " " + item.Last; 
            }

            return View(ViewBag.GolferFullName);
        }

        //
        // POST: /TeeTime/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TeeTime/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TeeTime/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TeeTime/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TeeTime/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
