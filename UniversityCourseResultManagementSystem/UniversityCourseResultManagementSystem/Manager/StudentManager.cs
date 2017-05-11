using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using UniversityCourseResultManagementSystem.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public string RegisterStudent(Student student)
        {
            string messasge = "";
            int rowAffected = 0; 

            if (studentGateway.IsStudentExist(student) == false)
            {
                student.DepartmentCode = departmentGateway.GetDepartmentCode(student);
                student.RegistrationNo = GenerateRegistrationNo(student);
                rowAffected = studentGateway.RegisterStudent(student);
                if (rowAffected > 0)
                    messasge = "Student Registered";
                else
                {
                    messasge = "Not Registered";
                }
            }
            else
            {
                messasge = "Student already exist";
            }
            return messasge;
        }

        private string GenerateRegistrationNo(Student student)
        {
            string dept = student.DepartmentCode;
            string date = student.Date;
            string yy = date.Substring(6, 4);
            string generateRegistrationNo = dept +"-"+ yy;
            string regCount = studentGateway.RegFinder(generateRegistrationNo);
            if ( regCount != "")
            {
                int count = Convert.ToInt32(regCount);
                count++;
                string countString = count.ToString();
                if (countString.Length == 1)
                {
                    generateRegistrationNo = generateRegistrationNo +"-00"+ countString;
                }
                else if (countString.Length == 2)
                {
                    generateRegistrationNo = generateRegistrationNo + "-0" + countString;
                }
                else
                {
                    generateRegistrationNo = generateRegistrationNo + "-" + countString;
                }
            }
            else
            {
                generateRegistrationNo = generateRegistrationNo + "-" + "001"; 
            }
            return generateRegistrationNo; 
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentsList = studentGateway.GetAllStudents();
            return studentsList; 
        }
        public Student GetStudent(int studentId)
        {
            Student student = studentGateway.GetStudent(studentId);
            return student;
        }

        public string EnrollCourse(Student student)
        {
            string message = "";
            int rowAffected = 0; 
            if (!studentGateway.IsCourseEnrolled(student))
            {
                string status = studentGateway.IsCourseAssigned(student); 
                if (status == "unassign")
                {
                    rowAffected = studentGateway.UpdateEnrollCourse(student);
                    if (rowAffected > 0)
                        message = "Congratulations! Course enrolled";
                    else
                    {
                        message = "Sorry! Course is not enrolled";
                    }
                    return message; 
                }
                student.Grade = "Not Graded Yet";
                rowAffected = studentGateway.EnrollCourse(student);
                if (rowAffected > 0)
                    message = "Congratulations! Course enrolled";
                else
                {
                    message = "Sorry! Course is not enrolled";
                }
            }
            else
            {
                message = "Course already enrolled";
            }
            return message; 
        }

        public string saveResult(Student student)
        {
            string message = "";
            if (!studentGateway.IsGradeAssigned(student))
            {
                int rowAffected = studentGateway.AssignGrade(student);
                if (rowAffected > 0)
                    message = "Grade updated!";
                else
                {
                    message = "Grade not updated!";
                }
            }
            else
            {
                message = "Grade already updated!";
            }
            return message; 
        }

        public int GetStudentId(string registrationNo)
        {
            int id = studentGateway.GetStudentId(registrationNo);
            return id; 
        }
    }
}