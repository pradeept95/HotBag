
using HotBag.AppUser;
using HotBag.AppUserDto;
using HotBag.AutoMaper;
using HotBag.Data;
using HotBag.DI.Base;
using HotBag.EntityFrameworkCore.Repository;
using HotBag.EntityFrameworkCore.UnitOfWork;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Security.PasswordHasher;
using HotBag.Services.RepositoryFactory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotBag.Services.Identity
{
    public class AppUserService : IAppUserService, ITransientDependencies
    {
        private readonly IBaseRepository<HotBagUser, Guid> _repository;
        private readonly IBaseRepository<HotBagPasswordHistoryLog, long> _passwordHistoryLogRepository;
        private readonly IBaseRepository<HotBagUserStatusLog, long> _userStatusLogRepository;
       // private readonly IUnitOfWork _unitOfWork;
        private readonly IObjectMapper _objectMapper;
        public AppUserService(
            IRepositoryFactory<HotBagUser, Guid> repository,
            IRepositoryFactory<HotBagPasswordHistoryLog, long> passwordHistoryLogRepository,
            IRepositoryFactory<HotBagUserStatusLog, long> userStatusLogRepository,
           // IUnitOfWork unitOfWork,
            IObjectMapper objectMapper)
        {
            _repository = repository.GetRepository();
            this._passwordHistoryLogRepository = passwordHistoryLogRepository.GetRepository();
            this._userStatusLogRepository = userStatusLogRepository.GetRepository();
           // _unitOfWork = unitOfWork;
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
            var finalResult = result
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
                });
            result = await Task.FromResult(result);
            return new ListResultDto<HotBagUserDto>(finalResult.ToList(), "Users");
        }

        public async Task<PagedResultDto<HotBagUserDto>> GetAllPaged(int skip = 0, int maxResultCount = 10, string searchText = "")
        {
            var result = _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.Username.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            } 

            var totalCount = result.Count();
            var finalResult = result
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
                .Take(maxResultCount);

            finalResult = await Task.FromResult(finalResult);
            return new PagedResultDto<HotBagUserDto>(totalCount, finalResult.ToList(), skip + maxResultCount < totalCount, "Total Data With summary");
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

            await _repository.SaveChangeAsync();
            var res = _objectMapper.Map<HotBagUserDto>(result);
            return new ResultDto<HotBagUserDto>(res);
        }

        public async Task<ResultDto<HotBagUserDto>> Update(HotBagUserDto entity)
        {
            var updateModel = _objectMapper.Map<HotBagUser>(entity);
            var result = await _repository.UpdateAsync(updateModel);
            await _repository.SaveChangeAsync();
            var res = _objectMapper.Map<HotBagUserDto>(result);
            return new ResultDto<HotBagUserDto>(res);
        }
    }
}
