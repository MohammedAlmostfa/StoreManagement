using StoreManagement.Domain.Enums;

namespace StoreManagement.Domain.Entities;

public class StockMovement
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public Guid WarehouseId { get; private set; }

    public decimal Quantity { get; private set; }

    public StockMovementType Type { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private StockMovement()
    {
    }


    public StockMovement(
        Guid productId,
        Guid warehouseId,
        decimal quantity,
        StockMovementType type)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        WarehouseId = warehouseId;
        Quantity = quantity;
        Type = type;
        CreatedAt = DateTime.UtcNow;
    }
}