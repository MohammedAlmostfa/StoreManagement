namespace StoreManagement.Application.DTOs.Products;

public class UpdateProductRequest
{
    public string Name { get; set; } = string.Empty;

    public string SKU { get; set; } = string.Empty;

    public string? Barcode { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal SalePrice { get; set; }

    public Guid CategoryId { get; set; }
}