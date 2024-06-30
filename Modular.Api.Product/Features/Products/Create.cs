using FastEndpoints;
using Modular.Api.Catalogs.Domains;
using Modular.Api.Catalogs.Shareds;
using Modular.Api.Catalogs.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Catalogs.Features.Products
{
    public class Create : Endpoint<CreateProductRequest, ProductResponse>
    {
        private readonly CatalogDbContext _context;

        public Create(CatalogDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Post("/api/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(req.Name) || req.Price <= 0 || req.Stock < 0)
            {
                ThrowError("Invalid product data.");
            }

            var product = new Product
            {
                Name = req.Name,
                Description = req.Description,
                Price = req.Price,
                Stock = req.Stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(ct);

            var response = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };

            await SendCreatedAtAsync<GetById>(new { product.Id }, response, cancellation: ct);
        }
    }
}
