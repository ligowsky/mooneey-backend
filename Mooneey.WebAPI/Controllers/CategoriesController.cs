using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mooneey.Core.Interfaces;
using Mooneey.Presentation.ViewModels.Entity;
using Mooneey.Presentation.ViewModels.Request;

namespace Mooneey.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllCategories")]
        public async Task<IActionResult> GetAllAsync()
        {
            var records = await _repository.GetAllAsync();
            var result = records.Select(record => CategoryViewModel.FromDomain(record));

            return Ok(result);
        }

        [HttpGet("{id:guid}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var record = await _repository.GetByIdAsync(id);
            var result = CategoryViewModel.FromDomain(record);

            return Ok(result);
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateRequest request)
        {
            var record = CategoryCreateRequest.ToDomain(request);
            var createdRecord = await _repository.CreateAsync(record);
            var result = CategoryViewModel.FromDomain(createdRecord);

            return CreatedAtRoute("GetById", new { Id = result.Id }, result);
        }

        [HttpPut("{id:guid}", Name = "UpdateCategory")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CategoryUpdateRequest request)
        {
            var record = CategoryUpdateRequest.ToDomain(request);
            var updatedRecord = await _repository.UpdateAsync(id, record);
            var result = CategoryViewModel.FromDomain(updatedRecord);

            return Ok(result);
        }

        [HttpDelete("{id:guid}", Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);

            return Ok();
        }
    }
}

