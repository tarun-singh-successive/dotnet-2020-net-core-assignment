using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schedule;
using Schedule.Entities;

namespace SuccessiveDotNetTests.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewSchedulesController : ControllerBase
    {
        private readonly DataContext _context;

        public InterviewSchedulesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/InterviewSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterviewSchedule>>> GetInterviewSchedule()
        {
            return await _context.InterviewSchedule.ToListAsync();
        }

        // GET: api/InterviewSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewSchedule>> GetInterviewSchedule(int id)
        {
            var interviewSchedule = await _context.InterviewSchedule.FindAsync(id);

            if (interviewSchedule == null)
            {
                return NotFound();
            }

            return interviewSchedule;
        }

        // PUT: api/InterviewSchedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewSchedule(int id, InterviewSchedule interviewSchedule)
        {
            if (id != interviewSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(interviewSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewScheduleExists(id))
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

        // POST: api/InterviewSchedules
        [HttpPost]
        public async Task<ActionResult<InterviewSchedule>> PostInterviewSchedule(InterviewSchedule interviewSchedule)
        {
            _context.InterviewSchedule.Add(interviewSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewSchedule", new { id = interviewSchedule.Id }, interviewSchedule);
        }

        // DELETE: api/InterviewSchedules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InterviewSchedule>> DeleteInterviewSchedule(int id)
        {
            var interviewSchedule = await _context.InterviewSchedule.FindAsync(id);
            if (interviewSchedule == null)
            {
                return NotFound();
            }

            _context.InterviewSchedule.Remove(interviewSchedule);
            await _context.SaveChangesAsync();

            return interviewSchedule;
        }

        private bool InterviewScheduleExists(int id)
        {
            return _context.InterviewSchedule.Any(e => e.Id == id);
        }
    }
}
