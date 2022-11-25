using Microsoft.EntityFrameworkCore;

namespace Mooneey.Core.Application.Contexts;

public abstract class AppDbContext : DbContext
{
    protected AppDbContext(DbContextOptions options) : base(options)
    {
    }
}