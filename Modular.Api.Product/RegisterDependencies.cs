﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Api.Catalogs.DataContexts;
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
}
