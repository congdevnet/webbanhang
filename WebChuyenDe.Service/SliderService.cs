using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebChuyenDe.Data;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Service
{
    public class SliderService : ISliderService
    {
        private ISliderRepository _SliderRepository;
        private IUnitOfWork _unitOfWork;

        public SliderService(
            ISliderRepository SliderRepository,
            IUnitOfWork unitOfWork
            )
        {
            _SliderRepository = SliderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(SliderViewModel dto)
        {
            Slider data = Mapper.Map<SliderViewModel, Slider>(dto);
            _SliderRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<SliderViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(SliderViewModel dto)
        {
            Slider data = Mapper.Map<SliderViewModel, Slider>(dto);
            _SliderRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _SliderRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<SliderViewModel> FindAll(params Expression<Func<SliderViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public SliderViewModel FindT(object key)
        {
            var data = _SliderRepository.FindT(key);
            return Mapper.Map<Slider, SliderViewModel>(data);
        }

        public IQueryable<SliderViewModel> Getall()
        {
            return _SliderRepository.Getall().Project().To<SliderViewModel>();
        }

        public async Task<Pageding<SliderViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<SliderViewModel> pageding = new Pageding<SliderViewModel>();

            var Items = _SliderRepository.Getall().Project().To<SliderViewModel>().OrderByDescending(x => x.SlideID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<SliderViewModel> GetT(object key)
        {
            var data = await _SliderRepository.GetT(key);
            return Mapper.Map<Slider, SliderViewModel>(data);
        }

        public async Task Update(SliderViewModel dto)
        {
            var data = _SliderRepository.FindT(dto.SlideID);
            var dtos = Mapper.Map<SliderViewModel, Slider>(dto, data);
            _SliderRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}