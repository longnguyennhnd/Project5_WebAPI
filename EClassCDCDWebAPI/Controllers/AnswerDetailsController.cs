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
    public class AnswerDetailsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public AnswerDetailsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/AnswerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerDetails>>> GetAnswerDetails()
        {
            return await _context.AnswerDetails.ToListAsync();
        }

        // GET: api/AnswerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerDetails>> GetAnswerDetails(Guid id)
        {
            var answerDetails = await _context.AnswerDetails.FindAsync(id);

            if (answerDetails == null)
            {
                return NotFound();
            }

            return answerDetails;
        }

        // PUT: api/AnswerDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerDetails(Guid id, AnswerDetails answerDetails)
        {
            if (id != answerDetails.AnswerId)
            {
                return BadRequest();
            }

            _context.Entry(answerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerDetailsExists(id))
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

        // POST: api/AnswerDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnswerDetails>> PostAnswerDetails(AnswerDetails answerDetails)
        {
            _context.AnswerDetails.Add(answerDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnswerDetailsExists(answerDetails.AnswerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnswerDetails", new { id = answerDetails.AnswerId }, answerDetails);
        }

        // DELETE: api/AnswerDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnswerDetails>> DeleteAnswerDetails(Guid id)
        {
            var answerDetails = await _context.AnswerDetails.FindAsync(id);
            if (answerDetails == null)
            {
                return NotFound();
            }

            _context.AnswerDetails.Remove(answerDetails);
            await _context.SaveChangesAsync();

            return answerDetails;
        }

        private bool AnswerDetailsExists(Guid id)
        {
            return _context.AnswerDetails.Any(e => e.AnswerId == id);
        }
    }
}
