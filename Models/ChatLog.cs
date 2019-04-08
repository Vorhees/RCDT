using System;
using System.ComponentModel.DataAnnotations;

namespace RCDT.Models
{
    public class ChatLog
    {
        [Required]
        [Key]
        public int TaskSessionId { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
