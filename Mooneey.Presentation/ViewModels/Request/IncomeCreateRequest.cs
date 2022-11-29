namespace Mooneey.Presentation;

public class IncomeCreateRequest
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }

    public Mooneey.Domain.IncomeCreateRequest ToDomain() => new()
    {
        AccountId = AccountId,
        Amount = Amount,
    };
}