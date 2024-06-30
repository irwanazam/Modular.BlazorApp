using Microsoft.EntityFrameworkCore;
using Modular.Api.Audits.Domains;
using System.Security.Cryptography.X509Certificates;

namespace Modular.Api.Catalogs.DataContexts
{
    public class AuditDbContext :DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options): base(options)
        {
           
        }
        public DbSet<AuditEvent> AuditEvents { get; set; }
        
    }
}