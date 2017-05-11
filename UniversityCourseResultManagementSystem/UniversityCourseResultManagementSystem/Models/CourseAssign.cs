using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace University_Course_and_Result_Management_System.Models
{
    public class CourseAssign
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public double CraditToBeTaken { get; set; }
        public double ReaminingCredit { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double Credit { get; set; }

    }
}