using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using furni.Presentation.Models;
using furni.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using furni.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace furni.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ApplicationDbContext _context;

    public HomeController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ApplicationDbContext context)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Featured = await _context.Product.Where(p => p.IsFeatured == true)
            .Where(p => !p.IsDeleted)
            .Include(p => p.Thumbnail)
            .OrderByDescending(p => p.CreatedAt)
            .Take(8)
            .ToListAsync();
        ViewBag.NewProduct = await _context.Product
            .Include(p => p.Thumbnail)
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.CreatedAt)
            .Take(8)
            .ToListAsync();

        ViewBag.SuggestPost = await _context.Blog
            .Include(p => p.Thumbnail)
            .Where(p => !p.IsDeteled && p.IsPublic)
            .Include(b => b.Topic)
            .Include(b => b.AppUser)
            .OrderByDescending(blog => blog.CreateAt)
            .Take(4).ToListAsync();
        return View();
    }



    [Route("trackorder")]
    public IActionResult TrackOrder()
    {
        return View();
    }

    [Route("help")]
    public IActionResult Help()
    {
        return View();
    }

    [Route("cart")]
    public IActionResult Cart()
    {
        return View();
    }

    [Route("checkout")]
    public async Task<IActionResult> Checkout()
    {
        var currentUser = await _userManager.GetUserAsync(User);
        ViewBag.currentUser = currentUser;
        ViewBag.ShippingMethod = await _context.ShippingMethod.Where(p => p.IsDeleted == false).ToListAsync();
        if (currentUser != null)
        {
            ViewBag.Addresses = _context.Address.Where(a => a.AppUserId == currentUser.Id && !a.IsDeleted).ToList();
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
