using WebChuyenDen.Interface;
using System.Linq.Expressions;
using System.Data.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebChuyenDe.Data;

namespace WebChuyenDe.Enforcement
{
    public class Repository<T> : IRepository<T>, IDisposable where T:class
    {
        private ShoppingCartEntities _dbContext;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected ShoppingCartEntities DbContext
        {
            get { return _dbContext ?? (_dbContext = DbFactory.Init()); }
        }
        public Repository(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
        }

        public void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public async Task<bool> Contain(params Expression<Func<T, bool>>[] predicates)
        {
            IQueryable<T> Items =  _dbContext.Set<T>();
            if (predicates != null)
            {
                foreach (var predicate in predicates)
                {
                    Items = Items.Where(predicate);
                }
            }
            return await Items.AnyAsync();
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public void Delete<Y>(Y key)
        {
            var entity = FindT(key);
            DbContext.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public IQueryable<T> FindAll(params Expression<Func<T, bool>>[] predicates)
        {
            IQueryable<T> Items = _dbContext.Set<T>();
            if (predicates != null)
            {
                foreach (var predicate in predicates)
                {
                    Items = Items.Where(predicate);
                }
            }
            return Items;
        }

        public T FindT(object key)
        {
           return DbContext.Set<T>().Find(key);
        }

        public IQueryable<T> Getall()
        {
           return DbContext.Set<T>();
        }

        public IQueryable<T> GetAllPage()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetT(object key)
        {
            return await DbContext.Set<T>().FindAsync(key);
        }

        public void Update(T entity)
        {
            DbContext.Entry<T>(entity);
        }
    }
}