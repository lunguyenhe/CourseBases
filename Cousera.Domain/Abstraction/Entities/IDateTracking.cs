

namespace Cousera.Domain.Abstraction.Entities;

public interface IDateTracking
{
    DateTimeOffset CreatedDate { get; set; }
    DateTimeOffset? ModifiedDate { get; set; }
}
