namespace Mooneey.Core.Domain.Models.Entities
{
    public class Category : EntityBase
    {
        public string? Name { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}