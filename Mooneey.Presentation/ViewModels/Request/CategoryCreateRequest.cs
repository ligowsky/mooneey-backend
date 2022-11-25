using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Request;

public class CategoryCreateRequest
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	public static Category ToDomain(CategoryCreateRequest category) => new()
	{
		Name = category.Name
	};
}