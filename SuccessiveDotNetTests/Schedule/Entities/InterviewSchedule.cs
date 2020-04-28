using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Entities
{
    public class InterviewSchedule
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public DateTime Date { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string InterViewerName { get; set; }
        
        public Candidate candidates { get; set; }

    }
}
