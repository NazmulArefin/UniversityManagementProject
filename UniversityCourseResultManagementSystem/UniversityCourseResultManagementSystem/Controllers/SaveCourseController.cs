using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Manager;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class SaveCourseController : Controller
    {
        DepartmentManager aDepartmentsManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();
        public ActionResult SaveCourse()
        {
            List<Department> newDepartmentList = aCourseManager.GetAllDepartment();
            ViewBag.NewDepartment = newDepartmentList;

            List<Semester> newSemesterList = aCourseManager.GetAllSemester();
            ViewBag.NewSemester = newSemesterList;
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            List<Department> newDepartmentList = aCourseManager.GetAllDepartment();
            ViewBag.NewDepartment = newDepartmentList;

            List<Semester> newSemesterList = aCourseManager.GetAllSemester();
            ViewBag.NewSemester = newSemesterList;

            ViewBag.Message = aCourseManager.CourseSave(aCourse);
            return View();
        }
	}
}