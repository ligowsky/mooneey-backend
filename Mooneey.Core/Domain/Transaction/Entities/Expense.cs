using Mooneey.Domain;

public class Expense : Transaction
{
    private Expense() {}
    private Expense(Account account, decimal amount, DateTime timestamp, string? comment)
    {
        Account = account;
        AccountId = account.Id;
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
        Account?.UpdateBalance(-Amount) ;
    }
    
    public override void Revert()
    {
        Account?.UpdateBalance(Amount);
    }
    
    public static Expense Create(Account account, ExpenseCreateRequest request)
    {
        return new Expense(account, request.Amount, request.Timestamp, request.Comment);
    }
    
    public void Update(ExpenseUpdateRequest request)
    {
        Revert();

        Amount = request.Amount ?? Amount;
        Timestamp = request.Timestamp ?? Timestamp;
        Comment = request.Comment ?? Comment;
        UpdatedAt = DateTime.UtcNow;
        
        Apply();
    }
}