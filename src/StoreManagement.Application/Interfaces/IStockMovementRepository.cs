using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Interfaces;

public interface IStockMovementRepository
{
    Task AddAsync(StockMovement movement);
}