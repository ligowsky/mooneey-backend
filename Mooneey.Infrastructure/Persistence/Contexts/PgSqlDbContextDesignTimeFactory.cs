using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mooneey.Infrastructure.Persistence.Contexts;

public class PgSqlDbContextDesignTimeFactory : IDesignTimeDbContextFactory<PgSqlDbContext>
{
    public PgSqlDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<PgSqlDbContext>();
        builder.UseNpgsql("Host=localhost;Database=mooneey;User Id=postgres;Password=changeme");

        return new PgSqlDbContext(builder.Options);
    }
}