using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }             
    }
}