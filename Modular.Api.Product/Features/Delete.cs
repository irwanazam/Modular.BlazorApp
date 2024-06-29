using FastEndpoints;
using Modular.Api.Product.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Product.Features
{
    public class DeleteProductEndpoint : EndpointWithoutRequest
    {
        private readonly ProductDbContext _context;

        public DeleteProductEndpoint(ProductDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Delete("/api/products/{id:int}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<int>("id");

            var product = await _context.Products.FindAsync(new object[] { id }, ct);

            if (product == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(ct);

            await SendNoContentAsync(ct);
        }
    }
}
