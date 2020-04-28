using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessiveDotNetTests.Models
{
    public class InterviewScheduleModal
    {

        public int Id { get; set; }

        public int CandidateId { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string InterViewerName { get; set; }
    }
}
