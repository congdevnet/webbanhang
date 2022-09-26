using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory shoppingCartEntities)
          : base(shoppingCartEntities) { }
    }
}