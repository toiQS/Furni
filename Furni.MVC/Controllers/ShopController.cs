﻿using Microsoft.AspNetCore.Mvc;

namespace Furni.MVC.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
