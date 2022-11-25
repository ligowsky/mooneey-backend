using Mooneey.Core.Application.Contexts;

namespace Mooneey.Core.Application.Repositories
{
    public class RepositoryBase
    {
        public readonly AppDbContext _db;

        protected RepositoryBase(AppDbContext db)
        {
            _db = db;
        }
    }
}