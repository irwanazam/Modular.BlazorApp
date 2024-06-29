using FastEndpoints;
using Modular.Api.Product.DataContexts;
using Modular.Api.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Product.Features
{
    public class Update : Endpoint<UpdateProductRequest, ProductResponse>
    {
        private readonly ProductDbContext _context;

        public Update(ProductDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Put("/api/products/{id:int}");
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
