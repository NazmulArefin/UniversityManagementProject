using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseResultManagementSystem.Manager;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class UnAllocationController : Controller
    {
        UnAllocateRoomManager auAllocateRoomManager=new UnAllocateRoomManager();
        //
        // GET: /UnAllocation/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult UnAllocateRoom()
        {
           return View();
        }
        [HttpPost]
        public ActionResult UnAllocateRoom(UnAllocateRoom unAllocateRoom)
        {
            ViewBag.Message = auAllocateRoomManager.UnAllocate(unAllocateRoom);
            return View();
        }
	}
}