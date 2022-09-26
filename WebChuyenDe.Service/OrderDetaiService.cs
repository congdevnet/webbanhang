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
    public class OrderDetaiService : IOrderDetaiService
    {
        private IOrderDetailRepository _orderDetaiRepository;
        private IUnitOfWork _unitOfWork;
        public OrderDetaiService(IOrderDetailRepository orderDetaiRepository, IUnitOfWork unitOfWork)
        {
            _orderDetaiRepository = orderDetaiRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(OrderDetailVm entity)
        {
            OrderDetail data = Mapper.Map<OrderDetailVm, OrderDetail>(entity);
            _orderDetaiRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<OrderDetailViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(OrderDetailVm entity)
        {
            OrderDetail data = Mapper.Map<OrderDetailVm, OrderDetail>(entity);
            _orderDetaiRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _orderDetaiRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<OrderDetailViewModel> FindAll(params Expression<Func<OrderDetailViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public OrderDetailViewModel FindT(object key)
        {
            var data = _orderDetaiRepository.FindT(key);
            return Mapper.Map<OrderDetail, OrderDetailViewModel>(data);
        }

        public IQueryable<OrderDetailViewModel> Getall()
        {
            return _orderDetaiRepository.Getall().Project().To<OrderDetailViewModel>();
        }

        public async Task<Pageding<OrderDetailViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<OrderDetailViewModel> pageding = new Pageding<OrderDetailViewModel>();

            var Items = _orderDetaiRepository.Getall().Project().To<OrderDetailViewModel>().OrderByDescending(x => x.OrderID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<OrderDetailViewModel> GetT(object key)
        {
            var data = await _orderDetaiRepository.GetT(key);
            return Mapper.Map<OrderDetail, OrderDetailViewModel>(data);
        }

        public async Task Update(OrderDetailVm entity)
        {
            var data = _orderDetaiRepository.FindT(entity.OrderID);
            var dtos = Mapper.Map<OrderDetailVm, OrderDetail>(entity, data);
            _orderDetaiRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}
