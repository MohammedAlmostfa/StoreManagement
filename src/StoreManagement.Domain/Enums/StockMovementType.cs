namespace StoreManagement.Domain.Enums;

/// <summary>
/// Defines the type of stock movement recorded in the system.
/// </summary>
public enum StockMovementType
{
    Purchase = 1,
    Sale = 2,
    Adjustment = 3,
    Transfer = 4
}