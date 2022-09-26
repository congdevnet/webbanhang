using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbFactory shoppingCartEntities)
          : base(shoppingCartEntities) { }
    }
}