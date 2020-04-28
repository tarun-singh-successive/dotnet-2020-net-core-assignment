using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessiveDotNetTest.Models
{
    public class DbManager
    {
        private readonly DataContext _context;

        public DbManager(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<InterviewSchedules>GetCandidateDataWithInterviewSchedule()
        {
            var candidate = _context.InterviewSchedules.Include(e =>e.candidates);
            return candidate;
        }
        public IEnumerable<Candidates> GetInterviewDataWithCandidate()
        {
            var candidate = _context.Candidates.Include(e => e.InterviewSchedules);
            return candidate;
        }
        public IEnumerable<Candidates> CandidateList()
        {
            var cadidate = _context.Candidates;
            return cadidate.ToList();
        }
        public void Add(Candidates candidate)
        {
            _context.Add(candidate);

        }
        public void AddInterviewDetails(InterviewSchedules schedule)
        {
            _context.Add(schedule);

        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public bool EmailExists(string email)
        {
            var result = _context.Candidates.Where(e => e.Email == email).Select(e => e.Email);
            if (result == null)
            {
                return true;
            }
            else { return false; }
        }
    }
}
