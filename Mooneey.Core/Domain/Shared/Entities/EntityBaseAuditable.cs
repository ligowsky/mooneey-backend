namespace Mooneey.Domain;

public abstract class EntityBaseAuditable : EntityBase
{
    protected EntityBaseAuditable()
    {
        UpdatedAt = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;
    }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}