public class Stock
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public decimal Quantity { get; private set; }

    private Stock()
    {
    }

    public Stock(Guid productId)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
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