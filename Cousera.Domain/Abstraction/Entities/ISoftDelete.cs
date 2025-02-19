
namespace Cousera.Domain.Abstraction.Entities;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedDAt { get; set; }

    public void Undo()
    {
        IsDeleted = false;
        DeletedDAt = null;

    }
}