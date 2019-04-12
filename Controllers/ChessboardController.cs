using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Data;
using RCDT.Models;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RCDT.Controllers
{
    [Authorize(Policy = "RequireValidTaskRole")]
    public class ChessboardController : Controller
    {
         private readonly DataContext _context;
         public ChessboardController(DataContext context)
         {
             _context = context;
         }
         
         public IActionResult Index()
        {
            return View(_context.Tasks.ToList());
        }
    }
}