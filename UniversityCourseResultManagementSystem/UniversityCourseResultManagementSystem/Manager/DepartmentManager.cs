using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public List<Department> GetDepartments()
        {
            List<Department> deptList = departmentGateway.GetDepartment();
            return deptList;
        }

        public string GetDepartmentName(int departmentId)
        {
            string deptName = departmentGateway.GetDepartmentName(departmentId);
            return deptName; 
        }

        public int GetDepartmentId(string departmentName)
        {
            int deptId = departmentGateway.GetDepartmentId(departmentName);
            return deptId;
        }
        //********************************* sahed ***********************************
        public string Save(Department aDepartment)
        {
            int rowAffected = 0;

            if (departmentGateway.IsDeptCodeNameExist(aDepartment))
            {
                return "Department Code And Name Exist";
            }
            else if (departmentGateway.IsDeptCodeExist(aDepartment))
            {
                return "Department Code Are Exist";
            }
            else if (departmentGateway.IsDeptNameExist(aDepartment))
            {
                return "Department Name Are Exist";
            }

            else
            {
                rowAffected = departmentGateway.Save(aDepartment);

                if (rowAffected > 0)
                {
                    return "Saved successfully";
                }
                else
                {
                    return "DepartmetnSave failed";
                }
            }
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> department = departmentGateway.GetAllDepartment();
            return department;

        }
    }
}