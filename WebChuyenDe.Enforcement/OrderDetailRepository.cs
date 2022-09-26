using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory shoppingCartEntities)
           : base(shoppingCartEntities) { }
    }
}