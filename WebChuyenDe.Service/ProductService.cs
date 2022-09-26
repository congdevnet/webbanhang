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
    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository ProductRepository,
            IUnitOfWork unitOfWork
            )
        {
            _ProductRepository = ProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(ProductVm dto)
        {
            Product data = Mapper.Map<ProductVm, Product>(dto);
            _ProductRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<ProductViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(ProductVm dto)
        {
            Product data = Mapper.Map<ProductVm, Product>(dto);
            _ProductRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _ProductRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<ProductViewModel> FindAll(params Expression<Func<ProductViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel FindT(object key)
        {
            var data = _ProductRepository.FindT(key);
            return Mapper.Map<Product, ProductViewModel>(data);
        }

        public IQueryable<ProductViewModel> Getall()
        {
            return _ProductRepository.Getall().Project().To<ProductViewModel>();
        }

        public async Task<Pageding<ProductViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<ProductViewModel> pageding = new Pageding<ProductViewModel>();

            var Items = _ProductRepository.Getall().Project().To<ProductViewModel>().OrderByDescending(x => x.ProductID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<ProductViewModel> GetT(object key)
        {
            var data = await _ProductRepository.GetT(key);
            return Mapper.Map<Product, ProductViewModel>(data);
        }

        public async Task Update(ProductVm dto)
        {
            var data = _ProductRepository.FindT(dto.ProductID);
            var dtos = Mapper.Map<ProductVm, Product>(dto, data);
            _ProductRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}