using HotBag.AppUserDto;
using HotBag.ResultWrapper.ResponseModel;
using System;
using System.Threading.Tasks;

namespace HotBag.Services.Identity
{
    public interface IAppUserService
    { 
        Task<ListResultDto<HotBagUserDto>> GetAll(string searchText);
        Task<PagedResultDto<HotBagUserDto>> GetAllPaged(int skip, int maxResultCount, string searchText);
        Task<ResultDto<HotBagUserDto>> Get(Guid id);
        Task<ResultDto<int>> GetCount();
        Task<ResultDto<HotBagUserDto>> Save(HotBagUserDto entity);
        Task<ResultDto<HotBagUserDto>> Update(HotBagUserDto entity);
        Task Delete(Guid id);
    }
}
