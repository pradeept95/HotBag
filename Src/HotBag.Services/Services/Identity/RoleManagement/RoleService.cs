
using HotBag.AppUser;
using HotBag.AppUserDto;
using HotBag.AutoMaper;
using HotBag.DI.Base;
using HotBag.EntityFrameworkCore.Repository;
using HotBag.EntityFrameworkCore.UnitOfWork;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Security.PasswordHasher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotBag.Services.Identity
{
    public class RoleService : IRoleService, ITransientDependencies
    {
        private readonly IEFRepository<HotBagRole, long> _repository;
        private readonly IEFRepository<HotBagPasswordHistoryLog, long> _passwordHistoryLogRepository;
        private readonly IEFRepository<HotBagUserStatusLog, long> _userStatusLogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IObjectMapper _objectMapper;
        public RoleService(
            IEFRepository<HotBagRole, long> repository,
            IEFRepository<HotBagPasswordHistoryLog, long> passwordHistoryLogRepository,
            IEFRepository<HotBagUserStatusLog, long> userStatusLogRepository,
            IUnitOfWork unitOfWork, IObjectMapper objectMapper)
        {
            _repository = repository;
            this._passwordHistoryLogRepository = passwordHistoryLogRepository;
            this._userStatusLogRepository = userStatusLogRepository;
            _unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }

        public async Task Delete(long id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<ResultDto<HotBagRoleDto>> Get(long id)
        {
            var result = await _repository.GetAsync(id);
            var res = _objectMapper.Map<HotBagRoleDto>(result);
            return new ResultDto<HotBagRoleDto>(res);
        }

        public async Task<ListResultDto<HotBagRoleDto>> GetAll(string searchText)
        {
            var result = _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.RoleName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            //var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new HotBagRoleDto
                {
                    Id = x.Id,
                    RoleName = x.RoleName,
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync();

            return new ListResultDto<HotBagRoleDto>(finalResult, "Roles");
        }

        public async Task<PagedResultDto<HotBagRoleDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
        {
            var result = _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.RoleName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new HotBagRoleDto
                {
                    Id = x.Id,
                    RoleName = x.RoleName,
                    CreatedAt = x.CreatedAt
                })
                .Skip(skip)
                .Take(maxResultCount)
                .ToListAsync();

            return new PagedResultDto<HotBagRoleDto>(totalCount, finalResult, skip + maxResultCount < totalCount, "Total Data With summary");
        }

        public async Task<ResultDto<int>> GetCount()
        {
            return new ResultDto<int>(await _repository.CountAsync());
        }

        public async Task<ResultDto<HotBagRoleDto>> Save(HotBagRoleDto entity)
        {
            var saveModel = _objectMapper.Map<HotBagRole>(entity); 
            var result = await _repository.InsertAsync(saveModel); 
            await _unitOfWork.SaveChangesAsync();
            var res = _objectMapper.Map<HotBagRoleDto>(result);
            return new ResultDto<HotBagRoleDto>(res);
        }

        public async Task<ResultDto<HotBagRoleDto>> Update(HotBagRoleDto entity)
        {
            var updateModel = _objectMapper.Map<HotBagRole>(entity);
            var result = await _repository.UpdateAsync(updateModel);
            await _unitOfWork.SaveChangesAsync();
            var res = _objectMapper.Map<HotBagRoleDto>(result);
            return new ResultDto<HotBagRoleDto>(res);
        }
    }
}
