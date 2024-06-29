using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Modular.Api.Product.DataContexts;
using Modular.Api.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Product.Features
{
    public class GetAll : EndpointWithoutRequest<IEnumerable<ProductResponse>>
    {
        private readonly ProductDbContext _context;

        public GetAll(ProductDbContext context)
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
