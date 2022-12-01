namespace Mooneey.Presentation;

public class EntityBaseAuditableViewModel : EntityBaseViewModel
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}