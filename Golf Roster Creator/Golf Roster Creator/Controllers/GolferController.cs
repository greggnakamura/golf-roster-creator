using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Golf_Roster_Creator.Models;
using PetaPoco;
using Golf_Roster_Creator.Helpers;

namespace Golf_Roster_Creator.Controllers
{
    public class GolferController : Controller
    {
        //
        // GET: /Golfer/

        public ActionResult Index()
        {
            var golfers = Golfer.Fetch("Order By Last ASC");
            return View(golfers);

            //var db = new Database(ConnectionHelper.ConnectionStringName);
            //var golfers = db.Query<Golfer>("SELECT * FROM Golfers");

            //return Json(golfers, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Add Golfer
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Golfer golferModel)
        {
            if(ModelState.IsValid)
            {
                // Create new Golfer object
                var newGolfer = new Golfer();

                // Set data
                newGolfer._First = golferModel._First;
                newGolfer.Last = golferModel.Last;
                newGolfer.FullName = golferModel._First + " " + golferModel.Last; 
                newGolfer.Email = golferModel.Email;

                newGolfer.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Edit Golfer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var golfer = Golfer.SingleOrDefault(id);
            return View(golfer);
        }

        [HttpPost]
        public ActionResult Edit(int id, Golfer golferModel)
        {
            if(ModelState.IsValid)
            {
                var golfer = Golfer.SingleOrDefault(id);

                golfer._First = golferModel._First;
                golfer.Last = golferModel.Last;
                golfer.FullName = golferModel._First + " " + golferModel.Last; 
                golfer.Email = golferModel.Email;

                golfer.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Delete Golfer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var golfer = Golfer.SingleOrDefault(id);
            return View(golfer);
        }

        [HttpPost]
        public ActionResult Delete(int id, Golfer golferModel)
        {
            var golfer = Golfer.SingleOrDefault(id);

            if(ModelState.IsValid)
            {
                golferModel.GolferID = id;
                golferModel.Delete();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
