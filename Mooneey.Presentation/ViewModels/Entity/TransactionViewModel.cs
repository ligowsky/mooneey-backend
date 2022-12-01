using BitzArt;
using Mooneey.Domain;

namespace Mooneey.Presentation;

public class TransactionViewModel : EntityBaseAuditableViewModel
{
    public TransactionType TransactionType { get; set; }
    public object? Details { get; set; }
    public string? Comment { get; set; }

    public static TransactionViewModel FromDomain(Transaction input) => new()
    {
        Id = input.Id,
        TransactionType = GetTransactionType(input),
        Details = GetDetails(input),
        Comment = input.Comment,
        CreatedAt = input.CreatedAt,
        UpdatedAt = input.UpdatedAt
    };

    private static TransactionType GetTransactionType(Transaction input)
    {
        return input switch
        {
            Income => TransactionType.Income,
            Expense => TransactionType.Expense,
            Transfer => TransactionType.Transfer,
            _ => throw ApiException.Custom("Unknown transaction type")
        };
    }
    
    private static object GetDetails(Transaction input)
    {
        return input switch
        {
            Income income => IncomeDetailsViewModel.FromDomain(income),
            Expense expense => ExpenseDetailsViewModel.FromDomain(expense),
            Transfer => TransactionType.Transfer,
            _ => throw ApiException.Custom("Unknown transaction type")
        };
    }
}