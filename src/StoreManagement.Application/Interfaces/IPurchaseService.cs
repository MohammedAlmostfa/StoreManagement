using StoreManagement.Application.DTOs.Purchases;

namespace StoreManagement.Application.Interfaces;

public interface IPurchaseService
{
    Task<PurchaseResponse> CreateAsync(
        CreatePurchaseRequest request);

    Task<PurchaseResponse?> GetByIdAsync(Guid id);

    Task<List<PurchaseResponse>> GetAllAsync();
}