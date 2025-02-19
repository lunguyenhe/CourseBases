namespace Cousera.Domain.Abstraction.Entities;
public interface IEntityBase<TKey>
{
    TKey Id { get; }
}

