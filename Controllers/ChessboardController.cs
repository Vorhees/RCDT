using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Models;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RCDT.Controllers
{
    public class ChessboardController : Controller
    {
         public IActionResult Index()
        {
            return View();
        }
    }
}