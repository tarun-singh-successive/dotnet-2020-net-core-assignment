using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;

namespace SuccessiveDotNetTest.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateAPIController : ControllerBase
    {
        private readonly DataContext _context;

        public CandidateAPIController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CandidateAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidates>>> GetCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        // GET: api/CandidateAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidates>> GetCandidates(int id)
        {
            var candidates = await _context.Candidates.FindAsync(id);

            if (candidates == null)
            {
                return NotFound();
            }

            return candidates;
        }

        // PUT: api/CandidateAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidates(int id, Candidates candidates)
        {
            if (id != candidates.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatesExists(id))
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

        // POST: api/CandidateAPI
        [HttpPost]
        public async Task<ActionResult<Candidates>> PostCandidates(Candidates candidates)
        {
            _context.Candidates.Add(candidates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidates", new { id = candidates.Id }, candidates);
        }

        // DELETE: api/CandidateAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidates>> DeleteCandidates(int id)
        {
            var candidates = await _context.Candidates.FindAsync(id);
            if (candidates == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidates);
            await _context.SaveChangesAsync();

            return candidates;
        }

        private bool CandidatesExists(int id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
