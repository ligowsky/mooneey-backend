using Mooneey.Core.Contexts;

namespace Mooneey.Core.Repositories
{
    public class RepositoryBase
    {
        protected AppDbContext _db;

        public RepositoryBase(AppDbContext db)
        {
            _db = db;
        }
    }
}
