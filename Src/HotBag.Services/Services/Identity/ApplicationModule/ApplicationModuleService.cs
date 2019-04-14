
using HotBag.AppUser;
using HotBag.AppUserDto;
using HotBag.AutoMaper;
using HotBag.Core.EntityDto.Authenticate;
using HotBag.Core.Permissions;
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
    public class ApplicationModuleService : IApplicationModuleService, ITransientDependencies
    {
        private readonly IBaseRepository<HotBagApplicationModule, long> _applicationModuleRepository;
        private readonly IBaseRepository<HotBagApplicationModulePermissionLevel, long> _roleApplicationModulePermissionLevelRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IObjectMapper _objectMapper;

        public ApplicationModuleService(
            IRepositoryFactory<HotBagApplicationModulePermissionLevel, long> roleApplicationModulePermissionLevelRepository,
            IRepositoryFactory<HotBagApplicationModule, long> ApplicationModuleRepository, 
            IUnitOfWork unitOfWork, IObjectMapper objectMapper
            )
        {

            _applicationModuleRepository = ApplicationModuleRepository.GetRepository();
            this._roleApplicationModulePermissionLevelRepository = roleApplicationModulePermissionLevelRepository.GetRepository();
            _unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }
        public async Task Delete(long id)
        {
            var modulePermissionLevels = _roleApplicationModulePermissionLevelRepository.GetAll().Where(x => x.HotBagApplicationModuleId == id);
            foreach (var item in modulePermissionLevels)
            {
                await _roleApplicationModulePermissionLevelRepository.DeleteAsync(item);
            }
            await this._applicationModuleRepository.DeleteAsync(id);
        }

        public async Task<ResultDto<ApplicationModuleDto>> Get(long id)
        {
            var result = await (from applicatonModule in _applicationModuleRepository.GetAll()
                                join applicationModulePermission in _roleApplicationModulePermissionLevelRepository.GetAll()
                                on applicatonModule.Id equals applicationModulePermission.HotBagApplicationModuleId into temp
                                from applicationModulePermission in temp.DefaultIfEmpty()
                                where applicatonModule.Id == id
                                select new
                                {
                                    Id = applicatonModule.Id,
                                    ModuleName = applicatonModule.ModuleName,
                                    CreatedAt = applicatonModule.CreatedAt,
                                    ModulePermissions = applicationModulePermission != null ? applicationModulePermission : new HotBagApplicationModulePermissionLevel()
                                }).GroupBy(g => g.Id)
                          .Select(g => new ApplicationModuleDto
                          {
                              Id = g.First().Id,
                              CreatedAt = g.First().CreatedAt,
                              ModuleName = g.First().ModuleName,
                              PermissionLevels = PermissionLevelFactory.GetAllPermissionLevel(g.Select(x => x.ModulePermissions).ToList())
                          }).FirstOrDefaultAsync();
            if (result == null)
            {
                result = new ApplicationModuleDto();
                result.PermissionLevels = PermissionLevelFactory.GetAllPermissionLevel(new System.Collections.Generic.List<HotBagApplicationModulePermissionLevel>());
            }
            return new ResultDto<ApplicationModuleDto>(result);
        }

        public async Task<ListResultDto<HotBagApplicationModuleDto>> GetAll(string searchText)
        {
            var result = _applicationModuleRepository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.ModuleName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            //var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new HotBagApplicationModuleDto
                {
                    Id = x.Id,
                    ModuleName = x.ModuleName,
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync();

            return new ListResultDto<HotBagApplicationModuleDto>(finalResult, "Roles");
        }

        public async Task<PagedResultDto<HotBagApplicationModuleDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
        {
            var result = _applicationModuleRepository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.ModuleName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new HotBagApplicationModuleDto
                {
                    Id = x.Id,
                    ModuleName = x.ModuleName,
                    CreatedAt = x.CreatedAt
                })
                .Skip(skip)
                .Take(maxResultCount)
                .ToListAsync();

            return new PagedResultDto<HotBagApplicationModuleDto>(totalCount, finalResult, skip + maxResultCount < totalCount, "Total Data With summary");
        }

        public async Task<ResultDto<int>> GetCount()
        {
            return new ResultDto<int>(await _applicationModuleRepository.CountAsync());
        }

        public async Task<ResultDto<ApplicationModuleDto>> SaveOrUpdate(ApplicationModuleDto entity)
        {
            if (entity.Id == 0)
            {
                //create module
                var createModel = new HotBagApplicationModule
                {
                    ModuleName = entity.ModuleName,
                    CreatedAt = DateTime.Now
                };
                var result = await _applicationModuleRepository.InsertAsync(createModel);
                entity.Id = result.Id;
                foreach (var item in entity.PermissionLevels.Where(x => x.IsAssigned))
                {
                    if (!item.IsAssigned) continue;
                    var modelPermission = new HotBagApplicationModulePermissionLevel
                    {
                        HotBagApplicationModuleId = result.Id,
                        CreatedAt = DateTime.Now,
                        PermissionLevel = item.PermissionLevelName 
                    };
                    await _roleApplicationModulePermissionLevelRepository.InsertAsync(modelPermission);
                }
            }
            else
            {
                //edit module
                var updateModule = await _applicationModuleRepository.GetAsync(entity.Id);
                if(updateModule == null)
                {
                    throw new Exception("Invalid request");
                }
                updateModule.ModuleName = entity.ModuleName;
                var result = await _applicationModuleRepository.UpdateAsync(updateModule);

                foreach (var item in entity.PermissionLevels)
                {
                    if (!item.IsAssigned)
                    {
                        if (item.Id != 0) await _roleApplicationModulePermissionLevelRepository.DeleteAsync(item.Id);
                    }
                    else
                    {
                        var modelPermission = new HotBagApplicationModulePermissionLevel
                        {
                            Id = item.Id,
                            HotBagApplicationModuleId = entity.Id,
                            CreatedAt = DateTime.Now,
                            PermissionLevel = item.PermissionLevelName
                        };

                        var r = modelPermission.Id == 0
                            ? await _roleApplicationModulePermissionLevelRepository.InsertAsync(modelPermission)
                            : await _roleApplicationModulePermissionLevelRepository.UpdateAsync(modelPermission);
                    }
                   
                }
            }
            await _unitOfWork.SaveChangesAsync();
            return new ResultDto<ApplicationModuleDto>(entity);
        }
    }
}
