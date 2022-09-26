using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory shoppingCartEntities)
           : base(shoppingCartEntities) { }
    }
}