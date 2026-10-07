using StoreManagement.Application.DTOs.Products;

namespace StoreManagement.Application.Interfaces;

public interface IProductService
{
    Task<ProductResponse> CreateAsync(
        CreateProductRequest request);

    Task<ProductResponse?> GetByIdAsync(Guid id);

    Task<List<ProductResponse>> GetAllAsync();

    Task UpdateAsync(
        Guid id,
        UpdateProductRequest request);

    Task DeleteAsync(Guid id);
}