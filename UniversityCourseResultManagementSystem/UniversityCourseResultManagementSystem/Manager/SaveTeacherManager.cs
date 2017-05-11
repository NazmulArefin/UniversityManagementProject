using System.Collections.Generic;
using UniversityCourseResultManagementSystem.Gateway;
using UniversityCourseResultManagementSystem.Models;
using University_Course_and_Result_Management_System.Models;

namespace UniversityCourseResultManagementSystem.Manager
{
    public class SaveTeacherManager
    {
        TeacherSaveGateway aTeacherSaveGateway = new TeacherSaveGateway();

        public string SaveTeacher(SaveTeacher saveTeacher)
        {
            //if (saveTeacher.ContactNo.Length != 11)
            //{
            //    return "Contact No must be 11 digit";
            //}

            if (aTeacherSaveGateway.EmailExists(saveTeacher.Email))
            {
                return "Email already exists..";
            }
            int rowAffected = aTeacherSaveGateway.SaveTeacher(saveTeacher);

            if (rowAffected > 0)
            {
                return "Saved Successfuly";
            }
            else
            {
                return "Save failed";
            }
        }

        public List<Department> TakeAllDeparment()
        {
            return aTeacherSaveGateway.TakeAllDeparment();
        }

        public dynamic GetTeachers(int id)
        {
            return aTeacherSaveGateway.GetTeacher(id);
        }
    }
}