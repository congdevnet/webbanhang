using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface IOrderService
    {
        IQueryable<OrderViewModel> Getall();

        Task<Pageding<OrderViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<OrderViewModel> FindAll(params Expression<Func<OrderViewModel, bool>>[] predicate);

        Task<OrderViewModel> GetT(object key);

        OrderViewModel FindT(object key);

        Task Add(OrderViewModel entity);

        Task Update(OrderViewModel entity);

        Task Delete(OrderViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<OrderViewModel, bool>>[] predicate);
    }
}
