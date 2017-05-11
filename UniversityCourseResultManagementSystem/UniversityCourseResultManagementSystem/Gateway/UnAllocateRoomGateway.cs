using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.Gateway
{
    public class UnAllocateRoomGateway:Gateway
    {
        public int IsRoomAllocate(UnAllocateRoom unAllocateRoom)
        {
            Query = "UPDATE  ClassRoom SET Status=@Status WHERE Status='Allocate'";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.VarChar);
            Command.Parameters["Status"].Value = "UnAllocate";
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }
    }
}