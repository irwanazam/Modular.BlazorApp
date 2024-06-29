using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Modular.Api.Product.DataContexts
{
    public class ProductDbContext :DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }
    }
}