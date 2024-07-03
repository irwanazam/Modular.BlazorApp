using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Api.Catalogs.DataContexts;
using Modular.Api.Catalogs.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Catalogs
{
    public static class RegisterDependencies
    {
        public static void RegisterModuleCatalogs(this IServiceCollection services,string connection)
        {
            services.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseNpgsql(connection);
            });

        }
    }

    public static class CatalogSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new CatalogDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<CatalogDbContext>>());

            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            context.Categories.AddRange(
                new Category { Name = "Car Accessories" },
                new Category { Name = "Home Appliance" }
            );
            context.SaveChanges();
        }
    }



}
