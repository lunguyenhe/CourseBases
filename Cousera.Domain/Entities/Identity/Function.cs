using Cousera.Domain.Abstraction;
using Cousera.Domain.Abstraction.Entities;
using Cousera.Domain.Enums;


namespace Cousera.Domain.Entities.Identity;

public class Function : EntityBase<int>, IDateTracking
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string? CssClass { get; set; }
    public int ParentId { get; set; }
    public int SortOrder { get; set; }
    public FunctionStatus Status { get; set; }
    public string Key { get; set; }
    public int ActiveValue { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
}
