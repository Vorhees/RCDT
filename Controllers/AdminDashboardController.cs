using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Data;
using System.Text.Encodings.Web;
using RCDT.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCDT.Services;

namespace RCDT.Controllers
{
    //[Authorize(Policy = "RequireAdminRole")]
    //[Authorize(Roles="admin")]
    public class AdminDashboardController : Controller
    {
        private DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private IEmailSender _emailSender;

        public AdminDashboardController(DataContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.Select(user =>
            new ApplicationUser{
                Email = user.Email,
                UserName = user.UserName,
                Role = user.Role,
            }).ToListAsync());
        }

        public IActionResult ManageUsers()
        {
            return View(_context.Users.ToList());
        }

        public async Task<IActionResult> EditParticipant(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByNameAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new ApplicationUser
            {
                UserName = user.UserName,
                ParticipantUserId = user.ParticipantUserId,
                Role = user.Role
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditParticipant(string id, ApplicationUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(id);
                    var newPassword = _userManager.PasswordHasher.HashPassword(user, appUser.ParticipantUserId);

                    user.UserName = appUser.UserName;
                    user.ParticipantUserId = appUser.ParticipantUserId;
                    user.PasswordHash = newPassword;
                    
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterViewModelExists(appUser.UserName))
                    {
                        Console.WriteLine("Db error");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(ManageUsers));
            }

            return View(appUser);
        }
        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByNameAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string id, ApplicationUser appUser)
        {
            // if (id != appUser.UserName)
            // {
            //     return NotFound();
            // }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(id);
                    Console.WriteLine(user);
                    var newPassword = _userManager.PasswordHasher.HashPassword(user, appUser.PasswordHash);

                    user.Email = appUser.Email;
                    user.UserName = appUser.UserName;
                    user.PasswordHash = newPassword;
                    
                    var emailToken = await _userManager.GenerateChangeEmailTokenAsync(user, user.Email);

                    await _userManager.ChangeEmailAsync(user, user.Email, emailToken);

                    user.EmailConfirmed = false;

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "Confirm your NEW email", $"Please confirm your account by: <a href='{ HtmlEncoder.Default.Encode(callbackUrl) }'> Clicking here </a>");
                    
                    await _userManager.UpdateAsync(user);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterViewModelExists(appUser.Email))
                    {
                        Console.WriteLine("Db error");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(ManageUsers));
            }

            return View(appUser);
        }

        private bool RegisterViewModelExists(string username)
        {
            return _context.Users.Any(e => e.Email == username);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByNameAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new ApplicationUser 
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            });
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByNameAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("ManageUsers", "AdminDashboard");
        }
        
    }
}