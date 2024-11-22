using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace furni.Presentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SubmitContact([Bind("Name, Email, Message")] ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message,
                };
                _context.Add(contact);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
