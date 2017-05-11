using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagement.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class StudentGateway:Gateway
    {
        public int RegisterStudent(Student student)
        {
            Query =
                "INSERT INTO Student VALUES(@StudentName, @Email, @ContactNo, @Date, @Address, @DepartmentId, @RegistrationNo)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("StudentName", SqlDbType.VarChar);
            Command.Parameters["StudentName"].Value = student.StudentName;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = student.Email;
            Command.Parameters.Add("ContactNo", SqlDbType.VarChar);
            Command.Parameters["ContactNo"].Value = student.ContactNo;
            Command.Parameters.Add("Date", SqlDbType.VarChar);
            Command.Parameters["Date"].Value = student.Date;
            Command.Parameters.Add("Address", SqlDbType.VarChar);
            Command.Parameters["Address"].Value = student.Address;
            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = student.DepartmentId;
            Command.Parameters.Add("RegistrationNo", SqlDbType.VarChar);
            Command.Parameters["RegistrationNo"].Value = student.RegistrationNo; 

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected; 
        }

        public bool IsStudentExist(Student student)
        {
            Query = "Select * from Student where Student.Email = @Email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = student.Email;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = false;
            if (Reader.HasRows)
            {
                hasRows = true;
            }
            Connection.Close();
            return hasRows; 
        }

        public string RegFinder(string concat)
        {
            Query = "SELECT substring(Student.RegistrationNo,10,3) RegistrationNo FROM Student WHERE Student.RegistrationNo LIKE '" + concat + "%'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string registrationNo = "";
            while (Reader.Read())
            {
                registrationNo = Reader["RegistrationNo"].ToString();
            }
            Connection.Close();
            return registrationNo; 
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentsList = new List<Student>();
            Query = "SELECT * FROM Student";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = (int) Reader["Id"];
                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.ContactNo = Reader["ContactNo"].ToString();
                aStudent.Date = Reader["Date"].ToString();
                aStudent.Address = Reader["Address"].ToString();
                aStudent.DepartmentId = (int)Reader["DepartmentId"];
                aStudent.RegistrationNo = Reader["RegistrationNo"].ToString(); 
                studentsList.Add(aStudent);
            }
            Connection.Close();
            return studentsList; 
        }
        public Student GetStudent(int studentId)
        {
            Student aStudent = new Student();
            Query = "SELECT * FROM Student WHERE Id = '"+studentId+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if(Reader.HasRows)
            {
                Reader.Read();
                aStudent.Id = (int)Reader["Id"];
                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.ContactNo = Reader["ContactNo"].ToString();
                aStudent.Date = Reader["Date"].ToString();
                aStudent.Address = Reader["Address"].ToString();
                aStudent.DepartmentId = (int)Reader["DepartmentId"];
                aStudent.RegistrationNo = Reader["RegistrationNo"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return aStudent;
        }

        public bool IsCourseEnrolled(Student student)
        {
            Query = "SELECT * FROM StudentCourse WHERE  CourseId = '" + student.CourseId + "' and StudentId = '"+student.Id+"' and Status = 'assigned'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool courseEnrolled = false;
            if (Reader.HasRows)
            {
                courseEnrolled = true; 
            }
            Reader.Close();
            Connection.Close();
            return courseEnrolled;
        }

        public int EnrollCourse(Student student)
        {
            Query = "INSERT INTO StudentCourse Values(@StudentId, @DepartmentId, @CourseId, @Grade, @Date, 'assigned')";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("StudentId", SqlDbType.Int);
            Command.Parameters["StudentId"].Value = student.Id;
            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = student.DepartmentId;
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = student.CourseId;
            Command.Parameters.Add("Grade", SqlDbType.VarChar);
            Command.Parameters["Grade"].Value = student.Grade;
            Command.Parameters.Add("Date", SqlDbType.VarChar);
            Command.Parameters["Date"].Value = student.Date;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public int UpdateEnrollCourse(Student student)
        {
            Query = "Update StudentCourse set Status = 'assigned' where StudentId = @StudentId and CourseId = @CourseId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("StudentId", SqlDbType.Int);
            Command.Parameters["StudentId"].Value = student.Id;
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = student.CourseId;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsGradeAssigned(Student student)
        {
            Query = "Select * from StudentCourse where StudentCourse.StudentId = @StudentId and StudentCourse.CourseId = @CourseId and Grade = @Grade";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("StudentId", SqlDbType.Int);
            Command.Parameters["StudentId"].Value = student.Id;
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = student.CourseId;
            Command.Parameters.Add("Grade", SqlDbType.VarChar);
            Command.Parameters["Grade"].Value = student.Grade;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool gradeExist = false;
            if (Reader.HasRows)
            {
                gradeExist = true;
            }
            Reader.Close();
            Connection.Close();
            return gradeExist;
        }

        public int AssignGrade(Student student)
        {
            Query = "Update StudentCourse set Grade = @Grade where StudentCourse.StudentId = @StudentId and CourseId = @CourseId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("Grade", SqlDbType.VarChar);
            Command.Parameters["Grade"].Value = student.Grade;
            Command.Parameters.Add("StudentId", SqlDbType.VarChar);
            Command.Parameters["StudentId"].Value = student.Id;
            Command.Parameters.Add("CourseId", SqlDbType.VarChar);
            Command.Parameters["CourseId"].Value = student.CourseId;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int GetStudentId(string registrationNo)
        {
            Query = "Select Id from Student where RegistrationNo = '" + registrationNo + "'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            int id = 0; 
            if (Reader.HasRows)
            {
                Reader.Read();
                id = (int) Reader["Id"]; 
            }
            Connection.Close();
            return id;
        }

        public string IsCourseAssigned(Student student)
        {
            Query = "Select StudentCourse.Status from StudentCourse where StudentCourse.StudentId = @StudentId and StudentCourse.CourseId = @CourseId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("StudentId", SqlDbType.Int);
            Command.Parameters["StudentId"].Value = student.Id;
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = student.CourseId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool Exist = true;
            string status = "";
            if (Reader.HasRows)
            {
                Reader.Read();
                status = Reader["Status"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return status;
        }
    }
}