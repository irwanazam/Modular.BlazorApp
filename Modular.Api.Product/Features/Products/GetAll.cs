using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Modular.Api.Catalogs.Shareds;
using Modular.Api.Catalogs.DataContexts;
using Modular.Api.Catalogs.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Catalogs.Features.Products
{
    public class GetAll : EndpointWithoutRequest<IEnumerable<ProductResponse>>
    {
        private readonly CatalogDbContext _context;

        public GetAll(CatalogDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Get("/api/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var products = await _context.Products.ToListAsync(ct);

            var response = products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock
            });

            await SendOkAsync(response, ct);
        }
    }
}
