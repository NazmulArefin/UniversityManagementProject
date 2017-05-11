using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Course_and_Result_Management_System.Models;

namespace University_Course_and_Result_Management_System.Gateway
{
    public class UnassignAllCoursesGateway : UniversityCourseResultManagementSystem.Gateway.Gateway
    {
        public int UnassignAllCoursesNow()
        {
            Query = "Update CourseAssign  SET Status = 'Unassign'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffecteed = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffecteed;
        }

        public void UpdateReaminCredit()
        {
            List<SaveTeacher> aSaveTeachers = GetAllTeacher();
            foreach (SaveTeacher saveTeacher in aSaveTeachers)
            {
                Query = "Update Teacher  SET RemainCredit = '"+saveTeacher.CraditToBeTaken+"' Where Id = '"+saveTeacher.Id+"'";

                Command = new SqlCommand(Query, Connection);

                Connection.Open();

                Command.ExecuteNonQuery();

                Connection.Close();
            }
                

            Connection.Close();

           
        }

        private List<SaveTeacher> GetAllTeacher()
        {
            Query = "SELECT * FROM Teacher";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<SaveTeacher> aSaveTeachers = new List<SaveTeacher>();

            while (Reader.Read())
            {
                SaveTeacher aSaveTeacher = new SaveTeacher();
                aSaveTeacher.Id = (int)Reader["Id"];
                aSaveTeacher.Name = Reader["TeacherName"].ToString();
                aSaveTeacher.Address = Reader["Address"].ToString();
                aSaveTeacher.ContactNo = (string)Reader["ContactNo"];
                aSaveTeacher.DepartmentId = (int)Reader["DepartmentId"];
                aSaveTeacher.Designation = Reader["Designation"].ToString();
                aSaveTeacher.CraditToBeTaken = (decimal)Reader["CreditToBeTaken"];
                aSaveTeacher.CraditToRemain = (decimal)Reader["RemainCredit"];
                aSaveTeacher.Email = (string)Reader["Email"];

                aSaveTeachers.Add(aSaveTeacher);
            }
            Connection.Close();
            return aSaveTeachers;
        }

        public int UnassignAllStudentCoursesNow()
        {
            Query = "Update StudentCourse SET Status = 'unassign' , Grade = 'Not Graded Yet'  ";

           Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowAffected;
        }
    }
}