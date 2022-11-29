using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Domain;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("Transfers");

        builder.Property(x => x.SourceAmount).IsRequired();
        builder.Property(x => x.TargetAmount).IsRequired();

        builder.HasOne(x => x.SourceAccount).WithMany().HasForeignKey(x => x.SourceAccountId);
        builder.HasOne(x => x.TargetAccount).WithMany().HasForeignKey(x => x.TargetAccountId);
    }
}