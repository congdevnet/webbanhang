using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
  public  interface IProductCategoryService
    {
        IQueryable<ProductCategoryViewModel> Getall();

        Task<Pageding<ProductCategoryViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<ProductCategoryViewModel> FindAll(params Expression<Func<ProductCategoryViewModel, bool>>[] predicate);

        Task<ProductCategoryViewModel> GetT(object key);

        ProductCategoryViewModel FindT(object key);

        Task Add(ProductCategoryViewModel entity);

        Task Update(ProductCategoryViewModel entity);

        Task Delete(ProductCategoryViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<ProductCategoryViewModel, bool>>[] predicate);
    }
}
