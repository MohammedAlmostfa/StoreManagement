using StoreManagement.Application.DTOs.Suppliers;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(
        ISupplierRepository supplierRepository,
        IUnitOfWork unitOfWork)
    {
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<SupplierResponse> CreateAsync(
        CreateSupplierRequest request)
    {
        var supplier = new Supplier(
            request.Name,
            request.Phone,
            request.Email,
            request.Address);

        await _supplierRepository.AddAsync(supplier);

        await _unitOfWork.SaveChangesAsync();

        return MapToResponse(supplier);
    }

    public async Task<SupplierResponse?> GetByIdAsync(
        Guid id)
    {
        var supplier =
            await _supplierRepository.GetByIdAsync(id);

        if (supplier is null)
        {
            return null;
        }

        return MapToResponse(supplier);
    }

    public async Task<List<SupplierResponse>> GetAllAsync()
    {
        var suppliers =
            await _supplierRepository.GetAllAsync();

        return suppliers
            .Select(MapToResponse)
            .ToList();
    }

    public async Task UpdateAsync(
        Guid id,
        UpdateSupplierRequest request)
    {
        var supplier =
            await _supplierRepository.GetByIdAsync(id);

        if (supplier is null)
        {
            throw new KeyNotFoundException(
                "Supplier not found.");
        }

        supplier.Update(
            request.Name,
            request.Phone,
            request.Email,
            request.Address);

        await _supplierRepository.UpdateAsync(supplier);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var supplier =
            await _supplierRepository.GetByIdAsync(id);

        if (supplier is null)
        {
            throw new KeyNotFoundException(
                "Supplier not found.");
        }

        await _supplierRepository.DeleteAsync(supplier);

        await _unitOfWork.SaveChangesAsync();
    }

    private static SupplierResponse MapToResponse(
        Supplier supplier)
    {
        return new SupplierResponse
        {
            Id = supplier.Id,
            Name = supplier.Name,
            Phone = supplier.Phone,
            Email = supplier.Email,
            Address = supplier.Address,
            IsActive = supplier.IsActive
        };
    }

    public async Task DeactivateAsync(Guid id)
{
    var supplier =
        await _supplierRepository.GetByIdAsync(id);

    if (supplier is null)
    {
        throw new KeyNotFoundException(
            "Supplier not found.");
    }

    supplier.Deactivate();

    await _unitOfWork.SaveChangesAsync();
}

public async Task ActivateAsync(Guid id)
{
    var supplier =
        await _supplierRepository.GetByIdAsync(id);

    if (supplier is null)
    {
        throw new KeyNotFoundException(
            "Supplier not found.");
    }

    supplier.Activate();

    await _unitOfWork.SaveChangesAsync();
}
}