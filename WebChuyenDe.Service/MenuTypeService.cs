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
    public class MenuTypeService : IMenuTypeService
    {
        private IMenuTypeRepository _MenuTypeRepository;
        private IUnitOfWork _unitOfWork;

        public MenuTypeService(
            IMenuTypeRepository MenuTypeRepository,
            IUnitOfWork unitOfWork
            )
        {
            _MenuTypeRepository = MenuTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(MenuTypeViewModel dto)
        {
            MenuType data = Mapper.Map<MenuTypeViewModel, MenuType>(dto);
            _MenuTypeRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<MenuTypeViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(MenuTypeViewModel dto)
        {
            MenuType data = Mapper.Map<MenuTypeViewModel, MenuType>(dto);
            _MenuTypeRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _MenuTypeRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<MenuTypeViewModel> FindAll(params Expression<Func<MenuTypeViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public MenuTypeViewModel FindT(object key)
        {
            var data = _MenuTypeRepository.FindT(key);
            return Mapper.Map<MenuType, MenuTypeViewModel>(data);
        }

        public IQueryable<MenuTypeViewModel> Getall()
        {
            return _MenuTypeRepository.Getall().Project().To<MenuTypeViewModel>();
        }
        public async Task<Pageding<MenuTypeViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<MenuTypeViewModel> pageding = new Pageding<MenuTypeViewModel>();

            var Items = _MenuTypeRepository.Getall().Project().To<MenuTypeViewModel>().OrderByDescending(x => x.MenuTypeID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<MenuTypeViewModel> GetT(object key)
        {
            var data = await _MenuTypeRepository.GetT(key);
            return Mapper.Map<MenuType, MenuTypeViewModel>(data);
        }

        public async Task Update(MenuTypeViewModel dto)
        {
            var data = _MenuTypeRepository.FindT(dto.MenuTypeID);
            var dtos = Mapper.Map<MenuTypeViewModel, MenuType>(dto, data);
            _MenuTypeRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}