using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Application.DTOs.Purchases;

public class CreatePurchaseRequest
{
    public Guid SupplierId { get; set; }

    [Required]
    [MinLength(
        1,
        ErrorMessage = "Purchase must contain at least one item.")]
    public List<CreatePurchaseItemRequest> Items { get; set; } = new();
}