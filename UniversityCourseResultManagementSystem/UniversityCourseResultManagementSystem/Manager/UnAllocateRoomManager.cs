using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Gateway;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Manager
{
    public class UnAllocateRoomManager
    {
        UnAllocateRoomGateway aUnAllocateRoomGateway=new UnAllocateRoomGateway();
        public string UnAllocate(UnAllocateRoom unAllocateRoom)
        {
            int rowAffected = 0;
            rowAffected = aUnAllocateRoomGateway.IsRoomAllocate(unAllocateRoom);

            if (rowAffected > 0)
            {
                return "UnAllocate Successfully";
            }
            return "Already All Are UnAllocated";
        }
    }
}