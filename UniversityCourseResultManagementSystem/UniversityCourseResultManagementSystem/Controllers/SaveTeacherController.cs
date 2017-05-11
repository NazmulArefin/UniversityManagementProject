using System.Web.Mvc;
using UniversityCourseResultManagementSystem.Manager;
using University_Course_and_Result_Management_System.Manager;
using University_Course_and_Result_Management_System.Models;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class SaveTeacherController : Controller
    {
        SaveTeacherManager aSaveTeacherManager = new SaveTeacherManager();
        // GET: SaveTeacher
        public ActionResult Saveteacher()
        {
            ViewBag.Department = aSaveTeacherManager.TakeAllDeparment();
            

            return View();
        }
        
        [HttpPost]
        public ActionResult Saveteacher(SaveTeacher  saveTeacher)
        {

            ViewBag.saveReport = aSaveTeacherManager.SaveTeacher(saveTeacher);
            ViewBag.Department = aSaveTeacherManager.TakeAllDeparment();

            return View();
        }
    }
}