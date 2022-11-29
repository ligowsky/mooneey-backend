using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Domain;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public abstract class EntityBaseAuditableConfiguration<T> : EntityBaseConfiguration<T>
    where T : EntityBaseAuditable
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
       base.Configure(builder);
       
       builder.Property(r => r.CreatedAt).IsRequired();

       builder.Property(r => r.UpdatedAt).IsRequired();
    }
}