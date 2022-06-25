using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitetSayti.Models;

namespace UniversitetSayti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChairEmployeeController:ControllerBase
    {
        Universitet_SaytiContext _chair;
        public ChairEmployeeController(Universitet_SaytiContext chair)
        {
            _chair = chair;
        } 
        
       [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_chair.ChairEmployees.ToList());
        }

        [HttpGet("Get{id}")]
        public IActionResult Getid(int id)
        {
            var chair = _chair.ChairEmployees.Where(chr => chr.Chairemployeeid == id);
            return Ok(chair);
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] ChairEmployee chair)
        {
            _chair.Add(chair);
            _chair.SaveChanges();
            return Ok($"{chair.Chairemployeeid}-idli ishchi qo'shildi");
        }

        [HttpPut("Put{id}")]
        public IActionResult Put(int id,[FromBody] ChairEmployee chair)
        {
            if (id == chair.Chairemployeeid)
            {
                _chair.Update(chair);
                _chair.SaveChanges();
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
            var chair = _chair.ChairEmployees.Where(chair => chair.Chairemployeeid == id).FirstOrDefault();
            _chair.Remove(chair);
            _chair.SaveChanges();
            return Ok($"{id} idli odam o'chdi");
        }
    }

}
