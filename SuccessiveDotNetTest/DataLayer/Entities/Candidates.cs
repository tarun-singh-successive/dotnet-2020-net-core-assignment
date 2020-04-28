using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Candidates
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Experience { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public ICollection<InterviewSchedules> InterviewSchedules { get; set; }
    }
}
