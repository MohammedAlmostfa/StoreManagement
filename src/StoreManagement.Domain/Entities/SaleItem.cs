namespace StoreManagement.Domain.Entities;

public class SaleItem
{
    public Guid Id { get; private set; }

    public Guid SaleId { get; private set; }

    public Guid ProductId { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal Total =>
        Quantity * UnitPrice;

    private SaleItem()
    {
    }

    public SaleItem(
        Guid saleId,
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
        SaleId = saleId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}