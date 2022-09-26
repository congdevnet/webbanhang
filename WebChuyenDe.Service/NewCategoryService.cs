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
    public class NewCategoryService : INewCategoryService
    {
        private INewCategoryRepository _NewCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public NewCategoryService(
            INewCategoryRepository NewCategoryRepository,
            IUnitOfWork unitOfWork
            )
        {
            _NewCategoryRepository = NewCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(NewCategoryViewModel dto)
        {
            NewCategory data = Mapper.Map<NewCategoryViewModel, NewCategory>(dto);
            _NewCategoryRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<NewCategoryViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(NewCategoryViewModel dto)
        {
            NewCategory data = Mapper.Map<NewCategoryViewModel, NewCategory>(dto);
            _NewCategoryRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _NewCategoryRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<NewCategoryViewModel> FindAll(params Expression<Func<NewCategoryViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public NewCategoryViewModel FindT(object key)
        {
            var data = _NewCategoryRepository.FindT(key);
            return Mapper.Map<NewCategory, NewCategoryViewModel>(data);
        }

        public IQueryable<NewCategoryViewModel> Getall()
        {
            return _NewCategoryRepository.Getall().Project().To<NewCategoryViewModel>();
        }

        public async Task<Pageding<NewCategoryViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<NewCategoryViewModel> pageding = new Pageding<NewCategoryViewModel>();

            var Items = _NewCategoryRepository.Getall().Project().To<NewCategoryViewModel>().OrderByDescending(x => x.NewCategoryID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<NewCategoryViewModel> GetT(object key)
        {
            var data = await _NewCategoryRepository.GetT(key);
            return Mapper.Map<NewCategory, NewCategoryViewModel>(data);
        }

        public async Task Update(NewCategoryViewModel dto)
        {
            var data = _NewCategoryRepository.FindT(dto.NewCategoryID);
            var dtos = Mapper.Map<NewCategoryViewModel, NewCategory>(dto, data);
            _NewCategoryRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}