using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefultViewComponents
{
    public class _SpecialOfferComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}