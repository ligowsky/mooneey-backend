namespace Mooneey.Domain;

public abstract class Transaction : EntityBaseAuditable
{
    public string? Comment { get; set; }

    public DateTime Timestamp { get; set; }

    public ICollection<Account>? Accounts { get; set; }

    public abstract void Apply();

    public abstract void Revert();
}