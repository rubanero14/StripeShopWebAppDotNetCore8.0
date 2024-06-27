using Microsoft.AspNetCore.Mvc;

namespace StripeShopWebApp.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
