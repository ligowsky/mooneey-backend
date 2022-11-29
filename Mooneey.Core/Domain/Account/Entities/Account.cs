namespace Mooneey.Domain
{
    public class Account : EntityBaseAuditable
    {
        public AccountType AccountType { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}