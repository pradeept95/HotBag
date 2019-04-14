using HotBag.AppUserDto;
using HotBag.ResultWrapper.ResponseModel;
using System;
using System.Threading.Tasks;

namespace HotBag.Services.Identity
{
    public interface IRoleService
    {

        Task<ListResultDto<HotBagRoleDto>> GetAll(string searchText);
        Task<PagedResultDto<HotBagRoleDto>> GetAllPaged(int skip, int maxResultCount, string searchText);
        Task<ResultDto<HotBagRoleDto>> Get(long id);
        Task<ResultDto<int>> GetCount();
        Task<ResultDto<HotBagRoleDto>> Save(HotBagRoleDto entity);
        Task<ResultDto<HotBagRoleDto>> Update(HotBagRoleDto entity);
        Task Delete(long id);
    }
}
