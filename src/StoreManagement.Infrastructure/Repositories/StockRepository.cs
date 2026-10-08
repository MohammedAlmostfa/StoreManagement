using Microsoft.EntityFrameworkCore;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;
using StoreManagement.Infrastructure.Persistence;

namespace StoreManagement.Infrastructure.Repositories;

public class StockRepository : IStockRepository
{
    private readonly StoreDbContext _context;

    public StockRepository(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<Stock?> GetByProductIdAsync(
        Guid productId)
    {
        return await _context.Stocks
            .FirstOrDefaultAsync(x =>
                x.ProductId == productId);
    }

    public async Task AddAsync(Stock stock)
    {
        await _context.Stocks.AddAsync(stock);
    }
}