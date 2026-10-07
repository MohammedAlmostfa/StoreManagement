using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Application.DTOs.Categories;

/// <summary>
/// Represents the payload used to update an existing category.
/// </summary>
public class UpdateCategoryRequest
{
    /// <summary>
    /// Updated category name.
    /// </summary>
    [Required (ErrorMessage = "Category name is required.")]
    [MaxLength(150, ErrorMessage = "Category name cannot exceed 150 characters.")]
    public string Name { get; set; } = string.Empty;
}