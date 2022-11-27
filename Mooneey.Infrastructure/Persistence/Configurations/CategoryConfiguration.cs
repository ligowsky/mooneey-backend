using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasMany(r => r.Transactions)
            .WithOne(r => r.Category)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(r => r.CreatedAt).IsRequired();

        builder.Property(r => r.UpdatedAt).IsRequired();
    }
}