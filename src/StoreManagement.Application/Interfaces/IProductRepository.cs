using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Interfaces;

/// <summary>
/// Defines the data access contract for product persistence operations.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <returns>The matching product or null.</returns>
    Task<Product?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A collection of products.</returns>
    Task<List<Product>> GetAllAsync();

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="product">The product to add.</param>
    Task AddAsync(Product product);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="product">The updated product.</param>
    Task UpdateAsync(Product product);

    /// <summary>
    /// Removes a product.
    /// </summary>
    /// <param name="product">The product to delete.</param>
    Task DeleteAsync(Product product);

    /// <summary>
    /// Checks whether a product SKUs already exists.
    /// </summary>
    /// <param name="sku">The SKU to validate.</param>
    /// <param name="excludeId">Optional product id to exclude from check during update operations.</param>
    /// <returns>True if an identical SKU exists.</returns>
    Task<bool> ExistsBySkuAsync(string sku, Guid? excludeId = null);

    /// <summary>
    /// Checks whether a product barcode already exists.
    /// </summary>
    /// <param name="barcode">The barcode to validate.</param>
    /// <param name="excludeId">Optional product id to exclude from check during update operations.</param>
    /// <returns>True if an identical barcode exists.</returns>
    Task<bool> ExistsByBarcodeAsync(string barcode, Guid? excludeId = null);
}