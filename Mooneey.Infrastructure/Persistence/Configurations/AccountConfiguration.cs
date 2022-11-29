using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Domain;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : EntityBaseAuditableConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.AccountType).IsRequired();

        builder.Property(x => x.CurrencyCode).IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.Balance).IsRequired();
        
        builder.HasMany(x => x.Transactions)
            .WithMany(x => x.Accounts);
    }
}