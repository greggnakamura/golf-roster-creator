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
                // String.Replace time
                var timeStringIndex = 0;
                var updatedTimeInput = "";
                var timeInput = teeTimeModel._TeeTime;

                timeStringIndex = timeInput.IndexOf("9:");

                // Create new object
                var newTeeTime = new TeeTime();

                if (timeStringIndex == 0)
                {
                    updatedTimeInput = timeInput.Replace("9:", "09:");
                    newTeeTime._TeeTime = updatedTimeInput;
                }
                else
                {
                    newTeeTime._TeeTime = teeTimeModel._TeeTime;
                }

                // Set data
                newTeeTime.Golfer1 = teeTimeModel.Golfer1;
                newTeeTime.Golfer2 = teeTimeModel.Golfer2;
                newTeeTime.Golfer3 = teeTimeModel.Golfer3;
                newTeeTime.Golfer4 = teeTimeModel.Golfer4;
                newTeeTime.Golfer5 = teeTimeModel.Golfer5;
                newTeeTime.WalkRide1 = teeTimeModel.WalkRide1;
                newTeeTime.WalkRide2 = teeTimeModel.WalkRide2;
                newTeeTime.WalkRide3 = teeTimeModel.WalkRide3;
                newTeeTime.WalkRide4 = teeTimeModel.WalkRide4;
                newTeeTime.WalkRide5 = teeTimeModel.WalkRide5;


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
                // String.Replace time
                var timeStringIndex = 0;
                var updatedTimeInput = "";
                var timeInput = teeTimeModel._TeeTime;

                timeStringIndex = timeInput.IndexOf("9:");

                // Set data
                var teeTime = TeeTime.SingleOrDefault(id);

                if (timeStringIndex == 0)
                {
                    updatedTimeInput = timeInput.Replace("9:", "09:");
                    teeTime._TeeTime = updatedTimeInput;
                }
                else 
                {
                    teeTime._TeeTime = teeTimeModel._TeeTime;
                }
                
                teeTime.Golfer1 = teeTimeModel.Golfer1;
                teeTime.Golfer2 = teeTimeModel.Golfer2;
                teeTime.Golfer3 = teeTimeModel.Golfer3;
                teeTime.Golfer4 = teeTimeModel.Golfer4;
                teeTime.Golfer5 = teeTimeModel.Golfer5;
                teeTime.WalkRide1 = teeTimeModel.WalkRide1;
                teeTime.WalkRide2 = teeTimeModel.WalkRide2;
                teeTime.WalkRide3 = teeTimeModel.WalkRide3;
                teeTime.WalkRide4 = teeTimeModel.WalkRide4;
                teeTime.WalkRide5 = teeTimeModel.WalkRide5;

                teeTime.Save();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Delete all tee times
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var teeTimes = TeeTime.SingleOrDefault(id);
            return View(teeTimes);
        }

        //
        // POST: /TeeTime/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, TeeTime teeTimeModel)
        {
            //var golfer = TeeTime.SingleOrDefault(id);

            if (ModelState.IsValid)
            {
                teeTimeModel.TeeTimeId = id;
                teeTimeModel.Delete();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
