using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.AccountType).IsRequired();

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(r => r.Balance).IsRequired();

        builder.HasMany(r => r.Transactions)
            .WithOne(r => r.Account)
            .HasForeignKey(r => r.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(r => r.CreatedAt).IsRequired();

        builder.Property(r => r.UpdatedAt).IsRequired();
    }
}