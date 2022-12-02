namespace Mooneey.Domain
{
    public class Account : EntityBaseAuditable
    {
        private Account(AccountType accountType, CurrencyCode currencyCode, string? name, decimal balance)
        {
            AccountType = accountType;
            CurrencyCode = currencyCode;
            Name = name;
            Balance = balance;
        }

        public AccountType AccountType { get; private set; }
        public CurrencyCode CurrencyCode { get; private set; }
        public string? Name { get; private set; }
        public decimal Balance { get; private set; }

        public ICollection<Transaction>? Transactions { get; private set; }

        public static Account Create(AccountCreateRequest request)
        {
            return new Account(request.AccountType, request.CurrencyCode, request.Name, request.Balance);
        }

        public void Update(AccountUpdateRequest request)
        {
            AccountType = request.AccountType ?? AccountType;
            CurrencyCode = request.CurrencyCode ?? CurrencyCode;
            Name = request.Name ?? Name;
            Balance = request.Balance ?? Balance;
        }

        public void UpdateBalance(decimal delta)
        {
            Balance += delta;
        }
    }
}