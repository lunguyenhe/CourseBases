using Cousera.Domain.Abstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cousera.Domain.Abstraction;

public abstract class EntityCouseraBase<TKey> :IEntityCouseraBase<TKey>
{
    public TKey Id { get; set; }
    public bool IsDeleted { get ; set ; }
    public DateTimeOffset? DeletedDAt { get ; set ; }
    public Guid CreateBy { get ; set ; }
    public Guid? ModifiedBy { get ; set ; }
    public DateTimeOffset CreatedDate { get ; set ; }
    public DateTimeOffset? ModifiedDate { get ; set ; }
}

