namespace Mooneey.Domain;

public abstract class EntityBaseAuditable : EntityBase
{
    protected EntityBaseAuditable()
    {
        UpdatedAt = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;
    }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
}