namespace Mooneey.Domain;

public class Transfer : Transaction
{
    private Transfer()
    {
    }

    public Transfer(Account sourceAccount, Account targetAccount, decimal sourceAmount, decimal targetAmount,
        DateTime timestamp, string? comment)
    {
        SourceAccountId = sourceAccount.Id;
        SourceAccount = sourceAccount;

        TargetAccountId = targetAccount.Id;
        TargetAccount = targetAccount;

        SourceAmount = sourceAmount;
        TargetAmount = targetAmount;

        Timestamp = timestamp;
        Comment = comment;

        Accounts = new List<Account> { sourceAccount, targetAccount };
    }

    public Guid? SourceAccountId { get; set; }
    public Account? SourceAccount { get; set; }
    public Guid? TargetAccountId { get; set; }
    public Account? TargetAccount { get; set; }
    public decimal SourceAmount { get; set; }
    public decimal TargetAmount { get; set; }

    public override void Apply()
    {
        SourceAccount?.UpdateBalance(-SourceAmount);
        TargetAccount?.UpdateBalance(TargetAmount);
    }

    public override void Revert()
    {
        SourceAccount?.UpdateBalance(SourceAmount);
        TargetAccount?.UpdateBalance(-TargetAmount);
    }

    public void Update(TransferUpdateRequest request)
    {
        Revert();

        SourceAmount = request.SourceAmount ?? SourceAmount;
        TargetAmount = request.TargetAmount ?? TargetAmount;
        Timestamp = request.Timestamp ?? Timestamp;
        Comment = request.Comment ?? Comment;
        UpdatedAt = DateTime.UtcNow;
        
        Apply();
    }
}