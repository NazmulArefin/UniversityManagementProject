using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseResultManagementSystem.Models
{
    public class ClassScheduleVM
    {
        public int DepartmentId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string DayName { get; set; }
        public string RoomNo { get; set; }
        public string ScheduleInfo { get; set; }
    }
}