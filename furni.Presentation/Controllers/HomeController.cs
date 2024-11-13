using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using furni.Presentation.Models;
using furni.Application.Interfaces.Management;
using furni.Domain.Entities;

namespace furni.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductManagement productManagement;
    private readonly ICartManagement _cartManagement;

    public HomeController(ILogger<HomeController> logger, ICartManagement cartManagement)
    {
        _logger = logger;
        _cartManagement = cartManagement;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {

        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
