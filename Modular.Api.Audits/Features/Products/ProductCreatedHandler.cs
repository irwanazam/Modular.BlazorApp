using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Modular.Api.Audits.Domains;
using Modular.Api.Catalogs.DataContexts;
using Modular.Api.Events.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Audits.Features.Products
{
    public class ProductCreatedHandler : IEventHandler<ProductCreated>
    {
        
        private readonly IServiceScopeFactory _scopeFactory;

        private readonly ILogger<ProductCreatedHandler> _logger;

        public ProductCreatedHandler(IServiceScopeFactory scopeFactory, ILogger<ProductCreatedHandler> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task HandleAsync(ProductCreated eventModel, CancellationToken ct)
        {

            using var scope = _scopeFactory.CreateScope();

            var context = scope.Resolve<AuditDbContext>();

            _logger.LogInformation($"Product {eventModel.Name} created at {eventModel.EventDate}");

            context.AuditEvents.Add(new AuditEvent
            {
                Date = eventModel.EventDate,
                Entity = "Product",
                EntityId = eventModel.EntityId,
                User = "System",
                Event = "ProductCreated",
                Message = $"Product - {eventModel.Name} created at {eventModel.EventDate}"
            });

            await context.SaveChangesAsync(ct);
        }
    }
}
