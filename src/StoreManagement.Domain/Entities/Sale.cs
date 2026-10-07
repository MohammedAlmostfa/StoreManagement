using StoreManagement.Domain.Enums;

namespace StoreManagement.Domain.Entities;

public class Sale
{
    public Guid Id { get; private set; }

    public Guid? CustomerId { get; private set; }

    public Guid WarehouseId { get; private set; }

    public SaleStatus Status { get; private set; }

    public DateTime SaleDate { get; private set; }

    public decimal TotalAmount { get; private set; }

    private Sale()
    {
    }

    public Sale(
        Guid warehouseId,
        Guid? customerId = null)
    {
        Id = Guid.NewGuid();
        WarehouseId = warehouseId;
        CustomerId = customerId;
        Status = SaleStatus.Draft;
        SaleDate = DateTime.UtcNow;
        TotalAmount = 0;
    }

    public void Confirm()
    {
        if (Status != SaleStatus.Draft)
        {
            throw new InvalidOperationException(
                "Only draft sales can be confirmed.");
        }

        Status = SaleStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == SaleStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "Confirmed sales cannot be cancelled.");
        }

        Status = SaleStatus.Cancelled;
    }
}