using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Manager;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class DepartmentSaveController : Controller
    {
        DepartmentManager aDepartmentsManager = new DepartmentManager();
        
        public ActionResult DepartmentSave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentSave(Department aDepartments)
        {
            ViewBag.Message = aDepartmentsManager.Save(aDepartments);
            
            return View();
        }
        public ActionResult AllDepartmentView()
        {
            //ViewBag.AllDept = aDepartmentsManager.GetAllDepartment();
            ViewBag.allDepartmentseList = aDepartmentsManager.GetAllDepartment();
            return View();
        }
	}
}