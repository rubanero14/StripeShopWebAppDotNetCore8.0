using Microsoft.AspNetCore.Mvc;

namespace StripeShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
