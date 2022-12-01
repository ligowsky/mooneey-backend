using Mooneey.Domain;

public class Expense : Transaction
{
    private Expense() {}
    public Expense(Account account, decimal amount, DateTime timestamp, string? comment)
    {
        Account = account;
        AccountId = account.Id;
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
        if (Account is not null) Account.Balance -= Amount;
    }
    
    public override void Revert()
    {
        if (Account is not null) Account.Balance += Amount;
    }
    
    public void Update(ExpenseUpdateRequest request)
    {
        if (Account is not null && request.Amount.HasValue) 
            Account.Balance -= (request.Amount.Value - Amount);

        Amount = request.Amount ?? Amount;
        Timestamp = request.Timestamp ?? Timestamp;
        Comment = request.Comment ?? Comment;
        UpdatedAt = DateTime.UtcNow;
    }
}