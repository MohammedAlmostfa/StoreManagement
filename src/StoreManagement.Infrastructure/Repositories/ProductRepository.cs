using Microsoft.EntityFrameworkCore;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;
using StoreManagement.Infrastructure.Persistence;

namespace StoreManagement.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreDbContext _context;

    public ProductRepository(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);

        return Task.CompletedTask;
    }

    
public async Task<bool> ExistsBySkuAsync(
    string sku,
    Guid? excludeId = null)
{
    return await _context.Products
        .AnyAsync(x =>
            x.SKU == sku &&
            (!excludeId.HasValue ||
             x.Id != excludeId.Value));
}

public async Task<bool> ExistsByBarcodeAsync(
    string barcode,
    Guid? excludeId = null)
{
    return await _context.Products
        .AnyAsync(x =>
            x.Barcode == barcode &&
            (!excludeId.HasValue ||
             x.Id != excludeId.Value));
}
}