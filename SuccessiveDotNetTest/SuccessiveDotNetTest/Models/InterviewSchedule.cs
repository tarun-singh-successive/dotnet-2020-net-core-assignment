using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessiveDotNetTest.Models
{
    public class InterviewSchedule
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime TimeTO { get; set; }
        public DateTime TimeFrom { get; set; }
        public string InterviewerName { get; set; }
    }
}
