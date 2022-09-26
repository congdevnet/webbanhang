using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface IMenuService
    {
        IQueryable<MenuViewModel> Getall();

        Task<Pageding<MenuViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<MenuViewModel> FindAll(params Expression<Func<MenuViewModel, bool>>[] predicate);

        Task<MenuViewModel> GetT(object key);

        MenuViewModel FindT(object key);

        Task Add(MenuVm entity);

        Task Update(MenuVm entity);

        Task Delete(MenuVm entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<MenuViewModel, bool>>[] predicate);
    }
}