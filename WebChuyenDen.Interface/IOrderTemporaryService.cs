using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface IOrderTemporaryService
    {
        IQueryable<OrderTemporaryViewModel> Getall();

        Task<Pageding<OrderTemporaryViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<OrderTemporaryViewModel> FindAll(params Expression<Func<OrderTemporaryViewModel, bool>>[] predicate);

        Task<OrderTemporaryViewModel> GetT(object key);

        OrderTemporaryViewModel FindT(object key);

        Task Add(OrderTemporaryViewModel entity);

        Task Update(OrderTemporaryViewModel entity);

        Task Delete(OrderTemporaryViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<OrderTemporaryViewModel, bool>>[] predicate);
    }
}
