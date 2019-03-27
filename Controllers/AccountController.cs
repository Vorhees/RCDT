using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RCDT.Models;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Http;
using RCDT.Data;

namespace RCDT.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
       private readonly UserManager<ApplicationUser> _userManager;
       private readonly SignInManager<ApplicationUser> _signInManager;
      // private readonly IEmailSender _emailSender;
       private readonly ILogger _logger;

       //private readonly IHttpContextAccessor _context;
       private readonly DataContext _context;
       public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                             ILogger<AccountController> logger, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
           _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clears existing cookies
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                    return View(loginModel);
                }
            }

            return View(loginModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginParticipant(string returnUrl = null)
        {
            // Clears existing cookies
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginParticipant(LoginParticipantViewModel loginParticipantModel, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginParticipantModel.UserID, loginParticipantModel.SessionKey, loginParticipantModel.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in");

                    return RedirectToAction("Index", "Chessboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                    return View(loginParticipantModel);
                }
            }

            return View(loginParticipantModel);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Logged out");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Register(string returnUrl = null)
        {
           ViewBag.Name = new SelectList(_context.Roles.Where(u => !u.Name.Contains("Admin") && !u.Name.Contains("Participant")).ToList(), "Name", "Name");

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpGet]
        [Authorize(Policy = "RequireResearcherRole")]
        public IActionResult RegisterParticipant(string returnUrl = null)
        {
           /*
           ViewBag.Name = new SelectList(_context.Roles.Where(u => !u.Name.Contains("Admin") && !u.Name.Contains("IRB Reviewer") && !u.Name.Contains("Transcriber") && !u.Name.Contains("Researcher") && !u.Name.Contains("Research Assistant")).ToList(), "Name", "Name");
           */

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterParticipant(RegisterParticipantViewModel participantViewModel, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = participantViewModel.UserID };

                var result = await _userManager.CreateAsync(user, participantViewModel.SessionKey);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Participant was successfully created");

                    await _userManager.AddToRoleAsync(user, "Participant");

                    // Signs Participant in after registration.
                    //await _signInManager.SignInAsync(user, isPersistent: false);

                    _logger.LogInformation("Participant's account was created");

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(participantViewModel);
        }
        

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerModel, string Roles, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            //Roles = Request.Form["Roles"].ToString();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = registerModel.Email,Email = registerModel.Email};

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account.");
                    
                    // Temp. add as researcher for now. 
                    await _userManager.AddToRoleAsync(user, registerModel.UserRoles);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    _logger.LogInformation("User created a new account");

                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View(registerModel);
        }

        /* Older code.
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "AdminDashboard");
            }

            return View(loginModel);
        }
        */
    }
}