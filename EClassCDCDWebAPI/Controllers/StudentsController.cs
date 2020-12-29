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
    public class StudentsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public StudentsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudents(string id)
        {
            var students = await _context.Students.FindAsync(id);

            if (students == null)
            {
                return NotFound();
            }

            return students;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutStudents(string id, Students students)
        {
            if (id != students.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(students).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Students>> PostStudents(Students students)
        {
            _context.Students.Add(students);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentsExists(students.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudents", new { id = students.StudentId }, students);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Students>> DeleteStudents(string id)
        {
            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            _context.Students.Remove(students);
            await _context.SaveChangesAsync();

            return students;
        }

        private bool StudentsExists(string id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
