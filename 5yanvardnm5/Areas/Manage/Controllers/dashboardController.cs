using Microsoft.AspNetCore.Mvc;

namespace _5yanvardnm5.Areas.manages.Controllers
{
    [Area("Manage")]
    public class dashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
