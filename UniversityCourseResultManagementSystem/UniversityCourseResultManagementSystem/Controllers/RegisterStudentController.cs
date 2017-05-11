using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Manager;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class RegisterStudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        DepartmentManager _departmentManager = new DepartmentManager();
        public ActionResult Registration()
        {
            List<Department> newDepartments = _departmentManager.GetDepartments();
            ViewBag.Departments = newDepartments;
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Student student)
        {
            List<Department> newDepartments = _departmentManager.GetDepartments();
            ViewBag.Departments = newDepartments;

            student.Date = student.Date.Substring(0, 10);
            string message = studentManager.RegisterStudent(student);
            ViewBag.message = message; 
            return View();
        }
	}
}