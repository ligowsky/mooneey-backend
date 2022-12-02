namespace Mooneey.Domain;

public class Income : Transaction
{
    private Income() {}
    private Income(Account account, decimal amount, DateTime timestamp, string? comment)
    {
        AccountId = account.Id;
        Account = account;
        Amount = amount;
        Timestamp = timestamp;
        Comment = comment;

        Accounts = new List<Account> { account };
    }

    public Guid AccountId { get; private set; }
    public Account? Account { get; private set; }
    public decimal Amount { get; private set; }

    public override void Apply()
    {
        Account?.UpdateBalance(Amount);
    }

    public override void Revert()
    {
        Account?.UpdateBalance(-Amount);
    }

    public static Income Create(Account account, IncomeCreateRequest request)
    {
        return new Income(account, request.Amount, request.Timestamp, request.Comment);
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