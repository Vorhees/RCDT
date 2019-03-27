using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RCDT.Models
{
    public class LoginParticipantViewModel
    {
        [Required]
        [StringLength(2,MinimumLength = 1, ErrorMessage = "Please enter a valid user ID")]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "SessionKey")]
        [Range(1, 9999, ErrorMessage = "Please enter a valid session key")]
        public string SessionKey { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}