using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);

    Task<List<Product>> GetAllAsync();

    Task AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);
    Task<bool> ExistsBySkuAsync(
    string sku,
    Guid? excludeId = null);

Task<bool> ExistsByBarcodeAsync(
    string barcode,
    Guid? excludeId = null);
}