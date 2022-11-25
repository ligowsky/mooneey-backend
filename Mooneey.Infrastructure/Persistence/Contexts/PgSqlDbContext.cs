using Microsoft.EntityFrameworkCore;
using Mooneey.Core.Application.Contexts;

namespace Mooneey.Infrastructure.Persistence.Contexts;

public class PgSqlDbContext : AppDbContext
{
    public PgSqlDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PgSqlDbContext).Assembly);
    }
}