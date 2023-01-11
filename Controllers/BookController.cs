using _5yanvardnm5.Models;
using _5yanvardnm5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _5yanvardnm5.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _datacontext;

        public BookController(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            book book = _datacontext.books.Include(x=>x.Author).Include(x=>x.bookImages).Include(x=>x.Genre).FirstOrDefault(x=>x.Id == id);
            if (book == null) return View("error");
            BookDetailViewModel bookDetailViewModel = new BookDetailViewModel
            {
                book = book,
                RelatedBooks = _datacontext.books
                                           .Include(x=>x.bookImages)
                                           .Include(x=>x.Author)
                                           .Where(x=>x.GenreId == book.GenreId && x.Id != book.Id).ToList(),
            };
            return View(bookDetailViewModel);
        }
    }
}
