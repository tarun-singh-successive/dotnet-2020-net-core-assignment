using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuccessiveDotNetTest.Models
{
    public class ScheduleInterviewModal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name Can't be Empty")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Can't be Empty")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "DOB Can't be Empty")]
         [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Experience Can't be Empty")]
        [Display(Name ="Experience (in Months)")]
        public int Experience { get; set; }
        [Required(ErrorMessage = "Mobile Can't be Empty")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Email Can't be Empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date Can't be Empty")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "TimeFrom Can't be Empty")]
        [DataType(DataType.Time)]
        public DateTime TimeFrom { get; set; }
        [DataType(DataType.Time)]
        public DateTime TimeTo { get; set; }
        public string InterviewerName { get; set; }
    }
}
