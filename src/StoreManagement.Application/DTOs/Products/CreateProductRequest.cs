using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Application.DTOs.Products;

public class CreateProductRequest
{
    [Required(ErrorMessage = "Product name is required.")]
    [MaxLength(200, ErrorMessage = "Product name cannot exceed 200 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "SKU is required.")]
    [MaxLength(100, ErrorMessage = "SKU cannot exceed 100 characters.")]
    public string SKU { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = "Barcode cannot exceed 100 characters.")]
    public string? Barcode { get; set; }

    [Range(
        0,
        double.MaxValue,
        ErrorMessage = "Purchase price cannot be negative.")]
    public decimal PurchasePrice { get; set; }

    [Range(
        0,
        double.MaxValue,
        ErrorMessage = "Sale price cannot be negative.")]
    public decimal SalePrice { get; set; }

    public Guid CategoryId { get; set; }
}