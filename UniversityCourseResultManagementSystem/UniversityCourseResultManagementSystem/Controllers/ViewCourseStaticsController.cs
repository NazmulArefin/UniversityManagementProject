using System.Collections.Generic;
using System.Web.Mvc;
using University_Course_and_Result_Management_System.Manager;
using University_Course_and_Result_Management_System.Models;

namespace UniversityCourseResultManagementSystem.Controllers
{
    
    public class ViewCourseStaticsController : Controller
    {
        ViewCourseStaticsManager aCourseStaticsManager = new ViewCourseStaticsManager();
        
        // GET: ViewCourseStatics
        public ActionResult Index()
        {
            ViewBag.Department = aCourseStaticsManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public JsonResult Index(int departmentId)
        {

            
            List<ViewCourseStatics> viewCourseStaticsList = aCourseStaticsManager.GetViewCourseStaticsList(departmentId);
            viewCourseStaticsList = viewCourseStaticsList.FindAll(x => x.DepartmentId == departmentId);
            ViewBag.Department = aCourseStaticsManager.GetAllDepartment();
            return Json(viewCourseStaticsList);
        }
    }
}