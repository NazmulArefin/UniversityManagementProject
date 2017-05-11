using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseResultManagementSystem.Manager;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class AllocateRoomController : Controller
    {
        AllocateRoomManager allocateRoomManager=new AllocateRoomManager();
        //
        // GET: /AllocateRoom/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Allocate()
        {
            ViewBag.Departments = allocateRoomManager.GetAllDepartments();
            //ViewBag.Courses = allocateRoomManager.GetAllCourses();
            ViewBag.Rooms = allocateRoomManager.GetAllRooms();
            ViewBag.Days = allocateRoomManager.GetAllDays();
            return View();
        }
        [HttpPost]
        public ActionResult Allocate(AllocateRoom allocateRoom)
        {
            ViewBag.Departments = allocateRoomManager.GetAllDepartments();
            //ViewBag.Courses = allocateRoomManager.GetAllCourses();
            ViewBag.Rooms = allocateRoomManager.GetAllRooms();
            ViewBag.Days = allocateRoomManager.GetAllDays();

            ViewBag.Message = allocateRoomManager.Allocate(allocateRoom);
            return View();
        }

        public JsonResult GetCoursesByDepartmentId(int DepartmentId)
        {
            var Courses = allocateRoomManager.GetAllCourses();
            var courseList = Courses.Where(a => a.DepartmentId == DepartmentId).ToList();
            return Json(courseList);
        }

	}
}