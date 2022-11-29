using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Domain;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : EntityBaseAuditableConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder.ToTable("Transactions");
        
        builder.Property(r => r.Timestamp)
            .IsRequired();

        builder.Property(r => r.Comment)
            .HasMaxLength(256);
    }
}