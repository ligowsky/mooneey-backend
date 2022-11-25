using System;
using Microsoft.EntityFrameworkCore;

namespace Mooneey.Core.Contexts
{
    public abstract class AppDbContext : DbContext
    {
        protected AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

