using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Course_and_Result_Management_System.Models
{
    public class ViewCourseStatics
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string AssignedTo { get; set; }
        public int DepartmentId { get; set; }
    }
}