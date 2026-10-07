using Microsoft.EntityFrameworkCore;
using StoreManagement.Application.Interfaces;
using StoreManagement.Domain.Entities;
using StoreManagement.Infrastructure.Persistence;

namespace StoreManagement.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly StoreDbContext _context;

    public CategoryRepository(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories
            .ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);

        return Task.CompletedTask;
    }
}