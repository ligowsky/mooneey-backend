namespace Mooneey.Domain
{
    public class AccountCreateRequest
    {
        public AccountType AccountType { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }

        public Account ToEntity() => new(AccountType, CurrencyCode, Name, Balance);
    }
}