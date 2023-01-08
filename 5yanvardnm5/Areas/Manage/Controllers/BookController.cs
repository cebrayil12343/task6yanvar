using _5yanvardnm5.Models;
using _5yanvardnm5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace _5yanvardnm5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BookController : Controller
    {
        private readonly DataContext _datacontext;

        public BookController(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public IActionResult Index()
        {
            return View(_datacontext.books.ToList());
        }

        public IActionResult Creat()
        {

            ViewBag.authors = _datacontext.authors.ToList();
            ViewBag.genres = _datacontext.genres.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Creat(BookViewModel bookVm)
        {
            ViewBag.authors = _datacontext.authors.ToList();
            ViewBag.genres = _datacontext.genres.ToList();
            if (!ModelState.IsValid) return View();

            book book = new book
            {
                Name = bookVm.Name,
                Code = bookVm.Code,
                Desc = bookVm.Desc,
                AuthorId = bookVm.AuthorId,
                GenreId = bookVm.GenreId,
                CostPrice = bookVm.CostPrice,
                DiscountPrice = bookVm.DiscountPrice,
                SalePrice = bookVm.SalePrice,
                IsAviable = bookVm.IsAviable
            };

            _datacontext.books.Add(book);
            _datacontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            ViewBag.authors = _datacontext.authors.ToList();
            ViewBag.genres = _datacontext.genres.ToList();
            book book = _datacontext.books.Find(id);
            if(book == null) return View("error");

            return View(book);
        }
        [HttpPost]
        public IActionResult Update(book books)
        {
            ViewBag.authors = _datacontext.authors.ToList();
            ViewBag.genres = _datacontext.genres.ToList();

            book book = _datacontext.books.FirstOrDefault(x=>x.Id == books.Id);
            if(books == null) return View("error");
            if (!ModelState.IsValid) return View();

                book.Name = books.Name;
                book.Code = books.Code;
                book.Desc = books.Desc;
                book.AuthorId = books.AuthorId;
                book.GenreId = books.GenreId;
                book.CostPrice = books.CostPrice;
                book.DiscountPrice = books.DiscountPrice;
                book.SalePrice = books.SalePrice;
                book.IsAviable = books.IsAviable;

            _datacontext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
