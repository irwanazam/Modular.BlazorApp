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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //// Seed categories
            //modelBuilder.Entity<Category>().HasData(
            //    new Category { Name = "Electronics" },
            //    new Category { Name = "Books" },
            //    new Category { Name = "Clothing" }
            //);
        }
    }
}