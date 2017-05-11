using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Manager
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();

        //public string CourseSave(Course aCourse)
        //{
        //    int rowAffected = 0;

        //    if (courseGateway.IsCourseCodeNameExist(aCourse))
        //    {
        //        return "Course Code And Name Exist";
        //    }
        //    else
        //    {
        //        rowAffected = courseGateway.CourseSave(aCourse);

        //        if (rowAffected > 0)
        //        {
        //            return "Saved successfully";
        //        }
        //        else
        //        {
        //            return "Save failed";
        //        }
        //    }
        //}

        
        //public List<Semester> GetAllSemester()
        //{
        //    List<Semester> aSemesters = courseGateway.GetAllSemester();
        //    return aSemesters;
        //}

        public List<Course> GetAllCourses()
        {
            List<Course> courseList = courseGateway.GetAllCourse();
            return courseList; 
        }

        public List<Course> GetCourses(int studentId)
        {
            List<Course> aCourse = courseGateway.GetCourseByDept(studentId);
            return aCourse;
        }

        public List<Course> GetCoursesByStudentId(int studentId)
        {
            List<Course> aCourse = courseGateway.GetCourseByStudent(studentId);
            return aCourse;
        }

        public List<Course> GetCourseDetails(int studentId)
        {
            List<Course> coursesWithGrades = courseGateway.GetCourseWithGrades(studentId);
            return coursesWithGrades; 
        }

        //******************************* SAHED *************************************
        public string CourseSave(Course aCourse)
        {
            int rowAffected = 0;

            if (courseGateway.IsCourseCodeNameExist(aCourse))
            {
                return "Course Code And Name Exist";
            }
            else if (courseGateway.IsCourseCodeExist(aCourse))
            {
                return "Course Code Are Exist";
            }
            else if (courseGateway.IsCourseNameExist(aCourse))
            {
                return "Course Name Are Exist";
            }

            else
            {
                rowAffected = courseGateway.CourseSave(aCourse);

                if (rowAffected > 0)
                {
                    return "Saved successfully";
                }
                else
                {
                    return "DepartmetnSave failed";
                }
            }
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departments = courseGateway.GetAllDepartments();
            return departments;

        }
        public List<Semester> GetAllSemester()
        {
            List<Semester> aSemesters = courseGateway.GetAllSemester();
            return aSemesters;

        }
    }
}