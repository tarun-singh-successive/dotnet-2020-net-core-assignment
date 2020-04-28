using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Text;

namespace SuccessiveDotNetTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly DataContext _context;

        public CandidatesController(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Candidates>>> GetCandidate()
            {
            return (await _context.Candidates.ToListAsync());
          }
        // GET: api/Candidates/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Candidates>> GetCandidates(string name)
        {
            StringBuilder email = new StringBuilder();
            int index = name.IndexOf("<");
            int length;
             length   = name.Length - 1;
            index += 1;
            for (int i = index; i < length ; i++)
            {
                email.Append(name[i]);
            }
            string addr = email.ToString();
            List < Candidates > candidate= _context.Candidates.ToList();
            int id =candidate.Where(d => d.Email.Equals(addr)).Select(f => f.Id).SingleOrDefault();
            var candidates = await _context.Candidates.FindAsync(id);

            if (candidates == null)
            {
                return NotFound();
            }

            return candidates;
        }

        // PUT: api/Candidates/5
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

        // POST: api/Candidates
        [HttpPost]
        public async Task<ActionResult<Candidates>> PostCandidates(Candidates candidates)
        {
            _context.Candidates.Add(candidates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidates", new { id = candidates.Id }, candidates);
        }

        // DELETE: api/Candidates/5
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
