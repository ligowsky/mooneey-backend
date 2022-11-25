using System;
using Microsoft.EntityFrameworkCore;
using Mooneey.Core.Contexts;
using Mooneey.Core.Interfaces;
using Mooneey.Core.Models.Entities;

namespace Mooneey.Core.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var records = await _db.Set<Category>().ToListAsync<Category>();

            return records;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var record = await _db.Set<Category>()
                 .Where(r => r.Id == id)
                 .FirstOrDefaultAsync();

            if (record is null)
            {
                throw new Exception($"Category with id = '{id}' was not found.");
            }

            return record;
        }

        public async Task<Category> CreateAsync(Category request)
        {
            await _db.Set<Category>().AddAsync(request);
            await _db.SaveChangesAsync();

            return request;
        }

        public async Task<Category> UpdateAsync(Guid id, Category request)
        {
            var record = await _db.Set<Category>()
                 .Where(r => r.Id == id)
                 .FirstOrDefaultAsync();

            if (record is null)
            {
                throw new Exception($"Category with id = '{id}' was not found.");
            }

            record.Name = request.Name;
            record.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return record;
        }

        public async Task DeleteAsync(Guid id)
        {
            var record = await _db.Set<Category>()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (record is null)
            {
                throw new Exception($"Category with id = '{id}' was not found.");
            }

            _db.Set<Category>().Remove(record);
            await _db.SaveChangesAsync();
        }
    }
}

