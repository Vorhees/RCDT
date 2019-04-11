// using System;
// using System.Threading.Tasks;
// using RCDT.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;

// namespace RCDT.Data
// {
//     public static class SeedRoles
//     {
//         public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration config)
//         {
//             //context.Database.EnsureCreated();
//             var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//             var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

//             string[] roles = { "Admin", "Researcher", "Research Assistant", "IRB Reviewer", "Transcriber", "Participant"};

//             IdentityResult roleResult;

//             foreach (var role in roles)
//             {
//                 // Creating roles and seeding to db.
//                 var roleExist = await RoleManager.RoleExistsAsync(role);

//                 if (!roleExist)
//                 {
//                     roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
//                 }
//             }

//             var powerUser = new ApplicationUser
//             {
//                 UserName = config.GetSection("AppSettings")["Email"],
//                 Email = config.GetSection("AppSettings")["Email"]
//             };

//             string userPassword = config.GetSection("AppSettings")["Password"];
//             var user = await UserManager.FindByEmailAsync(config.GetSection("AppSettings")["Email"]);

//             if (user == null)
//             {
//                 var createPowerUser = await UserManager.CreateAsync(powerUser, userPassword);

//                 if (createPowerUser.Succeeded)
//                 {
//                     await UserManager.AddToRoleAsync(powerUser, "Admin");

//                     //context.admin.Add(powerUser);

//                     //context.SaveChanges();
//                 }
//             }
//         }
//     }
// }