using System;
using System.Collections.Generic;

namespace RCDT.Models
{
    public class AdminUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        //public bool isResearcher { get; set; }
        
    }
}