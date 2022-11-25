using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Entity;

public class CategoryViewModel
{
    [JsonPropertyName("id")] 
    public Guid Id { get; set; }

    [JsonPropertyName("name")] 
    public string? Name { get; set; }

    [JsonPropertyName("createdAt")] 
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")] 
    public DateTime UpdatedAt { get; set; }

    public static CategoryViewModel FromDomain(Category category) => new()
    {
        Id = category.Id,
        Name = category.Name,
        CreatedAt = category.CreatedAt,
        UpdatedAt = category.UpdatedAt
    };
}