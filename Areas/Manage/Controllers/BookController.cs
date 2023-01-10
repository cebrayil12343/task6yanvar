using _5yanvardnm5.Helpers;
using _5yanvardnm5.Models;
using _5yanvardnm5.ViewModels;
//using AspNetCore;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
//using System.Xml.Linq;


namespace _5yanvardnm5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BookController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IWebHostEnvironment envs;
        public BookController(DataContext dataContext, IWebHostEnvironment _envs)
        {
            _datacontext = dataContext;
            envs=_envs;
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

        //[HttpPost]
        //public IActionResult Creat(BookViewModel bookVm)
        //{
        //    ViewBag.authors = _datacontext.authors.ToList();
        //    ViewBag.genres = _datacontext.genres.ToList();
        //    if (!ModelState.IsValid) return View();

        //    book book = new book
        //    {
        //        Name = bookVm.Name,
        //        Code = bookVm.Code,
        //        Desc = bookVm.Desc,
        //        AuthorId = bookVm.AuthorId,
        //        GenreId = bookVm.GenreId,
        //        CostPrice = bookVm.CostPrice,
        //        DiscountPrice = bookVm.DiscountPrice,
        //        SalePrice = bookVm.SalePrice,
        //        IsAviable = bookVm.IsAviable,
        //        IsNew = bookVm.IsNew,
        //        IsFeature = bookVm.IsFeature
        //    };

        //    _datacontext.books.Add(book);
        //    _datacontext.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}



        [HttpPost]
        public IActionResult Creat(book book)
        {
            ViewBag.authors = _datacontext.authors.ToList();
            ViewBag.genres = _datacontext.genres.ToList();
            if (!ModelState.IsValid) return View();

            if (book.ImagesPoster != null)
            {
               
                    if (book.ImagesPoster.ContentType != "image/png" && book.ImagesPoster.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("ImagesPoster", "Jpeg and Png");
                        return View();
                    }

                    if (book.ImagesPoster.Length > 3145728)
                    {
                        ModelState.AddModelError("ImagesPoster", "max 3 mb");
                        return View();
                    }

                    BookImage bookImage = new BookImage
                    {
                        Book = book,
                        Image = FileManage.SaveFile(envs.WebRootPath, "upload\\books", book.ImagesPoster),
                        IsPoster = true
                    };
                    _datacontext.bookImages.Add(bookImage);
            }

            if (book.ImagesHover != null)
            {

                if (book.ImagesHover.ContentType != "image/png" && book.ImagesHover.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImagesHover", "Jpeg and Png");
                    return View();
                }

                if (book.ImagesHover.Length > 3145728)
                {
                    ModelState.AddModelError("ImagesHover", "max 3 mb");
                    return View();
                }

                BookImage bookImage = new BookImage
                {
                    Book = book,
                    Image = FileManage.SaveFile(envs.WebRootPath, "upload\\books", book.ImagesHover),
                    IsPoster = false
                };
                _datacontext.bookImages.Add(bookImage);
            }

            if (book.ImagesFiles != null)
            {
               foreach(IFormFile image in book.ImagesFiles)
               {
                    if (image.ContentType != "image/png" && image.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("ImageFile", "Jpeg and Png");
                        return View();
                    }

                    if (image.Length > 3145728)
                    {
                        ModelState.AddModelError("ImageFile", "max 3 mb");
                        return View();
                    }

                    BookImage bookImage = new BookImage
                    {
                        Book = book,
                        Image = FileManage.SaveFile(envs.WebRootPath,"upload\\books",image),
                        IsPoster = null
                    };
                    _datacontext.bookImages.Add(bookImage);
                }
            }

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
                book.IsNew = books.IsNew;
                book.IsFeatured = books.IsFeatured;

            _datacontext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
