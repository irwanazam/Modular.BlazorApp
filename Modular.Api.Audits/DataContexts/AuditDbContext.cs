using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Modular.Api.Catalogs.DataContexts
{
    public class AuditDbContext :DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options): base(options)
        {
           
        }

        
    }
}