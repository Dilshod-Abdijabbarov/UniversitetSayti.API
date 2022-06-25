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
    public class ScienceController : ControllerBase
    {

        Universitet_SaytiContext _science;
        public ScienceController(Universitet_SaytiContext science)
        {
            _science = science;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Science> GetAll()
        {
            return _science.Sciences.ToList();
        }

        [HttpGet("Get{id}")]
        public IActionResult Getid(int id)
        {
            var science = _science.Sciences.Where(science => science.Scienceid == id).FirstOrDefault();
            return Ok(science);
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Science science)
        {
            _science.Sciences.Add(science);
            _science.SaveChanges();
            return Ok(science);

        }

        [HttpPut("Put{id}")]
        public IActionResult Put(int id,[FromBody] Science science )
        {
           if(id==science.Scienceid)
            {
                _science.Sciences.Update(science);
                _science.SaveChanges();
                return Ok(science);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete ("Delete{id}")]
        public IActionResult Delete(int id)
        {
            var science = _science.Sciences.Where(science => science.Scienceid == id).FirstOrDefault();
            _science.Remove(science);
            _science.SaveChanges();
            return Ok(id);
        }
    }
}
