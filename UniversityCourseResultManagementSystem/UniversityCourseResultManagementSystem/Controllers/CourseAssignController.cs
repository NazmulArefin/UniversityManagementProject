using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityCourseResultManagementSystem.Manager;
using UniversityCourseResultManagementSystem.Models;
using University_Course_and_Result_Management_System.Manager;
using University_Course_and_Result_Management_System.Models;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class CourseAssignController : Controller
    {
        CourseAssignManager anCourseAssignManager = new CourseAssignManager();
        SaveTeacherManager aSaveTeacherManager = new SaveTeacherManager();
        // GET: CourseAssign
        public ActionResult CourseAssign()
        {
            ViewBag.Department = aSaveTeacherManager.TakeAllDeparment();
            return View();
        }
        
        [HttpPost]
        public JsonResult CourseAssign(CourseAssign courseAssign)
        {
            
           courseAssign.ReaminingCredit = courseAssign.ReaminingCredit - courseAssign.Credit;
            
            
           string log = anCourseAssignManager.SaveAssignCourse(courseAssign);
            anCourseAssignManager.UpdateReaminingCredit(courseAssign.ReaminingCredit, courseAssign.TeacherId);
            
            ViewBag.Department = aSaveTeacherManager.TakeAllDeparment();



            return Json(log);
        }

        public JsonResult GetTeachers(int departmentId)
        {
            List<SaveTeacher> aSaveTeachers = anCourseAssignManager.GetAllTeacher();
            aSaveTeachers = aSaveTeachers.FindAll(x => x.DepartmentId == departmentId).ToList();
            return Json(aSaveTeachers);
        }
        public JsonResult GetCourse(int departmentId)
        {
            List<Course> aCourses = anCourseAssignManager.GetAllCourse();
            aCourses = aCourses.FindAll(x => x.DepartmentId == departmentId).ToList();
            return Json(aCourses);
        }

        public JsonResult CraditToBeTaken(int teacherId)
        {
            List<SaveTeacher> aSaveTeachers = anCourseAssignManager.GetAllTeacher();
            aSaveTeachers = aSaveTeachers.FindAll(x => x.Id == teacherId).ToList();
            return Json(aSaveTeachers);
        }

        public JsonResult GetCourseInfo(int courseId)
        {
            List<Course> aCourses = anCourseAssignManager.GetAllCourse();
            aCourses = aCourses.FindAll(x => x.Id == courseId).ToList();
            return Json(aCourses);
        }
        public JsonResult IsCourseAssignedBesore(int courseId)
        {
            string lable = anCourseAssignManager.IsCourseAssignedBesore(courseId);
            
            return Json(lable);
        }

        
    }
}