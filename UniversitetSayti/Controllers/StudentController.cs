using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitetSayti.Models;

namespace UniversitetSayti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        Universitet_SaytiContext _student;
        public StudentController(Universitet_SaytiContext student)
        {
            _student = student;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Student> GetAll()
        {
            return _student.Students.ToList();
        }

        [HttpGet("Get{id}")]
        public IActionResult Getid(int id)
        {
            var student = _student.Students.Where(student => student.Studentid == id);
            return Ok(student);
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Student student)
        {
            _student.Add(student);
            _student.SaveChanges();
            return Created("", student);
        }

        [HttpPut("Put{id}")]
        public IActionResult Put(int id,[FromBody] Student student )
        {
            if(id==student.Studentid)
            {
                _student.Update(student);
                _student.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            var student = _student.Students.Where(student => student.Studentid == id).FirstOrDefault();
            _student.Remove(student);
            _student.SaveChanges();
            return Ok(id);
        }
    }
}
