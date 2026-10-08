namespace StoreManagement.Application.DTOs.Purchases;

public class PurchaseItemResponse
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total { get; set; }
}