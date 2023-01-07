using _5yanvardnm5.Models;
using Microsoft.AspNetCore.Mvc;

namespace _5yanvardnm5.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class SliderController : Controller
	{
		private readonly DataContext _datacontext;

		public SliderController(DataContext dataContext)
		{
			_datacontext = dataContext;
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
			ex.Title2 = slider.Title2;
			ex.Title1 = slider.Title1;
			ex.Desc = slider.Desc;
			ex.ButonUrlText = slider.ButonUrlText;
			ex.ButonUrl = slider.ButonUrl;
			ex.Image = slider.Image;

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
