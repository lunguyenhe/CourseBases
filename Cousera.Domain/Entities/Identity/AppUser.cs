using Cousera.Domain.Abstraction.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cousera.Domain.Entities.Identity;

public class AppUser : IdentityUser<Guid>, ICousera
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName { get; set; }
    public DateTime? DayOfBirth { get; set; }

    public bool IsDirector { get; set; }
    public bool IsHeadOfDepartment { get; set; }

    public Guid? ManagerId { get; set; }

    public Guid PositionId { get; set; }
    public int IsReceipient { get; set; }
    public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; }
    public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; }
    public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; }
    public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedDAt { get; set; }
    public Guid CreateBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
}
