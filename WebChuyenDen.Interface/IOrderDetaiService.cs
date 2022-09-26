using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface IOrderDetaiService
    {
        IQueryable<OrderDetailViewModel> Getall();

        Task<Pageding<OrderDetailViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<OrderDetailViewModel> FindAll(params Expression<Func<OrderDetailViewModel, bool>>[] predicate);

        Task<OrderDetailViewModel> GetT(object key);

        OrderDetailViewModel FindT(object key);

        Task Add(OrderDetailVm entity);

        Task Update(OrderDetailVm entity);

        Task Delete(OrderDetailVm entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<OrderDetailViewModel, bool>>[] predicate);
    }
}
