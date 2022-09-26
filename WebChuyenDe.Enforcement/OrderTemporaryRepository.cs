using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class OrderTemporaryRepository : Repository<OrderTemporary>, IOrderTemporaryRepository
    {
        public OrderTemporaryRepository(IDbFactory shoppingCartEntities)
           : base(shoppingCartEntities) { }
    }
}