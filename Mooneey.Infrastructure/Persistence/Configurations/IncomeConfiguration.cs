using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Domain;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.ToTable("Income");

        builder.Property(x => x.Amount).IsRequired();
        
        builder.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId);
    }
}