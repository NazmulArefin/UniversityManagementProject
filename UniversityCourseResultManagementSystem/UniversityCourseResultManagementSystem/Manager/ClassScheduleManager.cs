using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Gateway;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Manager
{
    public class ClassScheduleManager
    {
        AllocateRoomGateway allocateRoomGateway = new AllocateRoomGateway();
        ClassScheduleGateway aClassScheduleGateway=new ClassScheduleGateway();
        public List<Department> GetAllDepartments()
        {
            return allocateRoomGateway.GetAllDepartments();
        }

        public List<ClassScheduleVM> GetClassScheduleByDepartmentId(int departmentId)
        {
            return aClassScheduleGateway.GetClassScheduleByDepartmentId(departmentId);
        }
    }
}