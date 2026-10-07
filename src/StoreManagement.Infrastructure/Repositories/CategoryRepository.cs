using Microsoft.EntityFrameworkCore;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;
using StoreManagement.Infrastructure.Persistence;

namespace StoreManagement.Infrastructure.Repositories;

/// <summary>
/// Data access implementation responsible for category persistence.
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private readonly StoreDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="context">The EF Core database context.</param>
    public CategoryRepository(StoreDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <inheritdoc />
    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    /// <inheritdoc />
    public Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);

        return Task.CompletedTask;
    }
}