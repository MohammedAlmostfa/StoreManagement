namespace StoreManagement.Domain.Entities;

/// <summary>
/// Represents a logical product category used to organize inventory.
/// </summary>
public class Category
{
    /// <summary>
    /// Unique category identifier.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Name of the category.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Indicates whether the category is active.
    /// </summary>
    public bool IsActive { get; private set; }

    private Category()
    {
    }

    /// <summary>
    /// Initializes a new category instance.
    /// </summary>
    /// <param name="name">Category name.</param>
    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsActive = true;
    }

    /// <summary>
    /// Updates the category name.
    /// </summary>
    /// <param name="name">The updated category name.</param>
    public void Update(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Category name is required.");
        }

        Name = name;
    }
}