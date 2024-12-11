using Microsoft.AspNetCore.Mvc;
using furni.Domain.Entities;

namespace furni.Presentation.Components
{
    public class ShoeCardsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Product shoe)
        {
            return View(shoe);
        }
    }
}
