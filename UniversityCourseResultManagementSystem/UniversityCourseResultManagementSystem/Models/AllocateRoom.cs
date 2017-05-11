using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityCourseResultManagementSystem.Models
{
    public class AllocateRoom
    {
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string RoomId { get; set; }
        public string DayId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Status { get; set; }
        public int Id { get; set; }
    }
}