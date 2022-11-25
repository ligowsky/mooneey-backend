using Mooneey.Core.Domain.Enums;

namespace Mooneey.Core.Domain.Models.Entities;

public class Transaction : EntityBase
{
    public TransactionTypeEnum TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string? Comment { get; set; }

    public Guid AccountId { get; set; }
    public Account? Account { get; set; }

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}