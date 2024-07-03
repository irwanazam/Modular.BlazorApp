using FastEndpoints;
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
    public class Update : Endpoint<UpdateProductRequest, ProductResponse>
    {
        private readonly CatalogDbContext _context;

        public Update(CatalogDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Put("/api/catalogs/products/{id:int}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateProductRequest req, CancellationToken ct)
        {
            var id = Route<int>("id");

            if (id != req.Id || string.IsNullOrEmpty(req.Name) || req.Price <= 0 || req.Stock < 0)
            {
                ThrowError("Invalid product data.");
            }

            var product = await _context.Products.FindAsync(new object[] { id }, ct);

            if (product == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            product.Name = req.Name;
            product.Description = req.Description;
            product.Price = req.Price;
            product.Stock = req.Stock;

            await _context.SaveChangesAsync(ct);

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
