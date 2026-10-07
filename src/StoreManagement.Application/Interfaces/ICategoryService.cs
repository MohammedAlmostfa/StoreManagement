using StoreManagement.Application.DTOs.Categories;

namespace StoreManagement.Application.Interfaces;

/// <summary>
/// Defines category-related business operations.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="request">The category creation data.</param>
    /// <returns>The created category.</returns>
    Task<CategoryResponse> CreateAsync(CreateCategoryRequest request);

    /// <summary>
    /// Retrieves a category by identifier.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <returns>The category if found; otherwise null.</returns>
    Task<CategoryResponse?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A list of categories.</returns>
    Task<List<CategoryResponse>> GetAllAsync();

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <param name="request">The latest category data.</param>
    Task UpdateAsync(Guid id, UpdateCategoryRequest request);

    /// <summary>
    /// Deletes a category.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    Task DeleteAsync(Guid id);
}