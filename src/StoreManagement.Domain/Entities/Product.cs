namespace StoreManagement.Domain.Entities;

/// <summary>
/// Represents an inventory product in the store.
/// </summary>
public class Product
{
    /// <summary>
    /// Unique product identifier.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Product display name.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Product SKU.
    /// </summary>
    public string SKU { get; private set; } = string.Empty;

    /// <summary>
    /// Optional barcode for product identification.
    /// </summary>
    public string? Barcode { get; private set; }

    /// <summary>
    /// Purchase cost of the product.
    /// </summary>
    public decimal PurchasePrice { get; private set; }

    /// <summary>
    /// Sale price for customers.
    /// </summary>
    public decimal SalePrice { get; private set; }

    /// <summary>
    /// Identifier of the associated category.
    /// </summary>
    public Guid CategoryId { get; private set; }

    /// <summary>
    /// Indicates whether the product remains active.
    /// </summary>
    public bool IsActive { get; private set; }

    private Product()
    {
    }

    /// <summary>
    /// Initializes a new product instance.
    /// </summary>
    /// <param name="name">Product name.</param>
    /// <param name="sku">Product SKU.</param>
    /// <param name="purchasePrice">Purchase price.</param>
    /// <param name="salePrice">Selling price.</param>
    /// <param name="categoryId">Associated category identifier.</param>
    /// <param name="barcode">Optional product barcode.</param>
    public Product(
        string name,
        string sku,
        decimal purchasePrice,
        decimal salePrice,
        Guid categoryId,
        string? barcode = null)
    {
        Validate(name, sku, purchasePrice, salePrice);

        Id = Guid.NewGuid();
        Name = name;
        SKU = sku;
        Barcode = barcode;
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
        CategoryId = categoryId;
        IsActive = true;
    }

    /// <summary>
    /// Updates the product details.
    /// </summary>
    public void Update(
        string name,
        string sku,
        decimal purchasePrice,
        decimal salePrice,
        Guid categoryId,
        string? barcode = null)
    {
        Validate(name, sku, purchasePrice, salePrice);

        Name = name;
        SKU = sku;
        Barcode = barcode;
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
        CategoryId = categoryId;
    }

    private static void Validate(
        string name,
        string sku,
        decimal purchasePrice,
        decimal salePrice)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name is required.");
        }

        if (string.IsNullOrWhiteSpace(sku))
        {
            throw new ArgumentException("SKU is required.");
        }

        if (purchasePrice < 0)
        {
            throw new ArgumentException("Purchase price cannot be negative.");
        }

        if (salePrice < 0)
        {
            throw new ArgumentException("Sale price cannot be negative.");
        }
    }
}