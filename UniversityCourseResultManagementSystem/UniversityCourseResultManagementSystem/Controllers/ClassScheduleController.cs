using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseResultManagementSystem.Manager;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class ClassScheduleController : Controller
    {

        AllocateRoomManager allocateRoomManager = new AllocateRoomManager();
        ClassScheduleManager aClassScheduleManager=new ClassScheduleManager();
        //    //
        //    // GET: /ClassSchedule/
        //    public ActionResult Index()
        //    {
        //        return View();
        //    }

        public ActionResult ClassScheduleInfo()
        {
            ViewBag.Departments = allocateRoomManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult ClassScheduleInfo(Department department)
        {
            ViewBag.Departments = allocateRoomManager.GetAllDepartments();
            return View();
        }
        public JsonResult GetClassScheduleByDepartmentId(int departmentId)
        {
            return Json(aClassScheduleManager.GetClassScheduleByDepartmentId(departmentId));
        }


    }
}