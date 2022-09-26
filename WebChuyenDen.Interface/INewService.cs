using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface INewService
    {
        IQueryable<NewViewModel> Getall();

        Task<Pageding<NewViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<NewViewModel> FindAll(params Expression<Func<NewViewModel, bool>>[] predicate);

        Task<NewViewModel> GetT(object key);

        NewViewModel FindT(object key);

        Task Add(NewViewModel entity);

        Task Update(NewViewModel entity);

        Task Delete(NewViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<NewViewModel, bool>>[] predicate);
    }
}