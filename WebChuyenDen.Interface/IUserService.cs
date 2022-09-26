using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface IUserService
    {
        IQueryable<UserViewModel> Getall();

        Task<Pageding<UserViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<UserViewModel> FindAll(params Expression<Func<UserViewModel, bool>>[] predicate);

        Task<UserViewModel> GetT(object key);

        UserViewModel FindT(object key);

        Task Add(UserViewModel entity);

        Task Update(UserViewModel entity);

        Task Delete(UserViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<UserViewModel, bool>>[] predicate);
    }
}