using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class InterviewSchedules
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public DateTime Date { get; set; }
        public Candidates Candidates { get; set; }
        public DateTime TimeTO { get; set; }
        public DateTime TimeFrom { get; set; }
        public string InterviewerName { get; set; }

    }
}
