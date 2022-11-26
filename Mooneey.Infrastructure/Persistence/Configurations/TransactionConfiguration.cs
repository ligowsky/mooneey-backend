using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.TransactionType)
            .IsRequired();

        builder.Property(r => r.Amount).IsRequired();

        builder.Property(r => r.Comment)
            .HasMaxLength(256);

        builder.Property(r => r.CreatedAt).IsRequired();

        builder.Property(r => r.UpdatedAt).IsRequired();
    }
}