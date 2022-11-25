using System;
using Mooneey.Core.Models.Entities;

namespace Mooneey.Core.Interfaces
{
	public interface ICategoryRepository
	{
		Task<List<Category>> GetAllAsync();
		Task<Category> GetByIdAsync(Guid id);
		Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Guid id, Category category);
        Task DeleteAsync(Guid id);
	}
}

