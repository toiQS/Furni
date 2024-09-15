using Microsoft.AspNetCore.Mvc;

namespace Furni.MVC.Controllers
{
	public class AboutUs : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
