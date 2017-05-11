using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Gateway;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Manager
{
    public class AllocateRoomManager
    {
        AllocateRoomGateway allocateRoomGateway = new AllocateRoomGateway();
        public List<Department> GetAllDepartments()
        {
            return allocateRoomGateway.GetAllDepartments();
        }
        public List<Course> GetAllCourses()
        {
            return allocateRoomGateway.GetAllCourses();
        }

        public List<Room> GetAllRooms()
        {
            return allocateRoomGateway.GetAllRooms();
        }
        public List<Day> GetAllDays()
        {
            return allocateRoomGateway.GetAllDays();
        }

        public string Allocate(AllocateRoom allocateRoom)
        {
            int rowAffected = 0;
            if (allocateRoomGateway.IsRoomFree(allocateRoom) == false)
            {
                return "Room is not Free";
            }
            if (allocateRoomGateway.IsRoomUnAllocate(allocateRoom) > 0)
            {
                return "Update successfully";
            }

            rowAffected = allocateRoomGateway.Allocate(allocateRoom);

            if (rowAffected > 0)
            {
                return "Saved successfully";
            }
            return "Save failed";
        }
    }
}