using HotBag.Core.EntityDto;
using HotBag.ResultWrapper.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotBag.Services.DapperProviders
{
    public interface IDapperTestService
    {
        Task<ListResultDto<DappperTestEntityDto>> GetAll(string searchText);
        Task<PagedResultDto<DappperTestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText);
        Task<ResultDto<DappperTestEntityDto>> Get(long id);
        Task<ResultDto<int>> GetCount();
        Task<ResultDto<DappperTestEntityDto>> Save(DappperTestEntityDto entity);
        Task<ResultDto<DappperTestEntityDto>> Update(DappperTestEntityDto entity);
        Task Delete(long id);
    }
}
