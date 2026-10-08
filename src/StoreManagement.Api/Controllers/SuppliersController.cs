using Microsoft.AspNetCore.Mvc;
using StoreManagement.Application.DTOs.Suppliers;
using StoreManagement.Application.Interfaces;

namespace StoreManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(
        ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SupplierResponse>>> GetAll()
    {
        var suppliers =
            await _supplierService.GetAllAsync();

        return Ok(suppliers);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SupplierResponse>> GetById(
        Guid id)
    {
        var supplier =
            await _supplierService.GetByIdAsync(id);

        if (supplier is null)
        {
            return NotFound();
        }

        return Ok(supplier);
    }

    [HttpPost]
    public async Task<ActionResult<SupplierResponse>> Create(
        CreateSupplierRequest request)
    {
        var supplier =
            await _supplierService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = supplier.Id },
            supplier);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateSupplierRequest request)
    {
        await _supplierService.UpdateAsync(
            id,
            request);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        await _supplierService.DeleteAsync(id);

        return NoContent();
    }


    [HttpPatch("{id:guid}/deactivate")]
public async Task<IActionResult> Deactivate(Guid id)
{
    await _supplierService.DeactivateAsync(id);

    return NoContent();
}

[HttpPatch("{id:guid}/activate")]
public async Task<IActionResult> Activate(Guid id)
{
    await _supplierService.ActivateAsync(id);

    return NoContent();
}
}