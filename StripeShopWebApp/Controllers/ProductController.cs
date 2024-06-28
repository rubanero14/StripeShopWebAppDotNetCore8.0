using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StripeShopWebApp.Data;

namespace StripeShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        // Injecting Data into Controller using context constructor
        private readonly ProductContext _productContext;
        public ProductController(ProductContext productContext) { 
            _productContext = productContext;
        }

        public async Task<IActionResult> Index(string searchMenu)
        {   
            var products = await _productContext.Products.ToListAsync();

            if (!string.IsNullOrEmpty(searchMenu)) 
            {
                products = await _productContext.Products.Where(c => c.Name.Contains(searchMenu)).ToListAsync();
                return View(products);
            }
            return View(products);
        }
    }
}
