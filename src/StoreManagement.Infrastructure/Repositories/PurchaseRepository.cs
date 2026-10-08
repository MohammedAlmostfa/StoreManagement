using Microsoft.EntityFrameworkCore;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;
using StoreManagement.Infrastructure.Persistence;

namespace StoreManagement.Infrastructure.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly StoreDbContext _context;

    public PurchaseRepository(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<Purchase?> GetByIdAsync(Guid id)
    {
        return await _context.Purchases
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Purchase>> GetAllAsync()
    {
        return await _context.Purchases
            .Include(x => x.Items)
            .ToListAsync();
    }

    public async Task AddAsync(Purchase purchase)
    {
        await _context.Purchases.AddAsync(purchase);
    }

    public Task UpdateAsync(Purchase purchase)
    {
        _context.Purchases.Update(purchase);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Purchase purchase)
    {
        _context.Purchases.Remove(purchase);

        return Task.CompletedTask;
    }
}