using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Application.DTOs.Categories;

/// <summary>
/// Represents the payload used to create a new category.
/// </summary>
public class CreateCategoryRequest
{
    /// <summary>
    /// Category name.
    /// </summary>
    [Required (ErrorMessage = "Category name is required.")]
    [MaxLength(150, ErrorMessage = "Category name cannot exceed 150 characters.")]
    public string Name { get; set; } = string.Empty;
}