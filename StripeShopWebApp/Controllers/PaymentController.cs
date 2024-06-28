using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using StripeShopWebApp.Data;

namespace StripeShopWebApp.Controllers
{
    public class PaymentController : Controller
    {
        // Injecting Data into Controller using context constructor
        private readonly ProductContext _productContext;
        public PaymentController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IActionResult> Index(string searchMenu)
        {
            var products = _productContext.Products;

            if (!string.IsNullOrEmpty(searchMenu))
            {
                return View(await products.Where(c => c.Name.Contains(searchMenu)).ToListAsync());
            }
            return View(products);
        }

        [HttpPost]
        public ActionResult Checkout()
        {
            var domain = "https://localhost:7271";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "price_1PWDOgP9UQlxna3s6Yi0JJyu",
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "/Payment/Success",
                CancelUrl = domain + "/Payment/Cancel",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }
    }
}
