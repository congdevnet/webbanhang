using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebChuyenDe.Data;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Service
{
   public class ProductCategoryService: IProductCategoryService
    {
        private IProductCategoryRepository _ProductCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(
            IProductCategoryRepository ProductCategoryRepository,
            IUnitOfWork unitOfWork
            )
        {
            _ProductCategoryRepository = ProductCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(ProductCategoryViewModel dto)
        {
            ProductCategory data = Mapper.Map<ProductCategoryViewModel, ProductCategory>(dto);
            _ProductCategoryRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<ProductCategoryViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(ProductCategoryViewModel dto)
        {
            ProductCategory data = Mapper.Map<ProductCategoryViewModel, ProductCategory>(dto);
            _ProductCategoryRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _ProductCategoryRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<ProductCategoryViewModel> FindAll(params Expression<Func<ProductCategoryViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public ProductCategoryViewModel FindT(object key)
        {
            var data = _ProductCategoryRepository.FindT(key);
            return Mapper.Map<ProductCategory, ProductCategoryViewModel>(data);
        }

        public IQueryable<ProductCategoryViewModel> Getall()
        {
            return _ProductCategoryRepository.Getall().Project().To<ProductCategoryViewModel>();
        }

        public async Task<Pageding<ProductCategoryViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<ProductCategoryViewModel> pageding = new Pageding<ProductCategoryViewModel>();

            var Items = _ProductCategoryRepository.Getall().Project().To<ProductCategoryViewModel>().OrderByDescending(x => x.CategoryID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<ProductCategoryViewModel> GetT(object key)
        {
            var data = await _ProductCategoryRepository.GetT(key);
            return Mapper.Map<ProductCategory, ProductCategoryViewModel>(data);
        }

        public async Task Update(ProductCategoryViewModel dto)
        {
            var data = _ProductCategoryRepository.FindT(dto.CategoryID);
            var dtos = Mapper.Map<ProductCategoryViewModel, ProductCategory>(dto, data);
            _ProductCategoryRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}
