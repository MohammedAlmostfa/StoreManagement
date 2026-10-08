using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Application.DTOs.Purchases;

public class CreatePurchaseItemRequest
{
    public Guid ProductId { get; set; }

    [Range(
        0.001,
        double.MaxValue,
        ErrorMessage = "Quantity must be greater than zero.")]
    public decimal Quantity { get; set; }

    [Range(
        0,
        double.MaxValue,
        ErrorMessage = "Unit price cannot be negative.")]
    public decimal UnitPrice { get; set; }
}