using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Interfaces;

public interface ISupplierRepository
{
    Task<Supplier?> GetByIdAsync(Guid id);

    Task<List<Supplier>> GetAllAsync();

    Task AddAsync(Supplier supplier);

    Task UpdateAsync(Supplier supplier);

    Task DeleteAsync(Supplier supplier);
}