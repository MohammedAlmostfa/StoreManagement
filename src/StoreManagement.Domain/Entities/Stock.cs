namespace StoreManagement.Domain.Entities;

public class Stock
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public Guid WarehouseId { get; private set; }

    public decimal Quantity { get; private set; }

    private Stock()
    {
    }

    public Stock(
        Guid productId,
        Guid warehouseId)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        WarehouseId = warehouseId;
        Quantity = 0;
    }

    public void Increase(decimal quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException(
                "Quantity must be greater than zero.");
        }

        Quantity += quantity;
    }

    public void Decrease(decimal quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException(
                "Quantity must be greater than zero.");
        }

        if (Quantity < quantity)
        {
            throw new InvalidOperationException(
                "Insufficient stock.");
        }

        Quantity -= quantity;
    }
}