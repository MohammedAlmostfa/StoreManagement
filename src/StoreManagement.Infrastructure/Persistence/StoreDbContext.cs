using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Entities;
using StoreManagement.Application.Interfaces;
namespace StoreManagement.Infrastructure.Persistence;

public class StoreDbContext : DbContext, IUnitOfWork
{
    public StoreDbContext(
        DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }public DbSet<Product> Products =>Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(StoreDbContext).Assembly);
    }

    
}