using StoreManagement.Application.DTOs.Categories;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Services;

/// <summary>
/// Provides business logic for category management operations.
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryService"/> class.
    /// </summary>
    /// <param name="categoryRepository">Repository used to access category data.</param>
    /// <param name="unitOfWork">Unit of work used to persist changes.</param>
    public CategoryService(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<CategoryResponse> CreateAsync(CreateCategoryRequest request)
    {
        var category = new Category(request.Name);

        await _categoryRepository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();

        return MapToResponse(category);
    }

    /// <inheritdoc />
    public async Task<CategoryResponse?> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            throw new KeyNotFoundException("Category not found.");
        }

        return MapToResponse(category);
    }

    /// <inheritdoc />
    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories
            .Select(MapToResponse)
            .ToList();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Guid id, UpdateCategoryRequest request)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            throw new KeyNotFoundException("Category not found.");
        }

        category.Update(request.Name);

        await _categoryRepository.UpdateAsync(category);
        await _unitOfWork.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            throw new KeyNotFoundException("Category not found.");
        }

        await _categoryRepository.DeleteAsync(category);
        await _unitOfWork.SaveChangesAsync();
    }

    /// <summary>
    /// Maps a domain entity to a category response object.
    /// </summary>
    /// <param name="category">The category entity.</param>
    /// <returns>The mapped category response.</returns>
    private static CategoryResponse MapToResponse(Category category)
    {
        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            IsActive = category.IsActive
        };
    }
}