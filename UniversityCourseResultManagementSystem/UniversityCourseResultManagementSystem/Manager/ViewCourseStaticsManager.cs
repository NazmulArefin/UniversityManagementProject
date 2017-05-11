using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Gateway;
using University_Course_and_Result_Management_System.Gateway;
using University_Course_and_Result_Management_System.Models;

namespace University_Course_and_Result_Management_System.Manager
{
    public class ViewCourseStaticsManager
    {
        ViewCourseStaticsGateway aCourseStaticsGateway = new ViewCourseStaticsGateway();
        public dynamic GetAllDepartment()
        {
            return aCourseStaticsGateway.GetAllDepartment();
        }

        public dynamic GetViewCourseStaticsList(int departmentId)
        {
            return aCourseStaticsGateway.GetViewCourseStaticsList(departmentId);
        }
    }
}