using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Modular.Api.Catalogs;
using Modular.Api.Audits;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

builder.Services.AddFastEndpoints();
builder.Services.RegisterModuleCatalogs(builder.Configuration.GetConnectionString("CatalogsConnection"));
builder.Services.RegisterModuleAudits(builder.Configuration.GetConnectionString("AuditsConnection"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5024") // specify your domain here
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapRazorPages();


app.UseFastEndpoints();
app.Run();

