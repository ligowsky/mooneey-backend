using Microsoft.EntityFrameworkCore;

namespace Mooneey.Application;

public abstract class AppDbContext : DbContext
{
    protected AppDbContext(DbContextOptions options) : base(options)
    {
    }
}