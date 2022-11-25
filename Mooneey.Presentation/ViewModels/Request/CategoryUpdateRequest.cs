using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Request;

public class CategoryUpdateRequest
{
    [JsonPropertyName("id")] 
    public Guid Id { get; set; }

    [JsonPropertyName("name")] 
    public string? Name { get; set; }

    public static Category ToDomain(CategoryUpdateRequest category) => new()
    {
        Id = category.Id,
        Name = category.Name,
    };
}