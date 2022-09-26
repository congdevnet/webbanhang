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
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IUnitOfWork _unitOfWork;

        public OrderService(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork
            )
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(OrderViewModel dto)
        {
            Order data = Mapper.Map<OrderViewModel, Order>(dto);
            _orderRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<OrderViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(OrderViewModel dto)
        {
            Order data = Mapper.Map<OrderViewModel, Order>(dto);
            _orderRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _orderRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<OrderViewModel> FindAll(params Expression<Func<OrderViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel FindT(object key)
        {
            var data = _orderRepository.FindT(key);
            return Mapper.Map<Order, OrderViewModel>(data);
        }

        public IQueryable<OrderViewModel> Getall()
        {
            return _orderRepository.Getall().Project().To<OrderViewModel>();
        }
        public async Task<Pageding<OrderViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<OrderViewModel> pageding = new Pageding<OrderViewModel>();

            var Items = _orderRepository.Getall().Project().To<OrderViewModel>().OrderByDescending(x => x.Id);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<OrderViewModel> GetT(object key)
        {
            var data = await _orderRepository.GetT(key);
            return Mapper.Map<Order, OrderViewModel>(data);
        }

        public async Task Update(OrderViewModel dto)
        {
            var data = _orderRepository.FindT(dto.Id);
            var dtos = Mapper.Map<OrderViewModel, Order>(dto, data);
            _orderRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}