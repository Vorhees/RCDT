using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RCDT.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
        public string ParticipantUserId { get; set; }
        public string TaskSessionID { get; set; }

        public int NumUsersInGroup { get; set; }
    }
}
