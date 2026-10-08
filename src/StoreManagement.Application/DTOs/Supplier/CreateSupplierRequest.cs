using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Application.DTOs.Suppliers;

public class CreateSupplierRequest
{
    [Required(ErrorMessage = "Supplier name is required.")]
    [MaxLength(
        200,
        ErrorMessage = "Supplier name cannot exceed 200 characters.")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(
        50,
        ErrorMessage = "Phone cannot exceed 50 characters.")]
    public string? Phone { get; set; }

    [EmailAddress(
        ErrorMessage = "Invalid email address.")]
    [MaxLength(
        200,
        ErrorMessage = "Email cannot exceed 200 characters.")]
    public string? Email { get; set; }

    [MaxLength(
        300,
        ErrorMessage = "Address cannot exceed 300 characters.")]
    public string? Address { get; set; }
}