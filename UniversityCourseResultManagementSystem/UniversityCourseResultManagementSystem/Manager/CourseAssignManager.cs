using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Gateway;
using University_Course_and_Result_Management_System.Gateway;
using University_Course_and_Result_Management_System.Models;

namespace University_Course_and_Result_Management_System.Manager
{
    public class CourseAssignManager
    {
        CourseAssignGateway anCourseAssignGateway = new CourseAssignGateway();
        public dynamic GetAllTeacher()
        {
            return anCourseAssignGateway.GetAllTeacher();
        }

        public dynamic GetAllCourse()
        {
            return anCourseAssignGateway.GetAllCourse();
        }

        public dynamic SaveAssignCourse(CourseAssign courseAssign)
        {
            int rowAffect = anCourseAssignGateway.SaveAssignCourse(courseAssign);
            if (rowAffect > 0)
            {
                return "Saved";
            }
            else
            {
                return "Failed";
            }
        }

        public void UpdateReaminingCredit(double reaminingCredit, int teacherId)
        {
            anCourseAssignGateway.UpdateReaminingCredit(reaminingCredit, teacherId);
        }

        public string IsCourseAssignedBesore(int courseId)
        {
            bool rowAffect = anCourseAssignGateway.IsCourseAssignedBesore(courseId);
            if (rowAffect)
            {
                return "Already Assigned";
            }
            else
            {
                return "";
            }
        }

        public void UpdateCreditToBeTaken(double assignCredit, double teacherId)
        {
            anCourseAssignGateway.UpdateCreditToBeTaken(assignCredit, teacherId);
        }
    }
}