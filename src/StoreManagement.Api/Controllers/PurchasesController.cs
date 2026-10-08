using Microsoft.AspNetCore.Mvc;
using StoreManagement.Application.DTOs.Purchases;
using StoreManagement.Application.Interfaces;

namespace StoreManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchasesController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchasesController(
        IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PurchaseResponse>>> GetAll()
    {
        var purchases =
            await _purchaseService.GetAllAsync();

        return Ok(purchases);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PurchaseResponse>> GetById(
        Guid id)
    {
        var purchase =
            await _purchaseService.GetByIdAsync(id);

        if (purchase is null)
        {
            return NotFound();
        }

        return Ok(purchase);
    }

    [HttpPost]
    public async Task<ActionResult<PurchaseResponse>> Create(
        CreatePurchaseRequest request)
    {
        var purchase =
            await _purchaseService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = purchase.Id },
            purchase);
    }
}