using Cousera.Domain.Abstraction.Entities;


namespace Cousera.Domain.Abstraction;

public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    public TKey Id { get; set; }
}
//khi nào dùng abstarct class khi nào dùng interface
//trong bài toán này ta thấy entity base không cần phải implement nhiều interface nên ta dùng abstract class
// còn interface thì dùng khi cần implement nhiều interface
//ví dụ 
//trong bài toán này ta có thể tạo interface IDateTracking và implement vào các entity cần theo dõi thời gian tạo và sửa
//nhưng trong bài toán này ta chỉ cần implement 2 property CreatedDate và ModifiedDate vào entitybase thôi