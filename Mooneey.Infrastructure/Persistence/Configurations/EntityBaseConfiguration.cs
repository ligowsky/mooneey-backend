using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mooneey.Domain;

namespace Mooneey.Infrastructure.Persistence.Configurations;

public abstract class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T>
    where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
    }
}