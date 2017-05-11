using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class AllocateRoomGateway : Gateway
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

        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM Course ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = (int)Reader["Id"];
                // aType.DepartmentCode = Reader["DepartmentCode"].ToString();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.DepartmentId = (int)Reader["DepartmentId"];

                courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();

            return courses;
        }

        public List<Room> GetAllRooms()
        {
            Query = "SELECT * FROM Room ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Room> rooms = new List<Room>();

            while (Reader.Read())
            {
                Room aRoom = new Room();
                aRoom.Id = (int)Reader["Id"];
                // aType.DepartmentCode = Reader["DepartmentCode"].ToString();
                aRoom.RoomNo = Reader["RoomNo"].ToString();

                rooms.Add(aRoom);
            }
            Reader.Close();
            Connection.Close();

            return rooms;
        }

        public List<Day> GetAllDays()
        {
            Query = "SELECT * FROM Day ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Day> days = new List<Day>();

            while (Reader.Read())
            {
                Day aDay = new Day();
                aDay.Id = (int)Reader["Id"];
                // aType.DepartmentCode = Reader["DepartmentCode"].ToString();
                aDay.DayName = Reader["DayName"].ToString();

                days.Add(aDay);
            }
            Reader.Close();
            Connection.Close();

            return days;
        }

        public int Allocate(AllocateRoom allocateRoom)
        {
            Query = "INSERT INTO ClassRoom VALUES (@RoomId,@DayId,@FromTime,@ToTime,@CourseId,@DepartmentId,@Status)";
            
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("RoomId", SqlDbType.Int);
            Command.Parameters["RoomId"].Value = allocateRoom.RoomId;

            Command.Parameters.Add("DayId", SqlDbType.Int);
            Command.Parameters["DayId"].Value = allocateRoom.DayId;

            Command.Parameters.Add("FromTime", SqlDbType.VarChar);
            Command.Parameters["FromTime"].Value = allocateRoom.FromTime;

            Command.Parameters.Add("ToTime", SqlDbType.VarChar);
            Command.Parameters["ToTime"].Value = allocateRoom.ToTime;

            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = allocateRoom.CourseId;

            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = allocateRoom.DepartmentId;

            Command.Parameters.Add("Status", SqlDbType.VarChar);
            Command.Parameters["Status"].Value = "Allocate";



            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsRoomFree(AllocateRoom allocateRoom)
        {
            Query =
                "SELECT * FROM  ClassRoom  WHERE RoomId=@RoomId AND DayId=@DayId";

         
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("RoomId", SqlDbType.Int);
            Command.Parameters["RoomId"].Value = allocateRoom.RoomId;

            Command.Parameters.Add("DayId", SqlDbType.Int);
            Command.Parameters["DayId"].Value = allocateRoom.DayId;

            Connection.Open();

            Reader = Command.ExecuteReader();
            bool hasRow = true;
            while (Reader.Read())
            {
                if (Convert.ToDateTime(Reader["ToTime"]) > Convert.ToDateTime(allocateRoom.FromTime)
                    && Convert.ToDateTime(allocateRoom.ToTime) > Convert.ToDateTime(Reader["FromTime"]) && Reader["Status"].ToString()=="Allocate")
                {
                    hasRow = false;
                }
                
              
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int IsRoomUnAllocate(AllocateRoom allocateRoom)
        {
            Query = "UPDATE  ClassRoom SET RoomId=@RoomId,DayId=@DayId,FromTime=@FromTime,ToTime=@ToTime,CourseId=@CourseId,DepartmentId=@DepartmentId,Status=@Status WHERE RoomId=@RoomId AND DayId=@DayId AND DepartmentId=@DepartmentId AND FromTime=@FromTime AND ToTime=@ToTime AND Status='UnAllocate'";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("RoomId", SqlDbType.Int);
            Command.Parameters["RoomId"].Value = allocateRoom.RoomId;

            Command.Parameters.Add("DayId", SqlDbType.Int);
            Command.Parameters["DayId"].Value = allocateRoom.DayId;

            Command.Parameters.Add("FromTime", SqlDbType.VarChar);
            Command.Parameters["FromTime"].Value = allocateRoom.FromTime;

            Command.Parameters.Add("ToTime", SqlDbType.VarChar);
            Command.Parameters["ToTime"].Value = allocateRoom.ToTime;

            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = allocateRoom.CourseId;

            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = allocateRoom.DepartmentId;

            Command.Parameters.Add("Status", SqlDbType.VarChar);
            Command.Parameters["Status"].Value = "Allocate";



            Connection.Open();
            int UpdateRowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return UpdateRowAffected;
           
        }
    }
}