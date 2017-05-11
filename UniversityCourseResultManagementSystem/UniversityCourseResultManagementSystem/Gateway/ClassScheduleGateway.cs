using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class ClassScheduleGateway:Gateway
    {
        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Department> departments = new List<Department>();

            while (Reader.Read())
            {
                Department aType = new Department();
                aType.Id = (int)Reader["Id"];
                // aType.DepartmentCode = Reader["DepartmentCode"].ToString();
                aType.DepartmentName = Reader["DepartmentName"].ToString();

                departments.Add(aType);
            }
            Reader.Close();
            Connection.Close();

            return departments;
        }

        public List<ClassScheduleVM> GetClassScheduleByDepartmentId(int departmentId)
        {
            Query =
                "SELECT DISTINCT DepartmentId,CourseName,CourseCode, ( SELECT 'R. No:'+RoomNo + ',' ,DayName+',',+FromTime+'-',''+ToTime+CHAR(13)+';' FROM  ClassScheduleAndRoomAllocation WHERE DepartmentId = @DepartmentId ORDER BY CourseCode FOR XML PATH('') ) AS ScheduleInfo FROM ClassScheduleAndRoomAllocation  WHERE DepartmentId = @DepartmentId";


            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = departmentId;

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<ClassScheduleVM> classSchedules=new List<ClassScheduleVM>();

            //ArrayList arrayListnew = new ArrayList();
            //var temp;
            while (Reader.Read())
            {
                ClassScheduleVM aClassScheduleVm = new ClassScheduleVM();
                // aType.DepartmentCode = Reader["DepartmentCode"].ToString();
               // aClassScheduleVm.DayName = Reader["DayName"].ToString();
              //  aClassScheduleVm.RoomNo = Reader["RoomNo"].ToString();
                aClassScheduleVm.CourseName = Reader["CourseName"].ToString();
                aClassScheduleVm.CourseCode = Reader["CourseCode"].ToString();
                aClassScheduleVm.ScheduleInfo = Reader["ScheduleInfo"].ToString();



               // aClassScheduleVm.FromTime = Reader["FromTime"].ToString();
               // aClassScheduleVm.ToTime = Reader["ToTime"].ToString();
              //  aClassScheduleVm.Concat = aClassScheduleVm.RoomNo + aClassScheduleVm.DayName;

                classSchedules.Add(aClassScheduleVm);

            }
            Reader.Close();
            Connection.Close();

            return classSchedules;
        }
    }

}