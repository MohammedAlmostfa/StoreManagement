namespace StoreManagement.Application.DTOs.Products;

/// <summary>
/// Represents the public product data returned to clients.
/// </summary>
public class ProductResponse
{
    /// <summary>
    /// Unique product identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Product SKU.
    /// </summary>
    public string SKU { get; set; } = string.Empty;

    /// <summary>
    /// Product barcode, if available.
    /// </summary>
    public string? Barcode { get; set; }

    /// <summary>
    /// Product purchase cost.
    /// </summary>
    public decimal PurchasePrice { get; set; }

    /// <summary>
    /// Selling price for customers.
    /// </summary>
    public decimal SalePrice { get; set; }

    /// <summary>
    /// Category relationship identifier.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Indicates whether the product is active.
    /// </summary>
    public bool IsActive { get; set; }
}