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

        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Create Tee Timee
        /// </summary>
        /// <param name="teeTimeModel"></param>
        /// <returns></returns>
        public ActionResult Create()
        {
            var db = new Database(ConnectionHelper.ConnectionStringName);
            ViewBag.golfers = new SelectList(db.Query<Golfer>("SELECT * FROM Golfers ORDER BY Last ASC"), "FullName", "FullName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(TeeTime teeTimeModel)
        {
            if(ModelState.IsValid)
            {
                // Create new object
                var newTeeTime = new TeeTime();

                // Set data
                newTeeTime._TeeTime = teeTimeModel._TeeTime;
                newTeeTime.Golfer1 = teeTimeModel.Golfer1;
                newTeeTime.Golfer2 = teeTimeModel.Golfer2;
                newTeeTime.Golfer3 = teeTimeModel.Golfer3;
                newTeeTime.Golfer4 = teeTimeModel.Golfer4;
                newTeeTime.Golfer5 = teeTimeModel.Golfer5;

                newTeeTime.Save();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    
        /// <summary>
        /// Edit Tee Time
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var db = new Database(ConnectionHelper.ConnectionStringName);
            ViewBag.golfers = new SelectList(db.Query<Golfer>("SELECT * FROM Golfers ORDER BY Last ASC"), "FullName", "FullName");

            var teeTime = TeeTime.SingleOrDefault(id);
            return View(teeTime);
        }

        [HttpPost]
        public ActionResult Edit(int id, TeeTime teeTimeModel)
        {
            if(ModelState.IsValid)
            {
                var teeTime = TeeTime.SingleOrDefault(id);

                teeTime._TeeTime = teeTimeModel._TeeTime;
                teeTime.Golfer1 = teeTimeModel.Golfer1;
                teeTime.Golfer2 = teeTimeModel.Golfer2;
                teeTime.Golfer3 = teeTimeModel.Golfer3;
                teeTime.Golfer4 = teeTimeModel.Golfer4;
                teeTime.Golfer5 = teeTimeModel.Golfer5;

                teeTime.Save();

                return RedirectToAction("Index", "Home");
            }
            else
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
