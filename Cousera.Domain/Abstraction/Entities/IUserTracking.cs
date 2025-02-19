
namespace Cousera.Domain.Abstraction.Entities;
public interface IUserTracking
{
    Guid CreateBy { get; set; }
    Guid? ModifiedBy { get; set; }
}


