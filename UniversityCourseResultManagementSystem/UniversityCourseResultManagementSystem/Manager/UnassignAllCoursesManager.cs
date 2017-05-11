using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Course_and_Result_Management_System.Gateway;

namespace University_Course_and_Result_Management_System.Manager
{
    public class UnassignAllCoursesManager
    {
         UnassignAllCoursesGateway anUnassignAllCoursesGateway = new UnassignAllCoursesGateway();
        public string UnassignAllCoursesNow()
        {
            int rowAffected = anUnassignAllCoursesGateway.UnassignAllCoursesNow();
            if (rowAffected > 0)
            {
                return "All Teacher Course unassign";
            }
            return "Teachers Unassign already";

        }

        public void UpdateReaminCredit()
        {
            anUnassignAllCoursesGateway.UpdateReaminCredit();
        }

        public string UnassignAllStudentCoursesNow()
        {
           int rowAffected = anUnassignAllCoursesGateway.UnassignAllStudentCoursesNow();
           if (rowAffected > 0)
           {
               return "All Student Course unassign";
           }
           return "Student Unassign already";
        }
    }
}