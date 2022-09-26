using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface INewCategoryService
    {
        IQueryable<NewCategoryViewModel> Getall();

        Task<Pageding<NewCategoryViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<NewCategoryViewModel> FindAll(params Expression<Func<NewCategoryViewModel, bool>>[] predicate);

        Task<NewCategoryViewModel> GetT(object key);

        NewCategoryViewModel FindT(object key);

        Task Add(NewCategoryViewModel entity);

        Task Update(NewCategoryViewModel entity);

        Task Delete(NewCategoryViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<NewCategoryViewModel, bool>>[] predicate);
    }
}
