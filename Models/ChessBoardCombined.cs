using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RCDT.Models
{
    public class ChessBoardCombined
    {
        public ApplicationUser User { get; set; }
        public DDMT Task { get; set; }
    }
}
