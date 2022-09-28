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
    public class UserService : IUserService
    {
        private IUserRepository _UserRepository;
        private IUnitOfWork _unitOfWork;

        public UserService(
            IUserRepository UserRepository,
            IUnitOfWork unitOfWork
            )
        {
            _UserRepository = UserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(UserViewModel dto)
        {
            User data = Mapper.Map<UserViewModel, User>(dto);
            _UserRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<UserViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(UserViewModel dto)
        {
            User data = Mapper.Map<UserViewModel, User>(dto);
            _UserRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _UserRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<UserViewModel> FindAll(params Expression<Func<UserViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public UserViewModel FindT(object key)
        {
            var data = _UserRepository.FindT(key);
            return Mapper.Map<User, UserViewModel>(data);
        }

        public IQueryable<UserViewModel> Getall()
        {
            return _UserRepository.Getall().Project().To<UserViewModel>();
        }

        public async Task<Pageding<UserViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<UserViewModel> pageding = new Pageding<UserViewModel>();

            var Items = _UserRepository.Getall().Project().To<UserViewModel>().OrderByDescending(x => x.UserID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<UserViewModel> GetT(object key)
        {
            var data = await _UserRepository.GetT(key);
            return Mapper.Map<User, UserViewModel>(data);
        }

        public async Task<bool> Login(UserLoginViewModel userLoginView)
        {
          return await  _UserRepository.Getall().Project()
                .To<UserLoginViewModel>().Where(
              x=>x.Username==userLoginView.Username 
              && x.Password==userLoginView.Password).AnyAsync();
        }

        public async Task Update(UserViewModel dto)
        {
            var data = _UserRepository.FindT(dto.UserID);
            var dtos = Mapper.Map<UserViewModel, User>(dto, data);
            _UserRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}