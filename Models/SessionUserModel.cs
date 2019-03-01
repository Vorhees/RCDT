using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCDT.Models
{
    public class SessionUserModel
    {
        // This will be the primary key.
        public int Id { get; set; }

        [Required]
        [StringLength(1,MinimumLength = 1, ErrorMessage = "Please enter a valid user ID")]
        public String userID { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid session key")]
        public int sessionKey { get; set; }
    }
}