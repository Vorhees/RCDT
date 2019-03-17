using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

/*
    This class is the user class that will extend from the
    IdentityUser class, part of the Identity framework.
    Currently it is being used to test role adding and seeding.
*/

namespace RCDT.Models
{
    public class IDUser : IdentityUser
    {
    }
}