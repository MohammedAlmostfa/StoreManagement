using StoreManagement.Domain.Enums;

namespace StoreManagement.Domain.Entities;

public class StockMovement
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public decimal Quantity { get; private set; }

    public StockMovementType Type { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private StockMovement()
    {
    }

    public StockMovement(
        Guid productId,
        decimal quantity,
        StockMovementType type)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException(
                "Quantity must be greater than zero.");
        }

        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        Type = type;
        CreatedAt = DateTime.UtcNow;
    }
}