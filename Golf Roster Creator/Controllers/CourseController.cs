using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Golf_Roster_Creator.Models;

namespace Golf_Roster_Creator.Controllers
{
    public class CourseController : Controller
    {

        public ActionResult Index()
        {
            var courses = Course.Fetch("Order By Name ASC");
            return View(courses);
        }

        /// <summary>
        /// Create Golf Course
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course courseModel)
        {
            if(ModelState.IsValid)
            {
                // Create new Course object
                var newCourse = new Course();

                newCourse.Name = courseModel.Name;
                newCourse.Phone = courseModel.Phone;

                newCourse.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        /// <summary> 
        /// Edit Golf Course information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var course = Course.SingleOrDefault(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(int id, Course courseModel)
        {
            if(ModelState.IsValid)
            {
                var course = Course.SingleOrDefault(id);

                course.Name = courseModel.Name;
                course.Phone = courseModel.Phone;

                course.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Delete Golf Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var course = Course.SingleOrDefault(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if(ModelState.IsValid)
            {
                var course = Course.SingleOrDefault(id);

                course.CourseID = id;

                course.Delete();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
