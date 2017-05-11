using System.Collections.Generic;
using System.Web.Mvc;
using Rotativa;
using UniversityManagement.Manager;
using UniversityManagement.Models;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class ResultSaveController : Controller
    {
        CourseManager courseManager = new CourseManager();
        StudentManager studentManager = new StudentManager();
        DepartmentManager departementManager = new DepartmentManager();
        public ActionResult SaveResult()
        {
            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students; 
            List<string> gradeList = new List<string>()
            {
                "A+","A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-","F"
            };
            ViewBag.grades = gradeList; 
            return View();
        }
        [HttpPost]
        public ActionResult SaveResult(Student student)
        {
            List<string> gradeList = new List<string>()
            {
                "A+","A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-","F"
            };
            ViewBag.grades = gradeList; 
            List<Student> studentsList = studentManager.GetAllStudents();
            ViewBag.Students = studentsList;
            student.Id = studentManager.GetStudentId(student.RegistrationNo); 
            //student.Id = Convert.ToInt32(student.RegistrationNo); //as i took the value of studentId and show registrationNo to the user
            student.DepartmentId = departementManager.GetDepartmentId(student.DepartmentName); //as i took department name from the user through cshtml
            string message = studentManager.saveResult(student);
            ViewBag.SaveResult = message; 
            return View();
        }
        public JsonResult GetStudentByRegistrationNo(string registrationNo)
        {
            int studentId = studentManager.GetStudentId(registrationNo);
            Student student = studentManager.GetStudent(studentId);
            student.DepartmentName = departementManager.GetDepartmentName(student.DepartmentId);
            return Json(student);
        }
        public JsonResult SelectCourseByStudent(string registrationNo)
        {
            int studentId = studentManager.GetStudentId(registrationNo);
            List<Course> course = courseManager.GetCoursesByStudentId(studentId); //course list taken by the student id based on the studentId
            return Json(course);
        }

        public JsonResult CoursesResult(string registrationNo)
        {
            int studentId = studentManager.GetStudentId(registrationNo);
            List<Course> course = courseManager.GetCourseDetails(studentId);
            return Json(course);
        }
        
        public ActionResult ViewResult()
        {
            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students; 
            return View(); 
        }
        [HttpPost]

        public ActionResult ViewResult(Student student)
        {
            Student students = student;
            ViewBag.Students = students;
            int studentId = studentManager.GetStudentId(student.RegistrationNo);
            List<Course> course = courseManager.GetCourseDetails(studentId);
            return new ViewAsPdf("ViewPDF", course)
            {
                FileName = "TestViewAsPdf.pdf"
            };
        }

        //public ActionResult ExportPDF()
        //{

        //    return new ActionAsPdf("ViewPDF")
        //    {
        //        FileName = Server.MapPath("~/Content/ViewResult.pdf")
        //    };
        //}
	}
}