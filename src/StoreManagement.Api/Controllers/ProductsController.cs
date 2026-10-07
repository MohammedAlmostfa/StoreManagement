using Microsoft.AspNetCore.Mvc;
using StoreManagement.Application.DTOs.Products;
using StoreManagement.Application.Interfaces;

namespace StoreManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(
        IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetAll()
    {
        var products =
            await _productService.GetAllAsync();

        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductResponse>> GetById(
        Guid id)
    {
        var product =
            await _productService.GetByIdAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> Create(
        CreateProductRequest request)
    {
        var product =
            await _productService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateProductRequest request)
    {
        await _productService.UpdateAsync(
            id,
            request);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        await _productService.DeleteAsync(id);

        return NoContent();
    }
}