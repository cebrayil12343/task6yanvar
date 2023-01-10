using _5yanvardnm5.Helpers;
using _5yanvardnm5.Models;
using Microsoft.AspNetCore.Mvc;

namespace _5yanvardnm5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IWebHostEnvironment _env;

        public SliderController(DataContext dataContext, IWebHostEnvironment env)
        {
            _datacontext = dataContext;
            this._env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliderList = _datacontext.sliders.ToList();
            return View(sliderList);
        }
        [HttpGet]
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Creat(Slider slider)
        {
            if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Jpeg and Png");
                return View();
            }

            if(slider.ImageFile.Length > 3145728)
            {
                ModelState.AddModelError("ImageFile", "max 3 mb");
                return View();
            }

            //string file = slider.ImageFile.FileName;

            //if (file.Length>100)
            //{
            //    file = file.Substring(file.Length - 100,100);
            //}

            //file = Guid.NewGuid().ToString() + file;

            ////string data = "C:\\Users\\User\\Desktop\\5yanvardnm5\\5yanvardnm5\\wwwroot\\Upload\\Slider\\" + file;

            //string data = Path.Combine(_env.WebRootPath, "Upload\\Slider",file);

            //using (FileStream fileStream = new FileStream(data, FileMode.Create))
            //{
            //    slider.ImageFile.CopyTo(fileStream);
            //}

            

            slider.Image = FileManage.SaveFile(_env.WebRootPath,"Upload\\Slider",slider.ImageFile);

            _datacontext.sliders.Add(slider);	
			_datacontext.SaveChanges();
			return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
			Slider slider = _datacontext.sliders.Find(id);
			if (slider == null) return View("Error");
			return View(slider);
        }

		[HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider ex = _datacontext.sliders.Find(slider.Id);
            if (ex == null) return View("Error");

            if(slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg and Png");
                    return View();
                }

                if (slider.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "max 3 mb");
                    return View();
                }
                string file = FileManage.SaveFile(_env.WebRootPath,"Upload\\Slider",slider.ImageFile);
                //string deletepath = Path.Combine(_env.WebRootPath, "Upload\\Slider", ex.Image);
                //if (System.IO.File.Exists(deletepath))
                //{
                //    System.IO.File.Delete(deletepath);
                //}
                FileManage.Delete(_env.WebRootPath, "Upload\\Slider", ex.Image);
                ex.Image = file;
                
            }

            ex.Title2 = slider.Title2;
			ex.Title1 = slider.Title1;
			ex.Desc = slider.Desc;
			ex.ButonUrlText = slider.ButonUrlText;
			ex.ButonUrl = slider.ButonUrl;

			_datacontext.SaveChanges();
			return RedirectToAction("index");
        }


        public IActionResult Delete(int id)
        {
            Slider slider = _datacontext.sliders.Find(id);
            if (slider == null) return View("Error");
            return View(slider);
        }

		[HttpPost]
        public IActionResult Delete(Slider slider)
        {
            Slider exd = _datacontext.sliders.Find(slider.Id);
            if (exd == null) return View("Error");
            _datacontext.sliders.Remove(exd);
			_datacontext.SaveChanges();
			return RedirectToAction("index");
        }
    }
}
