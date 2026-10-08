using Microsoft.EntityFrameworkCore;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;
using StoreManagement.Infrastructure.Persistence;

namespace StoreManagement.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly StoreDbContext _context;

    public SupplierRepository(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<Supplier?> GetByIdAsync(Guid id)
    {
        return await _context.Suppliers
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Supplier>> GetAllAsync()
    {
        return await _context.Suppliers
            .ToListAsync();
    }

    public async Task AddAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
    }

    public Task UpdateAsync(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Supplier supplier)
    {
        _context.Suppliers.Remove(supplier);

        return Task.CompletedTask;
    }
}