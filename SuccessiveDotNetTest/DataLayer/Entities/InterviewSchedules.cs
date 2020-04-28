using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class InterviewSchedules
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string InterviewerName { get; set; }
        public Candidates candidates { get; set; }
    }
}
