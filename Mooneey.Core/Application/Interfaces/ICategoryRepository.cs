using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Core.Application.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(Guid id);
    Task<Category> CreateAsync(Category category);
    Task<Category> UpdateAsync(Guid id, Category category);
    Task DeleteAsync(Guid id);
}