using Microsoft.EntityFrameworkCore;
using StripeShopWebApp.Models;

namespace StripeShopWebApp.Data
{
    public class ProductContext : DbContext 
    {
        // Constructor for context, standard impementation 
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        // Database side instances for the model created for Product, standard impementation 
        public DbSet<Product> Products { get; set; } 
    }
}
