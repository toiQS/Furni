﻿using Microsoft.AspNetCore.Mvc;

namespace Furni.MVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
