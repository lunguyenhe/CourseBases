using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cousera.Domain.Abstraction.Entities;

public interface IEntityCouseraBase<TKey> :IEntityBase<TKey>, ICousera
{
}
