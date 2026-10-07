using Microsoft.AspNetCore.Mvc;
using StoreManagement.Application.DTOs.Products;
using StoreManagement.Application.Interfaces;

namespace StoreManagement.Api.Controllers;

/// <summary>
/// Provides product-related HTTP endpoints for creation, retrieval, updating, and deletion.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsController"/> class.
    /// </summary>
    /// <param name="productService">The product service used by the controller.</param>
    public ProductsController(
        IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Retrieves all active products.
    /// </summary>
    /// <returns>A list of products.</returns>
    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetAll()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products);
    }

    /// <summary>
    /// Retrieves a single product by its identifier.
    /// </summary>
    /// <param name="id">The unique product identifier.</param>
    /// <returns>The matching product or NotFound when it does not exist.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductResponse>> GetById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="request">The product creation data.</param>
    /// <returns>A created product response.</returns>
    [HttpPost]
    public async Task<ActionResult<ProductResponse>> Create(CreateProductRequest request)
    {
        var product = await _productService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <param name="request">The updated product data.</param>
    /// <returns>NoContent when the update succeeds.</returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductRequest request)
    {
        await _productService.UpdateAsync(id, request);

        return NoContent();
    }

    /// <summary>
    /// Deletes a product by identifier.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <returns>NoContent when the delete succeeds.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteAsync(id);

        return NoContent();
    }
}