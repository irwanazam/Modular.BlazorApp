using Microsoft.EntityFrameworkCore;
using Modular.Api.Catalogs.Domains;
using System.Security.Cryptography.X509Certificates;

namespace Modular.Api.Catalogs.DataContexts
{
    public class CatalogDbContext :DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options): base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}