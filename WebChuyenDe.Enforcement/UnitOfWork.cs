using System;
using System.Threading.Tasks;
using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ShoppingCartEntities _context;
        private readonly IDbFactory dbFactory;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public ShoppingCartEntities DbContext
        {
            get { return _context ?? (_context = dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public async Task CommitAnysc()
        {
          await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            
        }
    }
}