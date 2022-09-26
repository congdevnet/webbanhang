using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface ITagService
    {
        IQueryable<TagViewModel> Getall();

        Task<Pageding<TagViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<TagViewModel> FindAll(params Expression<Func<TagViewModel, bool>>[] predicate);

        Task<TagViewModel> GetT(object key);

        TagViewModel FindT(object key);

        Task Add(TagViewModel entity);

        Task Update(TagViewModel entity);

        Task Delete(TagViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<TagViewModel, bool>>[] predicate);
    }
}
