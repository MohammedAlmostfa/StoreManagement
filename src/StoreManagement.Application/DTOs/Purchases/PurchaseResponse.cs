namespace StoreManagement.Application.DTOs.Purchases;

public class PurchaseResponse
{
    public Guid Id { get; set; }

    public Guid SupplierId { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime PurchaseDate { get; set; }

    public decimal TotalAmount { get; set; }

    public List<PurchaseItemResponse> Items { get; set; } = new();
}