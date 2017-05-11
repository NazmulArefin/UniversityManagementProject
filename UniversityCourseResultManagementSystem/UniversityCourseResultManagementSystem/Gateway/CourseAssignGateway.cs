using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityCourseResultManagementSystem.Models;
using University_Course_and_Result_Management_System.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class CourseAssignGateway : UniversityCourseResultManagementSystem.Gateway.Gateway
    {
        public dynamic GetAllTeacher()
        {
            Query = "SELECT * FROM Teacher";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<SaveTeacher> aSaveTeachers = new List<SaveTeacher>();

            while (Reader.Read())
            {
                SaveTeacher aSaveTeacher = new SaveTeacher();
                aSaveTeacher.Id = (int) Reader["Id"];
                aSaveTeacher.Name = Reader["TeacherName"].ToString();
                aSaveTeacher.Address = Reader["Address"].ToString();
                aSaveTeacher.ContactNo = (string) Reader["ContactNo"];
                aSaveTeacher.DepartmentId = (int) Reader["DepartmentId"];
                aSaveTeacher.Designation = Reader["Designation"].ToString();
                aSaveTeacher.CraditToBeTaken = (decimal)Reader["CreditToBeTaken"];
                aSaveTeacher.CraditToRemain = (decimal)Reader["RemainCredit"];
                aSaveTeacher.Email = (string) Reader["Email"];
                
                aSaveTeachers.Add(aSaveTeacher);
            }
            Connection.Close();
            return aSaveTeachers;
        }

        public dynamic GetAllCourse()
        {
            Query = "SELECT * FROM Course";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Course> aCourses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = (int)Reader["Id"];
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.Description = (string)Reader["Description"];
                aCourse.DepartmentId = (int)Reader["DepartmentId"];
                aCourse.Semister = Reader["Semester"].ToString();
                aCourse.Credit =  (decimal)Reader["Credit"];
              

                aCourses.Add(aCourse);
            }
            Connection.Close();
            return aCourses;
        }

        public int SaveAssignCourse(CourseAssign courseAssign)
        {
            Query = "INSERT INTO CourseAssign VALUES(@departmentId, @teacherId, @CourseId, 'Assign')";


            Command = new SqlCommand(Query, Connection);


            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = courseAssign.DepartmentId;

            Command.Parameters.Add("teacherId", SqlDbType.Int);
            Command.Parameters["teacherId"].Value = courseAssign.TeacherId;

            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = courseAssign.CourseId;

           

            Connection.Open();

            int rowAffeted = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffeted;
        }

        public void UpdateReaminingCredit(double reaminingCredit, int teacherId)
        {
            Query = "UPDATE  Teacher SET RemainCredit=@reaminingCredit WHERE Id = @teacherId";


            Command = new SqlCommand(Query, Connection);


            Command.Parameters.Add("reaminingCredit", SqlDbType.Float);
            Command.Parameters["reaminingCredit"].Value = reaminingCredit;

            Command.Parameters.Add("teacherId", SqlDbType.Int);
            Command.Parameters["teacherId"].Value = teacherId;
            

            Connection.Open();

            Command.ExecuteNonQuery();

            Connection.Close();
        }

        public bool IsCourseAssignedBesore(int courseId)
        {
            Query = "SELECT * FROM CourseAssign WHERE CourseId = @courseId AND Status ='Assign'";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = courseId;

            Connection.Open();

            Reader = Command.ExecuteReader();
            bool rowAffected= Reader.HasRows;
            Connection.Close();
            return rowAffected;
        }

        public void UpdateCreditToBeTaken(double assignCredit, double teacherId)
        {
            Query = "UPDATE  Teacher SET Credit=Credit+@assignCredit WHERE Id = @teacherId";


            Command = new SqlCommand(Query, Connection);


            Command.Parameters.Add("assignCredit", SqlDbType.Float);
            Command.Parameters["assignCredit"].Value = assignCredit;

            Command.Parameters.Add("teacherId", SqlDbType.Int);
            Command.Parameters["teacherId"].Value = teacherId;


            Connection.Open();

            Command.ExecuteNonQuery();

            Connection.Close();
        }
    }
}