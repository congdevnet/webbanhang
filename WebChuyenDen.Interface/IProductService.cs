using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface IProductService
    {
        IQueryable<ProductViewModel> Getall();

        Task<Pageding<ProductViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<ProductViewModel> FindAll(params Expression<Func<ProductViewModel, bool>>[] predicate);

        Task<ProductViewModel> GetT(object key);

        ProductViewModel FindT(object key);

        Task Add(ProductVm entity);

        Task Update(ProductVm entity);

        Task Delete(ProductVm entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<ProductViewModel, bool>>[] predicate);
    }
}
