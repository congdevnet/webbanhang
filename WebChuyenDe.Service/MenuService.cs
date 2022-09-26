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
    public class MenuService : IMenuService
    {
        private IMenuRepository _menuRepository;
        private IUnitOfWork _unitOfWork;

        public MenuService(
            IMenuRepository menuRepository,
            IUnitOfWork unitOfWork
            )
        {
            _menuRepository = menuRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(MenuVm dto)
        {
            Menu data = Mapper.Map<MenuVm, Menu>(dto);
            _menuRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<MenuViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(MenuVm dto)
        {
            Menu data = Mapper.Map<MenuVm, Menu>(dto);
            _menuRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _menuRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<MenuViewModel> FindAll(params Expression<Func<MenuViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public MenuViewModel FindT(object key)
        {
            var data = _menuRepository.FindT(key);
            return Mapper.Map<Menu, MenuViewModel>(data);
        }

        public IQueryable<MenuViewModel> Getall()
        {
            return _menuRepository.Getall().Project().To<MenuViewModel>();
        }
        public async Task<Pageding<MenuViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<MenuViewModel> pageding = new Pageding<MenuViewModel>();

            var Items = _menuRepository.Getall().Project().To<MenuViewModel>().OrderByDescending(x=>x.MenuID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<MenuViewModel> GetT(object key)
        {
            var data = await _menuRepository.GetT(key);
            return Mapper.Map<Menu, MenuViewModel>(data);
        }

        public async Task Update(MenuVm dto)
        {
            var data = _menuRepository.FindT(dto.MenuID);
            var dtos = Mapper.Map<MenuVm, Menu>(dto, data);
            _menuRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}