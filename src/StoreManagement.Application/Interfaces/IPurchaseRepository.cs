using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Interfaces;

public interface IPurchaseRepository
{
    Task<Purchase?> GetByIdAsync(Guid id);

    Task<List<Purchase>> GetAllAsync();

    Task AddAsync(Purchase purchase);

    Task UpdateAsync(Purchase purchase);

    Task DeleteAsync(Purchase purchase);
}