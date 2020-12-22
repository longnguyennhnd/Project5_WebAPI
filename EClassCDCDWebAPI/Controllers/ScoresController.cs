using EClassCDCDWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EClassCDCDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public ScoresController(CoreDbContext context)
        {
            _context = context;
        }
        // GET: api/<ScoresController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ScoresController>/5
        [HttpGet("GetScoreStudent/{studentId}/{subjectId}")]
        public ActionResult GetSccoreStudent(string studentId, string subjectId)
        {
            var score = _context.Scores.Where(s => s.StudentId == studentId && s.SubjectId == subjectId).FirstOrDefault();
            return Ok(score);
        }


        [HttpGet("GetScoresStudent/{studentId}")]
        public ActionResult GetSccoresStudent(string studentId)
        {
            var score = _context.Scores.Where(s => s.StudentId == studentId).ToList();
            return Ok(score);
        }
        // POST api/<ScoresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ScoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ScoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
