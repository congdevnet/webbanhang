using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebChuyenDen.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> Getall();
        IQueryable<T> GetAllPage();
        IQueryable<T> FindAll(params Expression<Func<T, bool>>[] predicate);

        Task<T> GetT(object key);
        T FindT(object key);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete<Y>(Y key);

        Task<bool> Contain(params Expression<Func<T, bool>>[] predicate);

    }
}
