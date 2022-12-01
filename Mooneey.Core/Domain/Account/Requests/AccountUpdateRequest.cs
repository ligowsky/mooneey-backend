namespace Mooneey.Domain
{
    public class AccountUpdateRequest
    {
        public AccountType? AccountType { get; set; }
        public CurrencyCode? CurrencyCode { get; set; }
        public string? Name { get; set; }
        public decimal? Balance { get; set; }
    }
}