namespace Mooneey.Domain;

public class Income : Transaction
{
    private Income()
    {
    }

    public Income(Account account, decimal amount, DateTime timestamp, string? comment)
    {
        AccountId = account.Id;
        Account = account;
        Amount = amount;
        Timestamp = timestamp;
        Comment = comment;

        Accounts = new List<Account> { account };
    }

    public Guid AccountId { get; set; }
    public Account? Account { get; set; }
    public decimal Amount { get; set; }

    public override void Apply()
    {
        Account?.UpdateBalance(Amount);
    }

    public override void Revert()
    {
        Account?.UpdateBalance(-Amount);
    }

    public void Update(IncomeUpdateRequest request)
    {
        Revert();

        Amount = request.Amount ?? Amount;
        Timestamp = request.Timestamp ?? Timestamp;
        Comment = request.Comment ?? Comment;
        UpdatedAt = DateTime.UtcNow;
        
        Apply();
    }
}