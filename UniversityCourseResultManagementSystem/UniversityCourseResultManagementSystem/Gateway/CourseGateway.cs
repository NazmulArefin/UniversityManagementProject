using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagement.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class CourseGateway: Gateway
    {
        public List<Course> GetAllCourse()
        {
            List<Course> courses = new List<Course>();
            Query = "SELECT * FROM Course";
            Command = new SqlCommand(Query,Connection);
          
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseName = Reader["CourseName"].ToString();
                course.Credit =  Reader["Credit"].ToString();
                course.Description = Reader["Description"].ToString();
                course.DepartmentId = (int) Reader["DepartmentId"];
                course.Semester = Reader["Semester"].ToString();
                
                courses.Add(course);
            }
            Connection.Close();
            return courses; 
        }

        public List<Course> GetCourseByDept(int studentId)
        {
            List<Course> courses = new List<Course>();
            Query = "SELECT c.Id, c.CourseCode,c.CourseName FROM Course c join Student s on s.DepartmentId = c.DepartmentId where s.Id = '"+studentId+"' "; 
            //we take course by joining course & Student table by the department id couse Courses are needed to take by the id of dept id
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = (int) Reader["Id"];
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseName = Reader["CourseName"].ToString();
                //course.Description = Reader["Description"].ToString();
                //course.DepartmentId = (int)Reader["DepartmentId"];
                //course.Semester = Reader["Semester"].ToString();

                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses; 
        }

        public List<Course> GetCourseByStudent(int studentId)
        {
            List<Course> courses = new List<Course>();
            Query = "SELECT c.Id,c.CourseCode, c.CourseName FROM StudentCourse sc join Course c on sc.CourseId = c.Id where StudentId = '" + studentId + "' and sc.Status = 'assigned'";
            //we take course by joining course & Student table by the department id couse Courses are needed to take by the id of dept id
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = (int)Reader["Id"];
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseName = Reader["CourseName"].ToString();
                //course.Description = Reader["Description"].ToString();
                //course.DepartmentId = (int)Reader["DepartmentId"];
                //course.Semester = Reader["Semester"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses; 
        }

        public List<Course> GetCourseWithGrades(int studentId)
        {
            List<Course> courses = new List<Course>();
            Query = "Select c.Id Id, c.CourseCode, c.CourseName Name, sc.Grade  from StudentCourse sc join Course c on sc.CourseId = c.Id where sc.StudentId = '" + studentId + "' and sc.Status = 'assigned'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = (int)Reader["Id"];
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseName = Reader["Name"].ToString();
                course.Grade = Reader["Grade"].ToString(); 
                //course.Description = Reader["Description"].ToString();
                //course.DepartmentId = (int)Reader["DepartmentId"];
                //course.Semester = Reader["Semester"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses; 
        }


        //************************************************Sahed's Code***********************************************
        public int CourseSave(Course aCourses)
        {
            Query = "INSERT INTO Course VALUES (@CourseCode,@CourseName,@Credit,@Description,@DepartmentId,@Semester)";

            Connection.Open();

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("CourseCode", SqlDbType.VarChar);
            Command.Parameters["CourseCode"].Value = aCourses.CourseCode;

            Command.Parameters.Add("CourseName", SqlDbType.VarChar);
            Command.Parameters["CourseName"].Value = aCourses.CourseName;

            Command.Parameters.Add("Credit", SqlDbType.Decimal);
            Command.Parameters["Credit"].Value = aCourses.Credit;

            Command.Parameters.Add("Description", SqlDbType.VarChar);
            Command.Parameters["Description"].Value = aCourses.Description;

            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = aCourses.DepartmentId;

            Command.Parameters.Add("Semester", SqlDbType.VarChar);
            Command.Parameters["Semester"].Value = aCourses.Semester;

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsCourseCodeExist(Course courseCode)
        {
            Query = "SELECT * FROM Course WHERE CourseCode = @CourseCode";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("CourseCode", SqlDbType.VarChar);
            Command.Parameters["CourseCode"].Value = courseCode.CourseCode;


            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRow = false;

            if (Reader.HasRows)
            {
                hasRow = true;
            }

            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public bool IsCourseNameExist(Course courseName)
        {
            Query = "SELECT * FROM Course WHERE CourseName = @CourseName";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("CourseName", SqlDbType.VarChar);
            Command.Parameters["CourseName"].Value = courseName.CourseName;


            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRow = false;

            if (Reader.HasRows)
            {
                hasRow = true;
            }

            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public bool IsCourseCodeNameExist(Course courseCodeName)
        {
            Query = "SELECT * FROM Course WHERE CourseCode=@CourseCode AND CourseName = @CourseName";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("CourseCode", SqlDbType.VarChar);
            Command.Parameters["CourseCode"].Value = courseCodeName.CourseCode;

            Command.Parameters.Add("CourseName", SqlDbType.VarChar);
            Command.Parameters["CourseName"].Value = courseCodeName.CourseName;


            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRow = false;

            if (Reader.HasRows)
            {
                hasRow = true;
            }

            Reader.Close();
            Connection.Close();

            return hasRow;
        }
        public List<Department> GetAllDepartments()
        {


            Query = "SELECT * FROM Department ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Department> departmentses = new List<Department>();

            while (Reader.Read())
            {
                Department departments = new Department();


                departments.Id = (int)Reader["Id"];
                departments.DepartmentCode = Reader["DepartmentCode"].ToString();
                departments.DepartmentName = Reader["DepartmentName"].ToString();


                departmentses.Add(departments);
            }
            Reader.Close();
            Connection.Close();

            return departmentses;
        }

        public List<Semester> GetAllSemester()
        {


            Query = "SELECT * FROM Semester";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Semester> semesteres = new List<Semester>();

            while (Reader.Read())
            {
                Semester semester = new Semester();


                semester.Id = (int)Reader["Id"];
                semester.Semesters = Reader["Semesters"].ToString();


                semesteres.Add(semester);
            }
            Reader.Close();
            Connection.Close();

            return semesteres;
        }
    }
}