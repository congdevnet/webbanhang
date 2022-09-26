using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class DbFactory : IDbFactory
    {
        private ShoppingCartEntities dbContext;

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public ShoppingCartEntities Init()
        {
            return dbContext ?? (dbContext = new ShoppingCartEntities());
        }
    }
}