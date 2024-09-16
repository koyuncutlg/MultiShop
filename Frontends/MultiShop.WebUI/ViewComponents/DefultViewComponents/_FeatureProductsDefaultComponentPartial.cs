using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}