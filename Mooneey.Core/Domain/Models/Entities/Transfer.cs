namespace Mooneey.Core.Domain.Models.Entities;

public class Transfer : EntityBase
{
    public Guid AccountId { get; set; }
    public Account? Account { get; set; }
    public Guid ToAccountId { get; set; }
    public Account? ToAccount { get; set; }
    public decimal OutcomeAmount { get; set; }
    public decimal IncomeAmount { get; set; }
    public string? Comment { get; set; }
    public DateTime TransferDate { get; set; }

    public decimal GetAmount(Guid accountId)
    {
        return AccountId == accountId ? -OutcomeAmount : ToAccountId == accountId ? IncomeAmount : 0;
    }
}