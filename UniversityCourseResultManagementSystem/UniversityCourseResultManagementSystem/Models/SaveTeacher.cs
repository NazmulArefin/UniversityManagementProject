using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Course_and_Result_Management_System.Models
{
    public class SaveTeacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public decimal CraditToBeTaken { get; set; }
        public decimal CraditToRemain { get; set; }
    }
}