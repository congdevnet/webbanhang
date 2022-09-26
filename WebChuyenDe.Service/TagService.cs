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
    public class TagService : ITagService
    {
        private ITagRepository _TagRepository;
        private IUnitOfWork _unitOfWork;

        public TagService(
            ITagRepository TagRepository,
            IUnitOfWork unitOfWork
            )
        {
            _TagRepository = TagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(TagViewModel dto)
        {
            Tag data = Mapper.Map<TagViewModel, Tag>(dto);
            _TagRepository.Add(data);
            await _unitOfWork.CommitAnysc();
        }

        public Task<bool> Contain(params Expression<Func<TagViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(TagViewModel dto)
        {
            Tag data = Mapper.Map<TagViewModel, Tag>(dto);
            _TagRepository.Delete(data);
            await _unitOfWork.CommitAnysc();
        }

        public async Task Delete(int key)
        {
            _TagRepository.Delete<int>(key);
            await _unitOfWork.CommitAnysc();
        }

        public IQueryable<TagViewModel> FindAll(params Expression<Func<TagViewModel, bool>>[] predicate)
        {
            throw new NotImplementedException();
        }

        public TagViewModel FindT(object key)
        {
            var data = _TagRepository.FindT(key);
            return Mapper.Map<Tag, TagViewModel>(data);
        }

        public IQueryable<TagViewModel> Getall()
        {
            return _TagRepository.Getall().Project().To<TagViewModel>();
        }

        public async Task<Pageding<TagViewModel>> GetAllPage(PageSetup pageSetup)
        {
            Pageding<TagViewModel> pageding = new Pageding<TagViewModel>();

            var Items = _TagRepository.Getall().Project().To<TagViewModel>().OrderByDescending(x => x.TagID);
            pageding.Page = pageSetup.Page;
            pageding.PageSize = pageSetup.PageSize;
            int lenghts = Items.Count();
            pageding.TotalPage = (int)Math.Ceiling(lenghts * 1.0 / pageSetup.PageSize);
            pageding.Items = await Items.Skip((pageSetup.Page - 1) * pageSetup.PageSize).
                Take(pageSetup.PageSize).ToListAsync();
            return pageding;
        }

        public async Task<TagViewModel> GetT(object key)
        {
            var data = await _TagRepository.GetT(key);
            return Mapper.Map<Tag, TagViewModel>(data);
        }

        public async Task Update(TagViewModel dto)
        {
            var data = _TagRepository.FindT(dto.TagID);
            var dtos = Mapper.Map<TagViewModel, Tag>(dto, data);
            _TagRepository.Update(dtos);
            await _unitOfWork.CommitAnysc();
        }
    }
}