using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessiveDotNetTests.Models
{
    public class ScheduleInterviewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Experience is required")]
        public int Experience { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [MaxLength(10)]
        [MinLength(10)]
        public long Mobile { get; set; }
        public int CandidateId { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string InterViewerName { get; set; }
    }
}
