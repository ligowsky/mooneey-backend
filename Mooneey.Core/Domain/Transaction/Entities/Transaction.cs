namespace Mooneey.Domain;

public abstract class Transaction : EntityBaseAuditable
{
    public string? Comment { get; protected set; }

    public DateTime Timestamp { get; protected set; }

    public ICollection<Account>? Accounts { get; protected set; }

    public abstract void Apply();

    public abstract void Revert();
}