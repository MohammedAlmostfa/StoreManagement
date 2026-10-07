namespace StoreManagement.Application.DTOs.Categories;

/// <summary>
/// Represents category data returned to API clients.
/// </summary>
public class CategoryResponse
{
    /// <summary>
    /// Unique category identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Category display name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the category remains active.
    /// </summary>
    public bool IsActive { get; set; }
}