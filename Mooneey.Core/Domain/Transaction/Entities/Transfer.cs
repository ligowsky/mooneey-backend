namespace Mooneey.Domain;

public class Transfer : Transaction
{
    private Transfer() {}
    private Transfer(Account sourceAccount, Account targetAccount, decimal sourceAmount, decimal targetAmount,
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

    public Guid? SourceAccountId { get; }
    public Account? SourceAccount { get; }
    public Guid? TargetAccountId { get; }
    public Account? TargetAccount { get; }
    public decimal SourceAmount { get; protected set; }
    public decimal TargetAmount { get; protected set; }

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

    public static Transfer Create(Account sourceAccount, Account targetAccount, TransferCreateRequest request)
    {
        return new Transfer(sourceAccount, targetAccount, request.SourceAmount, request.TargetAmount, request.Timestamp,
            request.Comment);
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