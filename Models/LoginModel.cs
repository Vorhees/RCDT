using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCDT.Models
{
    public class LoginModel
    {
        // This will be the primary key.
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 6, ErrorMessage = "Please enter a valid username")]
        public string Username { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 6, ErrorMessage = "Please enter a valid password")]
        public string Password { get; set; }
    }
}