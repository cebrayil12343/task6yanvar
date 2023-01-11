using _5yanvardnm5.Models;
using _5yanvardnm5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                slider = _datacontext.sliders.ToList(),
                FeaturedBooks=_datacontext.books.Include(x => x.bookImages).Include(x => x.Author).Where(x => x.IsFeatured).ToList(),
                NewBooks = _datacontext.books.Include(x => x.bookImages).Include(x => x.Author).Where(x => x.IsNew == true).ToList(),
                DiscountedBooks = _datacontext.books.Include(x=>x.bookImages).Include(x=>x.Author).Where(x=>x.DiscountPrice > 0).ToList(),
            };
            return View(homeViewModel);
        }
    }
}