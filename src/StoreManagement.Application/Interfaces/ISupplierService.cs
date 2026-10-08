using StoreManagement.Application.DTOs.Suppliers;

namespace StoreManagement.Application.Interfaces;
public interface ISupplierService
{
    Task<SupplierResponse> CreateAsync(
        CreateSupplierRequest request);

    Task<SupplierResponse?> GetByIdAsync(
        Guid id);

    Task<List<SupplierResponse>> GetAllAsync();

    Task UpdateAsync(
        Guid id,
        UpdateSupplierRequest request);

    Task DeleteAsync(Guid id);

    Task DeactivateAsync(Guid id);

    Task ActivateAsync(Guid id);
}