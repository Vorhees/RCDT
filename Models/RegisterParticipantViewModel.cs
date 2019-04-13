using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCDT.Models
{
    public class RegisterParticipantViewModel
    {
        [Required]
        [Display(Name = "UserID")]
        [StringLength(2,MinimumLength = 1, ErrorMessage = "Please enter a valid user ID")]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "SessionKey")]
        [Range(1, 9999, ErrorMessage = "Please enter a valid session key")]
        public string SessionKey { get; set; }

        [Required]
        [Display(Name = "Task Session ID")]
        public string TaskSessionID { get; set; }
    }
}