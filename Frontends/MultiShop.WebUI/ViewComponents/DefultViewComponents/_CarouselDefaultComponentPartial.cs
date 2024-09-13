using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
