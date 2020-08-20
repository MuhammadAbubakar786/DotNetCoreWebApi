using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetCoreWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebApi.Models;
using System.Linq;

namespace DotNetCoreWebApi.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {
        private static StudentDataProvider studentDataProvider = new StudentDataProvider();
        [TestMethod()]
        public void Get_ShouldReturnAllStudents()
        {
            var controller = new StudentsController(studentDataProvider);
            var students = StudentDataProvider.Students;
            var response = controller.Get() as OkObjectResult;
            var responseData = response.Value as IEnumerable<Student>;
            Assert.IsNotNull(response.Value);
            Assert.AreNotEqual(responseData.Count(), 0);
            Assert.AreEqual(responseData.Count(), students.Count());
        }
        [TestMethod()]
        public void Get_ShouldReturnStudentByIdOkResult()
        {
            int testStudentId = 1;
            var student = studentDataProvider.GetStudentById(testStudentId);
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Get(testStudentId) as OkObjectResult;
            var responseData = response.Value as Student;
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(responseData.Name, student.Name);
        }
        [TestMethod()]
        public void Delete_ShouldDeleteStudentByIdOkResult()
        {
            int testStudentDeletedId = 3;
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Delete(testStudentDeletedId) as OkResult;
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void Find_ShouldReturnStudentByNameOkResult()
        {
            string testStudentName = "AhmedHammad";
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Find(testStudentName) as OkObjectResult;
            var responseData = response.Value as Student;
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(responseData.Name, testStudentName);
        }
        [TestMethod()]
        public void Post_ShouldAddNewStudentOkResult()
        {
            Student student = new Student
            {

                StudentId = 3,
                Name = "Umar",
                Address = "Sialkot",
                Age = 21,
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
                        CourseName = "PakStudy",
                        CreditHours = 2
                    }
                }
            };
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Post(student) as CreatedResult;
            var responseData = response.Value as Student;
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(responseData.Name, student.Name);
        }
        [TestMethod()]
        public void Put_ShouldEditStudentOkResult()
        {
            Student student = new Student
            {

                StudentId = 2,
                Name = "Umar",
                Address = "Sialkot",
                Age = 21,
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
                        CourseName = "PakStudy",
                        CreditHours = 2
                    }
                }
            };
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Put(student) as CreatedResult;
            var responseData = response.Value as Student;
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(responseData.Age, student.Age);
        }
        [TestMethod()]
        public void Get_ShouldReturnCustomerByIdNotFoundResult()
        {
            int testStudentId = 4;
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Get(testStudentId) as NotFoundResult;
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void Find_ShouldReturnCustomerByNameNotFoundResult()
        {
            var testStudentName = "Ali";
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Find(testStudentName) as NotFoundResult;
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void Put_ShouldEditStudentNotFoundResult()
        {
            Student student = new Student
            {

                StudentId = 5,
                Name = "Umar",
                Address = "Sialkot",
                Age = 21,
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
                        CourseName = "PakStudy",
                        CreditHours = 2
                    }
                }
            };
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Put(student) as NotFoundResult;
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void Delete_ShouldDeleteStudentNotFoundResult()
        {
            int deletedStudentId = 10;
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Delete(deletedStudentId) as NotFoundResult;
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void Post_AddNewStudentBadRequest()
        {
            Student student = new Student
            {

                StudentId = 2,
                Name = "Umar",
                Address = "Sialkot",
                Age = 21,
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
                        CourseName = "PakStudy",
                        CreditHours = 2
                    }
                }
            };
            var controller = new StudentsController(studentDataProvider);
            var response = controller.Post(student) as BadRequestResult;
            Assert.IsNotNull(response);
        }
    }
}