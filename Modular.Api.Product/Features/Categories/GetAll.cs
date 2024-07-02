using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Modular.Api.Catalogs.DataContexts;
using Modular.Api.Catalogs.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Product.Features.Categories
{
    public class GetAll : EndpointWithoutRequest<List<Category>>
    {
        private readonly CatalogDbContext _context;

        public GetAll(CatalogDbContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Get("/api/categories");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var categories = await _context.Categories.ToListAsync(ct);
            await SendOkAsync(categories, ct);
        }
    }
}
