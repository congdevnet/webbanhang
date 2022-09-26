using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class MenuTypeRepository : Repository<MenuType>, IMenuTypeRepository
    {
        public MenuTypeRepository(IDbFactory shoppingCartEntities)
           : base(shoppingCartEntities) { }
    }
}