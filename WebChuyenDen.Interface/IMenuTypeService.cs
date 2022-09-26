using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface IMenuTypeService
    {
        IQueryable<MenuTypeViewModel> Getall();
        Task<Pageding<MenuTypeViewModel>> GetAllPage(PageSetup pageSetup);
        IQueryable<MenuTypeViewModel> FindAll(params Expression<Func<MenuTypeViewModel, bool>>[] predicate);

        Task<MenuTypeViewModel> GetT(object key);

        MenuTypeViewModel FindT(object key);

        Task Add(MenuTypeViewModel entity);

        Task Update(MenuTypeViewModel entity);

        Task Delete(MenuTypeViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<MenuTypeViewModel, bool>>[] predicate);
    }
}