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
    public class NewService : INewService
    {
        private INewRepository _NewRepository;
        private IUnitOfWork _unitOfWork;

        public NewService(
            INewRepository NewRepository,
            IUnitOfWork unitOfWork
            )
        {
            _NewRepository = NewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(NewViewModel dto)
        {
            New data = Mapper.Map<NewViewModel, New>(dto);
            _NewRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<NewViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(NewViewModel dto)
        {
            New data = Mapper.Map<NewViewModel, New>(dto);
            _NewRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _NewRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<NewViewModel> FindAll(params Expression<Func<NewViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public NewViewModel FindT(object key)
        {
            var data = _NewRepository.FindT(key);
            return Mapper.Map<New, NewViewModel>(data);
        }

        public IQueryable<NewViewModel> Getall()
        {
            return _NewRepository.Getall().Project().To<NewViewModel>();
        }

        public async Task<Pageding<NewViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<NewViewModel> pageding = new Pageding<NewViewModel>();

            var Items = _NewRepository.Getall().Project().To<NewViewModel>().OrderByDescending(x => x.NewID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<NewViewModel> GetT(object key)
        {
            var data = await _NewRepository.GetT(key);
            return Mapper.Map<New, NewViewModel>(data);
        }

        public async Task Update(NewViewModel dto)
        {
            var data = _NewRepository.FindT(dto.NewID);
            var dtos = Mapper.Map<NewViewModel, New>(dto, data);
            _NewRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}