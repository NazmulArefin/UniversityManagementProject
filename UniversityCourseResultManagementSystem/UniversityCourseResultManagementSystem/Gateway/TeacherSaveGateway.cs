using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityCourseResultManagementSystem.Models;
using University_Course_and_Result_Management_System.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class TeacherSaveGateway :UniversityCourseResultManagementSystem.Gateway.Gateway
    {
        public int SaveTeacher(SaveTeacher saveTeacher)
        {
            Query = "INSERT INTO Teacher VALUES(@name, @email, @contactNo, @address, @designation, @departmentId, @CraditToBeTaken, @reaminToBeTaken)";
            

            Command = new SqlCommand(Query, Connection);


            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = saveTeacher.Name;

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = saveTeacher.Email;

            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = saveTeacher.ContactNo;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = saveTeacher.Address;

            Command.Parameters.Add("designation", SqlDbType.VarChar);
            Command.Parameters["designation"].Value = saveTeacher.Designation;

            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = saveTeacher.DepartmentId;

            Command.Parameters.Add("CraditToBeTaken", SqlDbType.Decimal);
            Command.Parameters["CraditToBeTaken"].Value = saveTeacher.CraditToBeTaken;
            Command.Parameters.Add("reaminToBeTaken", SqlDbType.Decimal);
            Command.Parameters["reaminToBeTaken"].Value = saveTeacher.CraditToBeTaken;

            Connection.Open();

            int rowAffeted = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffeted;


        }

        public List<Department> TakeAllDeparment()
        {
            Query = "SELECT * FROM Department";

            Command = new SqlCommand(Query, Connection);



            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Department> aDepartmentList = new List<Department>();

            while (Reader.Read())
            {
                Department aDepartment = new Department();

                aDepartment.Id = (int) Reader["Id"];
                aDepartment.DepartmentCode = Reader["DepartmentCode"].ToString();
                aDepartment.DepartmentName = Reader["DepartmentName"].ToString();

                aDepartmentList.Add(aDepartment);
            }
            Connection.Close();
            return aDepartmentList;
        }

        public bool EmailExists(string saveTeacherEmail)
        {
            Query = "SELECT * FROM Teacher WHERE Email = @email";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = saveTeacherEmail;

            Connection.Open();

            Reader = Command.ExecuteReader();
            bool flag = Reader.HasRows;
            
            Connection.Close();
            return flag;
        }

        public dynamic GetTeacher(int id)
        {
            Query = "SELECT * FROM Teacher WHERE DepartmentId = @id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("id", SqlDbType.VarChar);
            Command.Parameters["id"].Value = id;

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<SaveTeacher> aSaveTeachers = new List<SaveTeacher>();
            if (Reader.HasRows)
            {
                SaveTeacher aSaveTeacher = new SaveTeacher();
                aSaveTeacher.Id = 0;
                aSaveTeacher.Name = "Not Found";
                aSaveTeachers.Add(aSaveTeacher);
            }
            else
            {
                while (Reader.Read())
                {
                    SaveTeacher aSaveTeacher = new SaveTeacher();
                    aSaveTeacher.Id = (int)Reader["Id"];
                    aSaveTeacher.Name = (string)Reader["Name"];
                    aSaveTeachers.Add(aSaveTeacher);
                }
            }
            
            Connection.Close();
            return aSaveTeachers;
        }
    }
}