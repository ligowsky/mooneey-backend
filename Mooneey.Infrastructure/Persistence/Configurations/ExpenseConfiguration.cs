using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses");

        builder.Property(x => x.Amount).IsRequired();
        
        builder.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId);
    }
}