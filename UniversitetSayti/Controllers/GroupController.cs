using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitetSayti.Models;

namespace UniversitetSayti.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        Universitet_SaytiContext _group;
        public GroupController(Universitet_SaytiContext group)
        {
            _group = group;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var group = _group.Groups.ToList();
            return Ok(group);
        }

        [HttpGet("Getid{id}")]
        public IActionResult GetId(int id)
        {
            var group = _group.Groups.Where(group => group.Groupid == id);
            return Ok(group);
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Group group)
        {
            _group.Add(group);
            _group.SaveChanges();
            return Ok($"{group.Groupid}-idli guruh qo'shildi");
        }

        [HttpPut("Put{id}")]
        public IActionResult Put(int id, [FromBody] Group group)
        {
            if (id == group.Groupid)
            {
                _group.Update(group);
                _group.SaveChanges();
                return Ok();
            }
            else
                return NotFound();

        }

        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            var delete = _group.Groups.Where(delete => delete.Groupid == id).FirstOrDefault();
            _group.Remove(delete);
            _group.SaveChanges();
            return Ok($"{delete.Groupid}-idli guruh o'chirildi");
        }

    }
}
