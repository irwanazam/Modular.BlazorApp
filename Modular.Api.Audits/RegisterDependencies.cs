using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Api.Catalogs.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Audits
{
    public static class RegisterDependencies
    {
        public static void RegisterModuleAudits(this IServiceCollection services,string connection)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<AuditDbContext>(options =>
            {
                options.UseNpgsql(connection);
            });
        }
    }
}
