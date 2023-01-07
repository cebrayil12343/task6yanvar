using _5yanvardnm5.Models;
using _5yanvardnm5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _5yanvardnm5.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _datacontext;

        public HomeController(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                slider = _datacontext.sliders.ToList()
            };
            return View(homeViewModel);
        }
    }
}