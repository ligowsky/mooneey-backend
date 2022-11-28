using Mooneey.Core.Domain.Enums;

namespace Mooneey.Core.Domain.Models.Entities
{
    public class Account : EntityBase
    {
        public AccountTypeEnum AccountType { get; set; }
        public string? Name { get; set; }
        public CurrencyEnum Currency { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }

        public void UpdateBalance(decimal delta)
        {
            Balance += delta;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}