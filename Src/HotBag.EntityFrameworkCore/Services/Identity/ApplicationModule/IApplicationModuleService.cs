using HotBag.AppUserDto;
using HotBag.Core.EntityDto.Authenticate;
using HotBag.ResultWrapper.ResponseModel;
using System;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.Services.Identity
{
    public interface IApplicationModuleService
    {

        Task<ListResultDto<HotBagApplicationModuleDto>> GetAll(string searchText);
        Task<PagedResultDto<HotBagApplicationModuleDto>> GetAllPaged(int skip, int maxResultCount, string searchText);
        Task<ResultDto<ApplicationModuleDto>> Get(long id);
        Task<ResultDto<int>> GetCount();
        Task<ResultDto<ApplicationModuleDto>> SaveOrUpdate(ApplicationModuleDto entity); 
        Task Delete(long id);
    }
}
