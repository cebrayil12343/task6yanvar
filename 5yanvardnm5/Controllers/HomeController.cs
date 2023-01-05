using _5yanvardnm5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _5yanvardnm5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}