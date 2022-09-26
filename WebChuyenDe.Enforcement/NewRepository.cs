using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class NewRepository : Repository<New>, INewRepository
    {
        public NewRepository(IDbFactory shoppingCartEntities)
           : base(shoppingCartEntities) { }
    }
}