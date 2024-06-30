using FastEndpoints;
using Modular.Api.Catalogs.DataContexts;
using Modular.Api.Catalogs.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Catalogs.Features.Products
{
    public class GetById : EndpointWithoutRequest<ProductResponse>
    {
        private readonly CatalogDbContext _context;

        public GetById(CatalogDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Get("/api/products/{id:int}");
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

            var response = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };

            await SendOkAsync(response, ct);
        }
    }


}
