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
    public  class OrderTemporaryService: IOrderTemporaryService
    {
        private IOrderTemporaryRepository _OrderTemporaryRepository;
        private IUnitOfWork _unitOfWork;

        public OrderTemporaryService(
            IOrderTemporaryRepository OrderTemporaryRepository,
            IUnitOfWork unitOfWork
            )
        {
            _OrderTemporaryRepository = OrderTemporaryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(OrderTemporaryViewModel dto)
        {
            OrderTemporary data = Mapper.Map<OrderTemporaryViewModel, OrderTemporary>(dto);
            _OrderTemporaryRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<OrderTemporaryViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(OrderTemporaryViewModel dto)
        {
            OrderTemporary data = Mapper.Map<OrderTemporaryViewModel, OrderTemporary>(dto);
            _OrderTemporaryRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _OrderTemporaryRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<OrderTemporaryViewModel> FindAll(params Expression<Func<OrderTemporaryViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public OrderTemporaryViewModel FindT(object key)
        {
            var data = _OrderTemporaryRepository.FindT(key);
            return Mapper.Map<OrderTemporary, OrderTemporaryViewModel>(data);
        }

        public IQueryable<OrderTemporaryViewModel> Getall()
        {
            return _OrderTemporaryRepository.Getall().Project().To<OrderTemporaryViewModel>();
        }
        public async Task<Pageding<OrderTemporaryViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<OrderTemporaryViewModel> pageding = new Pageding<OrderTemporaryViewModel>();

            var Items = _OrderTemporaryRepository.Getall().Project().To<OrderTemporaryViewModel>().OrderByDescending(x => x.ProductId);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<OrderTemporaryViewModel> GetT(object key)
        {
            var data = await _OrderTemporaryRepository.GetT(key);
            return Mapper.Map<OrderTemporary, OrderTemporaryViewModel>(data);
        }

        public async Task Update(OrderTemporaryViewModel dto)
        {
            var data = _OrderTemporaryRepository.FindT(dto.ProductId);
            var dtos = Mapper.Map<OrderTemporaryViewModel, OrderTemporary>(dto, data);
            _OrderTemporaryRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}
