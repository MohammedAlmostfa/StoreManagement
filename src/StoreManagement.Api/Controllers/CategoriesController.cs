using Microsoft.AspNetCore.Mvc;
using StoreManagement.Application.DTOs.Categories;
using StoreManagement.Application.Interfaces;

namespace StoreManagement.Api.Controllers;

/// <summary>
/// Provides category-related HTTP endpoints.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoriesController"/> class.
    /// </summary>
    /// <param name="categoryService">The category business service.</param>
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A list of categories.</returns>
    [HttpGet]
    public async Task<ActionResult<List<CategoryResponse>>> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();

        return Ok(categories);
    }

    /// <summary>
    /// Retrieves a category by identifier.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <returns>The matching category or NotFound.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryResponse>> GetById(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="request">The category payload.</param>
    /// <returns>The created category response.</returns>
    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> Create(CreateCategoryRequest request)
    {
        var category = await _categoryService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <param name="request">Updated category data.</param>
    /// <returns>NoContent when the operation succeeds.</returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateCategoryRequest request)
    {
        await _categoryService.UpdateAsync(id, request);

        return NoContent();
    }

    /// <summary>
    /// Deletes a category.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <returns>NoContent when the operation succeeds.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryService.DeleteAsync(id);

        return NoContent();
    }
}