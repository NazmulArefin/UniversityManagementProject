using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Manager;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class EnrollCourseController : Controller
    {
        CourseManager courseManager = new CourseManager();
        StudentManager studentManager = new StudentManager();
        DepartmentManager departementManager = new DepartmentManager();
        public ActionResult EnrollCourse()
        {
            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students; 
            return View(); 
        }
        [HttpPost]
        public ActionResult EnrollCourse(Student student)
        {
            List<Student> studentsList = studentManager.GetAllStudents();
            ViewBag.Students = studentsList;
            student.Id = Convert.ToInt32(student.RegistrationNo); //as i took the value of studentId and show registrationNo to the user
            student.DepartmentId = departementManager.GetDepartmentId(student.DepartmentName); //as i took department name from the user through cshtml
            string message = studentManager.EnrollCourse(student);
            ViewBag.EnrollingMessage = message; 
            return View();
        }

        public JsonResult GetStudentByRegistrationNo(int studentId)
        {
            Student student = studentManager.GetStudent(studentId);
            student.DepartmentName = departementManager.GetDepartmentName(student.DepartmentId);
            return Json(student);
        }
        public JsonResult EnrollCourseByRegNo(int studentId)
        {
            List<Course> course = courseManager.GetCourses(studentId); //course list taken by the student id based on the students departmenId
            return Json(course);
        }
	}
}