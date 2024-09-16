using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}