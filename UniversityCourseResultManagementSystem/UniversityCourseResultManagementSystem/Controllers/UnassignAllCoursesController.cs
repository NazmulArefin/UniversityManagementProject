using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Course_and_Result_Management_System.Manager;
using University_Course_and_Result_Management_System.Models;

namespace University_Course_and_Result_Management_System.Controllers
{
    public class UnassignAllCoursesController : Controller
    {
        UnassignAllCoursesManager anUnassignAllCoursesManager = new UnassignAllCoursesManager();
        // GET: UnassignAllCourses
        public ActionResult UnassignAllCourses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnassignAllCourses(CourseAssign assign)
        {
            ViewBag.log = anUnassignAllCoursesManager.UnassignAllCoursesNow();
            anUnassignAllCoursesManager.UpdateReaminCredit();
            ViewBag.studentLog = anUnassignAllCoursesManager.UnassignAllStudentCoursesNow();
            return View();
        }
        
    }
}