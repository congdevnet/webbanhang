using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory shoppingCartEntities)
          : base(shoppingCartEntities) { }
    }
}