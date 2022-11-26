using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Enums;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Entity;

public class TransactionViewModel
{
    [JsonPropertyName("id")] 
    public Guid Id { get; set; }

    [JsonPropertyName("type")] 
    public TransactionTypeEnum TransactionType { get; set; }

    [JsonPropertyName("category")] 
    public CategoryViewModel? Category { get; set; }
    
    [JsonPropertyName("account")] 
    public AccountViewModel? Account { get; set; }

    [JsonPropertyName("amount")] 
    public decimal Amount { get; set; }

    [JsonPropertyName("comment")] 
    public string? Comment { get; set; }

    [JsonPropertyName("createdAt")] 
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")] 
    public DateTime UpdatedAt { get; set; }

    public static TransactionViewModel FromDomain(Transaction input) => new()
    {
        Id = input.Id,
        TransactionType = input.TransactionType,
        Category = input.Category != null ? CategoryViewModel.FromDomain(input.Category) : null,
        Account = input.Account != null ? AccountViewModel.FromDomain(input.Account) : null,
        Amount = input.Amount,
        Comment = input.Comment,
        CreatedAt = input.CreatedAt,
        UpdatedAt = input.UpdatedAt
    };
}