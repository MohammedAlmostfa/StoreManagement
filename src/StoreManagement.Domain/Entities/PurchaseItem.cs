namespace StoreManagement.Domain.Entities;

public class PurchaseItem
{
    public Guid Id { get; private set; }

    public Guid PurchaseId { get; private set; }

    public Guid ProductId { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal Total =>
        Quantity * UnitPrice;

    private PurchaseItem()
    {
    }

    public PurchaseItem(
        Guid purchaseId,
        Guid productId,
        decimal quantity,
        decimal unitPrice)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException(
                "Quantity must be greater than zero.");
        }

        if (unitPrice < 0)
        {
            throw new ArgumentException(
                "Unit price cannot be negative.");
        }

        Id = Guid.NewGuid();
        PurchaseId = purchaseId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}