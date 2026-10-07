using StoreManagement.Domain.Enums;

namespace StoreManagement.Domain.Entities;

public class Purchase
{
    public Guid Id { get; private set; }

    public Guid SupplierId { get; private set; }

    public PurchaseStatus Status { get; private set; }

    public DateTime PurchaseDate { get; private set; }

    public decimal TotalAmount { get; private set; }

    private Purchase()
    {
    }

    public Purchase(Guid supplierId)
    {
        Id = Guid.NewGuid();
        SupplierId = supplierId;
        Status = PurchaseStatus.Draft;
        PurchaseDate = DateTime.UtcNow;
        TotalAmount = 0;
    }

    public void Confirm()
    {
        if (Status != PurchaseStatus.Draft)
        {
            throw new InvalidOperationException(
                "Only draft purchases can be confirmed.");
        }

        Status = PurchaseStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == PurchaseStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "Confirmed purchases cannot be cancelled.");
        }

        Status = PurchaseStatus.Cancelled;
    }
}