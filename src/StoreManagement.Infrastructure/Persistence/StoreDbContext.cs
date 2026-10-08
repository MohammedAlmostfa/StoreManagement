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

    public DbSet<Stock> Stocks => Set<Stock>();

    public DbSet<Purchase> Purchases =>
    Set<Purchase>();

public DbSet<PurchaseItem> PurchaseItems =>
    Set<PurchaseItem>();
public DbSet<Supplier> Suppliers =>
    Set<Supplier>();public DbSet<StockMovement> StockMovements =>
    Set<StockMovement>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(StoreDbContext).Assembly);
    }

    
}