namespace Mooneey.Domain;

public class Income : Transaction
{
    private Income() {}
    public Income(Account account, decimal amount)
    {
        Account = account;
        AccountId = account.Id;
        Amount = amount;

        Accounts = new List<Account> { account };
    }

    public Guid AccountId { get; set; }
    public Account? Account { get; set; }
    public decimal Amount { get; set; }

    public override void Apply()
    {
        if (Account is not null) Account.Balance += Amount;
    }

    public override void Revert()
    {
        if (Account is not null) Account.Balance -= Amount;
    }
}