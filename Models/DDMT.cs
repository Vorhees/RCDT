using System;
using System.ComponentModel.DataAnnotations;

namespace RCDT.Models
{
    public class DDMT
    {

        [Required]
        [Key]
        public int TaskSessionID { get; set; }

        [Required]
        public int participantNumber { get; set; }

        [Required]
        public int confederateNumber { get; set; }

        public string taskReport { get; set; }

        public DateTime taskTime { get; set; }

        public int moveNumber { get; set; }
    }   


}
