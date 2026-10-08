using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;
using StoreManagement.Infrastructure.Persistence;

namespace StoreManagement.Infrastructure.Repositories;

public class StockMovementRepository
    : IStockMovementRepository
{
    private readonly StoreDbContext _context;

    public StockMovementRepository(
        StoreDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        StockMovement movement)
    {
        await _context.StockMovements
            .AddAsync(movement);
    }
}