using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityCourseResultManagementSystem.Models;
using University_Course_and_Result_Management_System.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class ViewCourseStaticsGateway : UniversityCourseResultManagementSystem.Gateway.Gateway
    {
        public dynamic GetAllDepartment()
        {
            Query = "SELECT * FROM Department";

            Command = new SqlCommand(Query, Connection);



            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Department> aDepartmentList = new List<Department>();

            while (Reader.Read())
            {
                Department aDepartment = new Department();

                aDepartment.Id = (int)Reader["Id"];
                aDepartment.DepartmentCode = Reader["DepartmentCode"].ToString();
                aDepartment.DepartmentName = Reader["DepartmentName"].ToString();

                aDepartmentList.Add(aDepartment);
            }
            Connection.Close();
            return aDepartmentList;
        }

        public dynamic GetViewCourseStaticsList(int viewCourseStatics)
        {
            Query = "SELECT CourseCode, CourseName, C.DepartmentId, Semester, case WHEN CA.Status = 'Assign'  " +
                    "THEN TeacherName ELSE 'Not Assigned Yet' END AS AssignedTo FROM Course C " +
                    "LEFT OUTER JOIN CourseAssign CA ON C.Id = CA.CourseId LEFT OUTER JOIN Teacher T ON CA.TeacherId = T.Id  ";

            Command = new SqlCommand(Query, Connection);



            Connection.Open();

            Reader = Command.ExecuteReader();
            List<ViewCourseStatics> aCourseStaticses = new List<ViewCourseStatics>();

            while (Reader.Read())
            { 
                ViewCourseStatics aCourseStatics  = new ViewCourseStatics();
                aCourseStatics.Code = Reader["CourseCode"].ToString();
                aCourseStatics.Name = Reader["CourseName"].ToString();
                aCourseStatics.Semester = Reader["Semester"].ToString();
                aCourseStatics.AssignedTo = Reader["AssignedTo"].ToString();
                aCourseStatics.DepartmentId = (int) Reader["DepartmentId"];
                aCourseStaticses.Add(aCourseStatics);

            }
            Connection.Close();
            return aCourseStaticses;
        }
    }
}