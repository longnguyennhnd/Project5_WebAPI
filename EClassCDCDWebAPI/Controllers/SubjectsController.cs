using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EClassCDCDWebAPI.Models;

namespace EClassCDCDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public SubjectsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subjects>>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subjects>> GetSubjects(string id)
        {
            var subjects = await _context.Subjects.FindAsync(id);

            if (subjects == null)
            {
                return NotFound();
            }
            return subjects;
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjects(string id, Subjects subjects)
        {
            if (id != subjects.SubjectId)
            {
                return BadRequest();
            }

            _context.Entry(subjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<ActionResult<Subjects>> PostSubjects(Subjects subjects)
        {
            _context.Subjects.Add(subjects);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubjectsExists(subjects.SubjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubjects", new { id = subjects.SubjectId }, subjects);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subjects>> DeleteSubjects(string id)
        {
            var subjects = await _context.Subjects.FindAsync(id);
            if (subjects == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subjects);
            await _context.SaveChangesAsync();

            return subjects;
        }

        private bool SubjectsExists(string id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }
    }
}
