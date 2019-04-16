using System;
using System.ComponentModel.DataAnnotations;


namespace RCDT.Models
{
    public class ChessBoardMoveLog
    {
        [Required]
        [Key]
        public int MoveNumber { get; set; }

        [Required]
        public string TaskSessionID { get; set; }

        public string UserName { get; set; }

        public DateTime dateTime { get; set; }

        [Required]
        public string BoardState { get; set; }
    }
}
