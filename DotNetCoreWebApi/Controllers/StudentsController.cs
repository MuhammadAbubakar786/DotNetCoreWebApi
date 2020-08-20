using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApi.Data;
using DotNetCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
   
    public class StudentsController : ControllerBase
    {
        private StudentDataProvider _studentDataProvider { get; }
        public StudentsController(StudentDataProvider studentDataProvider)
        {
            _studentDataProvider = studentDataProvider;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentDataProvider.GetStudents());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            var student = _studentDataProvider.GetStudentById(Id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }
        [HttpGet]
        [Route("[action]/{Name}")]
        public IActionResult Find(string Name)
        {
            var student = _studentDataProvider.GetStudentByName(Name);
            if (student == null)
                return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Post(Student student)
        {
            var existingStudent = _studentDataProvider.GetStudentById(student.StudentId);
            if (existingStudent != null)
                return BadRequest();
            
            return Created($"Students/{student.StudentId}",_studentDataProvider.AddStudent(student));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var existingStudent = _studentDataProvider.GetStudentById(Id);
            if (existingStudent == null)
                return NotFound();
            _studentDataProvider.DeleteStudent(Id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Student student)
        {
            var existingStudent = _studentDataProvider.GetStudentById(student.StudentId);
            if (existingStudent == null)
                return NotFound();
            return Created($"Student/{student.StudentId}", _studentDataProvider.EditStudent(student));
          
        }
    }
}
