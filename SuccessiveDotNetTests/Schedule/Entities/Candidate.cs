using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public ICollection<InterviewSchedule> InterviewData { get; set; }

    }
}
