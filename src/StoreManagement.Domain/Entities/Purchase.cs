using StoreManagement.Domain.Enums;

namespace StoreManagement.Domain.Entities;

public class Purchase
{
    public Guid Id { get; private set; }

    public Guid SupplierId { get; private set; }

    public PurchaseStatus Status { get; private set; }

    public DateTime PurchaseDate { get; private set; }

    public decimal TotalAmount { get; private set; }

    private readonly List<PurchaseItem> _items = new();

    public IReadOnlyCollection<PurchaseItem> Items =>
        _items.AsReadOnly();

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

    public void AddItem(
        Guid productId,
        decimal quantity,
        decimal unitPrice)
    {
        if (Status != PurchaseStatus.Draft)
        {
            throw new InvalidOperationException(
                "Items can only be added to draft purchases.");
        }

        var item = new PurchaseItem(
            Id,
            productId,
            quantity,
            unitPrice);

        _items.Add(item);

        RecalculateTotal();
    }

    private void RecalculateTotal()
    {
        TotalAmount = _items.Sum(x => x.Total);
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