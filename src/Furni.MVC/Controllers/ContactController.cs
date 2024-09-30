using Microsoft.AspNetCore.Mvc;

namespace Furni.MVC.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
