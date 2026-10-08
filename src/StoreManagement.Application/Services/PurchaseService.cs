using StoreManagement.Application.DTOs.Purchases;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PurchaseService(
        IPurchaseRepository purchaseRepository,
        ISupplierRepository supplierRepository,
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _purchaseRepository = purchaseRepository;
        _supplierRepository = supplierRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PurchaseResponse> CreateAsync(
        CreatePurchaseRequest request)
    {
        var supplier =
            await _supplierRepository.GetByIdAsync(
                request.SupplierId);

        if (supplier is null)
        {
            throw new KeyNotFoundException(
                "Supplier not found.");
        }

        if (request.Items.Count == 0)
        {
            throw new ArgumentException(
                "Purchase must contain at least one item.");
        }

        var purchase = new Purchase(
            request.SupplierId);

        foreach (var item in request.Items)
        {
            var product =
                await _productRepository.GetByIdAsync(
                    item.ProductId);

            if (product is null)
            {
                throw new KeyNotFoundException(
                    $"Product with ID {item.ProductId} not found.");
            }

            purchase.AddItem(
                item.ProductId,
                item.Quantity,
                item.UnitPrice);
        }

        await _purchaseRepository.AddAsync(purchase);

        await _unitOfWork.SaveChangesAsync();

        return MapToResponse(purchase);
    }

    public async Task<PurchaseResponse?> GetByIdAsync(
        Guid id)
    {
        var purchase =
            await _purchaseRepository.GetByIdAsync(id);

        if (purchase is null)
        {
            return null;
        }

        return MapToResponse(purchase);
    }

    public async Task<List<PurchaseResponse>> GetAllAsync()
    {
        var purchases =
            await _purchaseRepository.GetAllAsync();

        return purchases
            .Select(MapToResponse)
            .ToList();
    }

    private static PurchaseResponse MapToResponse(
        Purchase purchase)
    {
        return new PurchaseResponse
        {
            Id = purchase.Id,
            SupplierId = purchase.SupplierId,
            Status = purchase.Status.ToString(),
            PurchaseDate = purchase.PurchaseDate,
            TotalAmount = purchase.TotalAmount,

            Items = purchase.Items
                .Select(item => new PurchaseItemResponse
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Total = item.Total
                })
                .ToList()
        };
    }
}