
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Api.Middleware;
using StoreManagement.Application.Interfaces;
using StoreManagement.Application.Services;
using StoreManagement.Infrastructure.Persistence;
using StoreManagement.Infrastructure.Repositories;

/// <summary>
/// Entry point for the StoreManagement API application.
/// Initializes dependency injection, configuration, and the HTTP pipeline.
/// </summary>

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    x => x.Key,
                    x => x.Value!.Errors
                        .Select(e => e.ErrorMessage)
                        .ToArray());

            return new BadRequestObjectResult(
                new
                {
                    message = "Validation failed.",
                    errors
                });
        };
    });

builder.Services.AddOpenApi();

// Application Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<
    ISupplierService,
    SupplierService>();
    
// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<
    IStockRepository,
    StockRepository>();

builder.Services.AddScoped<
    IStockMovementRepository,
    StockMovementRepository>();

    builder.Services.AddScoped<
    ISupplierService,
    SupplierService>();

// Database
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    var connectionString =
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException(
            "DefaultConnection is not configured.");

    options.UseNpgsql(connectionString);
});

// Unit of Work
builder.Services.AddScoped<IUnitOfWork>(provider =>
    provider.GetRequiredService<StoreDbContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
