using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Interfaces;

public interface IStockRepository
{
    Task<Stock?> GetByProductIdAsync(Guid productId);

    Task AddAsync(Stock stock);
}