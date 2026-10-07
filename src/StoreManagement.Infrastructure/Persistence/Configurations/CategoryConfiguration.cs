using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Domain.Entities;

namespace StoreManagement.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration
    : IEntityTypeConfiguration<Category>
{
    public void Configure(
        EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}