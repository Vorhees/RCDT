using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RCDT.Models
{
    public class TaskModel
    {
        //[Required]
        public String TaskType { get; set; }

        [Required]
        [Key]
        public string TaskSessionID { get; set; }

        [Required]
        [Range(1, 6)]
        public int participantNumber { get; set; }

        [Required]
        [Range(1, 6)]
        public int confederateNumber { get; set; }

        public string taskReport { get; set; }

        public DateTime taskCreatedTime { get; set; }

        public DateTime taskEditedTime { get; set; }
        
        // [NotMapped]
        // public IEnumerable<SelectListItem> TaskSelect { get; set; }
    }   
}