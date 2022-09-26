using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class NewCategoryRepository : Repository<NewCategory>, INewCategoryRepository
    {
        public NewCategoryRepository(IDbFactory shoppingCartEntities)
           : base(shoppingCartEntities) { }
    }
}