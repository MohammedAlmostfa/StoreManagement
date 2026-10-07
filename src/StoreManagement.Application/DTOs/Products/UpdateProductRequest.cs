using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Application.DTOs.Products;

/// <summary>
/// Represents the payload used to update an existing product.
/// </summary>
public class UpdateProductRequest
{
    /// <summary>
    /// Updated product name.
    /// </summary>
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Updated SKU.
    /// </summary>
    [MaxLength(100)]
    public string SKU { get; set; } = string.Empty;

    /// <summary>
    /// Updated barcode value.
    /// </summary>
    [MaxLength(100)]
    public string? Barcode { get; set; }

    /// <summary>
    /// Updated purchase price.
    /// </summary>
    [Range(0, double.MaxValue , ErrorMessage = "Purchase price must be a positive value.")]
    public decimal PurchasePrice { get; set; }

    /// <summary>
    /// Updated sale price.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "Sale price must be a positive value.")]
    public decimal SalePrice { get; set; }

    /// <summary>
    /// Product category identifier.
    /// </summary>
    [Required (ErrorMessage = "Category ID is required.")]
    public Guid CategoryId { get; set; }
}