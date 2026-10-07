using StoreManagement.Application.DTOs.Products;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;

namespace StoreManagement.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(
        IProductRepository productRepository,
            ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
          _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductResponse> CreateAsync(
        CreateProductRequest request)
    {

        var category =
    await _categoryRepository.GetByIdAsync(
        request.CategoryId);

if (category is null)
{
    throw new KeyNotFoundException(
        "Category not found.");
}

if (await _productRepository.ExistsBySkuAsync(request.SKU))
{
    throw new InvalidOperationException(
        "SKU already exists.");
}


if (!string.IsNullOrWhiteSpace(request.Barcode))
{
    if (await _productRepository.ExistsByBarcodeAsync(
        request.Barcode))
    {
        throw new InvalidOperationException(
            "Barcode already exists.");
    }
}
        var product = new Product(
            request.Name,
            request.SKU,
            request.PurchasePrice,
            request.SalePrice,
            request.CategoryId,
            request.Barcode);

        await _productRepository.AddAsync(product);

        return MapToResponse(product);
    }

    public async Task<ProductResponse?> GetByIdAsync(Guid id)
    {
        var product =
            await _productRepository.GetByIdAsync(id);

        if (product is null)
            return null;

        return MapToResponse(product);
    }

    public async Task<List<ProductResponse>> GetAllAsync()
    {
        var products =
            await _productRepository.GetAllAsync();

        return products
            .Select(MapToResponse)
            .ToList();
    }
public async Task UpdateAsync(
    Guid id,
    UpdateProductRequest request)
{
    var product =
        await _productRepository.GetByIdAsync(id);

    if (product is null)
    {
        throw new KeyNotFoundException(
            "Product not found.");
    }

    var category =
        await _categoryRepository.GetByIdAsync(
            request.CategoryId);

    if (category is null)
    {
        throw new KeyNotFoundException(
            "Category not found.");
    }

    product.Update(
        request.Name,
        request.SKU,
        request.PurchasePrice,
        request.SalePrice,
        request.CategoryId,
        request.Barcode);

    await _productRepository.UpdateAsync(product);

    await _unitOfWork.SaveChangesAsync();
}
    public async Task DeleteAsync(Guid id)
    {
        var product =
            await _productRepository.GetByIdAsync(id);

        if (product is null)
            throw new KeyNotFoundException(
                "Product not found.");

        await _productRepository.DeleteAsync(product);
        await _unitOfWork.SaveChangesAsync();
        
    }

    private static ProductResponse MapToResponse(
        Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            SKU = product.SKU,
            Barcode = product.Barcode,
            PurchasePrice = product.PurchasePrice,
            SalePrice = product.SalePrice,
            CategoryId = product.CategoryId,
            IsActive = product.IsActive
        };
    }
}