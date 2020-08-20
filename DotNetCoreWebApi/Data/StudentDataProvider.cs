using DotNetCoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.Data
{
    public class StudentDataProvider
    {
       public static List<Student> students = new List<Student>()
        {
            new Student
            {
                StudentId = 13541,
                Name = "AliHassan",
                Address = "Sambriyal Sialkot",
                Age = 22,
                Courses = new List<Course>
                {
                    new Course
                    {
                        CourseId = 1001,
                         CourseName = "Physics",
                         CreditHours = 3
                    },
                    new Course
                    {
                         CourseId = 1002,
                         CourseName = "Chemistry",
                         CreditHours = 3
                    }

                }
            },
              new Student
              {
                StudentId = 13545,
                Name = "AhmedHammad",
                Address = "Gondal Sialkot",
                Age = 22,
                Courses = new List<Course>
                {
                    new Course
                    {
                        CourseId = 10012,
                         CourseName = "Object Oriented Programming",
                         CreditHours = 3
                    },
                    new Course
                    {
                         CourseId = 10010,
                         CourseName = "Android",
                         CreditHours = 3
                    },
                    new Course
                    {
                        CourseId = 10011,
                        CourseName = "Pak Study",
                        CreditHours = 2
                    }
                }
              }
        };

        public void DeleteStudent(int Id)
        {
            var existingStudent = GetStudentById(Id);
            students.Remove(existingStudent);
        }

        public IEnumerable<Student> GetStudents()
        {
            return students;
        }
        public Student GetStudentById(int Id)
        {
            var student = students.Find(d => d.StudentId == Id);
            return student;
        }
        public Student GetStudentByName(string Name)
        {
            var student = students.Find(d => d.Name == Name);
            return student;
        }
        public Student AddStudent(Student student)
        {
            students.Add(student);
            return student;
        }
        public Student EditStudent(Student student)
        {
            var existingStudent = GetStudentById(student.StudentId);
            existingStudent.Age = student.Age;
            existingStudent.Name = student.Name;
            return existingStudent;
        }
    }
}
