namespace Mooneey.Domain;

public class IncomeCreateRequest
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
}