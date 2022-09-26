using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDen.Interface
{
    public interface ISliderService
    {
        IQueryable<SliderViewModel> Getall();

        Task<Pageding<SliderViewModel>> GetAllPage(PageSetup pageSetup);

        IQueryable<SliderViewModel> FindAll(params Expression<Func<SliderViewModel, bool>>[] predicate);

        Task<SliderViewModel> GetT(object key);

        SliderViewModel FindT(object key);

        Task Add(SliderViewModel entity);

        Task Update(SliderViewModel entity);

        Task Delete(SliderViewModel entity);

        Task Delete(int key);

        Task<bool> Contain(params Expression<Func<SliderViewModel, bool>>[] predicate);
    }
}
