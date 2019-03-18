using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace RCDT.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    //[Authorize(Roles="admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}