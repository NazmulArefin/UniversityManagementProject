using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagement.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class DepartmentGateway: Gateway
    {
        public List<Department> GetDepartment()
        {
            List<Department> departmentsList = new List<Department>();
            Query = "SELECT * FROM department";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department newDepartment = new Department();

                newDepartment.DepartmentCode = Reader["DepartmentCode"].ToString();
                newDepartment.DepartmentName = Reader["DepartmentName"].ToString();
                newDepartment.Id = (int) Reader["Id"];
                departmentsList.Add(newDepartment);
            }
            Reader.Close();
            Connection.Close();

            return departmentsList;
        }

        public string GetDepartmentCode(Student student)
        {
            Query = "select DepartmentCode from department where id = '" + student.DepartmentId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string code = "";
            if (Reader.HasRows)
            {
                Reader.Read();
                code = Reader["DepartmentCode"].ToString();
            }
            Connection.Close();
            return code; 
        }

        public string GetDepartmentName(int departmentId)
        {
            Query = "select DepartmentName from department where id = '" + departmentId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string name = "";
            if (Reader.HasRows)
            {
                Reader.Read();
                name = Reader["DepartmentName"].ToString();
            }
            Connection.Close();
            return name; 
        }

        public int GetDepartmentId(string departmentName)
        {
            Query = "select department.Id from department where DepartmentName = '" + departmentName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            int id = 0; 
            if (Reader.HasRows)
            {
                Reader.Read();
                id = (int)Reader["Id"];
            }
            Connection.Close();
            return id; 
        }

        //************************************* SAHED'S CODE ******************************************************
        public int Save(Department aDepartment)
        {


            Query = "INSERT INTO Department VALUES (@DepartmentCode,@DepartmentName)";

            Connection.Open();

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("DepartmentCode", SqlDbType.VarChar);
            Command.Parameters["DepartmentCode"].Value = aDepartment.DepartmentCode;


            Command.Parameters.Add("DepartmentName", SqlDbType.VarChar);
            Command.Parameters["DepartmentName"].Value = aDepartment.DepartmentName;

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsDeptCodeExist(Department department)
        {
            Query = "SELECT * FROM Department WHERE DepartmentCode = @DepartmentCode";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("DepartmentCode", SqlDbType.VarChar);
            Command.Parameters["DepartmentCode"].Value = department.DepartmentCode;


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

        public bool IsDeptNameExist(Department Department)
        {
            Query = "SELECT * FROM Department WHERE DepartmentName = @DepartmentName";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("DepartmentName", SqlDbType.VarChar);
            Command.Parameters["DepartmentName"].Value = Department.DepartmentName;

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

        public bool IsDeptCodeNameExist(Department Department)
        {
            Query = "SELECT * FROM Department WHERE DepartmentCode=@DepartmentCode AND DepartmentName = @DepartmentName";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("DepartmentCode", SqlDbType.VarChar);
            Command.Parameters["DepartmentCode"].Value = Department.DepartmentCode;

            Command.Parameters.Add("DepartmentName", SqlDbType.VarChar);
            Command.Parameters["DepartmentName"].Value = Department.DepartmentName;


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

        public List<Department> GetAllDepartment()
        {


            Query = "SELECT * FROM Department ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Department> Departmentes = new List<Department>();

            while (Reader.Read())
            {
                Department Department = new Department();


                Department.Id = (int)Reader["Id"];
                Department.DepartmentCode = Reader["DepartmentCode"].ToString();
                Department.DepartmentName = Reader["DepartmentName"].ToString();


                Departmentes.Add(Department);
            }
            Reader.Close();
            Connection.Close();

            return Departmentes;
        }
    }
}