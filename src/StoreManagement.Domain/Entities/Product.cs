namespace StoreManagement.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string SKU { get; private set; } = string.Empty;

    public string? Barcode { get; private set; }

    public decimal PurchasePrice { get; private set; }

    public decimal SalePrice { get; private set; }

    public Guid CategoryId { get; private set; }

    public bool IsActive { get; private set; }

    private Product()
    {
    }

    public Product(
        string name,
        string sku,
        decimal purchasePrice,
        decimal salePrice,
        Guid categoryId,
        string? barcode = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        SKU = sku;
        Barcode = barcode;
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
        CategoryId = categoryId;
        IsActive = true;
    }
    public void Update(
    string name,
    string sku,
    decimal purchasePrice,
    decimal salePrice,
    Guid categoryId,
    string? barcode = null)
{
   

    Name = name;
    SKU = sku;
    Barcode = barcode;
    PurchasePrice = purchasePrice;
    SalePrice = salePrice;
    CategoryId = categoryId;
}
    
}