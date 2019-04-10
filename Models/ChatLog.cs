using System;
using System.ComponentModel.DataAnnotations;

namespace RCDT.Models
{
    public class ChatLog
    { 
        [Required]
        [Key]
        public int MessageId { get; set; }

        [Required]
        public int TaskSessionId { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime dateTime { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
