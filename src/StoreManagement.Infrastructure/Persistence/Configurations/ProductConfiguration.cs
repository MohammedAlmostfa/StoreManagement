using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain.Entities;

namespace StoreManagement.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(
        EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.SKU)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Barcode)
            .HasMaxLength(100);

        builder.Property(x => x.PurchasePrice)
            .HasPrecision(18, 2);

        builder.Property(x => x.SalePrice)
            .HasPrecision(18, 2);

        builder.HasIndex(x => x.SKU)
            .IsUnique();

        builder.HasIndex(x => x.Barcode)
            .IsUnique();
    }
}