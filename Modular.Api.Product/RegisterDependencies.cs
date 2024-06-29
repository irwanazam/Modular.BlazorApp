using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Api.Product.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Product
{
    public static class RegisterDependencies
    {
        public static void RegisterModuleProduct(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Database=Products;Username=postgres;Password=cc123***");
            });
        }
    }
}
