
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
    public class AppUserService : IAppUserService, ITransientDependencies
    {
        private readonly IEFRepository<HotBagUser, Guid> _repository;
        private readonly IEFRepository<HotBagPasswordHistoryLog, long> _passwordHistoryLogRepository;
        private readonly IEFRepository<HotBagUserStatusLog, long> _userStatusLogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IObjectMapper _objectMapper;
        public AppUserService(
            IEFRepository<HotBagUser, Guid> repository,
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

        public async Task Delete(Guid id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<ResultDto<HotBagUserDto>> Get(Guid id)
        {
            var result = await _repository.GetAsync(id);
            var res = _objectMapper.Map<HotBagUserDto>(result);
            return new ResultDto<HotBagUserDto>(res);
        }

        public async Task<ListResultDto<HotBagUserDto>> GetAll(string searchText)
        {
            var result = _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.Username.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            //var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new HotBagUserDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    Username = x.Username,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Status = x.Status,
                    TanentIdId = x.TanentIdId
                })
                .ToListAsync();

            return new ListResultDto<HotBagUserDto>(finalResult, "Users");
        }

        public async Task<PagedResultDto<HotBagUserDto>> GetAllPaged(int skip = 0, int maxResultCount = 10, string searchText = "")
        {
            var result = _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.Username.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new HotBagUserDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    Username = x.Username,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Status = x.Status,
                    TanentIdId = x.TanentIdId
                })
                .Skip(skip)
                .Take(maxResultCount)
                .ToListAsync();

            return new PagedResultDto<HotBagUserDto>(totalCount, finalResult, skip + maxResultCount < totalCount, "Total Data With summary");
        }

        public async Task<ResultDto<int>> GetCount()
        {
            return new ResultDto<int>(await _repository.CountAsync());
        }

        public async Task<ResultDto<HotBagUserDto>> Save(HotBagUserDto entity)
        {
            var saveModel = _objectMapper.Map<HotBagUser>(entity);

            saveModel.HashedPassword = PasswordHasher.HashPassword(entity.Password);
            saveModel.Status = UserStatus.Active;
            var result = await _repository.InsertAsync(saveModel);

            #region Save Password History Log

            var passworHistory = new HotBagPasswordHistoryLog
            {
                HashedPassword = saveModel.HashedPassword,
                UserId = result.Id,
                Timestamp = DateTime.Now
            };
            await _passwordHistoryLogRepository.InsertAsync(passworHistory);
            #endregion

            #region Save User Status History Log

            var userStatusHistory = new HotBagUserStatusLog
            {
                Status = saveModel.Status,
                UserId = result.Id,
                Timestamp = DateTime.Now
            };
            await _userStatusLogRepository.InsertAsync(userStatusHistory);
            #endregion 

            await _unitOfWork.SaveChangesAsync();
            var res = _objectMapper.Map<HotBagUserDto>(result);
            return new ResultDto<HotBagUserDto>(res);
        }

        public async Task<ResultDto<HotBagUserDto>> Update(HotBagUserDto entity)
        {
            var updateModel = _objectMapper.Map<HotBagUser>(entity);
            var result = await _repository.UpdateAsync(updateModel);
            await _unitOfWork.SaveChangesAsync();
            var res = _objectMapper.Map<HotBagUserDto>(result);
            return new ResultDto<HotBagUserDto>(res);
        }
    }
}
