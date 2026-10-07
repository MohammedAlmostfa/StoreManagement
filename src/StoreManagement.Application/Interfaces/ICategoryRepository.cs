using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Interfaces;

/// <summary>
/// Defines the contract for category persistence operations.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <returns>The category if found; otherwise null.</returns>
    Task<Category?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A list of categories.</returns>
    Task<List<Category>> GetAllAsync();

    /// <summary>
    /// Adds a category.
    /// </summary>
    /// <param name="category">The category to add.</param>
    Task AddAsync(Category category);

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="category">The updated category.</param>
    Task UpdateAsync(Category category);

    /// <summary>
    /// Removes a category.
    /// </summary>
    /// <param name="category">The category to delete.</param>
    Task DeleteAsync(Category category);
}