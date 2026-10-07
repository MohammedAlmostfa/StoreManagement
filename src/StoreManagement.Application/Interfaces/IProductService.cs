using StoreManagement.Application.DTOs.Products;

namespace StoreManagement.Application.Interfaces;

/// <summary>
/// Defines the contract for product domain operations.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="request">The product creation data.</param>
    /// <returns>The created product.</returns>
    Task<ProductResponse> CreateAsync(CreateProductRequest request);

    /// <summary>
    /// Retrieves a product by identifier.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <returns>The product if found; otherwise null.</returns>
    Task<ProductResponse?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A list of products.</returns>
    Task<List<ProductResponse>> GetAllAsync();

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <param name="request">The updated product data.</param>
    Task UpdateAsync(Guid id, UpdateProductRequest request);

    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    Task DeleteAsync(Guid id);
}