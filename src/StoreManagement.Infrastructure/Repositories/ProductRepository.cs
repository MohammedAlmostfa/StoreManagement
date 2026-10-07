using Microsoft.EntityFrameworkCore;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;
using StoreManagement.Infrastructure.Persistence;

namespace StoreManagement.Infrastructure.Repositories;

/// <summary>
/// Data access implementation for product persistence using Entity Framework Core.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly StoreDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="context">The database context for product queries.</param>
    public ProductRepository(StoreDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <inheritdoc />
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    /// <inheritdoc />
    public Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task<bool> ExistsBySkuAsync(string sku, Guid? excludeId = null)
    {
        return await _context.Products
            .AnyAsync(x =>
                x.SKU == sku &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
    }

    /// <inheritdoc />
    public async Task<bool> ExistsByBarcodeAsync(string barcode, Guid? excludeId = null)
    {
        return await _context.Products
            .AnyAsync(x =>
                x.Barcode == barcode &&
                (!excludeId.HasValue || x.Id != excludeId.Value));
    }
}