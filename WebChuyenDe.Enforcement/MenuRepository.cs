using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory shoppingCartEntities)
            : base(shoppingCartEntities) { }
    }
}