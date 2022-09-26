using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory shoppingCartEntities)
           : base(shoppingCartEntities) { }
    }
}