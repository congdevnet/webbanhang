using System;
using WebChuyenDe.Data;

namespace WebChuyenDen.Interface
{
    public interface IDbFactory: IDisposable
    {
        ShoppingCartEntities Init();
    }
}