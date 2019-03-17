using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace RCDT.Controllers
{
    //[Authorize(Policy = "RequireAdminRole")]
    public class AdminDashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}