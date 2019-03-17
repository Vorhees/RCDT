using System;
using System.Threading.Tasks;
using RCDT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RCDT.Data
{
    public static class SeedRoles
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration config)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
        }
    }
}