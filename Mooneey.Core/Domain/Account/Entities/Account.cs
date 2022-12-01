namespace Mooneey.Domain
{
    public class Account : EntityBaseAuditable
    {
        private Account() {}
        
        public Account(AccountType accountType, CurrencyCode currencyCode, string? name, decimal balance)
        {
            AccountType = accountType;
            CurrencyCode = currencyCode;
            Name = name;
            Balance = balance;
        }
        
        public AccountType AccountType { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }

        public void UpdateBalance(decimal delta)
        {
            Balance += delta;
        }
    }
}